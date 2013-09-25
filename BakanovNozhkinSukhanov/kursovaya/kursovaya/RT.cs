using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RT
    {
        private List<tarif> tarifList = new List<tarif>();
        private tarif a = new tarif();

        public tarif ReturnMyClass(int i)
        {
            return tarifList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return tarifList.Count;
        }

        public void AddMyClass(tarif myclass)
        {
            tarifList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < tarifList.Count; i++)
            {
                if (s1 == tarifList[i].tname)
                {
                    tarifList.Remove(tarifList[i]);
                }
            }
        }

        public tarif FindCLass(string s1)
        {
            int j = -1;
            for (int i = 0; i < tarifList.Count; i++)
            {
                if (s1 == tarifList[i].tname)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return tarifList.ElementAt(j);
            else
                return tarifList.ElementAtOrDefault(j);
        }

        public tarif FindActive(string s1)
        {
            int j = -1;
            for (int i = 0; i < tarifList.Count; i++)
            {
                if (s1 == tarifList[i].status)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return tarifList.ElementAt(j);
            else
                return tarifList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<tarif>));
            xmls.Serialize(filestream, tarifList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<tarif>));
            tarifList = (List<tarif>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
