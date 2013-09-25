using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RORDER
    {
        private List<ordering> orderingList = new List<ordering>();
        private ordering a = new ordering();

        public ordering ReturnMyClass(int i)
        {
            return orderingList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return orderingList.Count;
        }

        public void AddMyClass(ordering myclass)
        {
            orderingList.Add(myclass);
        }

        public void RemoveMyClass(string s1, DateTime d2)
        {
            for (int i = 0; i < orderingList.Count; i++)
            {
                if (s1 == orderingList[i].boxname && d2 == orderingList[i].enddate)
                {
                    orderingList.Remove(orderingList[i]);
                }
            }
        }

        public ordering FindCLass(string s1, DateTime s2)
        {
            int j = -1;
            for (int i = 0; i < orderingList.Count; i++)
            {
                if (s1 == orderingList[i].boxname && s2 == orderingList[i].enddate)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return orderingList.ElementAt(j);
            else
                return orderingList.ElementAtOrDefault(j);
        }
        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<ordering>));
            xmls.Serialize(filestream, orderingList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<ordering>));
            orderingList = (List<ordering>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
