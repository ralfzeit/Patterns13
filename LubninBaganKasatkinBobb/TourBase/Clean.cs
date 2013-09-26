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
    public partial class Clean : Form
    {
        List<Clean_Cl> Graph = new List<Clean_Cl>();

        private void Load_rooms()
        {
            if (File.Exists("Rooms_Base.bin"))
            {
                FileStream fs = new FileStream("Rooms_Base.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                Graph.Clear();

                int kol = br.ReadInt32();
                Room_Cl New_room = new Room_Cl();
                for (int i = 0; i < kol; i++)
                {
                    New_room.Number = br.ReadInt32();
                    New_room.Type = br.ReadString();
                    New_room.Places = br.ReadInt32();
                    New_room.Cost = br.ReadInt32();
                    comboBox1.Items.Add(New_room.Number);
                    comboBox2.Items.Add(New_room.Number);
                }
                br.Close();
                fs.Close();
            }
        }

        private void Save_Graph()
        {
            FileStream fs = new FileStream("Rooms_Clean.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Graph.Count);
            for (int i = 0; i < Graph.Count; i++)
            {
                bw.Write(Graph[i].date.Year);
                bw.Write(Graph[i].date.Month);
                bw.Write(Graph[i].date.Day);
                bw.Write(Graph[i].rooms.Count);
                for (int j = 0; j < Graph[i].rooms.Count; j++)
                {
                    bw.Write(Graph[i].rooms[j]);
                }
            }
            bw.Close();
            fs.Close();
        }

        private void Load_Graph()
        {
            if (File.Exists("Rooms_Clean.bin"))
            {
                FileStream fs = new FileStream("Rooms_Clean.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                Graph.Clear();

                int kol = br.ReadInt32();
                for (int i = 0; i < kol; i++)
                {
                    Clean_Cl New_Cl = new Clean_Cl();
                    DateTime New_dt = new DateTime(br.ReadInt32(),br.ReadInt32(),br.ReadInt32());
                    New_Cl.date = New_dt;
                    int kol2 = br.ReadInt32();
                    for (int j = 0; j < kol2; j++)
                    {
                        New_Cl.rooms.Add(br.ReadInt32());
                    }
                    Graph.Add(New_Cl);
                }
                br.Close();
                fs.Close();
            }
        }

        public Clean()
        {
            InitializeComponent();
        }

        private void Refresh_Rooms()
        {
            listBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
            for (int i = 0; i < Graph.Count; i++)
            {
                if (Graph[i].date == monthCalendar1.SelectionStart.Date)
                {
                    for (int j = 0; j < Graph[i].rooms.Count; j++)
                    {
                        listBox1.Items.Add(Graph[i].rooms[j]);
                    }
                    break;
                }
            }
        }

        private void Clean_Load(object sender, EventArgs e)
        {
            Load_rooms();
            Load_Graph();
            Refresh_Rooms();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                int index = -1;
                for (int i = 0; i < Graph.Count; i++)
                {
                    if (Graph[i].date == monthCalendar1.SelectionStart.Date)
                    {
                        index = i;
                        break;
                    }
                }

                if (index >= 0)
                {
                    bool fl = true;
                    for (int i = 0; i < Graph[index].rooms.Count; i++)
                    {
                        if (Graph[index].rooms[i] == Int32.Parse(comboBox1.SelectedItem.ToString()))
                        {
                            MessageBox.Show("Этот номер уже\nесть в графике!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fl = false;
                            break;
                        }
                    }
                    if (fl)
                    {
                        Graph[index].rooms.Add(Int32.Parse(comboBox1.SelectedItem.ToString()));
                        Graph[index].rooms.Sort(delegate(int s1, int s2)
                        { return s1.CompareTo(s2); });
                        listBox1.Items.Clear();
                        for (int i = 0; i < Graph[index].rooms.Count; i++)
                        {
                            listBox1.Items.Add(Graph[index].rooms[i]);
                        }
                        Save_Graph();
                        MessageBox.Show("Комната успешно \nдобавлена в график", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    Clean_Cl New_Cl = new Clean_Cl();
                    New_Cl.date = monthCalendar1.SelectionStart.Date;
                    New_Cl.rooms.Add(Int32.Parse(comboBox1.SelectedItem.ToString()));
                    Graph.Add(New_Cl);
                    Graph.Sort(delegate(Clean_Cl cc1, Clean_Cl cc2)
                    { return cc1.date.CompareTo(cc2.date); });
                    listBox1.Items.Add(New_Cl.rooms[0].ToString());
                    Save_Graph();
                    MessageBox.Show("Комната успешно \nдобавлена в график", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Refresh_Rooms();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                button2.Enabled = true;
            }
            else
                button2.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                button3.Enabled = true;
            }
            else
                button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                MessageBox.Show("Комната будет убрана\nв ближайшее время", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox2.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Выберите комнату!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите\nудалить запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = listBox1.SelectedIndex;
                for (int i = 0; i < Graph.Count; i++)
                {
                    if (Graph[i].date == monthCalendar1.SelectionStart.Date)
                    {
                        listBox1.Items.RemoveAt(index);
                        Graph[i].rooms.RemoveAt(index);
                        if (Graph[i].rooms.Count == 0)
                        {
                            Graph.RemoveAt(i);
                        }
                        Save_Graph();
                        break;
                    }
                }
            }
        }

        private void Clean_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
