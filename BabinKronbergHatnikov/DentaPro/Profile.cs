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
    public partial class Profile : Form
    {
        DRIVER db;
        int ID;
        DataTable Prof;
        public Profile(DRIVER dob, int id)
        {
            InitializeComponent();
            db = dob;
            ID = id;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button61_Click(object sender, EventArgs e)
        {
            Tooth t = new Tooth();
            t.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FV a = new FV();
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FV qw = new FV();
            qw.ShowDialog();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
             db.Select("ID=" + ID);
             Prof = db.Respond.CopyToDataTable();

             pname.Text = Prof.Rows[0]["Surname"] + " " + 
                          Prof.Rows[0]["Name"] + " " +
                          Prof.Rows[0]["Lastname"];
            pbdate.Text = "17.06.1993";
            workplace.Text = Prof.Rows[0]["Workplace"].ToString();
            phone.Text = Prof.Rows[0]["Phone"].ToString();
            email.Text = Prof.Rows[0]["Email"].ToString();
            social.Text = Prof.Rows[0]["Social"].ToString();
            pregdate.Text = "13.04.2013";
            if (Convert.ToInt32(Prof.Rows[0]["Sex"]) == 1)
                sex.Text = "Мужской";
            else sex.Text = "Женский";

            Image FetchedImage;
            byte[] ImgBytes = (byte[])Prof.Rows[0]["Profileb"];
            
            MemoryStream ImgStream = new MemoryStream(ImgBytes);
            FetchedImage = Image.FromStream(ImgStream);
            PatientImage.Image = FetchedImage;
        }

        private void social_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + social.Text.ToString().Trim());
        }

        private void отправитьEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MailMessage Message = new MailMessage();
                     
            Message.BodyEncoding = Encoding.GetEncoding("UTF-8");  
            EmailText em = new EmailText();
            em.ShowDialog();
           

            Message.Body = em.text;
            
            Message.Subject = em.sub;
            if (Message.Body != "" || Message.Subject != "")
            {

                Message.From = new System.Net.Mail.MailAddress("ikronberg@yandex.ru");

                Message.To.Add(new MailAddress(Prof.Rows[0]["Email"].ToString()));

                System.Net.Mail.SmtpClient Smtp = new SmtpClient("localhost", 25);//эсли здесь заполнено то строчка ниже не нужна!!!!

                Smtp.Host = "smtp.yandex.ru";//например для gmail (smtp.gmail.com), mail.ru(smtp.mail.ru) 

                Smtp.EnableSsl = true; // включение SSL для gmail нужно!!! для mail.ru не нада!!!

                Smtp.Credentials = new System.Net.NetworkCredential("ikronberg", "kronberg");

                try
                {
                    Smtp.Send(Message);//отправка
                }
                catch (Exception)
                { }

                finally
                {

                    MessageBox.Show("Сообщение отправлено успешно!");

                }
            }

        }

        private void редактироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patient_Edit Edit = new Patient_Edit(db,ID);
            Edit.ShowDialog();

        }

        private void удалитьПациентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletePatient del = new DeletePatient(ID, pname.Text.ToString(), db);
            del.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FV firstview = new FV();
            firstview.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formula pat = new Formula();
            pat.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            anket patient_anket = new anket(db);
            patient_anket.ShowDialog();
        }


        ///
    }



}
