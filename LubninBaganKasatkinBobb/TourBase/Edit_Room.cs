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
    public partial class Edit_Room : Form
    {
        public Room_Cl New_room;

        public Edit_Room(Room_Cl Room)
        {
            InitializeComponent();
            New_room = Room;
        }

        private void Types_gen()
        {
            comboBox1.Items.Add("Стандарт");
            comboBox1.Items.Add("Люкс");
            comboBox1.Items.Add("Студия");
            comboBox1.Items.Add("Эконом");
        }

        private void Edit_Room_Load(object sender, EventArgs e)
        {
            Types_gen();
            label5.Text = New_room.Number.ToString();
            comboBox1.SelectedItem = New_room.Type;
            numericUpDown2.Value = Convert.ToDecimal(New_room.Places);
            textBox1.Text = New_room.Cost.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && textBox1.Text != "")
            {
                New_room.Type = comboBox1.Text;
                New_room.Places = System.Int32.Parse(numericUpDown2.Value.ToString());
                New_room.Cost = System.Int32.Parse(textBox1.Text);
                MessageBox.Show("Новая комната\nуспешно изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Edit_Room_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
