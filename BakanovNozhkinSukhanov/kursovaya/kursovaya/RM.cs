using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RM
    {
        private List<cash> cashList = new List<cash>();
        private cash a = new cash();

        public cash ReturnMyClass(int i)
        {
            return cashList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return cashList.Count;
        }

        public void AddMyClass(cash myclass)
        {
            cashList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < cashList.Count; i++)
            {
                if (s1 == cashList[i].box)
                {
                    cashList.Remove(cashList[i]);
                }
            }
        }

        public void ClearList()
        {
            cashList.Clear();
        }

        public void RemoveMyClassAt(int k)
        {
            for (int i = 0; i < cashList.Count; i++)
            {
                if (i == k)
                {
                    cashList.Remove(cashList[i]);
                }
            }
        }

        public cash FindCLass(string s1)
        {
            int j = -1;
            for (int i = 0; i < cashList.Count; i++)
            {
                if (s1 == cashList[i].box)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return cashList.ElementAt(j);
            else
                return cashList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<cash>));
            xmls.Serialize(filestream, cashList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<cash>));
            cashList = (List<cash>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
