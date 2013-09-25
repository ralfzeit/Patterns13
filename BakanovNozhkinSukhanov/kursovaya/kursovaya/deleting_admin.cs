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
    public partial class deleting_admin : Form
    {
        public deleting_admin()
        {
            InitializeComponent();
        }

        private string tmplogin = "";
        private string alogin = "";
        RA adminlist = new RA();

        private void deleting_admin_Load(object sender, EventArgs e)
        {
            string tmp;
            try
            {
                adminlist.LoadList("admin.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }
            comboBox1.Items.Clear();
            admin obj = new admin();
            for (int i = 0; i < adminlist.coun(); i++)
            {
                obj = adminlist.ReturnMyClass(i);
                tmp = obj.a_lastname + " " + obj.a_name;
                comboBox1.Items.Add(tmp);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                adminlist.LoadList("admin.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }
            admin obj = new admin();
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                obj = adminlist.ReturnMyClass(i);
                if (comboBox1.SelectedIndex == i)
                {
                    textBox1.Text = obj.a_lastname;
                    textBox2.Text = obj.a_name;
                    textBox3.Text = obj.a_name_2;
                    richTextBox1.Text = obj.kontakt;
                    textBox4.Text = obj.login;
                    textBox5.Text = obj.pass;
                    tmplogin = obj.login;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить данного пользователя?", "Удаление администратора", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    adminlist.LoadList("admin.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("admin.xml");
                }

                adminlist.RemoveMyClass(tmplogin);
                adminlist.SaveList("admin.xml");
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
