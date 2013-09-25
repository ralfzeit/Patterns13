using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Linq.Mapping;
using ALinq.Access;
using ALinq;
using ALinq.Mapping;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Denta_Pro
{
    public class BaseObject
    {
        public System.Data.DataTable item = new DataTable();
        static public Lib Library = new Lib();

        public int stop; 
        public string insert_string;
        public string update_string;
        public string ins_cols;
        public string[] Params = new string[3];

        public void Create_params()
        {
            item = Library.CreateDataTable(this);
            ins_cols = Library.CreateFieldNames(this);
            insert_string = DRIVER.Create_insert_string(this);
            update_string = DRIVER.Create_update_string(this);

            this.Params[0] = ins_cols;
            this.Params[1] = insert_string;
            this.Params[2] = update_string;
        }

        public void CreateStrings()
        {
            ins_cols = Library.CreateFieldNames(this);
            insert_string = DRIVER.Create_insert_string(this);
            update_string = DRIVER.Create_update_string(this);


        }

    }
}
