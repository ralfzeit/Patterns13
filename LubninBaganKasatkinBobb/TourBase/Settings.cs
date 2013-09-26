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
    public partial class Settings : Form
    {
        List<Room_Cl> Rooms = new List<Room_Cl>();
        List<Ecip_Category> Equips = new List<Ecip_Category>();

        public Settings()
        {
            InitializeComponent();
        }

        private void Save_rooms()
        {
            FileStream fs = new FileStream("Rooms_Base.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Rooms.Count);
            for (int i = 0; i < Rooms.Count; i++)
            {
                bw.Write(Rooms[i].Number);
                bw.Write(Rooms[i].Type);
                bw.Write(Rooms[i].Places);
                bw.Write(Rooms[i].Cost);
            }
            bw.Close();
            fs.Close();
        }

        private void Refresh_Table()
        {
            dataGridView1.ClearSelection();
            dataGridView1.RowCount = Rooms.Count;
            for (int i = 0; i < Rooms.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = Rooms[i].Number;
                dataGridView1.Rows[i].Cells[1].Value = Rooms[i].Type;
                dataGridView1.Rows[i].Cells[2].Value = Rooms[i].Places;
                dataGridView1.Rows[i].Cells[3].Value = Rooms[i].Cost;
            }
            dataGridView1.ClearSelection();
        }

        private void Load_rooms()
        {
            if (File.Exists("Rooms_Base.bin"))
            {
                FileStream fs = new FileStream("Rooms_Base.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                Rooms.Clear();
                dataGridView1.ClearSelection();
                dataGridView1.Rows.Clear();

                int kol = br.ReadInt32();
                dataGridView1.RowCount = kol;
                for (int i = 0; i < kol; i++)
                {
                    Room_Cl New_room = new Room_Cl();
                    New_room.Number = br.ReadInt32();
                    New_room.Type = br.ReadString();
                    New_room.Places = br.ReadInt32();
                    New_room.Cost = br.ReadInt32();
                    Rooms.Add(New_room);
                    dataGridView1.Rows[i].Cells[0].Value = Rooms[i].Number;
                    dataGridView1.Rows[i].Cells[1].Value = Rooms[i].Type;
                    dataGridView1.Rows[i].Cells[2].Value = Rooms[i].Places;
                    dataGridView1.Rows[i].Cells[3].Value = Rooms[i].Cost;
                }
                dataGridView1.ClearSelection();
                br.Close();
                fs.Close();
            }
        }

        private void Refresh_Equip()
        {
            dataGridView2.ClearSelection();
            dataGridView2.Rows.Clear();
            dataGridView2.RowCount = 0;

            listBox1.Items.Clear();
            for (int i = 0; i < Equips.Count; i++)
            {
                listBox1.Items.Add(Equips[i].Name);
            }
            listBox1.ClearSelected();
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

        private void Ec_Add(Ecip_Category New_Cat)
        {
            bool f1 = true;
            for (int i = 0; i < Equips.Count; i++)
            {
                if (Equips[i].Name == New_Cat.Name)
                {
                    f1 = false;
                    bool f2 = true;
                    for (int j = 0; j < Equips[i].Model.Count; j++)
                    {
                        if (Equips[i].Model[j].Name == New_Cat.Model[0].Name)
                        {
                            f2 = false;
                            Equips[i].Model[j].Size.Add(New_Cat.Model[0].Size[0]);
                            Equips[i].Model[j].Size.Sort(delegate(Ecip_Size s1, Ecip_Size s2)
                            { return s1.Name.CompareTo(s2.Name); });
                            break;
                        }
                    }
                    if (f2)
                    {
                        Equips[i].Model.Add(New_Cat.Model[0]);
                        Equips[i].Model.Sort(delegate(Ecip_Model m1, Ecip_Model m2)
                        { return m1.Name.CompareTo(m2.Name); });
                    }
                    break;
                }
            }
            if (f1)
            {
                Equips.Add(New_Cat);
                Equips.Sort(delegate(Ecip_Category c1, Ecip_Category c2)
                { return c1.Name.CompareTo(c2.Name); });
            }
            Save_equip();
            Refresh_Equip();
        }

        private void Ec_Del()
        {
            for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
            {
                if (Equips[listBox1.SelectedIndex].Model[i].Name == dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString())
                {
                    for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                    {
                        if (Equips[listBox1.SelectedIndex].Model[i].Size[j].Name == dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString())
                        {
                            Equips[listBox1.SelectedIndex].Model[i].Size.RemoveAt(j);
                            break;
                        }
                    }
                    if (Equips[listBox1.SelectedIndex].Model[i].Size.Count == 0)
                    {
                        Equips[listBox1.SelectedIndex].Model.RemoveAt(i);
                        break;
                    }
                }
            }
            if (Equips[listBox1.SelectedIndex].Model.Count == 0)
            {
                Equips.RemoveAt(listBox1.SelectedIndex);
            }
            Save_equip();
            Refresh_Equip();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Load_rooms();
            Load_equip();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Add_Room Add_window = new Add_Room(Rooms);
            Add_window.Owner = this;
            dr = Add_window.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Rooms.Add(Add_window.New_room);
                Rooms.Sort(delegate(Room_Cl r1, Room_Cl r2)
                { return r1.Number.CompareTo(r2.Number); });
                Save_rooms();
                Refresh_Table();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Edit_Room Edit_window = new Edit_Room(Rooms[dataGridView1.CurrentRow.Index]);
            Edit_window.Owner = this;
            dr = Edit_window.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Rooms[dataGridView1.CurrentRow.Index] = Edit_window.New_room;
                Save_rooms();
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value = Rooms[dataGridView1.CurrentRow.Index].Type;
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value = Rooms[dataGridView1.CurrentRow.Index].Places;
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = Rooms[dataGridView1.CurrentRow.Index].Cost;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите\nудалить комнату?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentRow.Index;
                dataGridView1.ClearSelection();
                Rooms.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
                dataGridView1.ClearSelection();
                Save_rooms();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Add_Ecip Add_window = new Add_Ecip(Equips);
            Add_window.Owner = this;
            dr = Add_window.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Ec_Add(Add_window.New_Cat);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                dataGridView2.ClearSelection();
                dataGridView2.Rows.Clear();
                int kol = 0;
                for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
                {
                    for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                    {
                        kol++;
                    }
                }
                dataGridView2.RowCount = kol;
                int ri = 0;
                for (int i = 0; i < Equips[listBox1.SelectedIndex].Model.Count; i++)
                {
                    for (int j = 0; j < Equips[listBox1.SelectedIndex].Model[i].Size.Count; j++)
                    {
                        dataGridView2.Rows[ri].Cells[0].Value = Equips[listBox1.SelectedIndex].Model[i].Name;
                        dataGridView2.Rows[ri].Cells[1].Value = Equips[listBox1.SelectedIndex].Model[i].Size[j].Name;
                        ri++;
                    }
                }
                dataGridView2.ClearSelection();
            }
            else
            {
                dataGridView2.ClearSelection();
                dataGridView2.Rows.Clear();
                dataGridView2.RowCount = 0;
                button5.Enabled = false;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Selected)
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите\nудалить экипировку?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Ec_Del();
            }
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        
    }
}