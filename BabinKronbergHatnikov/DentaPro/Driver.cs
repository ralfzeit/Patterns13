using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Reflection;
using System.Data.Linq.Mapping;
using ALinq.Access;
using ALinq;
using ALinq.Mapping;
using System.IO;


namespace Denta_Pro
{
    public class DRIVER
    {

        public string Connection_String = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb";

        
        public OleDbCommand DbCommand = new OleDbCommand();
        public OleDbDataReader DataReader;
        public OleDbConnection connect;
        public OleDbDataAdapter DataAdapter;
        public System.Data.DataTable LocalDataTable;
        public int rowPosition;
        public DataRow[] Respond;
          public FieldInfo[] Parames;

        public DRIVER()
        {
            
        }

        public void Create_Connection(String Table, System.Data.DataTable item)
        {
            this.connect = new OleDbConnection(Connection_String);
            this.DbCommand = connect.CreateCommand();
            LocalDataTable = item;

            this.connect.Open();
           
           DataAdapter = new OleDbDataAdapter("SELECT * FROM " + Table + " ", this.connect);
           DataAdapter.Fill(LocalDataTable);

            if (LocalDataTable.Rows.Count != 0) 
            {
                rowPosition = LocalDataTable.Rows.Count;
            }
            
            this.connect.Close();


        
        }

        public void Insert(string Table, string[] Params, Patient item = null)
        {

            OleDbParameter imgparam = new OleDbParameter();
           
            DbCommand = connect.CreateCommand();
            DbCommand.CommandText =
               "INSERT INTO " + Table
                + " (" + Params[0] + ")" +
                " VALUES (" + Params[1] + ")";

            if (Table == "Patients")
            {

                imgparam = DbCommand.Parameters.AddWithValue("@Image", SqlDbType.Binary);
                imgparam.Value = item.Profileb;
                imgparam.Size = item.Profileb.Length;


            }

            DbCommand.Connection.Open();

            Console.Write(DbCommand.CommandText.ToString());

            int affected = DbCommand.ExecuteNonQuery();

            DbCommand.Connection.Close();

        }

        public void Select(String where)
        {
             Respond =  this.LocalDataTable.Select(where);
            
          }

        
        public bool Delete(string Table, String where)
        {

           this.DbCommand.CommandText =
           "DELETE FROM " + Table +
           " WHERE " + where + "";

           Console.WriteLine(this.DbCommand.CommandText);

            this.connect.Open();

            this.DataReader = this.DbCommand.ExecuteReader();

            this.connect.Close();

            return false;
        }





        public bool Update(string Table, String what, String where, Patient item = null)
        {
            OleDbParameter imgparam = new OleDbParameter();

            this.DbCommand.CommandText =
            "UPDATE " + Table +
            " SET " + what +
            " WHERE " +  where ;

            /*
            if (Table == "Patients")
            {

                imgparam = DbCommand.Parameters.AddWithValue("@Image", SqlDbType.Binary);
                imgparam.Value = item.Profileb;
                imgparam.Size = item.Profileb.Length;


            }
            */

            this.connect.Open();

            Console.WriteLine(this.DbCommand.CommandText);
            Console.WriteLine(this.DbCommand.Parameters.Count.ToString());
             this.DbCommand.ExecuteNonQuery();

            this.connect.Close();

            return true;
        }

        public void Refresh() {

            this.connect.Close();
            this.LocalDataTable.Clear();
            this.connect.Open();
            
        
        }

       public static  String Create_insert_string(object item )
        {
           FieldInfo[] Parames  = item.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
             
            String insert_string = "'";
            
            int stop = Parames.Count() - 8;

            for (int i = 1; i <= stop; i++)
                if (i < stop)
                {
                    if (i == 11) insert_string += Parames[i].GetValue(item).ToString() + "',";
                    else
                        if (Parames[i].Name == "Profileb")
                            insert_string += "@Image" + ",'";
                        else
                            insert_string += Parames[i].GetValue(item).ToString() + "','";
                }
                else if (i == stop)
                    insert_string += Parames[i].GetValue(item).ToString() + "'";
                else { break; }

            Console.WriteLine(insert_string);

            return insert_string;
        }

        public static String Create_update_string(object item)
       {
           FieldInfo[] Parames = item.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
             
            String update_string = "";
            int stop = Parames.Count() - 8;

             for (int i = 1; i <= stop; i++)
                if (i < stop)
                {
                    if (i == 11) update_string += (Parames[i].Name.ToString() + "='" + Parames[i].GetValue(item).ToString() + "',");
                    else
                        if (Parames[i].Name == "Profileb") { }
                        /* update_string += "@Image" + ",";  */
                        else
                            update_string += (Parames[i].Name.ToString() + "='" + Parames[i].GetValue(item).ToString() + "',");


                }
                else if (i == stop)
                    update_string += (Parames[i].Name.ToString() + "='" + Parames[i].GetValue(item).ToString() + "'");
                else { break; }

             return update_string;

        } 







        
    }
}
