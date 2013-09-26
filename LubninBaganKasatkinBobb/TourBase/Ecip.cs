using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TourBase
{
    public partial class Ecip : Form
    {
        List<Room_Cl> Rooms = new List<Room_Cl>();
        List<Ecip_Category> Equips = new List<Ecip_Category>();
        Color Col = Color.DarkOrange;

        public Ecip()
        {
            InitializeComponent();
        }

        private void Save_equip()
        {
            FileStream fs = new FileStream("Equipment_Base.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Equips.Count);
            for (int i = 0; i < Equips.Count; i++)
            {
                bw.Write(Equips[i].Name);
                bw.Write(Equips[i].Model.Count);
                for (int j = 0; j < Equips[i].Model.Count; j++)
                {
                    bw.Write(Equips[i].Model[j].Name);
                    bw.Write(Equips[i].Model[j].Size.Count);
                    for (int k = 0; k < Equips[i].Model[j].Size.Count; k++)
                    {
                        bw.Write(Equips[i].Model[j].Size[k].Name);
                        bw.Write(Equips[i].Model[j].Size[k].arend);
                        if (Equips[i].Model[j].Size[k].arend == true)
                        {
                            bw.Write(Equips[i].Model[j].Size[k].Room);
                            bw.Write(Equips[i].Model[j].Size[k].Time_from.Year);
                            bw.Write(Equips[i].Model[j].Size[k].Time_from.Month);
                            bw.Write(Equips[i].Model[j].Size[k].Time_from.Day);
                            bw.Write(Equips[i].Model[j].Size[k].Time_from.Hour);
                            bw.Write(Equips[i].Model[j].Size[k].Time_from.Minute);
                            bw.Write(Equips[i].Model[j].Size[k].Time_to.Year);
                            bw.Write(Equips[i].Model[j].Size[k].Time_to.Month);
                            bw.Write(Equips[i].Model[j].Size[k].Time_to.Day);
                            bw.Write(Equips[i].Model[j].Size[k].Time_to.Hour);
                            bw.Write(Equips[i].Model[j].Size[k].Time_to.Minute);
                        }
                    }
                }
            }
            bw.Close();
            fs.Close();
        }

        private void Edit_equip()
        {
            int edit_index = 0;
            for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
            {
                for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                {
                    if (edit_index == dataGridView1.CurrentRow.Index)
                    {
                        Equips[listBox1.SelectedIndex].Model[i].Size[j].arend = true;
                        Equips[listBox1.SelectedIndex].Model[i].Size[j].Room = Int32.Parse(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                        Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_from = new DateTime(dateTimePicker1.Value.Year,
                            dateTimePicker1.Value.Month,
                            dateTimePicker1.Value.Day,
                            dateTimePicker3.Value.Hour,
                            dateTimePicker3.Value.Minute, 0);
                        Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_to = new DateTime(dateTimePicker2.Value.Year,
                            dateTimePicker2.Value.Month,
                            dateTimePicker2.Value.Day,
                            dateTimePicker4.Value.Hour,
                            dateTimePicker4.Value.Minute, 0);

                        for (int k = 0; k < 5; k++)
                        {
                            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[k].Style.BackColor = Col;
                        }
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Room;
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_from.ToString("dd.MM.yyyy") + "  " +
                            Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_from.ToString("H:MM");
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_to.ToString("dd.MM.yyyy") + "  " +
                            Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_to.ToString("H:MM");
                        dataGridView1.ClearSelection();
                        Save_equip();
                        return;
                    }
                    edit_index++;
                }
            }
        }

        private void Del_equip()
        {
            int del_index = 0;
            for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
            {
                for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                {
                    if (del_index == dataGridView1.CurrentRow.Index)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[k].Style.BackColor = Color.White;
                        }
                        Equips[listBox1.SelectedIndex].Model[i].Size[j].arend = false;
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value = "";
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = "";
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value = "";
                        dataGridView1.ClearSelection();
                        Save_equip();
                        return;
                    }
                    del_index++;
                }
            }
        }

        private void Load_rooms()
        {
            if (File.Exists("Rooms_Base.bin"))
            {
                FileStream fs = new FileStream("Rooms_Base.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                Rooms.Clear();

                int kol = br.ReadInt32();
                for (int i = 0; i < kol; i++)
                {
                    Room_Cl New_room = new Room_Cl();
                    New_room.Number = br.ReadInt32();
                    New_room.Type = br.ReadString();
                    New_room.Places = br.ReadInt32();
                    New_room.Cost = br.ReadInt32();
                    Rooms.Add(New_room);
                    comboBox1.Items.Add(Rooms[i].Number);
                }
                comboBox1.SelectedIndex = -1;
                br.Close();
                fs.Close();
            }
        }

        private void Load_equip()
        {
            if (File.Exists("Equipment_Base.bin"))
            {
                FileStream fs = new FileStream("Equipment_Base.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                int Category_kol = br.ReadInt32();
                for (int i = 0; i < Category_kol; i++)
                {
                    Ecip_Category New_Category = new Ecip_Category();
                    New_Category.Name = br.ReadString();
                    int Models_kol = br.ReadInt32();
                    for (int j = 0; j < Models_kol; j++)
                    {
                        Ecip_Model New_Model = new Ecip_Model();
                        New_Model.Name = br.ReadString();
                        int Size_kol = br.ReadInt32();
                        for (int k = 0; k < Size_kol; k++)
                        {
                            Ecip_Size New_Size = new Ecip_Size();
                            New_Size.Name = br.ReadString();
                            New_Size.arend = br.ReadBoolean();
                            if (New_Size.arend)
                            {
                                New_Size.Room = br.ReadInt32();
                                DateTime New_from = new DateTime(br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), 0);
                                New_Size.Time_from = New_from;
                                DateTime New_to = new DateTime(br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), 0);
                                New_Size.Time_to = New_to;
                            }
                            New_Model.Size.Add(New_Size);
                        }
                        New_Category.Model.Add(New_Model);
                    }
                    Equips.Add(New_Category);
                    listBox1.Items.Add(Equips[i].Name);
                }
                br.Close();
                fs.Close();
                listBox1.ClearSelected();
            }
        }

        private void Ecip_Load(object sender, EventArgs e)
        {
            Load_rooms();
            Load_equip();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows.Clear();
                int kol = 0;
                for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
                {
                    for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                    {
                        kol++;
                    }
                }
                dataGridView1.RowCount = kol;
                dataGridView1.ClearSelection();
                int ri = 0;
                for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
                {
                    for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                    {
                        dataGridView1.Rows[ri].Cells[0].Value = Equips[listBox1.SelectedIndex].Model[i].Name;
                        dataGridView1.Rows[ri].Cells[1].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Name;
                        if (Equips[listBox1.SelectedIndex].Model[i].Size[j].arend)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                dataGridView1.Rows[ri].Cells[k].Style.BackColor = Col;
                            }
                            dataGridView1.Rows[ri].Cells[2].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Room;
                            dataGridView1.Rows[ri].Cells[3].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_from.ToString("dd.MM.yyyy") + "  " +
                                Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_from.ToString("H:mm");
                            dataGridView1.Rows[ri].Cells[4].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_to.ToString("dd.MM.yyyy") + "  " +
                                Equips[listBox1.SelectedIndex].Model[i].Size[j].Time_to.ToString("H:mm");
                        }
                        else
                        {
                            dataGridView1.Rows[ri].Cells[2].Value = "";
                            dataGridView1.Rows[ri].Cells[2].Value = "";
                            dataGridView1.Rows[ri].Cells[2].Value = "";
                        }
                        ri++;
                    }
                }
            }
            else
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = 0;
                groupBox4.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Selected)
            {
                if (dataGridView1.CurrentRow.Cells[0].Style.BackColor == Col)
                {
                    groupBox4.Enabled = false;
                    button1.Enabled = true;
                }
                else
                {
                    groupBox4.Enabled = true;
                    button1.Enabled = false;
                }
            }
            else
            {
                groupBox4.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                Edit_equip();
            }
            else
            {
                MessageBox.Show("Выберите комнату!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Del_equip();
        }

        private void Ecip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
