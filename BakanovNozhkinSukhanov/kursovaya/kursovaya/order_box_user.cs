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
    public partial class order_box_user : Form
    {
        public order_box_user(string str1, string str2, int ioioioi)
        {
            tmpboxname = str1;
            tmpusername = str2;
            InitializeComponent();
        }

        private string tmpboxname;
        private string tmpusername;
        private DateTime oldDate;
        private DateTime newDate;

        RC clientlist = new RC();
        RT tariflist = new RT();
        RR rclientlist = new RR();
        RB boxlist = new RB();
        RORDER orderlist = new RORDER();

        private void order_box_user_Load(object sender, EventArgs e)
        {
            this.Text = "Аренда стояночного места - " + tmpboxname;
            label1.Text = "Место " + tmpboxname;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            dateTimePicker3.Value = dateTimePicker1.Value;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker3.Value;
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

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker4.Value;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите номер кредитной карты!",
            "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox2.Text == "")
                        {
                            MessageBox.Show("Введите PIN-код карты!",
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
                                    orderlist.LoadList("orders.xml");
                                }
                                catch (System.Exception ex)
                                {
                                    File.Delete("orders.xml");
                                }

                                client nclient = new client();
                                nclient = clientlist.FindCLass2(tmpusername);

                                ordering order = new ordering();
                                order.boxname = tmpboxname;
                                order.box_owner_category = nclient.category;
                                order.box_owner_lastname = nclient.C_lastname;
                                order.box_owner_name = nclient.C_name;
                                order.box_owner_kontakt = nclient.kontakt;
                                order.box_owner_login = nclient.login;
                                order.startdate = dateTimePicker1.Value;
                                order.enddate = dateTimePicker2.Value;

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
        }
    }
}
