using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace letnyaa_praktika
{
    public partial class Form2 : Form
    {
        public string picName;
        public Form2(string fileName1)
        {
            picName = fileName1;
            InitializeComponent();
        }

        public Image ImageDuplicate = null;

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(picName);
        }
    }
}
