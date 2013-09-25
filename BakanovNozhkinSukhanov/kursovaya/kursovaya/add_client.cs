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
    public partial class add_client : Form
    {
        public add_client()
        {
            InitializeComponent();
        }

        private string clogin = "";
        RA adminlist = new RA();
        RO operlist = new RO();
        RC clientlist = new RC();

        private void add_client_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
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
                            MessageBox.Show("Не заполнено поле Модель транспортного средства!",
                    "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (textBox5.Text == "")
                            {
                                MessageBox.Show("Не заполнено поле Номер транспортного средства!",
                    "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (textBox6.Text == "")
                                {
                                    MessageBox.Show("Не заполнено поле Логин!",
                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (textBox7.Text == "")
                                    {
                                        MessageBox.Show("Не заполнено поле Пароль!",
                            "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        //если всё ок
                                        clogin = textBox7.Text;
                                        if (proverka_logina_a(clogin) == true && proverka_logina_c(clogin) == true && proverka_logina_o(clogin) == true)
                                        {
                                            label9.Text = "";
                                            pictureBox1.Visible = false;

                                            DialogResult dialogResult = MessageBox.Show("Сохранить данные о новом клиенте?", "Сохранение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                try
                                                {
                                                    clientlist.LoadList("clients.xml");
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    File.Delete("clients.xml");
                                                }

                                                client obJ = new client();
                                                obJ.category = "Клиенты";
                                                obJ.C_lastname = textBox1.Text;
                                                obJ.C_name = textBox2.Text;
                                                if (textBox3.Text == "")
                                                    obJ.C_name_2 = "-";
                                                if (textBox3.Text != "")
                                                    obJ.C_name_2 = textBox3.Text;
                                                obJ.kontakt = richTextBox1.Text;
                                                obJ.auto_model = textBox4.Text;
                                                obJ.auto_number = textBox5.Text;
                                                obJ.login = textBox7.Text;
                                                obJ.pass = textBox6.Text;

                                                clientlist.AddMyClass(obJ);
                                                clientlist.SaveList("clients.xml");
                                                Close();
                                            }
                                            else if (dialogResult == DialogResult.No)
                                            {
                                            }
                                        }
                                        else
                                        if (proverka_logina_a(clogin) == false || proverka_logina_c(clogin) == false || proverka_logina_o(clogin) == false)
                                        {
                                            label9.Text = "Такой логин уже существует!";
                                            pictureBox1.Visible = true;
                                        }
                                    }
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
                if (obj.login == tmp)
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
                if (objj.login == tmpp)
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
                if (objjj.login == tmppp)
                    flaggg = 1;
            }
            if (flaggg == 0)
                return true;
            else
                return false;
        }
    }
}
