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
    public partial class kabinet : Form
    {
        public kabinet(string str)
        {
            tmpuserlogin = str;
            InitializeComponent();
        }

        RORDER orderlist = new RORDER();
        RB boxlist = new RB();
        RC clientlist = new RC();
        
        private string tmpuserlogin;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kabinet_Load(object sender, EventArgs e)
        {
            Init();
            ClearDGV();
        }

        private void Init()
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

            textBox1.Text = nclient.C_lastname;
            textBox2.Text = nclient.C_name;
            textBox3.Text = nclient.C_name_2;
            richTextBox1.Text = nclient.kontakt;
            textBox4.Text = nclient.auto_model;
            textBox5.Text = nclient.auto_number;
            textBox6.Text = nclient.login;
            textBox7.Text = nclient.pass;
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
                    if (order.box_owner_login == tmpuserlogin)
                    {
                        dataGridView1.Rows.Add(order.boxname, order.startdate, order.enddate);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pass_change pas = new pass_change(tmpuserlogin);
            pas.ShowDialog();
            Init();
        }
    }
}
