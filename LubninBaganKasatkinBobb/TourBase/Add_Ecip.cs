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
    public partial class Add_Ecip : Form
    {
        private List<Ecip_Category> Cat;
        public Ecip_Category New_Cat;
        public Ecip_Model New_Model;
        public Ecip_Size New_Size;

        public Add_Ecip(List<Ecip_Category> input)
        {
            InitializeComponent();
            Cat = input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                New_Cat = new Ecip_Category();
                New_Model = new Ecip_Model();
                New_Size = new Ecip_Size();
                
                New_Size.Name = comboBox3.Text;
                New_Model.Name = comboBox2.Text;
                New_Model.Size.Add(New_Size);
                New_Cat.Name = comboBox1.Text;
                New_Cat.Model.Add(New_Model);

                MessageBox.Show("Новая экипировка\nуспешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Ecip_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Cat.Count; i++)
            {
                comboBox1.Items.Add(Cat[i].Name);
            }
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                comboBox2.Items.Clear();
                for (int i = 0; i < Cat[comboBox1.SelectedIndex].Model.Count; i++)
                {
                    comboBox2.Items.Add(Cat[comboBox1.SelectedIndex].Model[i].Name);
                }
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "";
            }
            else
            {
                comboBox2.Items.Clear();
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                comboBox3.Items.Clear();
                for (int i = 0; i < Cat[comboBox1.SelectedIndex].Model[comboBox2.SelectedIndex].Size.Count; i++)
                {
                    comboBox3.Items.Add(Cat[comboBox1.SelectedIndex].Model[comboBox2.SelectedIndex].Size[i].Name);
                }
                comboBox3.SelectedIndex = -1;
                comboBox3.Text = "";
            }
            else
            {
                comboBox3.Items.Clear();
                comboBox3.SelectedIndex = -1;
                comboBox3.Text = "";
            }
        }

        private void Add_Ecip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
