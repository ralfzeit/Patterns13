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
    public partial class Formula : Form
    {
        public int kol = 0;
        public Formula()
        {
            InitializeComponent();
        }

        private void button58_Click(object sender, EventArgs e)
        {

        }

        private void button54_Click(object sender, EventArgs e)
        {    Button bt = (Button)sender;
            switch (kol)
            {
                case 0:
                  
                    bt.BackColor = System.Drawing.Color.LightGreen;
                    kol++;
                    break;
                case 1:
                    
                        bt.BackColor = System.Drawing.Color.Yellow;
                        kol++;
                        break;
                case 2:                      
                        bt.BackColor = System.Drawing.Color.Red;
                        kol = 0;
                        break;
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {

        }

        private void button61_MouseClick(object sender, MouseEventArgs e)
        {

          
             
                Tooth t = new Tooth();
                t.ShowDialog();
          
               
         

        }

        private void button64_Click(object sender, EventArgs e)
        {

        }

        private void button60_Click(object sender, EventArgs e)
        {

        }

        private void button63_Click(object sender, EventArgs e)
        {

        }

        private void button62_Click(object sender, EventArgs e)
        {

        }

        private void button59_Click(object sender, EventArgs e)
        {

        }
    }
}
