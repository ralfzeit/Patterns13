using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denta_Pro
{
    public partial class FV : Form
    {
        public FV()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Enabled = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = System.Drawing.Color.LightSeaGreen;
        }
    }
}
