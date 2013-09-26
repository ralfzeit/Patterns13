using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TourBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string Week(int num)
        {
            if (num == 1)
                return "Понедельник";
            if (num == 2)
                return "Вторник";
            if (num == 3)
                return "Среда";
            if (num == 4)
                return "Четверг";
            if (num == 5)
                return "Пятница";
            if (num == 6)
                return "Суббота";
            return "Воскресенье";
        }

        private string Month(int num)
        {
            if (num == 1)
                return "Января";
            if (num == 2)
                return "Февраля";
            if (num == 3)
                return "Марта";
            if (num == 4)
                return "Апреля";
            if (num == 5)
                return "Мая";
            if (num == 6)
                return "Июня";
            if (num == 7)
                return "Июля";
            if (num == 8)
                return "Августа";
            if (num == 9)
                return "Сентября";
            if (num == 10)
                return "Октября";
            if (num == 11)
                return "Ноября";
            return "Декабря";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Room Room_window = new Room();
            Room_window.Owner = this;
            dr = Room_window.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Sauna Sauna_window = new Sauna();
            Sauna_window.Owner = this;
            dr = Sauna_window.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Clean Clean_window = new Clean();
            Clean_window.Owner = this;
            dr = Clean_window.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Ecip Ecip_window = new Ecip();
            Ecip_window.Owner = this;
            dr = Ecip_window.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Settings Set_window = new Settings();
            Set_window.Owner = this;
            dr = Set_window.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("H:mm");
            label3.Text = Week(int.Parse(DateTime.Now.DayOfWeek.ToString("D")))
                + ", " + DateTime.Now.Day.ToString() + " "
                + Month(DateTime.Now.Month);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender,e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult dr = MessageBox.Show("Закрыть программу?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    Application.Exit();
            }
        }
    }
}
