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
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace kursovik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RQ list = new RQ();
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            ClearDGV();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    int temp2, temp3;
                    if (dataGridView1.RowCount != 0)
                    {
                        temp1 = Convert.ToString(dataGridView1.SelectedCells[2].Value);
                        temp2 = Convert.ToInt32(dataGridView1.SelectedCells[3].Value);
                        temp3 = Convert.ToInt32(dataGridView1.SelectedCells[4].Value);
                        list.RemoveMyClass(temp1, temp2, temp3);
                        list.SaveList("base.xml");
                        ClearDGV();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearDGV();
        }

        public string TEMP1;
        public int TEMP2;
        public int TEMP3;

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("База данных пуста! Добавте информацию нажав на кнопку 'Добавить'. ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TEMP1 = Convert.ToString(dataGridView1.SelectedCells[2].Value);
                TEMP2 = Convert.ToInt32(dataGridView1.SelectedCells[3].Value);
                TEMP3 = Convert.ToInt32(dataGridView1.SelectedCells[4].Value);
                Form3 ff = new Form3(TEMP1, TEMP2, TEMP3);
                ff.ShowDialog();
                ClearDGV();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("База данных пуста! Добавте информацию нажав на кнопку 'Добавить'. ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TEMP1 = Convert.ToString(dataGridView1.SelectedCells[2].Value);
                TEMP2 = Convert.ToInt32(dataGridView1.SelectedCells[3].Value);
                TEMP3 = Convert.ToInt32(dataGridView1.SelectedCells[4].Value);

                calculate fff = new calculate(TEMP1, TEMP2, TEMP3);
                fff.ShowDialog();
                ClearDGV();
            }
        }

        public void ClearDGV()
        {
            dataSet1.Clear();
            if (File.Exists("base.xml"))
            {
                try
                {
                    string filePath = "base.xml";
                    list.LoadList("base.xml");
                    dataSet1.ReadXml(filePath);
                    dataGridView1.DataSource = dataSet1;
                    dataGridView1.DataMember = "MyClass";
                    dataGridView1.Columns[0].HeaderText = "Город";
                    dataGridView1.Columns[0].Width = 60;
                    dataGridView1.Columns[1].HeaderText = "Улица";
                    dataGridView1.Columns[1].Width = 110;
                    dataGridView1.Columns[2].HeaderText = "ФИО";
                    dataGridView1.Columns[2].Width = 180;
                    dataGridView1.Columns[3].HeaderText = "N дома";
                    dataGridView1.Columns[3].Width = 40;
                    dataGridView1.Columns[4].HeaderText = "N квартиры";
                    dataGridView1.Columns[4].Width = 40;
                    dataGridView1.Columns[5].HeaderText = "Площадь";
                    dataGridView1.Columns[5].Width = 60;
                    dataGridView1.Columns[6].HeaderText = "Прописано";
                    dataGridView1.Columns[6].Width = 65;
                    dataGridView1.Columns[7].HeaderText = "Счетчики";
                    dataGridView1.Columns[7].Width = 60;
                    dataGridView1.Columns[8].HeaderText = "Лифт";
                    dataGridView1.Columns[8].Width = 50;
                    dataGridView1.Columns[9].HeaderText = "Вахтер";
                    dataGridView1.Columns[9].Width = 60;
                    dataGridView1.Columns[10].HeaderText = "Телефон";
                    dataGridView1.Columns[10].Width = 60;
                    dataGridView1.Columns[11].HeaderText = "Газ";
                    dataGridView1.Columns[11].Width = 40;
                }
                catch (System.Exception ex)
                {
                    File.Delete("base.xml");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult2 == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
