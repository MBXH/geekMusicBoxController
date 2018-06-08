using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace geekMusicBox
{
    public class waveAnalyse
    {
        private List<List<int>> allMusicList = new List<List<int>>();
        private List<string> musicName = new List<string>();

        public waveAnalyse()
        {
            FileStream aFile = new FileStream("Log.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(aFile);
            while (true)
            {
                string info = sr.ReadLine();
                if (info == null || info == "")
                {
                    break;
                }
                string[] datas = info.Split(' ');
                List<int> musicList = new List<int>();
                for (int i = 0; i < datas.Length - 1; i++)
                {
                    musicList.Add(Convert.ToInt32(datas[i]));
                }
                allMusicList.Add(musicList);
                musicName.Add(datas[datas.Length - 1]);

                MessageBox.Show(info);
            }
            sr.Close();
            aFile.Close();
        }
        public void addMusicList(List<int> dataList, string name)
        {
            FileStream aFile = new FileStream("Log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);
            this.allMusicList.Add(analyse(dataList));
            this.musicName.Add(name);
            string info = "";
            List<int> now = this.allMusicList[allMusicList.Count - 1];
            for (int i = 0; i < now.Count; i++)
            {
                info += now[i].ToString() + " ";
            }
            info += name;
            sw.WriteLine(info);
            sw.Close();
            aFile.Close();
        }

        public List<int> analyse(List<int> dataList)
        {
            List<int> ansList = new List<int>();
            int lastPoint = -1;
            for (int i = 1; i < dataList.Count - 2; i++)
            {
                if ((dataList[i - 1] > dataList[i] && dataList[i + 1] > dataList[i]))
                {
                    if (ansList.Count != 0 && Math.Abs(dataList[i] - ansList[ansList.Count - 1]) < 3 * 37500) continue;
                    if (ansList.Count == 0 && Math.Abs(dataList[i] - dataList[0]) < 37500) continue;
                    ansList.Add(dataList[i]);
                    lastPoint = i;
                }
            }
            string msg = "";
            for (int i = 0; i < ansList.Count; i++)
            {
                msg += ansList[i].ToString() + " ";
            }
            //MessageBox.Show(msg);
            return ansList;
        }

        public int calDistance(List<int> a, List<int> b)
        {
            int ans = 0;
            //if (a.Count < b.Count) return -1;
            int lim = Math.Min(a.Count,b.Count);
            for (int j = 0; j < lim; j++)
            {
                ans += Math.Abs(a[j] - b[j]);
            }
            ans += 5 * 37500*Math.Abs(a.Count-b.Count);
            /*for (int i = 0; i <= a.Count - lim; i += 2)
            {
                int now = 0;
                for (int j = 0; j < lim; j++)
                {
                    now += Math.Abs(a[i + j] - b[j]);
                }
                if (ans == -1) ans = now;
                else ans = Math.Min(ans, now);
            }*/
            return ans;
        }

        public string findMusic(List<int> datalist)
        {
            datalist = analyse(datalist);
            int ansPos = -1;
            int minDistance = -1;
            for (int i = 0; i < allMusicList.Count; i++)
            {
                int nowDistance = calDistance(datalist, allMusicList[i]);
                if (nowDistance != -1)
                {
                    if (minDistance == -1)
                    {
                        minDistance = nowDistance;
                        ansPos = i;
                    }
                    else
                    {
                        minDistance = Math.Min(minDistance, nowDistance);
                        ansPos = i;
                    }
                }
            }
            if (ansPos != -1) return musicName[ansPos];
            else return null;
        }
    }
}
