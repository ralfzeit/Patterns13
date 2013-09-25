using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace kursovaya
{
    public class RB
    {
        private List<boxes> boxList = new List<boxes>();
        private boxes a = new boxes();

        public boxes ReturnMyClass(int i)
        {
            return boxList.ElementAtOrDefault(i);
        }

        public int coun()
        {
            return boxList.Count;
        }

        public void AddMyClass(boxes myclass)
        {
            boxList.Add(myclass);
        }

        public void RemoveMyClass(string s1)
        {
            for (int i = 0; i < boxList.Count; i++)
            {
                if (s1 == boxList[i].box_number)
                {
                    boxList.Remove(boxList[i]);
                }
            }
        }

        public boxes FindCLass(string s1)
        {
            int j = -1;
            for (int i = 0; i < boxList.Count; i++)
            {
                if (s1 == boxList[i].box_number)
                {
                    j = i;
                }
            }
            if (j >= 0)
                return boxList.ElementAt(j);
            else
                return boxList.ElementAtOrDefault(j);
        }

        public void SaveList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer xmls = new XmlSerializer(typeof(List<boxes>));
            xmls.Serialize(filestream, boxList);
            filestream.Close();
        }

        public void LoadList(string path)
        {
            FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer xmls = new XmlSerializer(typeof(List<boxes>));
            boxList = (List<boxes>)xmls.Deserialize(filestream);
            filestream.Close();
        }
    }
}
