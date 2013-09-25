namespace Denta_Pro
{
    partial class Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.PatientImage = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.social = new System.Windows.Forms.LinkLabel();
            this.label18 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.workplace = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pregdate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pbdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pname = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.позвонитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправитьEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПациентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PatientImage)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatientImage
            // 
            this.PatientImage.Image = ((System.Drawing.Image)(resources.GetObject("PatientImage.Image")));
            this.PatientImage.Location = new System.Drawing.Point(24, 26);
            this.PatientImage.Name = "PatientImage";
            this.PatientImage.Size = new System.Drawing.Size(173, 176);
            this.PatientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PatientImage.TabIndex = 5;
            this.PatientImage.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(250)))), ((int)(((byte)(214)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.PatientImage);
            this.panel7.Location = new System.Drawing.Point(12, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(231, 229);
            this.panel7.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(250)))), ((int)(((byte)(214)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.social);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.phone);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.workplace);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.address);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pregdate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.sex);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pbdate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pname);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(236, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 229);
            this.panel1.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(218)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(308, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 172);
            this.panel3.TabIndex = 75;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(10, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "Анкета здоровья";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(10, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Зубная формула";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(10, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Первичный осмотр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // social
            // 
            this.social.AutoSize = true;
            this.social.Location = new System.Drawing.Point(132, 194);
            this.social.Name = "social";
            this.social.Size = new System.Drawing.Size(55, 13);
            this.social.TabIndex = 75;
            this.social.TabStop = true;
            this.social.Text = "linkLabel1";
            this.social.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.social_LinkClicked);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 194);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "Социальная сеть";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(132, 171);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(108, 13);
            this.email.TabIndex = 22;
            this.email.Text = "ikronberg@yandex.ru";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Электронная почта";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(132, 147);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(106, 13);
            this.phone.TabIndex = 20;
            this.phone.Text = "8 - 905- 989 - 99 - 32";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 147);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Контактные телефон";
            // 
            // workplace
            // 
            this.workplace.AutoSize = true;
            this.workplace.Location = new System.Drawing.Point(132, 123);
            this.workplace.Name = "workplace";
            this.workplace.Size = new System.Drawing.Size(165, 13);
            this.workplace.TabIndex = 18;
            this.workplace.Text = "Политехнический Университет";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Место работы";
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(132, 101);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(155, 13);
            this.address.TabIndex = 16;
            this.address.Text = "г.Барнаул Молодежная 50-17";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Домашний адрес";
            // 
            // pregdate
            // 
            this.pregdate.AutoSize = true;
            this.pregdate.Location = new System.Drawing.Point(132, 76);
            this.pregdate.Name = "pregdate";
            this.pregdate.Size = new System.Drawing.Size(65, 13);
            this.pregdate.TabIndex = 14;
            this.pregdate.Text = "17/06/1993";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Дата регистрации:";
            // 
            // sex
            // 
            this.sex.AutoSize = true;
            this.sex.Location = new System.Drawing.Point(218, 76);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(53, 13);
            this.sex.TabIndex = 12;
            this.sex.Text = "Мужской";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Пол";
            // 
            // pbdate
            // 
            this.pbdate.AutoSize = true;
            this.pbdate.Location = new System.Drawing.Point(132, 55);
            this.pbdate.Name = "pbdate";
            this.pbdate.Size = new System.Drawing.Size(65, 13);
            this.pbdate.TabIndex = 8;
            this.pbdate.Text = "17/06/1993";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дата рождения:";
            // 
            // pname
            // 
            this.pname.AutoSize = true;
            this.pname.Location = new System.Drawing.Point(131, 35);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(152, 13);
            this.pname.TabIndex = 6;
            this.pname.Text = "Кронберг Илья Анатольевич";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "ФИО пациента: ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 26);
            this.panel2.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.позвонитьToolStripMenuItem,
            this.отправитьEmailToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(439, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // позвонитьToolStripMenuItem
            // 
            this.позвонитьToolStripMenuItem.Name = "позвонитьToolStripMenuItem";
            this.позвонитьToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.позвонитьToolStripMenuItem.Text = "SMS";
            // 
            // отправитьEmailToolStripMenuItem
            // 
            this.отправитьEmailToolStripMenuItem.Name = "отправитьEmailToolStripMenuItem";
            this.отправитьEmailToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.отправитьEmailToolStripMenuItem.Text = "Email";
            this.отправитьEmailToolStripMenuItem.Click += new System.EventHandler(this.отправитьEmailToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьДанныеToolStripMenuItem,
            this.удалитьПациентаToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // редактироватьДанныеToolStripMenuItem
            // 
            this.редактироватьДанныеToolStripMenuItem.Name = "редактироватьДанныеToolStripMenuItem";
            this.редактироватьДанныеToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.редактироватьДанныеToolStripMenuItem.Text = "Редактировать данные пациента";
            this.редактироватьДанныеToolStripMenuItem.Click += new System.EventHandler(this.редактироватьДанныеToolStripMenuItem_Click);
            // 
            // удалитьПациентаToolStripMenuItem
            // 
            this.удалитьПациентаToolStripMenuItem.Name = "удалитьПациентаToolStripMenuItem";
            this.удалитьПациентаToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.удалитьПациентаToolStripMenuItem.Text = "Удалить пациента";
            this.удалитьПациентаToolStripMenuItem.Click += new System.EventHandler(this.удалитьПациентаToolStripMenuItem_Click);
            // 
            // Profile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(686, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Profile";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Профиль пациента";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PatientImage)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PatientImage;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label workplace;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label pregdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label sex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label pbdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.LinkLabel social;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem позвонитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправитьEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьПациентаToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}