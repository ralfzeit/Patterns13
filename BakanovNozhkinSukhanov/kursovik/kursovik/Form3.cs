using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursovik
{
    public partial class Form3 : Form 
    {
        private string temp1;
        private int temp2;
        private int temp3;

        RQ list = new RQ();

        public Form3(string aa, int bb, int cc)
        {
            InitializeComponent();
            temp1 = aa;
            temp2 = bb;
            temp3 = cc;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            list.LoadList("base.xml");
            MyClass obj = new MyClass();
            obj = list.FindCLass(temp1, temp2, temp3);
            textBox1.Text = obj.FIO;
            comboBox1.Text = obj.City;
            textBox2.Text = obj.Street;
            textBox3.Text = Convert.ToString(obj.HouseNum);
            textBox4.Text = Convert.ToString(obj.FlatNum);
            textBox5.Text = Convert.ToString(obj.Square);
            textBox6.Text = Convert.ToString(obj.PeopleInside);
            if (obj.SWater == "Да")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;

            if (obj.Elevator == "Да")
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;

            if (obj.Watchman == "Да")
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;

            if (obj.Phone == "Да")
                checkBox4.Checked = true;
            else
                checkBox4.Checked = false;

            if (obj.Gas == "Да")
                checkBox5.Checked = true;
            else
                checkBox5.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "")
            {
                DialogResult dialogResult = MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult1 = MessageBox.Show("Вы точно хотите изменить эти данные?", "Изменение данных", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dialogResult1 == DialogResult.Yes)
                {
                    MyClass newMyClass = new MyClass();
                    list.RemoveMyClass(temp1, temp2, temp3);
                    string t1,t2,t3,t4,t5;

            if (checkBox1.Checked == true)
                t1 = "Да";
            else
                t1 = "Нет";

            if (checkBox2.Checked == true)
                t2 = "Да";
            else
                t2 = "Нет";

            if (checkBox3.Checked == true)
                t3 = "Да";
            else
                t3 = "Нет";

            if (checkBox4.Checked == true)
                t4 = "Да";
            else
                t4 = "Нет";
            
            if (checkBox5.Checked == true)
                t5 = "Да";
            else
                t5 = "Нет";
                    newMyClass.City = comboBox1.Text;
                    newMyClass.Street = textBox2.Text;
                    newMyClass.FIO = textBox1.Text;
                    newMyClass.HouseNum = Convert.ToInt32(textBox3.Text);
                    newMyClass.FlatNum = Convert.ToInt32(textBox4.Text);
                    newMyClass.Square = Convert.ToDouble(textBox5.Text);
                    newMyClass.PeopleInside = Convert.ToInt32(textBox6.Text);
                    newMyClass.SWater = t1;
                    newMyClass.Elevator = t2;
                    newMyClass.Watchman = t3;
                    newMyClass.Phone = t4;
                    newMyClass.Gas = t5;

                    list.AddMyClass(newMyClass);
                    list.SaveList("base.xml");
                    Close();
                }
                else if (dialogResult1 == DialogResult.No)
                {

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '.') && (textBox5.Text.IndexOf(".") == -1) && (textBox5.Text.Length != 0)))
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
    }
}
