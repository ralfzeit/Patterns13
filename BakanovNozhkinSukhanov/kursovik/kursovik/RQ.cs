using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovik
{
    public class RQ
    {
        private List<MyClass> MyClassList = new List<MyClass>();
        private MyClass a = new MyClass();

        public MyClass ReturnMyClass(int i)
        {
            return MyClassList.ElementAtOrDefault(i);
        }

        public void AddMyClass(MyClass myclass)
        {
            MyClassList.Add(myclass);
        }

        public void RemoveMyClass(string s1, int s2, int s3)
        {
            for (int i = 0; i < MyClassList.Count; i++ )
            {
                if (s1 == MyClassList[i].FIO && s2 == MyClassList[i].HouseNum && s3 == MyClassList[i].FlatNum)
                {
                    MyClassList.Remove(MyClassList[i]);
                }
            }
        }

        public MyClass FindCLass(string s1, int s2, int s3)
        {
            int j=-1;
            for (int i = 0; i < MyClassList.Count; i++)
            {
                if (s1 == MyClassList[i].FIO && s2 == MyClassList[i].HouseNum && s3 == MyClassList[i].FlatNum)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return MyClassList.ElementAt(j);
            else
                return MyClassList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream("base.xml", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<MyClass>));
            xmls.Serialize(filestream, MyClassList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<MyClass>));
            MyClassList = (List<MyClass>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
