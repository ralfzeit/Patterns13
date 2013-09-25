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
    public partial class EmailText : Form
    {
        public String text;
        public String sub;
        public EmailText()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = email.Text.ToString();
            sub =  subject.Text.ToString();
            this.Close();
        }
    }
}
