using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RO
    {
        private List<oper> operList = new List<oper>();
        private oper a = new oper();

        public oper ReturnMyClass(int i)
        {
            return operList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return operList.Count;
        }

        public void AddMyClass(oper myclass)
        {
            operList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < operList.Count; i++)
            {
                if (s1 == operList[i].login)
                {
                    operList.Remove(operList[i]);
                }
            }
        }

        public oper FindCLass(string s1, string s2)
        {
            int j = -1;
            for (int i = 0; i < operList.Count; i++)
            {
                if (s1 == operList[i].login && s2 == operList[i].pass)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return operList.ElementAt(j);
            else
                return operList.ElementAtOrDefault(j);
        }

        public oper FindCLassLogin(string s1)
        {
            int j = -1;
            for (int i = 0; i < operList.Count; i++)
            {
                if (s1 == operList[i].login)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return operList.ElementAt(j);
            else
                return operList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<oper>));
            xmls.Serialize(filestream, operList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<oper>));
            operList = (List<oper>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
