using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RA
    {
        private List<admin> adminList = new List<admin>();
        private admin a = new admin();

        public admin ReturnMyClass(int i)
        {
            return adminList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return adminList.Count;
        }

        public void AddMyClass(admin myclass)
        {
            adminList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < adminList.Count; i++)
            {
                if (s1 == adminList[i].login)
                {
                    adminList.Remove(adminList[i]);
                }
            }
        }

        public admin FindCLass(string s1, string s2)
        {
            int j = -1;
            for (int i = 0; i < adminList.Count; i++)
            {
                if (s1 == adminList[i].login && s2 == adminList[i].pass)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return adminList.ElementAt(j);
            else
                return adminList.ElementAtOrDefault(j);
        }

        public admin FindCLassLogin(string s1)
        {
            int j = -1;
            for (int i = 0; i < adminList.Count; i++)
            {
                if (s1 == adminList[i].login)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return adminList.ElementAt(j);
            else
                return adminList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<admin>));
            xmls.Serialize(filestream, adminList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<admin>));
            adminList = (List<admin>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
