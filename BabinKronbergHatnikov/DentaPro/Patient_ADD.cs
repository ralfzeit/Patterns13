using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.IO;

using Microsoft.Office.Core;

namespace Denta_Pro
{
    public partial class Patient_ADD : Form
    {
            

        public bool anket_flag = false;

        public int active_page = 0;

        public Patient New_Patient = new Patient();

        public DRIVER db;
        public Patient_ADD(DRIVER dob)
        {
                       
            InitializeComponent();
            db = dob;
          
        }
          
                
        private bool Check_empty(TextBox item) 
        {
            if (item.Text.ToString() == "")
            {
                anket_flag = true;
                item.BackColor = Color.Wheat;
                return false;
            }
            else
            {
                item.BackColor = Color.White;
                return true;
            }
         }

        private String Ret(TextBox item) {

            return item.Text.ToString();
        
        }
        
        private bool Validate_Common() 
        {
           

            Men.Checked = true;
            /// Common Panel

            if (Check_empty(Namer))
                New_Patient.Name = Namer.Text.ToString();

            if (Check_empty(Sunamer))
                New_Patient.Surname = Ret (Sunamer);

            if (Check_empty(Lastnamer))
                New_Patient.Lastname = Ret(Lastnamer);

            if (Check_empty(Adnamer))
                New_Patient.Address = Ret (Adnamer) ;

            if (Check_empty(Worknamer))
                New_Patient.Workplace = Ret (Worknamer) ;

            if (Check_empty(Phonenamer))
                New_Patient.Phone = Ret (Phonenamer);

            if (Check_empty(Emailnamer))
                New_Patient.Email = Ret (Emailnamer);

            if (Check_empty(Socialnamer))
                New_Patient.Social = Ret(Socialnamer);

            if (m.Checked)
                New_Patient.Sex = 1;
            else New_Patient.Sex = 0;

            New_Patient.Birthdate = Birthnamer.Value;
            New_Patient.Regest = Regnamer.Value;

            New_Patient.Profile = Prof.Image;
            New_Patient.Desies = String.Empty;

            if (!anket_flag)
            {
               return anket_flag;
            }
            else
            {
                anket_flag = false;
                return true;
            }
            
        }

        /*Добавление аватара в профайл пациента*/

        private void UserImage_Click(object sender, EventArgs e)
        {
          
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Add_Patient(object sender, EventArgs e)
        {
            bool flag = false; 

                             
            flag =  Validate_Common();
        

            if (!flag)
            {
                New_Patient.Create_parametrs();

                New_Patient.Image2bytes();
                Patient.Library.ViewFields(New_Patient);
                db.Create_Connection("Patients", New_Patient.item);

                if (!flag)
                    try
                    {
                        db.Insert("Patients", New_Patient.Params, New_Patient);
                    }
                    catch (Exception a)
                    { MessageBox.Show(a.Message); }
                    finally
                    {
                        MessageBox.Show(New_Patient.Surname + " " + New_Patient.Name + " успешно добавлен в базу!");
                    }

                this.Close();
            }
                     
                         
        }

        private void Prof_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                if (openFileDialog1.FileName.Contains("jpg") || openFileDialog1.FileName.Contains("png")
                    || openFileDialog1.FileName.Contains("bmp"))
                {
                    Image img = Image.FromFile(openFileDialog1.FileName);

                    Prof.Image.Dispose();
                    Prof.Image = img;


                }
                else MessageBox.Show("Неверный формат файла!");



            }
        }


        ///  using Word = Microsoft.Office.Interop.Word;
        ///using Microsoft.Office.Interop.Word;

        /// public  Word._Application oWord = new Word.Application();
        // Определение переменной oWord


        // 
        /* private void buttonDocument(object sender, EventArgs e)
         {
             // Считывает шаблон и сохраняет измененный в новом
             _Document oDoc = GetDoc(Environment.CurrentDirectory + "\\Doc_propusk.dotx");
             oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\For_print.docx");
             oDoc.Close();
         }
 
         private _Document GetDoc(string path)
         {
             _Document oDoc = oWord.Documents.Add(path);
             SetTemplate(oDoc);
             return oDoc;
         }
             // Замена закладки SECONDNAME на данные введенные в textBox
         private void SetTemplate(Word._Document oDoc)
         {
           ///  oDoc.Bookmarks["SECONDNAME"].Range.Text = textSecondName.Text;
                  // если нужно заменять другие закладки, тогда копируем верхнюю строку изменяя на нужные параметры 
            
         }
        
         */





    }
}
