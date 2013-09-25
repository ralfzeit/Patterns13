using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace kursovaya
{
    public partial class MainForm_admin : Form
    {
        Form1 oi = new Form1();
        private string PLogin;
        private string PPass;
        RA adminlist = new RA();
        RB boxlist = new RB();
        RT tariflist = new RT();
        RORDER orderlist = new RORDER();
        RM cashlist = new RM();

        public delegate void DelegateForTime(Label label14);
        DelegateForTime DelTime;
        Thread t1;

        public MainForm_admin(string s1, string s2)
        {
            PLogin = s1;
            PPass = s2;
            InitializeComponent();
            DelTime = new DelegateForTime(StartTime);
        }

        void StartTime(Label label14)
        {
            string s = DateTime.Now.Hour.ToString("00");
            s += " : ";
            s += DateTime.Now.Minute.ToString("00");

            s += " : " + DateTime.Now.Second.ToString("00");
            label14.Text = s;           
        }

        void LabelTime()
        {
            try
            {
                while (true)
                {
                    Invoke(DelTime, label14);
                }
            }
            catch (System.Exception ex)
            {
                Close();
            }
        } 

        private void MainForm_admin_Load(object sender, EventArgs e)
        {
            this.label15.Text = this.monthCalendar1.SelectionRange.Start.ToShortDateString();
            t1 = new Thread(LabelTime); // создаем поток  
            t1.IsBackground = true; // задаем фоновый режым  
            t1.Priority = ThreadPriority.Lowest; // указываем свмый низкий приоритет
            t1.Start(); // стартуем 

            this.Text = "Автомобильная стоянка - " + PLogin;
            if (radioButton1.Checked == true)
            {
                iRefreshForm(0);
            }
            if (radioButton2.Checked == true)
            {
                iRefreshForm(12);
            }
            if (radioButton3.Checked == true)
            {
                iRefreshForm(24);
            }
        }

        private void добавитьАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_admin add_a = new add_admin();
            add_a.ShowDialog();
        }

        private void MainForm_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.timer1.Enabled = false;
            this.Visible = false;
            this.oi.ShowDialog();
        }

        private void редактироватьАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("admin.xml"))
            {
                try
                {
                    adminlist.LoadList("admin.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }
                if (adminlist.coun() == 0)
                {
                    DialogResult dialogResult1 = MessageBox.Show("База данных пуста! ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editing_admin ea = new editing_admin();
                    ea.ShowDialog();
                }
            }
        }

        private void удалитьАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("admin.xml"))
            {
                try
                {
                    adminlist.LoadList("admin.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }
                if (adminlist.coun() == 0)
                {
                    DialogResult dialogResult1 = MessageBox.Show("База данных пуста! ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    deleting_admin dela = new deleting_admin();
                    dela.ShowDialog();
                }
            }
        }

        private void списокАдминистраторовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                adminlist.LoadList("admin.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }

            admin obj = new admin();
            obj = adminlist.FindCLassLogin(PLogin);

            review_admin rw = new review_admin(obj.category);
            rw.ShowDialog();
        }

        private void добавитьОператораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_oper addoper = new add_oper();
            addoper.ShowDialog();
        }

        private void списокОператоровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                adminlist.LoadList("admin.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }

            admin obj = new admin();
            obj = adminlist.FindCLassLogin(PLogin);

            review_oper ro = new review_oper(obj.category);
            ro.ShowDialog();
        }

        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_client ac = new add_client();
            ac.ShowDialog();
        }

        private void списокКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            review_clients rewc = new review_clients();
            rewc.ShowDialog();
        }

        private void floor_1()
        {
            label2.Text = "A - 01";
            label3.Text = "A - 02";
            label4.Text = "A - 03";
            label5.Text = "A - 04";
            label6.Text = "A - 05";
            label7.Text = "A - 06";
            label8.Text = "A - 07";
            label9.Text = "A - 08";
            label10.Text = "A - 09";
            label11.Text = "A - 10";
            label12.Text = "A - 11";
            label13.Text = "A - 12";
            label1.Text = "Первый этаж";
        }

        private void floor_2()
        {
            label2.Text = "Б - 01";
            label3.Text = "Б - 02";
            label4.Text = "Б - 03";
            label5.Text = "Б - 04";
            label6.Text = "Б - 05";
            label7.Text = "Б - 06";
            label8.Text = "Б - 07";
            label9.Text = "Б - 08";
            label10.Text = "Б - 09";
            label11.Text = "Б - 10";
            label12.Text = "Б - 11";
            label13.Text = "Б - 12";
            label1.Text = "Второй этаж";
        }

        private void floor_3()
        {
            label2.Text = "В - 01";
            label3.Text = "В - 02";
            label4.Text = "В - 03";
            label5.Text = "В - 04";
            label6.Text = "В - 05";
            label7.Text = "В - 06";
            label8.Text = "В - 07";
            label9.Text = "В - 08";
            label10.Text = "В - 09";
            label11.Text = "В - 10";
            label12.Text = "В - 11";
            label13.Text = "В - 12";
            label1.Text = "Третий этаж";
        }

        private void CreateBoxes()
        {
            if (File.Exists("boxes.xml")) boxlist.LoadList("boxes.xml");
            boxes obj = new boxes();
            obj.n = 0;
            obj.box_number = "";
            obj.box_status = "свободен";
            obj.box_current_owner_login = "";

            for (int i = 0; i < 36; i++)
            {
                if (File.Exists("boxes.xml")) boxlist.LoadList("boxes.xml");
                if (i >= 0 && i < 12)
                {
                    obj.box_number = "А" + (i + 1).ToString();
                    obj.n = i;
                }
                if (i >= 12 && i < 24)
                {
                    obj.box_number = "Б" + (i - 12 + 1).ToString();
                    obj.n = i;
                }
                if (i >= 24 && i < 36)
                {
                    obj.box_number = "В" + (i - 24 + 1).ToString();
                    obj.n = i;
                }
                boxlist.AddMyClass(obj);
                boxlist.SaveList("boxes.xml");
            }
        }

        private void pictures(int i)
        {
            int h = i;
            string temp;
            boxlist.LoadList("boxes.xml");
            boxes obj = new boxes();
            //i
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label16.Text = "Свободен до";
                    label17.Text = tmpdate.ToShortDateString();
                    label18.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label16.Text = "";
                    label17.Text = "";
                    label18.Text = "";
                }
                this.pictureBox1.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label16.Text = "Занят до";
                label17.Text = tmpdate.ToShortDateString();
                label18.Text = tmpdate.ToLongTimeString();

                this.pictureBox1.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+1
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label21.Text = "Свободен до";
                    label20.Text = tmpdate.ToShortDateString();
                    label19.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label21.Text = "";
                    label20.Text = "";
                    label19.Text = "";
                }
                this.pictureBox2.Image = global::kursovaya.Properties.Resources.free;
            }

            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label21.Text = "Занят до";
                label20.Text = tmpdate.ToShortDateString();
                label19.Text = tmpdate.ToLongTimeString();

                this.pictureBox2.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+2
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label24.Text = "Свободен до";
                    label23.Text = tmpdate.ToShortDateString();
                    label22.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label24.Text = "";
                    label23.Text = "";
                    label22.Text = "";
                }

                this.pictureBox3.Image = global::kursovaya.Properties.Resources.free;
            }

            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label24.Text = "Занят до";
                label23.Text = tmpdate.ToShortDateString();
                label22.Text = tmpdate.ToLongTimeString();

                this.pictureBox3.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+3
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label27.Text = "Свободен до";
                    label26.Text = tmpdate.ToShortDateString();
                    label25.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label27.Text = "";
                    label26.Text = "";
                    label25.Text = "";
                }

                this.pictureBox4.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label27.Text = "Занят до";
                label26.Text = tmpdate.ToShortDateString();
                label25.Text = tmpdate.ToLongTimeString();
                
                this.pictureBox4.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+4
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label30.Text = "Свободен до";
                    label29.Text = tmpdate.ToShortDateString();
                    label28.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label30.Text = "";
                    label29.Text = "";
                    label28.Text = "";
                }

                this.pictureBox5.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label30.Text = "Занят до";
                label29.Text = tmpdate.ToShortDateString();
                label28.Text = tmpdate.ToLongTimeString();

                this.pictureBox5.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+5
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label33.Text = "Свободен до";
                    label32.Text = tmpdate.ToShortDateString();
                    label31.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label33.Text = "";
                    label32.Text = "";
                    label31.Text = "";
                }

                this.pictureBox6.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label33.Text = "Занят до";
                label32.Text = tmpdate.ToShortDateString();
                label31.Text = tmpdate.ToLongTimeString();

                this.pictureBox6.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+6
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label36.Text = "Свободен до";
                    label35.Text = tmpdate.ToShortDateString();
                    label34.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label36.Text = "";
                    label35.Text = "";
                    label34.Text = "";
                }

                this.pictureBox7.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label36.Text = "Занят до";
                label35.Text = tmpdate.ToShortDateString();
                label34.Text = tmpdate.ToLongTimeString();

                this.pictureBox7.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+7
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label39.Text = "Свободен до";
                    label38.Text = tmpdate.ToShortDateString();
                    label37.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label39.Text = "";
                    label38.Text = "";
                    label37.Text = "";
                }

                this.pictureBox8.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label39.Text = "Занят до";
                label38.Text = tmpdate.ToShortDateString();
                label37.Text = tmpdate.ToLongTimeString();

                this.pictureBox8.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+8
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label42.Text = "Свободен до";
                    label41.Text = tmpdate.ToShortDateString();
                    label40.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label42.Text = "";
                    label41.Text = "";
                    label40.Text = "";
                }

                this.pictureBox9.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label42.Text = "Занят до";
                label41.Text = tmpdate.ToShortDateString();
                label40.Text = tmpdate.ToLongTimeString();

                this.pictureBox9.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+9
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label45.Text = "Свободен до";
                    label44.Text = tmpdate.ToShortDateString();
                    label43.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label45.Text = "";
                    label44.Text = "";
                    label43.Text = "";
                }

                this.pictureBox10.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label45.Text = "Занят до";
                label44.Text = tmpdate.ToShortDateString();
                label43.Text = tmpdate.ToLongTimeString();

                this.pictureBox10.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+10
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label48.Text = "Свободен до";
                    label47.Text = tmpdate.ToShortDateString();
                    label46.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label48.Text = "";
                    label47.Text = "";
                    label46.Text = "";
                }

                this.pictureBox11.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label48.Text = "Занят до";
                label47.Text = tmpdate.ToShortDateString();
                label46.Text = tmpdate.ToLongTimeString();

                this.pictureBox11.Image = global::kursovaya.Properties.Resources.busy;
            }
            h++;
            //i+11
            obj = boxlist.ReturnMyClass(h);
            temp = obj.box_status;
            if (temp == "свободен")
            {
                if (proverka_future_busy(h))
                {
                    DateTime tmpdate;
                    tmpdate = return_start_time(h);
                    label51.Text = "Свободен до";
                    label50.Text = tmpdate.ToShortDateString();
                    label49.Text = tmpdate.ToLongTimeString();
                }
                else
                {
                    label51.Text = "";
                    label50.Text = "";
                    label49.Text = "";
                }

                this.pictureBox12.Image = global::kursovaya.Properties.Resources.free;
            }
            if (temp == "занят")
            {
                DateTime tmpdate;
                tmpdate = return_end_time(h);
                label51.Text = "Занят до";
                label50.Text = tmpdate.ToShortDateString();
                label49.Text = tmpdate.ToLongTimeString();

                this.pictureBox12.Image = global::kursovaya.Properties.Resources.busy;
            }
        }

        private void iRefreshForm(int o)
        {
            int tyyy = o;
            if (File.Exists("boxes.xml"))
            {
                pictures(tyyy);
            }
            else
            {
                CreateBoxes();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                floor_1();
                iRefreshForm(0);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                floor_2();
                iRefreshForm(12);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                floor_3();
                iRefreshForm(24);
            }
        }

        private void этажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void второйЭтажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void третийЭтажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (radioButton1.Checked == true)
                this.этажToolStripMenuItem.Checked = true;
            else
                this.этажToolStripMenuItem.Checked = false;

            if (radioButton2.Checked == true)
                this.второйЭтажToolStripMenuItem.Checked = true;
            else
                this.второйЭтажToolStripMenuItem.Checked = false;

            if (radioButton3.Checked == true)
                this.третийЭтажToolStripMenuItem.Checked = true;
            else
                this.третийЭтажToolStripMenuItem.Checked = false;
        }

        private void pbclick(string str1, string str2, string str3)
        {
            if (File.Exists("boxes.xml"))
            {
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                string tmpboxname;
                int tmpnum;

                if (radioButton1.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str1);
                    tmpboxname = box.box_number;
                    tmpnum = box.n;

                    if (box.box_status == "свободен")
                    {
                        info_box infobox = new info_box(tmpboxname, 1);
                        infobox.ShowDialog();
                        scarlett_johansson();
                        iRefreshForm(0);
                    }
                    else
                    {
                        info_box infobox = new info_box(tmpboxname, 0);
                        infobox.ShowDialog();
                        iRefreshForm(0);
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str2);
                    tmpboxname = box.box_number;
                    tmpnum = box.n;

                    if (box.box_status == "свободен")
                    {
                        info_box infobox = new info_box(tmpboxname, 1);
                        infobox.ShowDialog();
                        scarlett_johansson();
                        iRefreshForm(12);
                    }
                    else
                    {
                        info_box infobox = new info_box(tmpboxname,0);
                        infobox.ShowDialog();
                        iRefreshForm(12);
                    }
                }
                else if (radioButton3.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str3);
                    tmpboxname = box.box_number;
                    tmpnum = box.n;

                    if (box.box_status == "свободен")
                    {
                        info_box infobox = new info_box(tmpboxname, 1);
                        infobox.ShowDialog();
                        scarlett_johansson();
                        iRefreshForm(24);
                    }
                    else
                    {
                        info_box infobox = new info_box(tmpboxname,0);
                        infobox.ShowDialog();
                        iRefreshForm(24);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbclick("А1", "Б1", "В1");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pbclick("А2", "Б2", "В2");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pbclick("А3", "Б3", "В3");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pbclick("А4", "Б4", "В4");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pbclick("А5", "Б5", "В5");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pbclick("А6", "Б6", "В6");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pbclick("А7", "Б7", "В7");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pbclick("А8", "Б8", "В8");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pbclick("А9", "Б9", "В9");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pbclick("А10", "Б10", "В10");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pbclick("А11", "Б11", "В11");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pbclick("А12", "Б12", "В12");
        }

        private void striparendclick(string str1, string str2, string str3)
        {
            if (File.Exists("boxes.xml"))
            {
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                string tmpboxname;
                int tmpnum;

                if (radioButton1.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str1);
                    tmpboxname = box.box_number;
                    tmpnum = box.n;

                    info_box infobox = new info_box(tmpboxname, 1);
                    infobox.ShowDialog();
                    scarlett_johansson();
                    iRefreshForm(0);
                    
                }
                else if (radioButton2.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str2);
                    tmpboxname = box.box_number;
                    tmpnum = box.n;

                    info_box infobox = new info_box(tmpboxname, 1);
                    infobox.ShowDialog();
                    scarlett_johansson();
                    iRefreshForm(12);
                }
                else if (radioButton3.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str3);
                    tmpboxname = box.box_number;
                    tmpnum = box.n;

                    info_box infobox = new info_box(tmpboxname, 1);
                    infobox.ShowDialog();
                    scarlett_johansson();
                    iRefreshForm(24);
                }
            }
        }

        private void stripinfoclick(string str1, string str2, string str3)
        {
            if (File.Exists("boxes.xml"))
            {
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                string tmpboxname;

                if (radioButton1.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str1);
                    tmpboxname = box.box_number;

                    info_box infobox = new info_box(tmpboxname,0);
                    infobox.ShowDialog();
                    iRefreshForm(0);
                }
                else if (radioButton2.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str2);
                    tmpboxname = box.box_number;

                    info_box infobox = new info_box(tmpboxname,0);
                    infobox.ShowDialog();
                    iRefreshForm(12);
                }
                else if (radioButton3.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str3);
                    tmpboxname = box.box_number;

                    info_box infobox = new info_box(tmpboxname,0);
                    infobox.ShowDialog();
                    iRefreshForm(24); ;
                }
            }
        }

        private void stripchangeclick(string str1, string str2, string str3)
        {
            if (File.Exists("boxes.xml"))
            {
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                try
                {
                    orderlist.LoadList("orders.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                string tmpboxname;
                DateTime currr;
                currr = DateTime.Now;

                if (radioButton1.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str1);
                    tmpboxname = box.box_number;

                    ordering norder = new ordering();
                    int fl = 999;
                    for (int i = 0; i < orderlist.coun(); i++)
                    {
                        norder = orderlist.ReturnMyClass(i);
                        if (norder.boxname == tmpboxname)
                        {
                            if (currr >= norder.startdate && currr <= norder.enddate)
                                fl = i;
                        }
                    }

                    norder = orderlist.ReturnMyClass(fl);

                    edit_order edord = new edit_order(tmpboxname, norder.enddate);
                    edord.ShowDialog();
                    iRefreshForm(0);
                }
                else if (radioButton2.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str2);
                    tmpboxname = box.box_number;

                    ordering norder = new ordering();
                    int fl = 999;
                    for (int i = 0; i < orderlist.coun(); i++)
                    {
                        norder = orderlist.ReturnMyClass(i);
                        if (norder.boxname == tmpboxname)
                        {
                            if (currr >= norder.startdate && currr <= norder.enddate)
                                fl = i;
                        }
                    }

                    norder = orderlist.ReturnMyClass(fl);

                    edit_order edord = new edit_order(tmpboxname, norder.enddate);
                    edord.ShowDialog();
                    iRefreshForm(12);
                }
                else if (radioButton3.Checked == true)
                {
                    boxes box = new boxes();
                    box = boxlist.FindCLass(str3);
                    tmpboxname = box.box_number;

                    ordering norder = new ordering();
                    int fl = 999;
                    for (int i = 0; i < orderlist.coun(); i++)
                    {
                        norder = orderlist.ReturnMyClass(i);
                        if (norder.boxname == tmpboxname)
                        {
                            if (currr >= norder.startdate && currr <= norder.enddate)
                                fl = i;
                        }
                    }

                    norder = orderlist.ReturnMyClass(fl);

                    edit_order edord = new edit_order(tmpboxname, norder.enddate);
                    edord.ShowDialog();
                    iRefreshForm(24);
                }
            }
        }

        private void stripremoveclick(string str1, string str2, string str3)
        {
            if (File.Exists("boxes.xml"))
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эти данные из базы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        boxlist.LoadList("boxes.xml");
                    }
                    catch (System.Exception ex)
                    {
                        Close();
                    }

                    try
                    {
                        orderlist.LoadList("orders.xml");
                    }
                    catch (System.Exception ex)
                    {
                        Close();
                    }

                    string tmpboxname;
                    DateTime currr;
                    currr = DateTime.Now;

                    if (radioButton1.Checked == true)
                    {
                        boxes box = new boxes();
                        box = boxlist.FindCLass(str1);
                        tmpboxname = box.box_number;

                        ordering norder = new ordering();
                        int fl = 999;
                        for (int i = 0; i < orderlist.coun(); i++)
                        {
                            norder = orderlist.ReturnMyClass(i);
                            if (norder.boxname == tmpboxname)
                            {
                                if (currr >= norder.startdate && currr <= norder.enddate)
                                    fl = i;
                            }
                        }

                        norder = orderlist.ReturnMyClass(fl);
                        orderlist.RemoveMyClass(tmpboxname, norder.enddate);
                        orderlist.SaveList("orders.xml");
                        iRefreshForm(0);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        boxes box = new boxes();
                        box = boxlist.FindCLass(str2);
                        tmpboxname = box.box_number;

                        ordering norder = new ordering();
                        int fl = 999;
                        for (int i = 0; i < orderlist.coun(); i++)
                        {
                            norder = orderlist.ReturnMyClass(i);
                            if (norder.boxname == tmpboxname)
                            {
                                if (currr >= norder.startdate && currr <= norder.enddate)
                                    fl = i;
                            }
                        }

                        norder = orderlist.ReturnMyClass(fl);

                        orderlist.RemoveMyClass(tmpboxname, norder.enddate);
                        orderlist.SaveList("orders.xml");
                        iRefreshForm(12);
                    }
                    else if (radioButton3.Checked == true)
                    {
                        boxes box = new boxes();
                        box = boxlist.FindCLass(str3);
                        tmpboxname = box.box_number;

                        ordering norder = new ordering();
                        int fl = 999;
                        for (int i = 0; i < orderlist.coun(); i++)
                        {
                            norder = orderlist.ReturnMyClass(i);
                            if (norder.boxname == tmpboxname)
                            {
                                if (currr >= norder.startdate && currr <= norder.enddate)
                                    fl = i;
                            }
                        }

                        norder = orderlist.ReturnMyClass(fl);

                        orderlist.RemoveMyClass(tmpboxname, norder.enddate);
                        orderlist.SaveList("orders.xml");
                        iRefreshForm(24);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private string Mary_Louise_Parker(string picname)
        {
            if (radioButton1.Checked == true)
            {
                if (picname == "pictureBox1")
                    return "А1";
                else
                    if (picname == "pictureBox2")
                        return "А2";
                    else
                        if (picname == "pictureBox3")
                            return "А3";
                        else
                            if (picname == "pictureBox4")
                                return "А4";
                            else
                                if (picname == "pictureBox5")
                                    return "А5";
                                else
                                    if (picname == "pictureBox6")
                                        return "А6";
                                    else
                                        if (picname == "pictureBox7")
                                            return "А7";
                                        else
                                            if (picname == "pictureBox8")
                                                return "А8";
                                            else
                                                if (picname == "pictureBox9")
                                                    return "А9";
                                                else
                                                    if (picname == "pictureBox10")
                                                        return "А10";
                                                    else
                                                        if (picname == "pictureBox11")
                                                            return "А11";
                                                        else
                                                            if (picname == "pictureBox12")
                                                                return "А12";
                                                            else
                                                                return "jdhbsfj";
            }
            else
                if (radioButton2.Checked == true)
                {
                    if (picname == "pictureBox1")
                        return "Б1";
                    else
                        if (picname == "pictureBox2")
                            return "Б2";
                        else
                            if (picname == "pictureBox3")
                                return "Б3";
                            else
                                if (picname == "pictureBox4")
                                    return "Б4";
                                else
                                    if (picname == "pictureBox5")
                                        return "Б5";
                                    else
                                        if (picname == "pictureBox6")
                                            return "Б6";
                                        else
                                            if (picname == "pictureBox7")
                                                return "Б7";
                                            else
                                                if (picname == "pictureBox8")
                                                    return "Б8";
                                                else
                                                    if (picname == "pictureBox9")
                                                        return "Б9";
                                                    else
                                                        if (picname == "pictureBox10")
                                                            return "Б10";
                                                        else
                                                            if (picname == "pictureBox11")
                                                                return "Б11";
                                                            else
                                                                if (picname == "pictureBox12")
                                                                    return "Б12";
                                                                else
                                                                    return "jdhbsfj";
                }
                else
                    if (radioButton3.Checked == true)
                    {
                        if (picname == "pictureBox1")
                            return "В1";
                        else
                            if (picname == "pictureBox2")
                                return "В2";
                            else
                                if (picname == "pictureBox3")
                                    return "В3";
                                else
                                    if (picname == "pictureBox4")
                                        return "В4";
                                    else
                                        if (picname == "pictureBox5")
                                            return "В5";
                                        else
                                            if (picname == "pictureBox6")
                                                return "В6";
                                            else
                                                if (picname == "pictureBox7")
                                                    return "В7";
                                                else
                                                    if (picname == "pictureBox8")
                                                        return "В8";
                                                    else
                                                        if (picname == "pictureBox9")
                                                            return "В9";
                                                        else
                                                            if (picname == "pictureBox10")
                                                                return "В10";
                                                            else
                                                                if (picname == "pictureBox11")
                                                                    return "В11";
                                                                else
                                                                    if (picname == "pictureBox12")
                                                                        return "В12";
                                                                    else
                                                                        return "jdhbsfj";
                    }
                    else
                        return "sdfsdfsdfsdf";
        }

        private int Stana_Katic(string picname)
        {
            if (picname == "pictureBox1")
                return 1;
            else
                if (picname == "pictureBox2")
                    return 2;
                else
                    if (picname == "pictureBox3")
                        return 3;
                    else
                        if (picname == "pictureBox4")
                            return 4;
                        else
                            if (picname == "pictureBox5")
                                return 5;
                            else
                                if (picname == "pictureBox6")
                                    return 6;
                                else
                                    if (picname == "pictureBox7")
                                        return 7;
                                    else
                                        if (picname == "pictureBox8")
                                            return 8;
                                        else
                                            if (picname == "pictureBox9")
                                                return 9;
                                            else
                                                if (picname == "pictureBox10")
                                                    return 10;
                                                else
                                                    if (picname == "pictureBox11")
                                                        return 11;
                                                    else
                                                        if (picname == "pictureBox12")
                                                            return 12;
                                                        else
                                                            return 1000;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            PictureBox ppb = (PictureBox)((ContextMenuStrip)sender).SourceControl;
            string searchname;
            searchname = ppb.Name;
            if (File.Exists("boxes.xml"))
            {
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }
                string tmpboxname;


                boxes box = new boxes();
                box = boxlist.FindCLass(Mary_Louise_Parker(searchname));

                tmpboxname = box.box_number;

                if (box.box_status == "свободен")
                {
                    this.арендоватьМестоToolStripMenuItem.Enabled = true;
                    this.удалитьТекущуюДатуToolStripMenuItem.Enabled = false;
                    this.завершитьТекущуюАрендуМестаToolStripMenuItem.Enabled = false;
                    this.арендаНаДругуюДатуToolStripMenuItem.Enabled = false;
                }
                else
                {
                    this.арендоватьМестоToolStripMenuItem.Enabled = false;
                    this.удалитьТекущуюДатуToolStripMenuItem.Enabled = true;
                    this.завершитьТекущуюАрендуМестаToolStripMenuItem.Enabled = true;
                    this.арендаНаДругуюДатуToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void арендоватьМестоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox ppb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            striparendclick("А" + Stana_Katic(ppb.Name).ToString(), "Б" + Stana_Katic(ppb.Name).ToString(), "В" + Stana_Katic(ppb.Name).ToString());
        }

        private void информацияОМестеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox ppb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            stripinfoclick("А" + Stana_Katic(ppb.Name).ToString(), "Б" + Stana_Katic(ppb.Name).ToString(), "В" + Stana_Katic(ppb.Name).ToString());
        }

        private void удалитьТекущуюДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox ppb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            stripchangeclick("А" + Stana_Katic(ppb.Name).ToString(), "Б" + Stana_Katic(ppb.Name).ToString(), "В" + Stana_Katic(ppb.Name).ToString());
        }

        private void завершитьТекущуюАрендуМестаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox ppb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            stripremoveclick("А" + Stana_Katic(ppb.Name).ToString(), "Б" + Stana_Katic(ppb.Name).ToString(), "В" + Stana_Katic(ppb.Name).ToString());
        }

        private void арендаНаДругуюДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox ppb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            striparendclick("А" + Stana_Katic(ppb.Name).ToString(), "Б" + Stana_Katic(ppb.Name).ToString(), "В" + Stana_Katic(ppb.Name).ToString());
        }

        private void добавитьТарифToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_tarif addtarif = new add_tarif();
            addtarif.ShowDialog();
        }

        private void редактированиеТарифовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("tarif.xml"))
            {
                try
                {
                    tariflist.LoadList("tarif.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }
                if (tariflist.coun() == 0)
                {
                    DialogResult dialogResult1 = MessageBox.Show("База c тарифами пуста! ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    review_tarif revt = new review_tarif();
                    revt.ShowDialog();
                }
            }
        }

        private void инфоОТекущемТарифеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists("tarif.xml"))
            {
                try
                {
                    tariflist.LoadList("tarif.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }
                if (tariflist.coun() == 0)
                {
                    DialogResult dialogResult1 = MessageBox.Show("База c тарифами пуста! ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    base_tarif_info bti = new base_tarif_info();
                    bti.ShowDialog();
                }
            }
        }

        private void инфоОТекущемТарифеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tariflist.LoadList("tarif.xml");
            }
            catch (System.Exception ex)
            {
                Close();
            }
            if (tariflist.coun() == 0)
            {
                DialogResult dialogResult1 = MessageBox.Show("База c тарифами пуста! ", "Нет данных!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                base_tarif_info bti = new base_tarif_info();
                bti.ShowDialog();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.label15.Text = this.monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scarlett_johansson();
            if (radioButton1.Checked == true)
                iRefreshForm(0);
            if (radioButton2.Checked == true)
                iRefreshForm(12);
            if (radioButton3.Checked == true)
                iRefreshForm(24);
        }
        
        private void sortir(int nnn)
        {
            try
            {
                boxlist.LoadList("boxes.xml");
            }
            catch (System.Exception ex)
            {
                File.Delete("boxes.xml");
            }

            boxes a = new boxes();
            boxes b = new boxes();
            boxes c = new boxes();
            int sh = 36 - nnn;
            while (sh > 1)
            {
                a = boxlist.ReturnMyClass(nnn);
                boxlist.RemoveMyClass(a.box_number);
                boxlist.AddMyClass(a);
                boxlist.SaveList("boxes.xml");
                sh--;
            }
        }

        private int get_box_num(string str)
        {
            if (str == "А1")
                return 0;
            else
                if (str == "А2")
                    return 1;
                else
                    if (str == "А3")
                        return 2;
                    else
                        if (str == "А4")
                            return 3;
                        else
                            if (str == "А5")
                                return 4;
                            else
                                if (str == "А6")
                                    return 5;
                                else
                                    if (str == "А7")
                                        return 6;
                                    else
                                        if (str == "А8")
                                            return 7;
                                        else
                                            if (str == "А9")
                                                return 8;
                                            else
                                                if (str == "А10")
                                                    return 9;
                                                else
                                                    if (str == "А11")
                                                        return 10;
                                                    else
                                                        if (str == "А12")
                                                            return 11;
                                                        else
                                                            if (str == "Б1")
                                                                return 12;
                                                            else
                                                                if (str == "Б2")
                                                                    return 13;
                                                                else
                                                                    if (str == "Б3")
                                                                        return 14;
                                                                    else
                                                                        if (str == "Б4")
                                                                            return 15;
                                                                        else
                                                                            if (str == "Б5")
                                                                                return 16;
                                                                            else
                                                                                if (str == "Б6")
                                                                                    return 17;
                                                                                else
                                                                                    if (str == "Б7")
                                                                                        return 18;
                                                                                    else
                                                                                        if (str == "Б8")
                                                                                            return 19;
                                                                                        else
                                                                                            if (str == "Б9")
                                                                                                return 20;
                                                                                            else
                                                                                                if (str == "Б10")
                                                                                                    return 21;
                                                                                                else
                                                                                                    if (str == "Б11")
                                                                                                        return 22;
                                                                                                    else
                                                                                                        if (str == "Б12")
                                                                                                            return 23;
                                                                                                        else
                                                                                                            if (str == "В1")
                                                                                                                return 24;
                                                                                                            else
                                                                                                                if (str == "В2")
                                                                                                                    return 25;
                                                                                                                else
                                                                                                                    if (str == "В3")
                                                                                                                        return 26;
                                                                                                                    else
                                                                                                                        if (str == "В4")
                                                                                                                            return 27;
                                                                                                                        else
                                                                                                                            if (str == "В5")
                                                                                                                                return 28;
                                                                                                                            else
                                                                                                                                if (str == "В6")
                                                                                                                                    return 29;
                                                                                                                                else
                                                                                                                                    if (str == "В7")
                                                                                                                                        return 30;
                                                                                                                                    else
                                                                                                                                        if (str == "В8")
                                                                                                                                            return 31;
                                                                                                                                        else
                                                                                                                                            if (str == "В9")
                                                                                                                                                return 32;
                                                                                                                                            else
                                                                                                                                                if (str == "В10")
                                                                                                                                                    return 33;
                                                                                                                                                else
                                                                                                                                                    if (str == "В11")
                                                                                                                                                        return 34;
                                                                                                                                                    else
                                                                                                                                                        if (str == "В12")
                                                                                                                                                            return 35;
                                                                                                                                                        else
                                                                                                                                                            return 999;
        }

        private void scarlett_johansson()
        {
            if (File.Exists("orders.xml"))
            {
                try
                {
                    boxlist.LoadList("boxes.xml");
                }
                catch (System.Exception ex)
                {
                    Close();
                }

                boxes box = new boxes();
                ordering order = new ordering();
                DateTime currDateTime = DateTime.Now;

                for (int i = 0; i < boxlist.coun(); i++)
                {
                    box = boxlist.ReturnMyClass(i);
                    int flag = 0;

                    try
                    {
                        orderlist.LoadList("orders.xml");
                    }
                    catch (System.Exception ex)
                    {
                        Close();
                    }

                    for (int j = 0; j < orderlist.coun(); j++)
                    {
                        order = orderlist.ReturnMyClass(j);
                        if (box.box_number == order.boxname)
                        {
                            if (currDateTime >= order.startdate && currDateTime <= order.enddate)
                            {
                                box.box_status = "занят";
                                box.box_current_owner_login = order.box_owner_login;

                                boxlist.RemoveMyClass(box.box_number);
                                boxlist.AddMyClass(box);
                                boxlist.SaveList("boxes.xml");
                                sortir(box.n);
                                flag = 1;
                            }

                            if (currDateTime > order.enddate)
                            {
                                orderlist.RemoveMyClass(order.boxname, order.enddate);
                                orderlist.SaveList("orders.xml");
                            }
                        }
                    }
                    //конец фора по j

                    if (flag == 0)
                    {
                        if (box.box_status != "свободен")
                        {
                            box.box_status = "свободен";
                            box.box_current_owner_login = "-";

                            boxlist.RemoveMyClass(box.box_number);
                            boxlist.AddMyClass(box);
                            boxlist.SaveList("boxes.xml");
                            sortir(box.n);
                        }
                    }
                }
                //конец фора по i
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void принятьКассуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("cash.xml"))
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите принять кассу?", "Прием кассы", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        cashlist.LoadList("cash.xml");
                    }
                    catch (System.Exception ex)
                    {
                        Close();
                    }

                    cashlist.ClearList();
                    cashlist.SaveList("cash.xml");
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private void отчетПоФинансамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            review_cash rcash = new review_cash();
            rcash.ShowDialog();
        }

        private void отчетПоФинансамToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            review_cash rcash = new review_cash();
            rcash.ShowDialog();
        }

        private void техническаяПоддержкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Телефон тех. поддержки: 8-бла-бла-бла-бла",
                "Тех Поддержка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа является курсовой работой студента Ножкина А. С., гр. ПИ-01 2013г",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("help.chm"))
                Process.Start("help.chm");
        }

        private bool proverka_future_busy(int number)
        {
            boxlist.LoadList("boxes.xml");

            boxes box = new boxes();
            box = boxlist.ReturnMyClass(number);

            if (File.Exists("orders.xml"))
            {
                try
                {
                    orderlist.LoadList("orders.xml");
                }
                catch (System.Exception ex)
                {
                }

                int flag = 0;
                ordering order = new ordering();

                for (int i = 0; i < orderlist.coun(); i++)
                {
                    order = orderlist.ReturnMyClass(i);
                    if (order.boxname == box.box_number)
                        flag = 1;
                }

                if (flag == 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        private DateTime return_start_time(int number)
        {
            boxlist.LoadList("boxes.xml");

            boxes box = new boxes();
            box = boxlist.ReturnMyClass(number);
            DateTime rd = DateTime.Now;
            try
            {
                orderlist.LoadList("orders.xml");
            }
            catch (System.Exception ex)
            {
            }

            ordering order = new ordering();

            for (int i = 0; i < orderlist.coun(); i++)
            {
                order = orderlist.ReturnMyClass(i);
                if (order.boxname == box.box_number)
                {
                    rd = order.startdate;
                }
            }

            for (int i = 0; i < orderlist.coun(); i++)
            {
                order = orderlist.ReturnMyClass(i);
                if (order.boxname == box.box_number)
                {
                    if (rd > order.startdate)
                        rd = order.startdate;
                }
            }

            return rd;
        }

        private DateTime return_end_time(int number)
        {
            boxlist.LoadList("boxes.xml");

            boxes box = new boxes();
            box = boxlist.ReturnMyClass(number);
            DateTime curr = DateTime.Now;
            DateTime rd = DateTime.Now;
            try
            {
                orderlist.LoadList("orders.xml");
            }
            catch (System.Exception ex)
            {
            }

            ordering order = new ordering();

            for (int i = 0; i < orderlist.coun(); i++)
            {
                order = orderlist.ReturnMyClass(i);
                if (order.boxname == box.box_number)
                {
                    if (curr >= order.startdate && curr < order.enddate)
                    {
                        rd = order.enddate;
                    }
                }
            }

            return rd;
        }
    }
}
