using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;

namespace Denta_Pro
{
    public partial class Patient_Edit : Form
    {
        public DRIVER db;
        public int UserID;

        public Patient patient = new Patient();
        public byte[] image;

        public Patient_Edit(DRIVER dob, int ID)
        {
            InitializeComponent();

            db = dob;
            UserID = ID;
        
           
            db.Create_Connection("Patients", patient.item);

            DataTable Respond = db.LocalDataTable.Select("ID=" + UserID).CopyToDataTable();

           Patient.Columns.Add("Property", "Свойство");
            Patient.Columns.Add("Value", "Значение");
            Patient.Columns[1].Width = 220;

            for (int i = 0; i < 14; i++) 
            {

                if (i == 12) image = (byte[])Respond.Rows[0].ItemArray.GetValue(i); 
                String Name =  db.LocalDataTable.Columns[i].ColumnName.ToString();
                String Value = Respond.Rows[0].ItemArray.GetValue(i).ToString();
               
                Patient.Rows.Add(Name,Value);
                
           
            }

           Patient.Rows[0].Visible = false;
           Patient.Rows[9].Visible = false;
           Patient.Rows[10].Visible = false;          
           Patient.Rows[11].Visible = false;
           Patient.Rows[12].Visible = false;
           Patient.Rows[13].Visible = false;

           Image FetchedImage;
           byte[] ImgBytes = (byte[])Respond.Rows[0]["Profileb"];

           MemoryStream ImgStream = new MemoryStream(ImgBytes);
           FetchedImage = Image.FromStream(ImgStream);
           PatientImage.Image = FetchedImage;

         

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            patient.ID =UserID;
            patient.Name = Patient[1, 1].Value.ToString();
            patient.Surname = Patient[1, 2].Value.ToString();

            patient.Lastname = Patient[1, 3].Value.ToString();
            patient.Address = Patient[1, 4].Value.ToString();
            patient.Workplace = Patient[1, 5].Value.ToString();

            patient.Phone = Patient[1, 6].Value.ToString();
            patient.Email = Patient[1, 7].Value.ToString();
            patient.Social = Patient[1, 8].Value.ToString();
            patient.Sex = Convert.ToInt32(Patient[1, 9].Value);

            patient.Regest = DateTime.Parse(Patient[1, 10].Value.ToString());
            patient.Birthdate = DateTime.Parse(Patient[1, 11].Value.ToString());
            patient.Profile = PatientImage.Image;
            patient.Image2bytes();
            patient.Desies = "a";

            patient.CreateStrings();
          

            try
            {
                db.Update("Patients", patient.update_string, "ID=" + UserID,patient);
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }

            finally {

                MessageBox.Show("Изменения сохранены!");
            }

            this.Close();
        }

        private void PatientImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                if (openFileDialog1.FileName.Contains("jpg") || openFileDialog1.FileName.Contains("png")
                    || openFileDialog1.FileName.Contains("bmp"))
                {
                    Image img = Image.FromFile(openFileDialog1.FileName);

                    PatientImage.Image.Dispose();
                    PatientImage.Image = img;


                }
                else MessageBox.Show("Неверный формат файла!");



            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
