using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourBase
{
    public class Ecip_Category
    {
        public String Name;
        public List<Ecip_Model> Model = new List<Ecip_Model>();

        public Ecip_Category()
        {
            Name = "";
        }
    }
}
