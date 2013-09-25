using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RR
    {
        private List<random_client> rclientList = new List<random_client>();
        private client a = new client();

        public random_client ReturnMyClass(int i)
        {
            return rclientList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return rclientList.Count;
        }

        public void AddMyClass(random_client myclass)
        {
            rclientList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < rclientList.Count; i++)
            {
                if (s1 == rclientList[i].box)
                {
                    rclientList.Remove(rclientList[i]);
                }
            }
        }

        public random_client FindCLass(string s1, string s2)
        {
            int j = -1;
            for (int i = 0; i < rclientList.Count; i++)
            {
                if (s1 == rclientList[i].auto_number && s2 == rclientList[i].r_lastname)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return rclientList.ElementAt(j);
            else
                return rclientList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<random_client>));
            xmls.Serialize(filestream, rclientList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<random_client>));
            rclientList = (List<random_client>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
