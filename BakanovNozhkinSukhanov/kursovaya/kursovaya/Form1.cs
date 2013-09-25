using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {   
            MessageBox.Show("Для регистрации обратитесь к оператору.",
                "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        RA adminlist = new RA();
        RO operlist = new RO();
        RC clientlist = new RC();

        private int flag = 0;
        private string stlogin = "";
        private string stpass = "";
        private string templ = "";
        private string tempp = "";

        private void button1_Click(object sender, EventArgs e)
        {
            flag = 0;
            stlogin = "";
            stpass = "";
            templ = textBox1.Text;
            tempp = textBox2.Text;
            
            if (File.Exists("admin.xml") && (flag == 0))
            {
                AdminCheck();
            }

            if (File.Exists("oper.xml") && (flag == 0))
            {
                OperCheck();
            }

            if (File.Exists("clients.xml") && (flag == 0))
            {
                ClientCheck();
            }

            if (flag == 0)
            {
                label5.Text = "Некорректный логин / пароль!";
            }
        }

        private void AdminCheck()
        {
            try
            {
                adminlist.LoadList("admin.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("admin.xml");
            }

            admin obj = new admin();

            for (int i = 0; i < adminlist.coun(); i++)
            {
                obj = adminlist.FindCLass(templ, tempp);
            }
            try
            {
                stlogin = obj.login;
                stpass = obj.pass;
            }
            catch (System.Exception ex)
            {
                stlogin = "";
                stpass = "";
            }
            if (stlogin != "")
            {
                flag = 1;
                label5.Text = "";
                this.Visible = false;
                MainForm_admin fa = new MainForm_admin(stlogin, stpass);
                fa.ShowDialog();
                Close();
            }
        }

        private void OperCheck()
        {
            try
            {
                operlist.LoadList("oper.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("oper.xml");
            }

            oper obj = new oper();

            for (int i = 0; i < operlist.coun(); i++)
            {
                obj = operlist.FindCLass(templ, tempp);
            }
            try
            {
                stlogin = obj.login;
                stpass = obj.pass;
            }
            catch (System.Exception ex)
            {
                stlogin = "";
                stpass = "";
            }
            if (stlogin != "")
            {
                flag = 1;
                label5.Text = "";
                this.Visible = false;
                MainForm_oper fo = new MainForm_oper(stlogin, stpass);
                fo.ShowDialog();
                Close();
            }
        }

        private void ClientCheck()
        {
            try
            {
                clientlist.LoadList("clients.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("clients.xml");
            }

            client obj = new client();

            for (int i = 0; i < clientlist.coun(); i++)
            {
                obj = clientlist.FindCLass(templ, tempp);
            }
            try
            {
                stlogin = obj.login;
                stpass = obj.pass;
            }
            catch (System.Exception ex)
            {
                stlogin = "";
                stpass = "";
            }
            if (stlogin != "")
            {
                flag = 1;
                label5.Text = "";
                this.Visible = false;
                MainForm_user fu = new MainForm_user(stlogin, stpass);
                fu.ShowDialog();
                Close();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Left == -32000 && this.Top == -32000)
            {
                notifyIcon1.Visible = true;
                this.Visible = false;
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
