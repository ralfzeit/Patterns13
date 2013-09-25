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
    public partial class review_clients : Form
    {
        public review_clients()
        {
            InitializeComponent();
        }

        RC clientlist = new RC();

        private void review_clients_Load(object sender, EventArgs e)
        {
            ClearDGV();
        }

        private void ClearDGV()
        {
            dataSet1.Clear();
            if (File.Exists("clients.xml"))
            {
                try
                {
                    clientlist.LoadList("clients.xml");
                    dataSet1.ReadXml("clients.xml");
                    dataGridView1.DataSource = dataSet1;
                    dataGridView1.DataMember = "client";
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
                    dataGridView1.Columns[5].HeaderText = "Модель ТС";
                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[6].HeaderText = "Номер ТС";
                    dataGridView1.Columns[6].Width = 80;
                    dataGridView1.Columns[7].HeaderText = "Логин";
                    dataGridView1.Columns[7].Width = 80;
                    dataGridView1.Columns[8].HeaderText = "Пароль";
                    dataGridView1.Columns[8].Width = 80;
                    dataGridView1.Columns[8].Visible = false;
                }
                catch (System.Exception ex)
                {
                    File.Delete("clients.xml");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_client adc = new add_client();
            adc.ShowDialog();
            ClearDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
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
                        temp1 = Convert.ToString(dataGridView1.SelectedCells[7].Value);
                        clientlist.RemoveMyClass(temp1);
                        clientlist.SaveList("clients.xml");
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
                temp = Convert.ToString(dataGridView1.SelectedCells[7].Value);
                editing_client ecl = new editing_client(temp);
                ecl.ShowDialog();
                ClearDGV();
            }
        }
    }
}
