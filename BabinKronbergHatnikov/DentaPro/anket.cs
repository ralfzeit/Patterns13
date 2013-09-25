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
    public partial class anket : Form
    {
        public Patient New_Patient = new Patient();
        public DRIVER driver; 
        public anket(DRIVER drive)
        {
            InitializeComponent();
            driver = drive;
        }

        public void Validate_anket()
        {
            
            foreach (Control c in cheks.Controls)
                if ((c is CheckBox) && (((CheckBox)c).Checked == true))
                    New_Patient.Desies+=(c.Text.ToString()+"!");

            foreach (Control c in texts.Controls)
                if ((c is TextBox) && (((TextBox)c).Text.ToString() != ""))
                    New_Patient.Desies+=(c.Text.ToString()+"!");


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validate_anket();/*
           foreach (String a in New_Patient.DesiesMask) 
            Console.WriteLine(a);*/

           driver.Update("Patients", "Desies='" + New_Patient.Desies + "'", "ID=" + driver.Respond.CopyToDataTable().Rows[0]["ID"]);
        
        }

        private void anket_Load(object sender, EventArgs e)
        {
            if (driver.Respond.CopyToDataTable().Rows[0]["Desies"].ToString() == String.Empty)
            {
                Anketa.Visible = true;
                Desies.Visible = false;
                Anketa.BringToFront();
                Save.Visible = true;
                Rewind.Visible = false;
            }
            else
            {
                Anketa.Visible = false;
                Desies.Visible = true;
                Desies.BringToFront();
                Save.Visible = false;
                Result.Text = driver.Respond.CopyToDataTable().Rows[0]["Desies"].ToString().Replace
                    ("!",Environment.NewLine + Environment.NewLine);
            }
            


       }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Anketa.Visible = true;
            Desies.Visible = false;
            Anketa.BringToFront();
            Save.Visible = true;
            Rewind.Visible = false;
        }
    }
}
