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
    public partial class Sauna : Form
    {
        List<Room_Cl> Rooms = new List<Room_Cl>();
        List<Sauna_Arend> Arend = new List<Sauna_Arend>();

        private void Load_rooms()
        {
            if (File.Exists("Rooms_Base.bin"))
            {
                FileStream fs = new FileStream("Rooms_Base.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                Rooms.Clear();
                dataGridView1.Rows.Clear();

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
                {
                    comboBox1.SelectedIndex = 0;
                    button3.Enabled = true;
                }
            }
        }

        private void Load_Arend()
        {
            if (File.Exists("Sauna_Arendators.bin"))
            {
                FileStream fs = new FileStream("Sauna_Arendators.bin", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                int kol = br.ReadInt32();
                for (int i = 0; i < kol; i++)
                {
                    Sauna_Arend New_Arend = new Sauna_Arend();
                    DateTime fr = new DateTime(
                        br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), 0);
                    New_Arend.Time_from = fr;
                    DateTime to = new DateTime(
                        br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), 0);
                    New_Arend.Time_to = to;
                    New_Arend.Number = br.ReadInt32();
                    Arend.Add(New_Arend);
                    
                }
                br.Close();
                fs.Close();
                Refresh_grid();
            }
        }

        private void Save_Arend()
        {
            FileStream fs = new FileStream("Sauna_Arendators.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Arend.Count);
            for (int i = 0; i < Arend.Count; i++)
            {
                bw.Write(Arend[i].Time_from.Year);
                bw.Write(Arend[i].Time_from.Month);
                bw.Write(Arend[i].Time_from.Day);
                bw.Write(Arend[i].Time_from.Hour);
                bw.Write(Arend[i].Time_from.Minute);
                bw.Write(Arend[i].Time_to.Year);
                bw.Write(Arend[i].Time_to.Month);
                bw.Write(Arend[i].Time_to.Day);
                bw.Write(Arend[i].Time_to.Hour);
                bw.Write(Arend[i].Time_to.Minute);
                bw.Write(Arend[i].Number);
            }
            bw.Close();
            fs.Close();
        }

        private void Refresh_grid()
        {
            dataGridView1.Rows.Clear();

            if (Arend.Count > 0)
            {
                dataGridView1.RowCount = Arend.Count;

                for (int i = 0; i < Arend.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Arend[i].Time_from.ToString("dd.MM.yyyy");
                    dataGridView1.Rows[i].Cells[1].Value = Arend[i].Time_from.ToString("H:mm");
                    dataGridView1.Rows[i].Cells[2].Value = Arend[i].Time_to.ToString("H:mm");
                    dataGridView1.Rows[i].Cells[3].Value = Arend[i].Number;
                }
                dataGridView1.ClearSelection();
            }
        }

        private void Add_Arend()
        {
            DateTime New_fr = new DateTime(dateTimePicker1.Value.Year,
                dateTimePicker1.Value.Month,
                dateTimePicker1.Value.Day,
                dateTimePicker2.Value.Hour,
                dateTimePicker2.Value.Minute, 0);
            DateTime New_to = new DateTime(dateTimePicker1.Value.Year,
                dateTimePicker1.Value.Month,
                dateTimePicker1.Value.Day,
                dateTimePicker3.Value.Hour,
                dateTimePicker3.Value.Minute, 0);

            bool flag = true;
            for (int i = 0; i < Arend.Count; i++)
            {
                if (!(New_to < Arend[i].Time_from ||
                    New_fr > Arend[i].Time_to))
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Sauna_Arend New_Arend = new Sauna_Arend();
                New_Arend.Number = Int32.Parse(comboBox1.SelectedItem.ToString());
                New_Arend.Time_from = New_fr;
                New_Arend.Time_to = New_to;
                Arend.Add(New_Arend);
                Arend.Sort(delegate(Sauna_Arend s1, Sauna_Arend s2)
                { return s1.Time_from.CompareTo(s2.Time_from); });
                Refresh_grid();
                Save_Arend();
                MessageBox.Show("Новая запись\nуспешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Это время уже\nзанято!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Sauna()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Arend();

        }

        private void Sauna_Load(object sender, EventArgs e)
        {
            Load_rooms();
            Load_Arend();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate = dateTimePicker2.Value;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentCell.Selected)
                    button1.Enabled = true;
                else
                    button1.Enabled = false;
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
                int index = dataGridView1.CurrentRow.Index;
                Arend.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
                dataGridView1.ClearSelection();
                Save_Arend();
            }
        }

        private void Sauna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
