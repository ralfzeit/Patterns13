using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
 
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Linq.Mapping;
using ALinq.Access;
using ALinq;
using ALinq.Mapping;
 

namespace Denta_Pro
{
    public class Caller : BaseObject
    {
        public Caller() {

            stop = 3;
        }

        public long ID;
        public int UserID;
        public String Call;
        public String UserName;
 
       public virtual void Create_parametrs()
         {
             Create_params();
         }
         
      
       
    
    }
}
