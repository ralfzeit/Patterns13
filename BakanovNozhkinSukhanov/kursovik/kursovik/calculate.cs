using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursovik
{
    public partial class calculate : Form
    {
        public string temp1;
        public int temp2;
        public int temp3;

        RQ list = new RQ();

        public calculate(string t1, int t2, int t3)
        {
            InitializeComponent();
            temp1 = t1;
            temp2 = t2;
            temp3 = t3;
        }

        private void calculate_Load(object sender, EventArgs e)
        {
            //
            toolTip1.SetToolTip(textBox1, "ФИО владельца");
            toolTip1.SetToolTip(textBox2, "Улица");
            toolTip1.SetToolTip(textBox3, "Номер дома");
            toolTip1.SetToolTip(textBox4, "Номер квартиры");
            toolTip1.SetToolTip(textBox5, "Площадь квартиры");
            toolTip1.SetToolTip(textBox6, "Прописано человек");
            toolTip1.SetToolTip(textBox7, "Наличие счетчиков");
            toolTip1.SetToolTip(textBox8, "Наличие лифта");
            toolTip1.SetToolTip(textBox9, "Наличие вахтера");
            toolTip1.SetToolTip(textBox10, "Наличие телефона");
            toolTip1.SetToolTip(textBox11, "Газ");
            toolTip1.IsBalloon = true;
            //
            list.LoadList("base.xml");
            MyClass obj = new MyClass();
            obj = list.FindCLass(temp1, temp2, temp3);
            textBox1.Text = obj.FIO;
            textBox2.Text = obj.Street;
            textBox3.Text = Convert.ToString(obj.HouseNum);
            textBox4.Text = Convert.ToString(obj.FlatNum);
            textBox5.Text = Convert.ToString(obj.Square);
            textBox6.Text = Convert.ToString(obj.PeopleInside);
            textBox7.Text = obj.SWater;
            textBox8.Text = obj.Elevator;
            textBox9.Text = obj.Watchman;
            textBox10.Text = obj.Phone;
            textBox11.Text = obj.Gas;

            if (textBox7.Text == "Нет")
            {
                textBox13.Enabled = false;
                textBox14.Enabled = false;
            }
            else
            {
                textBox13.Enabled = true;
                textBox14.Enabled = true;
            }

            if (textBox11.Text == "Нет")
            {
                textBox22.Enabled = false;
            }
            else
            {
                textBox22.Enabled = true;
            }
            fillTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool FLAG = true;
            double ITOG = 0;

            if (textBox12.Text == "")
                FLAG = false;
            else
            {
                int electro;
                double SumEl = 0;
                electro = Convert.ToInt32(textBox12.Text);
                SumEl = electro * constans.elektr;
                ITOG = ITOG + SumEl;

                dataGridView1[2, 4].Value = electro;
                dataGridView1[4, 4].Value = SumEl;
                dataGridView1[5, 4].Value = SumEl;

            }
            if (textBox7.Text == "Да")
            {
                if (textBox13.Text != "" && textBox14.Text != "")
                {
                    double vodootvod = 0, r1, r2,cv,cr1,cr2;

                    r1 = Convert.ToDouble(textBox13.Text);
                    r2 = Convert.ToDouble(textBox14.Text);
                    vodootvod = r1 + r2;
                    textBox15.Text = Convert.ToString(vodootvod);

                    cr1 = r1 * constans.wHot;
                    cr2 = r2 * constans.wCold;
                    cv = vodootvod * constans.wRemove;
                    ITOG = ITOG + cr1 + cr2 + cv;

                    dataGridView1[2, 6].Value = r1;
                    dataGridView1[4, 6].Value = cr1;
                    dataGridView1[5, 6].Value = cr1;

                    dataGridView1[2, 7].Value = cr2;
                    dataGridView1[4, 7].Value = cr2;
                    dataGridView1[5, 7].Value = cr2;

                    dataGridView1[2, 8].Value = vodootvod;
                    dataGridView1[4, 8].Value = cv;
                    dataGridView1[5, 8].Value = cv;
                }
                else
                    FLAG = false;
            }
            else
            {
                int domCold,domHot,cRand,hRand,pn;
                double cRas,hRas,cSum=0,hSum=0,wOtv,wOtvSum,hRes,cRes;
                string cStr,hStr;

                Random rand = new Random();
                pn = Convert.ToInt32(textBox6.Text);

                domCold = rand.Next(180, 190);
                cRand = rand.Next(1,999);
                cRas = (domCold/90);
                cStr = Convert.ToString(cRas) + "," + Convert.ToString(cRand);
                cRes = Convert.ToDouble(cStr) * pn;

                domHot = rand.Next(180, 189);
                hRand = rand.Next(1, 999);
                hRas = (domHot/90);
                hStr = Convert.ToString(hRas) + "," + Convert.ToString(hRand);
                hRes = Convert.ToDouble(hStr) * pn;

                wOtv = cRes + hRes;

                cSum = cRes * constans.wCold;
                hSum = hRes * constans.wHot;
                wOtvSum = wOtv * constans.wRemove;
                ITOG = ITOG + cSum + hSum + wOtvSum;

                dataGridView1[2, 6].Value = hRes;
                dataGridView1[4, 6].Value = hSum;
                dataGridView1[5, 6].Value = hSum;

                dataGridView1[2, 7].Value = cRes;
                dataGridView1[4, 7].Value = cSum;
                dataGridView1[5, 7].Value = cSum;

                dataGridView1[2, 8].Value = wOtv;
                dataGridView1[4, 8].Value = wOtvSum;
                dataGridView1[5, 8].Value = wOtvSum;

            }
            if (textBox11.Text == "Да")
            {
                if (textBox22.Text == "")
                    FLAG = false;
                else
                {
                    double rGas, sumGas;
                    rGas = Convert.ToDouble(textBox22.Text);
                    sumGas = rGas * constans.rGas;
                    ITOG = ITOG + sumGas;

                    dataGridView1[2, 9].Value = rGas;
                    dataGridView1[4, 9].Value = sumGas;
                    dataGridView1[5, 9].Value = sumGas;
                }
            }
            else
            {
                int Gas=0;
                dataGridView1[2, 9].Value = Gas;
                dataGridView1[4, 9].Value = Gas;
                dataGridView1[5, 9].Value = Gas;
            }

            if (FLAG == false)
            {
                DialogResult dialogResult = MessageBox.Show("Не все поля заполнены! Внимательно заполните поля, на форме присутствует кнопка '*' которая автоматически заполняет поля",
                    "Не заполнены поля", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int pn=Convert.ToInt32(textBox6.Text);
                if (pn == 0)
                {
                    double rem;
                    rem = Convert.ToDouble(textBox5.Text);
                    ITOG = ITOG + rem;
                    dataGridView1[2, 0].Value = rem;
                    dataGridView1[4, 0].Value = rem;
                    dataGridView1[5, 0].Value = rem;
                }
                else
                {
                    if (textBox9.Text == "Да")
                    {
                        double rem, s;
                        s = Convert.ToDouble(textBox5.Text);
                        rem = s * constans.remont1;
                        ITOG = ITOG + rem;
                        dataGridView1[2, 0].Value = s;
                        dataGridView1[4, 0].Value = rem;
                        dataGridView1[5, 0].Value = rem;
                    }
                    else
                    {
                        double rem, s;
                        s = Convert.ToDouble(textBox5.Text);
                        rem = s * constans.remont2;
                        ITOG = ITOG + rem;
                        dataGridView1[2, 0].Value = s;
                        dataGridView1[4, 0].Value = rem;
                        dataGridView1[5, 0].Value = rem;
                    }
                }
                    double sq = Convert.ToDouble(textBox5.Text);
                    ITOG = ITOG + sq;
                    dataGridView1[2, 1].Value = sq;
                    dataGridView1[4, 1].Value = sq;
                    dataGridView1[5, 1].Value = sq;

                    double TBO,resTBO;
                    TBO = 0.1575 * pn;
                    resTBO = TBO * constans.TBO;
                    ITOG = ITOG + resTBO;
                    dataGridView1[2, 2].Value = TBO;
                    dataGridView1[4, 2].Value = resTBO;
                    dataGridView1[5, 2].Value = resTBO;

                    double lift;
                    lift = sq * constans.elev;
                    ITOG = ITOG + lift;
                    dataGridView1[2, 3].Value = sq;
                    dataGridView1[4, 3].Value = lift;
                    dataGridView1[5, 3].Value = lift;

                    Random randd = new Random();
                    double rOt,resOt,ot;
                    ot = randd.Next(135, 160);
                    rOt = (ot/90);
                    resOt = rOt * constans.otoplenie;
                    ITOG = ITOG + resOt;
                    dataGridView1[2, 5].Value = rOt;
                    dataGridView1[4, 5].Value = resOt;
                    dataGridView1[5, 5].Value = resOt;

                    dataGridView1[5, 11].Value = ITOG;
                
            }
            dataGridView1.ClearSelection();
        }
        //////////////////////////////////////////////////////////////////////////
        private void fillTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1[0, 0].Value = "Содержание и текущий ремонт жилья";
            dataGridView1[1, 0].Value = "м кв.";
            if (textBox6.Text == "0")
                dataGridView1[3, 0].Value = 1;
            else
            {
                if (textBox9.Text == "Да")
                    dataGridView1[3, 0].Value = constans.remont1;
                else
                    dataGridView1[3, 0].Value = constans.remont2;
            }

            dataGridView1[0, 1].Value = "Капитальный ремонт";
            dataGridView1[1, 1].Value = "м кв.";
            dataGridView1[3, 1].Value = constans.k_remont;

            dataGridView1[0, 2].Value = "Вывоз и утилизация ТБО";
            dataGridView1[1, 2].Value = "м куб.";
            dataGridView1[3, 2].Value = constans.TBO;

            dataGridView1[0, 3].Value = "Содержание лифта";
            dataGridView1[1, 3].Value = "м кв.";
            if(textBox8.Text == "Да")
            dataGridView1[3, 3].Value = constans.elev;
            else
                dataGridView1[3, 3].Value = 0;

            dataGridView1[0, 4].Value = "Электроснабжение";
            dataGridView1[1, 4].Value = "кВат ч";
            dataGridView1[3, 4].Value = constans.elektr;

            dataGridView1[0, 5].Value = "Отопление";
            dataGridView1[1, 5].Value = "Гкал.";
            dataGridView1[3, 5].Value = constans.otoplenie;

            dataGridView1[0, 6].Value = "Горячее водоснабжение";
            dataGridView1[1, 6].Value = "м куб.";
            dataGridView1[3, 6].Value = constans.wHot;

            dataGridView1[0, 7].Value = "Холодное водоснабжение";
            dataGridView1[1, 7].Value = "м куб.";
            dataGridView1[3, 7].Value = constans.wCold;

            dataGridView1[0, 8].Value = "Водоотведение";
            dataGridView1[1, 8].Value = "м куб.";
            dataGridView1[3, 8].Value = constans.wRemove;

            dataGridView1[0, 9].Value = "Газ";
            dataGridView1[1, 9].Value = "м куб.";
            dataGridView1[3, 9].Value = constans.rGas;

            dataGridView1[0, 10].Value = "----------------------------------------------------------------";
            dataGridView1[1, 10].Value = "------------";
            dataGridView1[2, 10].Value = "-----------------";
            dataGridView1[3, 10].Value = "--------------";
            dataGridView1[4, 10].Value = "-----------------";
            dataGridView1[5, 10].Value = "-----------------";

            dataGridView1[0, 11].Value = "ИТОГО:";
            dataGridView1.ClearSelection();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a;
            Random rand = new Random();
            a = rand.Next(40,200);
            textBox12.Text = Convert.ToString(a);
            if (textBox7.Text == "Да")
            {
                Random rand1 = new Random();
                int ran1, ran2, ran3, ran4;
                string sum1, sum2;
                double vodootvod, v1, v2;

                ran1 = rand1.Next(0, 3);
                sum1 = Convert.ToString(ran1) + ",";
                ran2 = rand1.Next(0, 999);
                sum1 = sum1 + Convert.ToString(ran2);
                textBox13.Text = sum1;
                v1 = Convert.ToDouble(sum1);

                ran3 = rand1.Next(0, 3);
                sum2 = Convert.ToString(ran3) + ",";
                ran4 = rand1.Next(0, 999);
                sum2 = sum2 + Convert.ToString(ran4);
                textBox14.Text = sum2;
                v2 = Convert.ToDouble(sum2);

                vodootvod = v1 + v2;
                textBox15.Text = Convert.ToString(vodootvod);
            }
            if (textBox11.Text == "Да")
            {
                Random rand2 = new Random();
                int ran5;
                string sum3;

                ran5 = rand2.Next(1, 50);
                sum3 = Convert.ToString(ran5);
                textBox22.Text = sum3;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
