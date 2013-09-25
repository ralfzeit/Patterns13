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
    public partial class Main : Form
    {

        public DRIVER db = new DRIVER();
        public DRIVER db1 = new DRIVER();
        public Patient Pater = new Patient();
        public List<int> actionIDs = new List<int>();
        public int action;
        public int UserID;
        public String UserNik = "Не выбран";
        public DateTime UserCallDate = DateTime.Today;
        
        public String Curtime;
        public DateTime newtime;
        public bool CallChanged = false;
        public int CallPrevious = 0;
        public DateTime today = DateTime.Today;




        public void WeekTravel() 
        {
            int num = 0;
            DateTime temp = DateTime.Now;
            int right, left;
            List<DateTime> week = new List<DateTime>();

            for (int i = 0; i < 7; i++)
                week.Add(temp);
           
            DateTime now = Calendar.Value;

            switch (Calendar.Value.DayOfWeek.ToString()) 
            {
                case "Monday": num = 0; break;
                case "Tuesday": num = 1; break;
                case "Wednesday": num = 2; break;
                case "Thursday": num = 3; break;
                case "Friday": num = 4; break;
                case "Saturday": num = 5; break;
                case "Sunday": num = 6; break;
     
            }

            Console.WriteLine(num.ToString());

            week[num] = Calendar.Value;

            Console.WriteLine(week[num].Date.ToShortDateString());


            right = 6 - num;

            Console.WriteLine(right.ToString());

            for (int i = 1; i < right + 1; i++) 
            { 
                now = now.AddDays(1);
                week[num + i] = now;  
            }

            now = Calendar.Value;

            for (int i = num-1; i > -1; i--)
            {
                now = now.AddDays(-1);
                week[i] = now;
            }

          /*  for (int i = 0; i < 7; i++)
                Console.WriteLine(week[i].Date.ToShortDateString());*/
            
            Caller travel = new Caller();
             
            DataTable Responder = new DataTable();
            db1.Create_Connection("Calls", travel.item);
            DataTable Result = new DataTable();
            Responder = travel.item.Clone();

            for (int r = 0; r < 7; r++)
            {
                Console.WriteLine(week[r].Date.ToShortDateString() + "!!!");
                for (int i = 0; i < db1.LocalDataTable.Rows.Count; i++)
                    if (db1.LocalDataTable.Rows[i].ItemArray.GetValue(2).ToString().Contains(week[r].Date.ToShortDateString()))
                    {
                        Console.WriteLine("YES");
                        Responder.Rows.Add(db1.LocalDataTable.Rows[i].ItemArray.ToArray());
                    }


                for (int j = 0; j < Responder.Rows.Count; j++)
                {
                    Console.WriteLine(Responder.Rows[j]["Call"].ToString() + "here");

                    for (int i = 0; i < 26; i++)
                    {

                        String str = Week.Rows[i].HeaderCell.Value.ToString().Trim();

                        Console.WriteLine(Responder.Rows[j]["Call"].ToString());
                        if (Responder.Rows[j]["Call"].ToString().Contains(str))
                        {
                            
                            Week[r,i].Value = Responder.Rows[j]["UserName"].ToString();
                        }
                    }
                }

                Responder.Clear(); 

            }



            db1.connect.Close();


              
        }



        private void DayTravel()
        {
            Caller travel = new Caller();
             
            db1.Create_Connection("Calls", travel.item);

            DataTable Respond = new DataTable();
            DataTable Result = new DataTable();
            Respond = travel.item.Clone();


            for (int i = 0; i < db1.LocalDataTable.Rows.Count; i++)
                if (db1.LocalDataTable.Rows[i].ItemArray.GetValue(2).ToString().Contains(Calldate.Value.ToShortDateString()))
                {
                    Respond.Rows.Add(db1.LocalDataTable.Rows[i].ItemArray.ToArray());
                }


            for (int j = 0; j < Respond.Rows.Count; j++)
            {
                 

                for (int i = 0; i < 26; i++)
                {
                    String str = Time[0, i].Value.ToString().Trim();


                    if (Respond.Rows[j]["Call"].ToString().Contains(str))
                    {
                        Time[1, i].Value = Respond.Rows[j]["UserName"].ToString();
                        Day[0, i].Value = Respond.Rows[j]["UserName"].ToString();
                    }
                }
            }

            Respond.Clear();
            //travel.item.Clear();
            db1.connect.Close();
            
        } 













        public Main()
        {
            InitializeComponent();
            db.Create_Connection("Patients", Pater.item);
            Men.Checked = true;

            for (int i = 0; i < 26; i++)
            {
                Week.Rows.Add();
                Day.Rows.Add();
                 
            }

            for (int i = 0; i < 6; i++)
                Mounth.Rows.Add();

             
            
            GlobalCurDate.Text = UserCallDate.ToShortDateString().ToString();

                Week.RowHeadersWidth = 90;

            Week.TopLeftHeaderCell.Value = "Июнь (3-9)";
            Week.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Week.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Week.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DateTime timer = new DateTime();
            timer  = timer.AddHours(8);

            for (int i = 0; i < 26; i++)
            {
                Time.Rows.Add();
            }


            Time.RowHeadersWidth = 95;
            Time.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Time.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Time.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < 26; i++ )
            {
                Week.Rows[i].HeaderCell.Value = timer.ToShortTimeString();
                Day.Rows[i].HeaderCell.Value = timer.ToShortTimeString();
                Time.Rows[i].HeaderCell.Value = timer.ToShortTimeString();
                timer = timer.AddMinutes(30);

            }
            
            Day.RowHeadersWidth = 90;
            Day.TopLeftHeaderCell.Value = Calendar.Value.ToShortDateString().ToString() ;
            Day.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Day.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Day.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           


            Mounth.RowHeadersWidth = 105;
            Mounth.TopLeftHeaderCell.Value = "Июнь";
            Mounth.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Mounth.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Mounth.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DayTravel();
            WeekTravel();
        
        
        }

        private void Week_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;

            if (null != gridView)
            {
                          }
        }


        
   
       
        private void регистратураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main asd = new Main();
            asd.Show();
        }

    
        private void button5_Click(object sender, EventArgs e)
        {
            Profile pr = new Profile(db,actionIDs[action]);
            pr.Show();
        }

        private void Regestry_Click(object sender, EventArgs e)
        {
          //  bug.SendToBack();
            reg.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            reg.SendToBack();
            //bug.BringToFront();
        }

       
        private void button11_Click(object sender, EventArgs e)
        {
            SendSMS sms = new SendSMS(actionIDs[action], Info[0, action].Value.ToString(), db);
            sms.ShowDialog();
        }

     
        private void button8_Click(object sender, EventArgs e)
        {
            reg.SendToBack();
            table.BringToFront();
        }

        private void button16_Click(object sender, EventArgs e)
        {
             
           /* FixingDetail fix = new FixingDetail(db);
            fix.ShowDialog();*/
        }

     
        private void textBox16_DoubleClick(object sender, EventArgs e)
        {
          /*  panel10.SendToBack();
            panel13.BringToFront();
            Week.Visible = true;
            for (int i = 0; i < 13; i++ )
                Week.Rows.Add();
            */
            
        }



        private void Patient_Add_btn_Click(object sender, EventArgs e)
        {
            Patient_ADD asd = new Patient_ADD(db);
            asd.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (action != null && Info.Rows.Count != 0)
            {
                DeletePatient del = new DeletePatient(actionIDs[action], Info[0, action].Value.ToString(), db);
                del.ShowDialog();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (action != null && Info.Rows.Count != 0)
            {
               /* FixingDetail fix = new FixingDetail(db, actionIDs[action]);
                fix.ShowDialog();*/
            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
           
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            /*if (action != null && Info.Rows.Count != 0)
            {
            SendSMS sms = new SendSMS(actionIDs[action], Info[0, action].Value.ToString(), db);
            sms.ShowDialog();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = "";
            String surname = "";
            int sex = 0;

           if (actionIDs != null) actionIDs.Clear();
             db.Respond = null;
            
            name = Namer.Text.ToString().Trim();
            surname = Surname.Text.ToString().Trim();
            if (Men.Checked == true) sex = 1;
            else sex = 0;


            if (name.Length != 0 && surname.Length != 0)
                db.Select("Name='" + name + "' and " +
                          "Surname='" + surname +"' and Sex=" + sex +"");
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

            for (int i = 0; i < db.Respond.Count()  ; i++)
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

                        Info.Rows.Add(FIO, Birthday, WorkPlace, Address);
                    }
                  
            }
             
              
           
        }

        private void Info_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            action  = Info.CurrentRow.Index;
            
            Console.WriteLine(action);
            Console.WriteLine(actionIDs[action]);

        }

        private void Main_Activated(object sender, EventArgs e)
        {
            db.LocalDataTable.Clear();
            db.Create_Connection("Patients", Pater.item);
        }

        private void Time_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (Time[0, Time.CurrentRow.Index].Value == null)
                {
                    Time[0, CallPrevious].Value = null;
                    CallPrevious = Time.CurrentRow.Index;
                    Time[0, Time.CurrentRow.Index].Value = UserNik;
                    Curtime = " " +  Time.Rows[Time.CurrentRow.Index].HeaderCell.Value.ToString();
                    Dater();

                }

                else MessageBox.Show("Это время уже занято!");
            }
            else
            {

                //Time[1, e.RowIndex].Value = UserNik;


                if (MessageBox.Show("Вы действительно хотите назначить текущего пациента на данное время?\nСтарая запись будет удалена!", "Переназначение", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }

                else { }


            }
        }


        private void Calldate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Dater()
        {
            String call = UserCallDate.ToShortDateString().ToString() + Curtime;
            newtime = DateTime.Parse(call);
            CurCallDate.Text = newtime.ToString("g");
        }

        private void Info_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Info.Rows.Count != 0) {

                UserNik = Info.Rows[Info.CurrentRow.Index].Cells[0].Value.ToString();
                CurPatient.Text = UserNik;
            
            
            }
        }

        private void Calldate_ValueChanged_1(object sender, EventArgs e)
        {
            UserCallDate = Calldate.Value;
            for (int i = 0; i < 26; i++)
                Time[0, i].Value = null;
            for (int i = 0; i < 26; i++)
                Day[0, i].Value = null;
            Dater();
            DayTravel();

            
        }

        private void Info_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (action != null && Info.Rows.Count != 0)
            {
                Profile pr = new Profile(db, actionIDs[action]);
                pr.ShowDialog();
                db.LocalDataTable.Clear();
                db.Create_Connection("Patients", Pater.item);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Caller NewCall = new Caller();
            NewCall.UserID = UserID;
            NewCall.UserName = UserNik;
            NewCall.Call = newtime.ToString("g");

            NewCall.Create_parametrs();
            Console.WriteLine(NewCall.ins_cols.ToString());
            db1.Create_Connection("Calls", NewCall.item);

           /// db1.LocalDataTable.Dispose();


             try
            {
                db1.Insert("Calls", NewCall.Params);
            }
            catch (Exception a)
            { MessageBox.Show(a.Message); }
            finally
            {
                MessageBox.Show(NewCall.UserName + " \n назначен на" + NewCall.Call);
               
            }

            db.Refresh();
            db1.connect.Close();
        }

        private void Calendar_ValueChanged(object sender, EventArgs e)
        {
            Calldate.Value= Calendar.Value;
            for (int i = 0; i < 26; i++)
                Time[1, i].Value = null;
            for (int i = 0; i < 26; i++)
                Day[0, i].Value = null;
            Dater();
            DayTravel();
            WeekTravel();
        }




















    }
}


 