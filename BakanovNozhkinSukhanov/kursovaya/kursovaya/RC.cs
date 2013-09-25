using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RC
    {
        private List<client> clientList = new List<client>();
        private client a = new client();

        public client ReturnMyClass(int i)
        {
            return clientList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return clientList.Count;
        }

        public void AddMyClass(client myclass)
        {
            clientList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < clientList.Count; i++)
            {
                if (s1 == clientList[i].login)
                {
                    clientList.Remove(clientList[i]);
                }
            }
        }

        public client FindCLass(string s1, string s2)
        {
            int j = -1;
            for (int i = 0; i < clientList.Count; i++)
            {
                if (s1 == clientList[i].login && s2 == clientList[i].pass)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return clientList.ElementAt(j);
            else
                return clientList.ElementAtOrDefault(j);
        }

        public client FindCLass2(string s1)
        {
            int j = -1;
            for (int i = 0; i < clientList.Count; i++)
            {
                if (s1 == clientList[i].login)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return clientList.ElementAt(j);
            else
                return clientList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<client>));
            xmls.Serialize(filestream, clientList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<client>));
            clientList = (List<client>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
