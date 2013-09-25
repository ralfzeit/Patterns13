using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denta_Pro
{
    public partial class FixingDetail : Form
    {/*
        public DRIVER db;
        public int UserID;
        public String UserNik;
        public DateTime UserCallDate = DateTime.Today;
        public String Curtime;
        public DateTime newtime;

        public bool CallChanged = false;
        public int CallPrevious = 0;

        public List<int> actionIDs = new List<int>();
        public int action;


        private void DayTravel() 
        {
            Caller travel = new Caller();
            db.LocalDataTable.Dispose();
            db.Create_Connection("Calls", travel.item);

            DataTable Respond = new DataTable();
           
            Respond = travel.item.Clone();
           
                      
            for (int i = 0; i < db.LocalDataTable.Rows.Count; i++)
                if (db.LocalDataTable.Rows[i].ItemArray.GetValue(2).ToString().Contains(Calldate.Value.ToShortDateString()))
                {
                    Respond.Rows.Add(db.LocalDataTable.Rows[i].ItemArray.ToArray());
                }

          
                for (int j = 0; j < Respond.Rows.Count; j++)
                {
                    Console.WriteLine(Respond.Rows[j]["Call"].ToString()+"here");

                    for (int i = 0; i < 26; i++)
                    {
                        String str = Time[0, i].Value.ToString().Trim();
                       
                        
                        if (Respond.Rows[j]["Call"].ToString().Contains(str))
                        {
                             Time[1, i].Value = Respond.Rows[j]["UserName"].ToString();
                        }
                    }
                } 
            
        } 

        public FixingDetail(DRIVER dob, int id = 0)
        {
            db = dob;
            UserID = id;
            Console.WriteLine(UserID);
            
           InitializeComponent();

            for (int i = 0; i < 26; i++)
            {
               Time.Rows.Add();
             }

           

            Time.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Time.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Time.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Time.Rows[0].SetValues("8:00");
            Time.Rows[1].SetValues("8:30");

            Time.Rows[2].SetValues("9:00");
            Time.Rows[3].SetValues("9:30");

            Time.Rows[4].SetValues("10:00");
            Time.Rows[5].SetValues("10:30");

            Time.Rows[6].SetValues("11:00");
            Time.Rows[7].SetValues("11:30");

            Time.Rows[8].SetValues( "12:00");
            Time.Rows[9].SetValues("12:30");

            Time.Rows[10].SetValues("13:00");
            Time.Rows[11].SetValues("13:30");

            Time.Rows[12].SetValues("14:00");
            Time.Rows[13].SetValues("14:30");

            Time.Rows[14].SetValues("15:00");
            Time.Rows[15].SetValues("15:30");

            Time.Rows[16].SetValues("16:00");
            Time.Rows[17].SetValues("16:30");

            Time.Rows[18].SetValues("17:00");
            Time.Rows[19].SetValues("17:30");

            Time.Rows[20].SetValues("18:00");
            Time.Rows[21].SetValues("18:30");

            Time.Rows[22].SetValues("19:00");
            Time.Rows[23].SetValues("19:30");

            Time.Rows[24].SetValues("20:00");
            Time.Rows[25].SetValues("20:30");

            DayTravel();

            if (UserID != 0)
            {
                db.LocalDataTable.Select("ID=" + UserID);
                DataTable LocalTable = db.Respond.CopyToDataTable();
                Namer.Text = LocalTable.Rows[0]["Name"].ToString();
                Surname.Text = LocalTable.Rows[0]["Surname"].ToString();

                UserNik = LocalTable.Rows[0]["Surname"].ToString() + " " +
                    LocalTable.Rows[0]["Name"].ToString() + " " +
                    LocalTable.Rows[0]["Lastname"].ToString();

                Info.Rows.Add(UserNik,
                    LocalTable.Rows[0]["Birthdate"].ToString(),
                    LocalTable.Rows[0]["Address"].ToString());
            }
             CurPatient.Text = UserNik;
              
        }

        private void reg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Time_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Time[1, Time.CurrentRow.Index].Value == null)
                {
                    Time[1, CallPrevious].Value = null;
                    CallPrevious = Time.CurrentRow.Index;
                    Time[1, Time.CurrentRow.Index].Value = UserNik;
                    Curtime = " " + Time[0, Time.CurrentRow.Index].Value.ToString();
                    Dater();

                }

                else MessageBox.Show("Это время уже занято!");
            }
            else {
                
                //Time[1, e.RowIndex].Value = UserNik;


                if (MessageBox.Show("Вы действительно хотите назначить текущего пациента на данное время?\nСтарая запись будет удалена!", "Переназначение", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }

                else { }
              
              
            }
        
        }

        private void Time_RowHeaderCellChanged(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void Time_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           
           
             
        }

        private void Calldate_ValueChanged(object sender, EventArgs e)
        {
            UserCallDate = Calldate.Value;
            for (int i = 0; i < 26; i++)
                Time[1, i].Value = null;
                Dater();
            DayTravel();
           
        }

        private void Dater() {
            String call = UserCallDate.ToShortDateString().ToString() + Curtime;
            newtime = DateTime.Parse(call);
            CurCallDate.Text = newtime.ToString("g");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Caller NewCall = new Caller();
            NewCall.UserID = UserID;
            NewCall.UserName = UserNik;
            NewCall.Call = newtime.ToString("g");

            NewCall.Create_params();

            NewCall.ViewFields();

            db.LocalDataTable.Dispose();
            
            
            db.Create_Connection("Calls", NewCall.item);
                       
                try
                {
                    db.Insert("Calls", NewCall.Params);
                }
                catch (Exception a)
                { MessageBox.Show(a.Message); }
                finally
                {
                    MessageBox.Show(NewCall.UserName + " \n назначен на" + NewCall.Call); 
                }

            db.Refresh();



        }

        private void Time_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("ВoubleClick");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            db.Create_Connection("Patients", pat.item);
 
            String name = "";
            String surname = "";
            int sex = 0;

            if (actionIDs != null) actionIDs.Clear();

            name = Namer.Text.ToString();
            surname = Surname.Text.ToString();
            if (Men.Checked == true) sex = 1;
            else sex = 0;


            if (name.Length != 0 && surname.Length != 0)
                db.Select("Name='" + name + "' and " +
                          "Surname='" + surname + "' and Sex=" + sex + "");
            else
            {
                if (name.Length != 0)
                    db.Select("Name='" + name + "'");
                else
                    if (surname.Length != 0)
                        db.Select("Surname='" + surname + "'");
                    else db.Select("Sex=" + sex + "");
            }

            Info.Rows.Clear();

            for (int i = 0; i < db.Respond.Count(); i++)
            {

                if (Convert.ToInt32(db.Respond[i].ItemArray.GetValue(9)) == sex)
                {

                    actionIDs.Add(Convert.ToInt32(db.Respond[i].ItemArray.GetValue(0)));

                    String Name = db.Respond[i].ItemArray.GetValue(2).ToString();
                    String pSurname = db.Respond[i].ItemArray.GetValue(1).ToString();
                    String LastName = db.Respond[i].ItemArray.GetValue(3).ToString();
                    String FIO = pSurname + " " + Name + " " + LastName;
                    String Birthday = db.Respond[i].ItemArray.GetValue(11).ToString();
                    String WorkPlace = db.Respond[i].ItemArray.GetValue(5).ToString();
                    String Address = db.Respond[i].ItemArray.GetValue(4).ToString();

                    Info.Rows.Add(FIO, Birthday, Address);
                }

            }

            
        } 
    
    */
    }
}
