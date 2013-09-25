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
    public partial class order_box : Form
    {
        public order_box(string str, int num)
        {
            tmpnum = num;
            tmpboxname = str;
            InitializeComponent();
        }

        private int tmpnum;
        private string tmpboxname;
        private DateTime oldDate;
        private DateTime newDate;

        RC clientlist = new RC();
        RT tariflist = new RT();
        RR rclientlist = new RR();
        RB boxlist = new RB();
        RM cashlist = new RM();
        RORDER orderlist = new RORDER();

        private void order_box_Load(object sender, EventArgs e)
        {
            this.Text = "Аренда стояночного места - " + tmpboxname;
            label1.Text = "Место " + tmpboxname;
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.ResetText();
                textBox2.ResetText();
                textBox3.ResetText();
                textBox4.ResetText();
                textBox5.ResetText();
                richTextBox1.ResetText();
                comboBox2.Items.Clear();
                label3.Enabled = true;
                comboBox2.Enabled = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                richTextBox1.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                if (File.Exists("clients.xml"))
                {
                    try
                    {
                        clientlist.LoadList("clients.xml");
                    }
                    catch (System.Exception ex)
                    {
                        Close();
                    }

                    client obj = new client();
                    for (int i = 0; i < clientlist.coun(); i++)
                    {
                        obj = clientlist.ReturnMyClass(i);
                        comboBox2.Items.Add(obj.login);
                    }
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                label3.Enabled = false;
                comboBox2.Enabled = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                richTextBox1.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;

                textBox1.ResetText();
                textBox2.ResetText();
                textBox3.ResetText();
                textBox4.ResetText();
                textBox5.ResetText();
                richTextBox1.ResetText();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clientlist.LoadList("clients.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }

            client obj = new client();

            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                obj = clientlist.ReturnMyClass(i);
                if (comboBox2.SelectedIndex == i)
                {
                    textBox1.Text = obj.C_lastname;
                    textBox2.Text = obj.C_name;
                    textBox3.Text = obj.C_name_2;
                    richTextBox1.Text = obj.kontakt;
                    textBox4.Text = obj.auto_model;
                    textBox5.Text = obj.auto_number;
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value;
            }
            dateTimePicker4.Value = dateTimePicker2.Value;
            oldDate = dateTimePicker1.Value;
            newDate = dateTimePicker2.Value;
            TimeSpan ts = newDate - oldDate;
            int difference = ts.Days + 1;
            
            textBox6.Text = difference.ToString();
            podschet(difference);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            dateTimePicker3.Value = dateTimePicker1.Value;
        }

        private void podschet(int days)
        {
            int tmp = days;
            int tmp1;
            double tmp2, tmp3;

            try
            {
                tariflist.LoadList("tarif.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }
            tarif obj = new tarif();

            obj = tariflist.FindActive("Активный");
            if (tmp < 7)
            {
                textBox7.Text = (tmp * obj.day).ToString();
            }
            if (tmp >= 7 && tmp < 14)
            {
                tmp1 = tmp - 7;
                textBox7.Text = ((1 * obj.week) + tmp1 * obj.day).ToString();
            }
            if (tmp >= 14 && tmp < 21)
            {
                tmp1 = tmp - 14;
                textBox7.Text = ((2 * obj.week) + tmp1 * obj.day).ToString();
            }
            if (tmp >= 21 && tmp < 28)
            {
                tmp1 = tmp - 21;
                textBox7.Text = ((3 * obj.week) + tmp1 * obj.day).ToString();
            }
            if (tmp >= 28 && tmp < 30)
            {
                tmp1 = tmp - 28;
                textBox7.Text = ((3 * obj.week) + tmp1 * obj.day).ToString();
            }
            if (tmp >= 30 && tmp < 90)
            {
                tmp2 = obj.month / 30;
                tmp3 = tmp2 * tmp;
                textBox7.Text = tmp3.ToString();
            }

            if (tmp >= 90 && tmp < 180)
            {
                tmp2 = obj.three_months / 90;
                tmp3 = tmp2 * tmp;
                textBox7.Text = tmp3.ToString();
            }
            if (tmp >= 180)
            {
                tmp2 = obj.six_months / 180;
                tmp3 = tmp2 * tmp;
                textBox7.Text = tmp3.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Не выбран логин!",
                    "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Выберите дату окончания аренды!",
            "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DateTime dt1, dt2;
                        dt1 = dateTimePicker1.Value;
                        dt2 = dateTimePicker2.Value;

                        if (check_date(tmpboxname, dt1, dt2) == false)
                        {
                            MessageBox.Show("В выбранный период место уже занято!",
            "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Сохранить запись?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                                try
                                {
                                    boxlist.LoadList("boxes.xml");
                                }
                                catch (System.Exception ex)
                                {
                                    File.Delete("boxes.xml");
                                }

                                try
                                {
                                    cashlist.LoadList("cash.xml");
                                }
                                catch (System.Exception ex)
                                {
                                    File.Delete("cash.xml");
                                }

                                try
                                {
                                    orderlist.LoadList("orders.xml");
                                }
                                catch (System.Exception ex)
                                {
                                    File.Delete("orders.xml");
                                }

                                client nclient = new client();
                                nclient = clientlist.FindCLass2(comboBox2.Text);

                                ordering order = new ordering();
                                order.boxname = tmpboxname;
                                order.box_owner_category = nclient.category;
                                order.box_owner_lastname = nclient.C_lastname;
                                order.box_owner_name = nclient.C_name;
                                order.box_owner_kontakt = nclient.kontakt;
                                order.box_owner_login = nclient.login;
                                order.startdate = dateTimePicker1.Value;
                                order.enddate = dateTimePicker2.Value;

                                cash money = new cash();
                                money.date = DateTime.Now.ToShortDateString();
                                money.category = nclient.category;
                                money.c_lastname = nclient.C_lastname;
                                money.c_name = nclient.C_name;
                                money.box = tmpboxname;
                                money.c_value = Convert.ToDouble(textBox7.Text);

                                //save

                                cashlist.AddMyClass(money);
                                cashlist.SaveList("cash.xml");

                                orderlist.AddMyClass(order);
                                orderlist.SaveList("orders.xml");
                                Close();

                            }
                            else if (dialogResult == DialogResult.No)
                            {
                            }
                        }
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
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
                                        MessageBox.Show("Выберите дату окончания аренды!",
                            "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        DateTime dt1, dt2;
                                        dt1 = dateTimePicker1.Value;
                                        dt2 = dateTimePicker2.Value;

                                        if (check_date(tmpboxname, dt1, dt2) == false)
                                        {
                                            MessageBox.Show("В выбранный период место уже занято!",
                            "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            DialogResult dialogResult = MessageBox.Show("Сохранить запись?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                //не забыть исправить 4 на 1))
                                                //написать проверку на существование файл, защиту от дурака, сохранить все в файл, запилить кэш, запилить занятость, запилить освобождение по времени, все, я спаааааать

                                                try
                                                {
                                                    rclientlist.LoadList("rclients.xml");
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    File.Delete("rclients.xml");
                                                }
                                                try
                                                {
                                                    boxlist.LoadList("boxes.xml");
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    File.Delete("boxes.xml");
                                                }

                                                try
                                                {
                                                    cashlist.LoadList("cash.xml");
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    File.Delete("cash.xml");
                                                }
                                                try
                                                {
                                                    orderlist.LoadList("orders.xml");
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    File.Delete("orders.xml");
                                                }

                                                random_client rcl = new random_client();
                                                rcl.category = "Незарегистрированный";
                                                rcl.r_lastname = textBox1.Text;
                                                rcl.r_name = textBox2.Text;
                                                if (textBox3.Text == "")
                                                    rcl.r_name_2 = "-";
                                                else
                                                    rcl.r_name_2 = textBox3.Text;
                                                rcl.kontakt = richTextBox1.Text;
                                                rcl.auto_model = textBox4.Text;
                                                rcl.auto_number = textBox5.Text;
                                                rcl.box = tmpboxname;
                                                rcl.d1 = dateTimePicker1.Value;
                                                rcl.d2 = dateTimePicker2.Value;

                                                ordering order = new ordering();
                                                order.boxname = tmpboxname;
                                                order.box_owner_category = rcl.category;
                                                order.box_owner_lastname = rcl.r_lastname;
                                                order.box_owner_name = rcl.r_name;
                                                order.box_owner_kontakt = rcl.kontakt;
                                                order.box_owner_login = rcl.auto_number;
                                                order.startdate = dateTimePicker1.Value;
                                                order.enddate = dateTimePicker2.Value;

                                                cash money = new cash();
                                                money.date = DateTime.Now.ToShortDateString();
                                                money.category = rcl.category;
                                                money.c_lastname = rcl.r_lastname;
                                                money.c_name = rcl.r_name;
                                                money.box = tmpboxname;
                                                money.c_value = Convert.ToDouble(textBox7.Text);

                                                //save

                                                cashlist.AddMyClass(money);
                                                cashlist.SaveList("cash.xml");

                                                orderlist.AddMyClass(order);
                                                orderlist.SaveList("orders.xml");

                                                rclientlist.AddMyClass(rcl);
                                                rclientlist.SaveList("rclients.xml");
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
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void sortir(int nnn)
        {
            try
            {
                boxlist.LoadList("boxes.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("boxes.xml");
            }

            boxes a = new boxes();
            boxes b = new boxes();
            boxes c = new boxes();
            int sh = 36 - nnn;
            while (sh > 1)
            {
                a = boxlist.ReturnMyClass(nnn);
                boxlist.RemoveMyClass(a.box_number);
                boxlist.AddMyClass(a);
                boxlist.SaveList("boxes.xml");
                sh--;
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker3.Value;
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker4.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool check_date(string str, DateTime dat1, DateTime dat2)
        {
            if (File.Exists("orders.xml"))
            {
                try
                {
                    orderlist.LoadList("orders.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                int flag = 0;
                ordering order = new ordering();

                for (int i = 0; i < orderlist.coun(); i++)
                {
                    order = orderlist.ReturnMyClass(i);
                    if (order.boxname == str)
                    {
                        if (dat1 >= order.startdate && dat1 <= order.enddate)
                            flag = 1;

                        if (dat2 >= order.startdate && dat2 <= order.enddate)
                            flag = 1;

                        if (dat1 < order.startdate && dat2 >= order.startdate && dat2 <= order.enddate)
                            flag = 1;

                        if (dat1 < order.startdate && order.enddate <= dat2)
                            flag = 1;
                    }
                }

                if (flag == 0)
                    return true;
                else
                    return false;
            }
            else return true;
        }
    }
}
