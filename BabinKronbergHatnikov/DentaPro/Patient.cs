using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Linq.Mapping;
using ALinq.Access;
using ALinq;
using ALinq.Mapping;
using System.IO;




namespace Denta_Pro
{ 
   
     public class Patient : BaseObject
    {


        public Patient() {

            stop = 13;
        
        }

        public long ID;        
        public String Name;
        public String Surname;
        public String Lastname;
        public String Address;
        public String Workplace;
        public String Phone;
        public String Email;
        public String Social;
        public int Sex;
        public DateTime Regest;
        public DateTime Birthdate;
        public byte[] Profileb;
        public String Desies;

        public Image Profile;

        public List<String> DesiesMask = new List<string>();

     
        public virtual void Create_parametrs() 
        
        {
            DesiasToList();
            Create_params();
        }

      
      public void Image2bytes( ) {

          Bitmap bit = new Bitmap(Profile);
          MemoryStream mystream = new MemoryStream();
          bit.Save(mystream, System.Drawing.Imaging.ImageFormat.Jpeg);

          this.Profileb = mystream.ToArray();
               
       }
           
         public void  DesiasToList() {

            this.Desies = "";
          
             for (int i = 0; i < DesiesMask.Count(); i++) {

                Desies += Desies + DesiesMask[i] + "\n";
            
            }
            
             this.Desies.Trim();
               
         }
       

      
        

    }
}







  
   
         
       
        
   
     
        
       
 
       
     
     
      

