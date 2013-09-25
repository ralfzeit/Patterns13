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
    public partial class DeletePatient : Form
    {
       public DRIVER db;
       public int id;
       public string fio;
        public DeletePatient(int ID, string FIO, DRIVER dob)
        {
            InitializeComponent();
            db = dob;
            id = ID;
            fio = FIO;
            namer.Text = fio;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            db.Delete("Patients", "ID=" + id+"");
            MessageBox.Show(fio + " успешно удалён из базы!");
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
