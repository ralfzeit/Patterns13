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
    public partial class base_tarif_info : Form
    {
        public base_tarif_info()
        {
            InitializeComponent();
        }
        RT tariflist = new RT();
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void base_tarif_info_Load(object sender, EventArgs e)
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

            obj = tariflist.FindActive("Активный");

            textBox1.Text = obj.tname;
            textBox2.Text = obj.day.ToString() + " руб";
            textBox3.Text = obj.week.ToString() + " руб";
            textBox4.Text = obj.month.ToString() + " руб";
            textBox5.Text = obj.three_months.ToString() + " руб";
            textBox6.Text = obj.six_months.ToString() + " руб";
        }
    }
}
