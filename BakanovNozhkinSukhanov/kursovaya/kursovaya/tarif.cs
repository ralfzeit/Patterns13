using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kursovaya
{
    [Serializable]
    public class tarif
    {
        public string status;
        public string tname;
        public double day;
        public double week;
        public double month;
        public double three_months;
        public double six_months;
    }
}
