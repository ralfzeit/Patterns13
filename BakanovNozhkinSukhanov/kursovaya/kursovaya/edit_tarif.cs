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
    public partial class edit_tarif : Form
    {
        public edit_tarif(string str)
        {
            tmptname = str;
            InitializeComponent();
        }

        RT tariflist = new RT();
        private string tmptname;
        private string ttname = "";

        private void edit_tarif_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Не заполнено поле Название!",
                "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Не заполнено поле Оплата за день!",
                "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Не заполнено поле Оплата за неделю!",
                    "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Не заполнено поле Оплата за месяц!",
                        "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (textBox5.Text == "")
                            {
                                MessageBox.Show("Не заполнено поле Оплата за три месяца!",
                            "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (textBox6.Text == "")
                                {
                                    MessageBox.Show("Не заполнено поле Оплата за полгода!",
                                "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ttname = textBox1.Text;
                                    //если все ок
                                    if (proverka_nazvaniya(ttname) == true)
                                    {
                                        DialogResult dialogResult = MessageBox.Show("Сохранить данные о новом тарифе?", "Сохранение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            try
                                            {
                                                tariflist.LoadList("tarif.xml");
                                            }
                                            catch (System.Exception ex)
                                            {
                                                File.Delete("tarif.xml");
                                            }
                                            tarif obJ = new tarif();
                                            obJ.tname = textBox1.Text;
                                            obJ.status = comboBox1.Text;
                                            obJ.day = Convert.ToDouble(textBox2.Text);
                                            obJ.week = Convert.ToDouble(textBox3.Text);
                                            obJ.month = Convert.ToDouble(textBox4.Text);
                                            obJ.three_months = Convert.ToDouble(textBox5.Text);
                                            obJ.six_months = Convert.ToDouble(textBox6.Text);

                                            if (comboBox1.Text == "Активный")
                                                check_status();
                                            else
                                            {
                                                if (check_status2() == true)
                                                    obJ.status = "Активный";
                                                else
                                                {
                                                }
                                            }

                                            tariflist.RemoveMyClass(tmptname);
                                            tariflist.AddMyClass(obJ);
                                            tariflist.SaveList("tarif.xml");
                                            Close();
                                        }
                                        else if (dialogResult == DialogResult.No)
                                        {
                                        }
                                    }
                                    else if (proverka_nazvaniya(ttname) == false)
                                    {
                                        MessageBox.Show("Такое название уже существует!",
                            "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if (textBox2.Text == "")
            {
                temp = 0;
            }
            else
            {
                temp = Convert.ToDouble(textBox2.Text);
            }
            textBox3.Text = (temp * 7).ToString();
            textBox4.Text = (temp * 30).ToString();
            textBox5.Text = (temp * 90).ToString();
            textBox6.Text = (temp * 180).ToString();
        }

        private void Init()
        {
            try
            {
                tariflist.LoadList("tarif.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }

            tarif obj = new tarif();
            obj = tariflist.FindCLass(tmptname);
            if (obj.status == "Активный")
                comboBox1.Text = "Активный";
            else
                comboBox1.Text = "Неактивный";

            textBox1.Text = obj.tname;
            textBox2.Text = obj.day.ToString();
            textBox3.Text = obj.week.ToString();
            textBox4.Text = obj.month.ToString();
            textBox5.Text = obj.three_months.ToString();
            textBox6.Text = obj.six_months.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox2.Text.IndexOf(",") == -1) && (textBox2.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox3.Text.IndexOf(",") == -1) && (textBox3.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox4.Text.IndexOf(",") == -1) && (textBox4.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox5.Text.IndexOf(",") == -1) && (textBox5.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox6.Text.IndexOf(",") == -1) && (textBox6.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private bool proverka_nazvaniya(string str)
        {
            int flag = 0;
            string tmp = str;

            try
            {
                tariflist.LoadList("tarif.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("tarif.xml");
            }
            tarif obj = new tarif();
            for (int i = 0; i < tariflist.coun(); i++)
            {
                obj = tariflist.ReturnMyClass(i);
                if (obj.tname == tmp && obj.tname != tmptname)
                    flag = 1;
            }
            if (flag == 0)
                return true;
            else
                return false;
        }

        private void check_status()
        {
            if (File.Exists("tarif.xml"))
            {
                try
                {
                    tariflist.LoadList("tarif.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("tarif.xml");
                }

                tarif obj = new tarif();

                for (int i = 0; i < tariflist.coun(); i++)
                {
                    obj = tariflist.ReturnMyClass(i);
                    if (obj.status == "Активный")
                        obj.status = "Неактивный";
                }
            }
        }

        private bool check_status2()
        {
            if (File.Exists("tarif.xml"))
            {
                int flag = 0;
                try
                {
                    tariflist.LoadList("tarif.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("tarif.xml");
                }

                tarif obj = new tarif();

                for (int i = 0; i < tariflist.coun(); i++)
                {
                    obj = tariflist.ReturnMyClass(i);
                    if (obj.status == "Активный")
                        flag = 1;
                }
                if (flag == 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
    }
}
