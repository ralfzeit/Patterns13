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
    public partial class editing_admin : Form
    {
        public editing_admin()
        {
            InitializeComponent();
        }

        private string tmplogin = "";
        private string alogin = "";
        RA adminlist = new RA();
        RO operlist = new RO();
        RC clientlist = new RC();

        private void editing_admin_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не заполнено поле Фамилия!",
                "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Не заполнено поле Имя!",
                "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (richTextBox1.Text == "")
                    {
                        MessageBox.Show("Не заполнено поле Контактная информация!",
                    "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Не заполнено поле Логин!",
                    "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (textBox5.Text == "")
                            {
                                MessageBox.Show("Не заполнено поле Пароль!",
                    "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //если всё ок
                                alogin = textBox4.Text;
                                if (proverka_logina_a(alogin) == true && proverka_logina_c(alogin) == true && proverka_logina_o(alogin) == true)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Сохранить изменения?", "Редактирование администратора", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

                                        admin obJ = new admin();
                                        obJ.category = "Администраторы";
                                        obJ.a_lastname = textBox1.Text;
                                        obJ.a_name = textBox2.Text;
                                        if (textBox3.Text == "")
                                            obJ.a_name_2 = "-";
                                        if (textBox3.Text != "")
                                            obJ.a_name_2 = textBox3.Text;
                                        obJ.kontakt = richTextBox1.Text;
                                        obJ.login = textBox4.Text;
                                        obJ.pass = textBox5.Text;

                                        adminlist.RemoveMyClass(tmplogin);
                                        adminlist.AddMyClass(obJ);
                                        adminlist.SaveList("admin.xml");
                                        Close();
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                    }
                                }
                                else
                                if (proverka_logina_a(alogin) == false || proverka_logina_c(alogin) == false || proverka_logina_o(alogin) == false)
                                {
                                    MessageBox.Show("Такой логин уже существует!",
                    "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool proverka_logina_a(string str)
        {
            int flag = 0;
            string tmp = str;

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
                obj = adminlist.ReturnMyClass(i);
                if (obj.login == tmp && obj.login != tmplogin)
                    flag = 1;
            }
            if (flag == 0)
                return true;
            else
                return false;
        }

        private bool proverka_logina_o(string str)
        {
            int flagg = 0;
            string tmpp = str;

            try
            {
                operlist.LoadList("oper.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("oper.xml");
            }
            oper objj = new oper();

            for (int i = 0; i < operlist.coun(); i++)
            {
                objj = operlist.ReturnMyClass(i);
                if (objj.login == tmpp && objj.login != tmplogin)
                    flagg = 1;
            }
            if (flagg == 0)
                return true;
            else
                return false;
        }

        private bool proverka_logina_c(string str)
        {
            int flaggg = 0;
            string tmppp = str;

            try
            {
                clientlist.LoadList("clients.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("clients.xml");
            }
            client objjj = new client();

            for (int i = 0; i < clientlist.coun(); i++)
            {
                objjj = clientlist.ReturnMyClass(i);
                if (objjj.login == tmppp && objjj.login != tmplogin)
                    flaggg = 1;
            }
            if (flaggg == 0)
                return true;
            else
                return false;
        }
    }
}
