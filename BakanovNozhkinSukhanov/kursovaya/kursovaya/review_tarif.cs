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
    public partial class review_tarif : Form
    {
        public review_tarif()
        {
            InitializeComponent();
        }

        RT tariflist = new RT();

        private void review_tarif_Load(object sender, EventArgs e)
        {
            ClearDGV();
        }

        private void ClearDGV()
        {
            dataGridView1.Rows.Clear();

            if (File.Exists("tarif.xml"))
            {
                try
                {
                    tariflist.LoadList("tarif.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("tarif.xml");
                }

                if (tariflist.coun() != 0)
                {

                    tarif ntarif = new tarif();
                    double summ = 0;
                    for (int i = 0; i < tariflist.coun(); i++)
                    {
                        ntarif = tariflist.ReturnMyClass(i);
                        dataGridView1.Rows.Add(ntarif.tname, ntarif.status, ntarif.day, ntarif.week, ntarif.month, ntarif.three_months, ntarif.six_months);
                    }
                }
            }
        }

        private void check_status()
        {
            if (File.Exists("tarif.xml"))
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

                for (int i = 0; i < tariflist.coun(); i++)
                {
                    obj = tariflist.ReturnMyClass(i);
                    if (obj.status == "Активный")
                        obj.status = "Неактивный";
                }
            }
        }

        private bool check_status2()
        {
            if (File.Exists("tarif.xml"))
            {
                int flag = 0;
                try
                {
                    tariflist.LoadList("tarif.xml");
                }
                catch (System.Exception ex)
                {
                    File.Delete("tarif.xml");
                }

                tarif obj = new tarif();

                for (int i = 0; i < tariflist.coun(); i++)
                {
                    obj = tariflist.ReturnMyClass(i);
                    if (obj.status == "Активный")
                        flag = 1;
                }
                if (flag == 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_tarif adtarif = new add_tarif();
            adtarif.ShowDialog();
            ClearDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("Нет данных для удаления! Сначала добавте информацию, для её последующего удаления :)", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataGridView1.RowCount == 1)
                {
                    DialogResult dialogResult1 = MessageBox.Show("Должен остаться хотя бы один тариф!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эти данные из базы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            tariflist.LoadList("tarif.xml");
                        }
                        catch (System.Exception ex)
                        {
                            File.Delete("tarif.xml");
                        }

                        string temp1;
                        temp1 = Convert.ToString(dataGridView1.SelectedCells[0].Value);
                        tariflist.RemoveMyClass(temp1);
                        tariflist.SaveList("tarif.xml");
                        ClearDGV();
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Активировать выбранный тариф?", "Активация тарифа", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
                string tmp1;
                tmp1 = Convert.ToString(dataGridView1.SelectedCells[0].Value);
                obj = tariflist.FindCLass(tmp1);
                check_status();
                obj.status = "Активный";

                tariflist.RemoveMyClass(tmp1);
                tariflist.AddMyClass(obj);
                tariflist.SaveList("tarif.xml");
                ClearDGV();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tmp1;
            tmp1 = Convert.ToString(dataGridView1.SelectedCells[0].Value);

            edit_tarif etarif = new edit_tarif(tmp1);
            etarif.ShowDialog();
            ClearDGV();
        }
    }
}
