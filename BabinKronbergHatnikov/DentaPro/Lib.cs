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

namespace Denta_Pro
{
    public class Lib
    {
         FieldInfo[] Parames; /// array of field types of input object item
               
        /* Input data: object item 
         * Output data: void
         * Function aim: returns Field names of item (object) to Params value; 
        */public void GetFields (object item)
        {        
          Parames = item.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
        }


        /* Input data: object item 
         * Output data: String
         * Function aim: returns String  with Field names of item (object);  
        */ public String CreateFieldNames(object item)
             {
                this.GetFields(item);
                String ins_cols = "";
                BaseObject baser = item as BaseObject;
                int stop = baser.stop;
                for (int i = 1; i <= stop; i++)
                    if (i < stop)
                    {

                        ins_cols += Parames[i].Name.ToString() + ",";
                    }

                    else
                        if (i == stop)
                            ins_cols += Parames[i].Name.ToString();
                        else { break; }
                return ins_cols;
            }
            
         /* Input data: object item 
          * Output data: void
          * Function aim: returns list of field names and there values to console  
         */public  void ViewFields(object item)
            {
                this.GetFields(item);
                Parames = item.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < Parames.Count(); i++)
                    Console.WriteLine(Parames[i].Name + " = " + Convert.ToString((Parames[i].GetValue(item))));
            }


         
          /* Input data: object item 
           * Output data: System.Data.DataTable
           * Function aim: creats and returns localdatatable of values from item's class  
          */public System.Data.DataTable CreateDataTable(object item)
           {
                this.GetFields(item);
                int stop = Parames.Count() - 7;
                this.GetFields(item);
                System.Data.DataTable Table = new System.Data.DataTable();

                    for (int i = 0; i < stop; i++)
                    {
                        Table.Columns.Add(Parames[i].Name, Parames[i].FieldType);
                    }
                   
                return Table;
            }
      
    
    }
}
