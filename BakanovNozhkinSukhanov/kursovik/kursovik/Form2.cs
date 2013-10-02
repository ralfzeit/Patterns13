using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace kursovik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (File.Exists("base.xml")) list.LoadList("base.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             if(textBox2.Text=="") {textBox3.Enabled=false;}
			 else
				{textBox3.Enabled=true;}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       		 if(textBox1.Text=="") {comboBox1.Enabled=false;}
			 else
				{comboBox1.Enabled=true;}
		 }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        if(textBox3.Text=="") {textBox4.Enabled=false;}
			 else
				{textBox4.Enabled=true;}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") { textBox5.Enabled = false; }
            else
            { textBox5.Enabled = true; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "") { textBox6.Enabled = false; }
            else
            { textBox6.Enabled = true; }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "") { button1.Enabled = false; }
            else
            { button1.Enabled = true; }            
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (textBox6.Text.Length != 0))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (textBox4.Text.Length != 0))
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (textBox3.Text.Length != 0))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        RQ list = new RQ();

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сохранить данные?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string temp1, temp2, temp3, temp4, temp5;

                if (checkBox1.Checked == true)
                    temp1 = "Да";
                else
                    temp1 = "Нет";

                if (checkBox2.Checked == true)
                    temp2 = "Да";
                else
                    temp2 = "Нет";

                if (checkBox3.Checked == true)
                    temp3 = "Да";
                else
                    temp3 = "Нет";

                if (checkBox4.Checked == true)
                    temp4 = "Да";
                else
                    temp4 = "Нет";

                if (checkBox5.Checked == true)
                    temp5 = "Да";
                else
                    temp5 = "Нет";

                MyClass newMyClass = new MyClass();
                newMyClass.City = comboBox1.Text;
                newMyClass.Street = textBox2.Text;
                newMyClass.FIO = textBox1.Text;
                newMyClass.HouseNum = Convert.ToInt32(textBox3.Text);
                newMyClass.FlatNum = Convert.ToInt32(textBox4.Text);
                newMyClass.Square = Convert.ToDouble(textBox5.Text);
                newMyClass.PeopleInside = Convert.ToInt32(textBox6.Text);
                newMyClass.SWater = temp1;
                newMyClass.Elevator = temp2;
                newMyClass.Watchman = temp3;
                newMyClass.Phone = temp4;
                newMyClass.Gas = temp5;
                list.AddMyClass(newMyClass);
                list.SaveList("base.xml");
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}

