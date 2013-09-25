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
    public partial class info_box : Form
    {
        public info_box(string str, int type)
        {
            tmptype = type;
            tmpboxname = str;
            InitializeComponent();
        }

        private string tmpboxname;
        private int tmpboxnum;
        private int tmptype;
        RORDER orderlist = new RORDER();
        RB boxlist = new RB();

        private void info_box_Load(object sender, EventArgs e)
        {
            if (tmptype == 0)
            {
                this.tabControl1.SelectedIndex = 0;
            }
            else
                this.tabControl1.SelectedIndex = 1;
            Init();
            ClearDGV();
        }

        private void Init()
        {
            this.Text = "Информация о стояночном месте - " + tmpboxname;
            this.label2.Text = "Место " + tmpboxname;
            this.label10.Text = "Место " + tmpboxname;

            if (File.Exists("orders.xml"))
            {
                try
                {
                    orderlist.LoadList("orders.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("orders.xml");
                }
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("boxes.xml");
                }

                boxes box = new boxes();
                box = boxlist.FindCLass(tmpboxname);
                tmpboxnum = box.n;
                if (box.box_status == "свободен")
                {
                    empty();
                }
                else
                {
                    DateTime d1;
                    d1 = DateTime.Now;

                    ordering order = new ordering();
                    for (int i = 0; i < orderlist.coun(); i++)
                    {
                        order = orderlist.ReturnMyClass(i);
                        if (order.boxname == tmpboxname)
                        {
                            if (d1 >= order.startdate && d1 <= order.enddate)
                            {
                                textBox1.Text = order.box_owner_category;
                                textBox2.Text = order.box_owner_login;
                                textBox3.Text = order.box_owner_lastname;
                                textBox4.Text = order.box_owner_name;
                                richTextBox1.Text = order.box_owner_kontakt;
                                dateTimePicker2.Value = order.startdate;
                                dateTimePicker3.Value = order.startdate;
                                dateTimePicker4.Value = order.enddate;
                                dateTimePicker5.Value = order.enddate;
                            }
                        }
                    }
                }
            }
            else
                empty();
        }

        private void empty()
        {
            textBox1.Text = "-";
            textBox2.Text = "-";
            textBox3.Text = "-";
            textBox4.Text = "-";
            richTextBox1.Text = "-";
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker5.Value = DateTime.Now;
        }

        private void ClearDGV()
        {
            dataGridView1.Rows.Clear();

            if (File.Exists("orders.xml"))
            {
                try
                {
                    orderlist.LoadList("orders.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("orders.xml");
                }

                ordering order = new ordering();

                for (int i = 0; i < orderlist.coun(); i++)
                {
                    order = orderlist.ReturnMyClass(i);
                    if (order.boxname == tmpboxname)
                    {
                        dataGridView1.Rows.Add(order.startdate,order.enddate,order.box_owner_category,order.box_owner_login, order.box_owner_lastname,order.box_owner_kontakt);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order_box ob = new order_box(tmpboxname,tmpboxnum);
            ob.ShowDialog();
            ClearDGV();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("Нет данных для удаления! Сначала добавте информацию, для её последующего удаления :)", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эти данные из базы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    string temp1;
                    DateTime d2;
                    if (dataGridView1.RowCount != 0)
                    {
                        try
                        {
                            orderlist.LoadList("orders.xml");
                        }
                        catch (System.Exception ex)
                        {
                            File.Delete("orders.xml");
                        }
                        temp1 = tmpboxname;
                        d2 = Convert.ToDateTime(dataGridView1.SelectedCells[1].Value);
                        orderlist.RemoveMyClass(temp1, d2);
                        orderlist.SaveList("orders.xml");
                        ClearDGV();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("Нет данных для изменения!", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DateTime d2;
                d2 = Convert.ToDateTime(dataGridView1.SelectedCells[1].Value);
                edit_order edor = new edit_order(tmpboxname, d2);
                edor.ShowDialog();
                ClearDGV();
            }
        }
    }
}
