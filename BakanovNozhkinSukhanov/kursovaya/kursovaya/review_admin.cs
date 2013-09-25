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
    public partial class review_admin : Form
    {
        public review_admin(string categ)
        {
            InitializeComponent();
            category = categ;
        }

        RA adminlist = new RA();
        string category;

        private void review_admin_Load(object sender, EventArgs e)
        {
            if (category != "Администраторы")
            {
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button3.Enabled = false;
            }
            if (category == "Администраторы")
            {
                this.button1.Enabled = true;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
            }
            ClearDGV();
        }

        private void ClearDGV()
        {
            dataSet1.Clear();
            if (File.Exists("admin.xml"))
            {
                try
                {
                    adminlist.LoadList("admin.xml");
                    dataSet1.ReadXml("admin.xml");
                    dataGridView1.DataSource = dataSet1;
                    dataGridView1.DataMember = "admin";
                    dataGridView1.Columns[0].HeaderText = "Категория";
                    dataGridView1.Columns[0].Width = 20;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Фамилия";
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[2].HeaderText = "Имя";
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[3].Width = 120;
                    dataGridView1.Columns[4].HeaderText = "Контакты";
                    dataGridView1.Columns[4].Width = 140;
                    dataGridView1.Columns[5].HeaderText = "Логин";
                    dataGridView1.Columns[5].Width = 80;
                    dataGridView1.Columns[6].HeaderText = "Пароль";
                    dataGridView1.Columns[6].Width = 80;
                    dataGridView1.Columns[6].Visible = false;
                }
                catch (System.Exception ex)
                {
                    File.Delete("admin.xml");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_admin ad = new add_admin();
            ad.ShowDialog();
            ClearDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("Нет данных для удаления! Сначала добавте информацию, для её последующего удаления :)", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эти данные из базы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    string temp1;
                    if (dataGridView1.RowCount != 0)
                    {
                        temp1 = Convert.ToString(dataGridView1.SelectedCells[5].Value);
                        adminlist.RemoveMyClass(temp1);
                        adminlist.SaveList("admin.xml");
                        ClearDGV();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("База данных пуста! Добавте информацию нажав на кнопку 'Добавить'. ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string temp;
                temp = Convert.ToString(dataGridView1.SelectedCells[5].Value);
                editing_admin2 ed2 = new editing_admin2(temp);
                ed2.ShowDialog();
                ClearDGV();
            }
        }
    }
}
