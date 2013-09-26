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
    public partial class Add_Room : Form
    {
        private List<int> Numbers = new List<int>();
        public Room_Cl New_room;

        public Add_Room(List<Room_Cl> Rooms)
        {
            InitializeComponent();

            for (int i = 0; i < Rooms.Count; i++)
            {
                Numbers.Add(Rooms[i].Number);
            }
        }

        private bool Search_number(int num)
        {
            for (int i = 0; i < Numbers.Count; i++)
            {
                if (Numbers[i] == num)
                    return true;
            }
            return false;
        }

        private void Types_gen()
        {
            comboBox1.Items.Add("Стандарт");
            comboBox1.Items.Add("Люкс");
            comboBox1.Items.Add("Студия");
            comboBox1.Items.Add("Эконом");
        }

        private void Add_Room_Load(object sender, EventArgs e)
        {
            Types_gen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && textBox1.Text != "")
            {
                if (Search_number(Int32.Parse(numericUpDown1.Value.ToString())))
                {
                    MessageBox.Show("Комната с таким номером\nуже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    New_room = new Room_Cl();
                    New_room.Number = System.Int32.Parse(numericUpDown1.Value.ToString());
                    New_room.Type = comboBox1.Text;
                    New_room.Places = System.Int32.Parse(numericUpDown2.Value.ToString());
                    New_room.Cost = System.Int32.Parse(textBox1.Text);
                    MessageBox.Show("Новая комната\nуспешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Room_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
