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
    public partial class Room : Form
    {
        List<Room_Cl> Rooms = new List<Room_Cl>();
        List<Arendator_Cl> Arendators = new List<Arendator_Cl>();
        List<Arendator_Cl> Arend_Table = new List<Arendator_Cl>();

        public Room()
        {
            InitializeComponent();
        }

        private int Search_Table(Arendator_Cl Srh)
        {
            for (int i = 0; i < Arendators.Count; i++)
            {
                if (Arendators[i].Number == Srh.Number)
                {
                    if (Arendators[i].Name == Srh.Name)
                    {
                        if (Arendators[i].Phone == Srh.Phone)
                        {
                            if (Arendators[i].Time_from == Srh.Time_from)
                            {
                                if (Arendators[i].Time_to == Srh.Time_to)
                                {
                                    return i;
                                }
                            }
                        }
                    }
                }
            }
            return -1;
        }
        

        private void Load_Arendators()
        {
            if (File.Exists("Room_Arendators.bin"))
            {
                FileStream fs = new FileStream("Room_Arendators.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                int kol = br.ReadInt32();
                for (int i = 0; i < kol; i++)
                {
                    Arendator_Cl New_Arend = new Arendator_Cl();
                    New_Arend.Number = br.ReadInt32();
                    DateTime fr = new DateTime(
                        br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), 0);
                    New_Arend.Time_from = fr;
                    DateTime to = new DateTime(
                        br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), 0);
                    New_Arend.Time_to = to;
                    New_Arend.Name = br.ReadString();
                    New_Arend.Phone = br.ReadString();
                    Arendators.Add(New_Arend);
                }
                br.Close();
                fs.Close();
            }
        }

        private void Save_Arendators()
        {
            FileStream fs = new FileStream("Room_Arendators.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Arendators.Count);
            for (int i = 0; i < Arendators.Count; i++)
            {
                bw.Write(Arendators[i].Number);
                bw.Write(Arendators[i].Time_from.Year);
                bw.Write(Arendators[i].Time_from.Month);
                bw.Write(Arendators[i].Time_from.Day);
                bw.Write(Arendators[i].Time_from.Hour);
                bw.Write(Arendators[i].Time_from.Minute);
                bw.Write(Arendators[i].Time_to.Year);
                bw.Write(Arendators[i].Time_to.Month);
                bw.Write(Arendators[i].Time_to.Day);
                bw.Write(Arendators[i].Time_to.Hour);
                bw.Write(Arendators[i].Time_to.Minute);
                bw.Write(Arendators[i].Name);
                bw.Write(Arendators[i].Phone);
            }
            bw.Close();
            fs.Close();
        }

        private void Load_rooms()
        {
            if (File.Exists("Rooms_Base.bin"))
            {
                FileStream fs = new FileStream("Rooms_Base.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                
                Rooms.Clear();
                dataGridView1.Rows.Clear();

                Load_Arendators();

                int kol = br.ReadInt32();
                for (int i = 0; i < kol; i++)
                {
                    Room_Cl New_room = new Room_Cl();
                    New_room.Number = br.ReadInt32();
                    New_room.Type = br.ReadString();
                    New_room.Places = br.ReadInt32();
                    New_room.Cost = br.ReadInt32();
                    Rooms.Add(New_room);
                    comboBox1.Items.Add(New_room.Number);
                }
                br.Close();
                fs.Close();

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
        }

        private void Refresh_grid()
        {
            Arend_Table.Clear();
            dataGridView1.ClearSelection();
            dataGridView1.Rows.Clear();

            if (comboBox1.SelectedIndex >= 0)
            {
                label1.Text = Rooms[comboBox1.SelectedIndex].Type;
                label5.Text = Rooms[comboBox1.SelectedIndex].Places.ToString();
                label7.Text = Rooms[comboBox1.SelectedIndex].Cost.ToString();
                for (int i = 0; i < Arendators.Count; i++)
                {
                    if (Arendators[i].Number.ToString() == comboBox1.SelectedItem.ToString())
                    {
                        Arendator_Cl New_table = new Arendator_Cl();
                        New_table.Number = Arendators[i].Number;
                        New_table.Time_from = Arendators[i].Time_from;
                        New_table.Time_to = Arendators[i].Time_to;
                        New_table.Name = Arendators[i].Name;
                        New_table.Phone = Arendators[i].Phone;
                        Arend_Table.Add(New_table);
                    }
                }

                if (Arend_Table.Count > 0)
                {
                    dataGridView1.RowCount = Arend_Table.Count;
                    for (int i = 0; i < Arend_Table.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = Arend_Table[i].Time_from.ToString("dd.MM.yyyy") + "  " +
                        Arend_Table[i].Time_from.ToString("H:mm");
                        dataGridView1.Rows[i].Cells[1].Value = Arend_Table[i].Time_to.ToString("dd.MM.yyyy") + "  " +
                            Arend_Table[i].Time_to.ToString("H:mm");
                        dataGridView1.Rows[i].Cells[2].Value = Arend_Table[i].Name;
                        dataGridView1.Rows[i].Cells[3].Value = Arend_Table[i].Phone;
                    }
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                    button1.Enabled = true;
                }
                else
                {
                    dataGridView1.RowCount = 0;
                    button1.Enabled = false;
                }
            }
            else
            {
                dataGridView1.RowCount = 0;
                label1.Text = "(неизвестно)";
                label5.Text = "(0)";
                label7.Text = "(0)";
            }
        }

        private void Add_Arend()
        {
            DateTime New_fr = new DateTime(dateTimePicker1.Value.Year,
                dateTimePicker1.Value.Month,
                dateTimePicker1.Value.Day,
                dateTimePicker3.Value.Hour,
                dateTimePicker3.Value.Minute, 0);
            DateTime New_to = new DateTime(dateTimePicker2.Value.Year,
                dateTimePicker2.Value.Month,
                dateTimePicker2.Value.Day,
                dateTimePicker4.Value.Hour,
                dateTimePicker4.Value.Minute, 0);
            
            bool flag = true;
            for (int i = 0; i < Arend_Table.Count; i++)
            {
                if (!(New_to < Arend_Table[i].Time_from ||
                    New_fr > Arend_Table[i].Time_to))
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Arendator_Cl New_Arend = new Arendator_Cl();
                New_Arend.Number = Int32.Parse(comboBox1.SelectedItem.ToString());
                New_Arend.Time_from = New_fr;
                New_Arend.Time_to = New_to;
                New_Arend.Name = textBox2.Text;
                New_Arend.Phone = textBox1.Text;
                Arendators.Add(New_Arend);
                Refresh_grid();
                Save_Arendators();
                MessageBox.Show("Новая бронь\nуспешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Это время уже\nзанято!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Room_Load(object sender, EventArgs e)
        {
            Load_rooms();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                button3.Enabled = true;
                Refresh_grid();
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Add_Arend();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите\nудалить бронь?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(index);
                Arendators.RemoveAt(Search_Table(Arend_Table[index]));
                Arend_Table.RemoveAt(index);
                Save_Arendators();
                

                if (Arend_Table.Count == 0)
                    button1.Enabled = false;
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate=dateTimePicker1.Value;
        }

        private void Room_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
