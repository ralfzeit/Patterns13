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
    public partial class add_admin : Form
    {
        public add_admin()
        {
            InitializeComponent();
        }

        private string alogin = "";
        RA adminlist = new RA();
        RO operlist = new RO();
        RC clientlist = new RC();

        private void add_admin_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
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
                                    label7.Text = "";
                                    pictureBox1.Visible = false;

                                    DialogResult dialogResult = MessageBox.Show("Сохранить данные о новом администраторе?", "Сохранение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

                                        adminlist.AddMyClass(obJ);
                                        adminlist.SaveList("admin.xml");
                                        Close();
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                    }
                                }
                                if (proverka_logina_a(alogin) == false || proverka_logina_c(alogin) == false || proverka_logina_o(alogin) == false)
                                {
                                    label7.Text = "Такой логин уже существует!";
                                    pictureBox1.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                Close();
            }
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите закрыть форму добавления администратора?", "Закрытие формы добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                { 
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
