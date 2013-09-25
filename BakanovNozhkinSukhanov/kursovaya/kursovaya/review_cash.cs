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
    public partial class review_cash : Form
    {
        public review_cash()
        {
            InitializeComponent();
        }

        RM cashlist = new RM();

        private void review_cash_Load(object sender, EventArgs e)
        {
            ClearDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearDGV()
        {
            dataGridView1.Rows.Clear();

            if (File.Exists("cash.xml"))
            {
                try
                {
                    cashlist.LoadList("cash.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("cash.xml");
                }

                if (cashlist.coun() != 0)
                {

                    cash money = new cash();
                    double summ = 0;
                    for (int i = 0; i < cashlist.coun(); i++)
                    {
                        money = cashlist.ReturnMyClass(i);
                        summ += money.c_value;
                        dataGridView1.Rows.Add(money.date, money.box, money.c_value, money.category, money.c_lastname, money.c_name);
                    }
                    textBox1.Text = summ + " руб";
                }
                else
                    textBox1.Text = "0 руб";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("cash.xml"))
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите принять кассу?", "Прием кассы", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        cashlist.LoadList("cash.xml");
                    }
                    catch (System.Exception ex)
                    {
                        Close();
                    }

                    cashlist.ClearList();
                    cashlist.SaveList("cash.xml");
                    ClearDGV();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }
    }
}
