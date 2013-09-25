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
    public partial class pass_change : Form
    {
        public pass_change(string str)
        {
            tmpuserlogin = str;
            InitializeComponent();
        }

        RC clientlist = new RC();
        private string tmpboxname;
        private string tmpuserlogin;

        private void pass_change_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clientlist.LoadList("clients.xml");
            }
            catch (System.Exception ex)
            {
            }

            client nclient = new client();
            nclient = clientlist.FindCLass2(tmpuserlogin);

            if (textBox1.Text != nclient.pass)
            {
                MessageBox.Show("Вы ввели неправильный пароль!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Заполните поле для нового пароля!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Пароли не совпадают!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Сохранить измененный пароль?", "Сохранение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            nclient.pass = textBox3.Text;

                            clientlist.RemoveMyClass(nclient.login);
                            clientlist.AddMyClass(nclient);
                            clientlist.SaveList("clients.xml");
                            Close();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }
                    }
                }
            }
        }
    }
}
