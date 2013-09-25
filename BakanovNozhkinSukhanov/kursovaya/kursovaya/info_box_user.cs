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
    public partial class info_box_user : Form
    {
        public info_box_user(string str, int ioiioi)
        {
            tmpboxname = str;
            InitializeComponent();
        }

        RORDER orderlist = new RORDER();
        RB boxlist = new RB();
        private string tmpboxname;

        private void info_box_user_Load(object sender, EventArgs e)
        {
            Init();
            ClearDGV();
        }

        private void empty()
        {
            textBox1.Text = "свободен";
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
        }

        private void Init()
        {
            this.Text = "Информация о стояночном месте - " + tmpboxname;
            this.label2.Text = "Место " + tmpboxname;

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
                                textBox1.Text = "занят";
                                dateTimePicker2.Value = order.enddate;
                                dateTimePicker3.Value = order.enddate;
                            }
                        }
                    }
                }
            }
            else
                empty();
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
                        dataGridView1.Rows.Add(order.startdate, order.enddate);
                    }
                }
            }
        }
    }
}
