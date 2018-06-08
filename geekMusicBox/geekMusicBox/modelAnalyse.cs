using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace geekMusicBox
{
    public class modelAnalyse
    {
        private List<int> modelList = new List<int>();
        private List<string> musicType = new List<string>();
        private const string filename = "modelFile.txt";

        public modelAnalyse()
        {
            FileStream aFile = new FileStream(filename, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(aFile);
            while (true)
            {
                string info = sr.ReadLine();
                if (info == null || info == "")
                {
                    break;
                }
                string[] datas = info.Split(' ');
                modelList.Add(Convert.ToInt32(datas[0]));
                musicType.Add(datas[1]);
            }
            sr.Close();
            aFile.Close();
        }
        public void addMusicList(List<int> dataList, string type)
        {
            FileStream aFile = new FileStream(filename, FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);
            modelList.Add(analyse(dataList));
            musicType.Add(type);
            string info = "";
            info += modelList[modelList.Count - 1].ToString() + " ";
            info += type;
            sw.WriteLine(info);
            sw.Close();
            aFile.Close();
        }

        public int analyse(List<int> dataList)
        {
            return dataList[dataList.Count - 1];
        }

        public string findMusicType(List<int> dataList)
        {
            int nowWeight = dataList[dataList.Count - 1];
            int ansPos = -1;
            int minDistance = -1;
            for (int i = 0; i < modelList.Count; i++)
            {
                int nowDistance = Math.Abs(modelList[i] - nowWeight);
                if (nowDistance > 3750) continue;
                if (minDistance == -1 || minDistance > nowDistance)
                {
                    minDistance = nowDistance;
                    ansPos = i;
                }
            }
            if (ansPos != -1) return musicType[ansPos];
            else return null;
        }
    }
}
