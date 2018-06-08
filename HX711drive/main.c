#include <reg52.h>
#define uint unsigned int
#define uchar unsigned char
#define ulong unsigned long
//ms��ʱ����
void delay (uint ms) {
    uchar a,b;
    for(a=3; a>0; a--) {
        for(b=245; b>0; b--)
            for (; ms > 0; ms--);
    }
}
//����:���ڳ�ʼ��,������9600
void   URATinit( ) {
    TMOD=0x20;
    SCON=0x50;
    EA=1;
    ES=1;
    TR1=1;
    TH1=0xfd;
    TL1=0xfd;
    TI=0;
}
//���ͺ���
void send(uchar msg) {
    ES=0;
    TI=0;
    SBUF=msg;
    while(!TI);
    TI=0;
    ES=1;
}
//����ѹ������
sbit ADDO=P2^7;
sbit ADSK=P2^6;
ulong readCount(void) {
    unsigned long count;
    unsigned char i;
    ADSK=0;
    count=0;
    while(ADDO);
    for(i=0; i<24; i++) {
        ADSK=1;
        count<<=1;
        ADSK=0;
        if(ADDO)
            count++;
    }
    ADSK=1;
    count=count^0x800000;
    ADSK=0;
    return(count);
}
//����int
void send32bit(ulong msg) {
    ulong temp=0xff;
    int i=0;
    for(i=0; i<4; i++) {
        uchar byteMsg=(uchar)(msg&temp);
        send(byteMsg);
        msg>>=8;
    }
}
//���պ���
uchar Buffer;
void receive() interrupt 4 {
    if(RI) {
        Buffer=SBUF;
        RI=0;
    }
}
ulong msg;
//������
void  main() {
    URATinit( );
    while(1) {
        send('$');
        send32bit(readCount());
        delay(100);
    }
}
