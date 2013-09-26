using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourBase
{
    public class Ecip_Model
    {
        public String Name;
        public List<Ecip_Size> Size = new List<Ecip_Size>();

        public Ecip_Model()
        {
            Name = "";
        }
    }
}
