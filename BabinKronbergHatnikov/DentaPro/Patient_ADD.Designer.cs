namespace Denta_Pro
{
    partial class Patient_ADD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient_ADD));
            this.Forward = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.patient_birthdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.Men = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.Women = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.patient_address = new System.Windows.Forms.TextBox();
            this.patient_reg_date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.patient_work = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.patient_phone = new System.Windows.Forms.TextBox();
            this.patient_Name = new System.Windows.Forms.TextBox();
            this.patient_Surname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.patient_Lastname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.patient_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.patient_social = new System.Windows.Forms.TextBox();
            this.common = new System.Windows.Forms.Panel();
            this.w = new System.Windows.Forms.RadioButton();
            this.m = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Regnamer = new System.Windows.Forms.DateTimePicker();
            this.Birthnamer = new System.Windows.Forms.DateTimePicker();
            this.Prof = new System.Windows.Forms.PictureBox();
            this.Socialnamer = new System.Windows.Forms.TextBox();
            this.Emailnamer = new System.Windows.Forms.TextBox();
            this.Adnamer = new System.Windows.Forms.TextBox();
            this.Worknamer = new System.Windows.Forms.TextBox();
            this.Lastnamer = new System.Windows.Forms.TextBox();
            this.Sunamer = new System.Windows.Forms.TextBox();
            this.Namer = new System.Windows.Forms.TextBox();
            this.Phonenamer = new System.Windows.Forms.TextBox();
            this.UserImage = new System.Windows.Forms.PictureBox();
            this.common.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Prof)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Forward
            // 
            this.Forward.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Forward.Location = new System.Drawing.Point(364, 354);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(152, 24);
            this.Forward.TabIndex = 60;
            this.Forward.Text = "Добавить пациента";
            this.Forward.UseVisualStyleBackColor = false;
            this.Forward.Click += new System.EventHandler(this.Add_Patient);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 57;
            // 
            // patient_birthdate
            // 
            this.patient_birthdate.Location = new System.Drawing.Point(347, 133);
            this.patient_birthdate.Name = "patient_birthdate";
            this.patient_birthdate.Size = new System.Drawing.Size(142, 20);
            this.patient_birthdate.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 68;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 55;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(10, 170);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(95, 13);
            this.label40.TabIndex = 56;
            // 
            // Men
            // 
            this.Men.AutoSize = true;
            this.Men.Location = new System.Drawing.Point(349, 27);
            this.Men.Name = "Men";
            this.Men.Size = new System.Drawing.Size(71, 17);
            this.Men.TabIndex = 3;
            this.Men.TabStop = true;
            this.Men.Text = "Мужской";
            this.Men.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 58;
            // 
            // Women
            // 
            this.Women.AutoSize = true;
            this.Women.Location = new System.Drawing.Point(423, 27);
            this.Women.Name = "Women";
            this.Women.Size = new System.Drawing.Size(72, 17);
            this.Women.TabIndex = 4;
            this.Women.TabStop = true;
            this.Women.Text = "Женский";
            this.Women.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(14, 187);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(146, 20);
            this.textBox5.TabIndex = 59;
            // 
            // patient_address
            // 
            this.patient_address.Location = new System.Drawing.Point(14, 187);
            this.patient_address.Name = "patient_address";
            this.patient_address.Size = new System.Drawing.Size(472, 20);
            this.patient_address.TabIndex = 7;
            // 
            // patient_reg_date
            // 
            this.patient_reg_date.Location = new System.Drawing.Point(347, 79);
            this.patient_reg_date.Name = "patient_reg_date";
            this.patient_reg_date.Size = new System.Drawing.Size(142, 20);
            this.patient_reg_date.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 63;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(12, 221);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(79, 13);
            this.label42.TabIndex = 64;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(13, 237);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(113, 20);
            this.textBox4.TabIndex = 65;
            // 
            // patient_work
            // 
            this.patient_work.Location = new System.Drawing.Point(13, 237);
            this.patient_work.Name = "patient_work";
            this.patient_work.Size = new System.Drawing.Size(473, 20);
            this.patient_work.TabIndex = 8;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(10, 267);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(114, 13);
            this.label43.TabIndex = 67;
            // 
            // patient_phone
            // 
            this.patient_phone.Location = new System.Drawing.Point(14, 288);
            this.patient_phone.Name = "patient_phone";
            this.patient_phone.Size = new System.Drawing.Size(137, 20);
            this.patient_phone.TabIndex = 9;
            // 
            // patient_Name
            // 
            this.patient_Name.Location = new System.Drawing.Point(174, 27);
            this.patient_Name.Name = "patient_Name";
            this.patient_Name.Size = new System.Drawing.Size(145, 20);
            this.patient_Name.TabIndex = 0;
            // 
            // patient_Surname
            // 
            this.patient_Surname.Location = new System.Drawing.Point(174, 79);
            this.patient_Surname.Name = "patient_Surname";
            this.patient_Surname.Size = new System.Drawing.Size(145, 20);
            this.patient_Surname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(174, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 77;
            // 
            // patient_Lastname
            // 
            this.patient_Lastname.Location = new System.Drawing.Point(175, 133);
            this.patient_Lastname.Name = "patient_Lastname";
            this.patient_Lastname.Size = new System.Drawing.Size(145, 20);
            this.patient_Lastname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 79;
            // 
            // patient_email
            // 
            this.patient_email.Location = new System.Drawing.Point(182, 288);
            this.patient_email.Name = "patient_email";
            this.patient_email.Size = new System.Drawing.Size(137, 20);
            this.patient_email.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 81;
            // 
            // patient_social
            // 
            this.patient_social.Location = new System.Drawing.Point(346, 288);
            this.patient_social.Name = "patient_social";
            this.patient_social.Size = new System.Drawing.Size(140, 20);
            this.patient_social.TabIndex = 11;
            // 
            // common
            // 
            this.common.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(250)))), ((int)(((byte)(214)))));
            this.common.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.common.Controls.Add(this.w);
            this.common.Controls.Add(this.m);
            this.common.Controls.Add(this.label24);
            this.common.Controls.Add(this.label23);
            this.common.Controls.Add(this.label22);
            this.common.Controls.Add(this.label21);
            this.common.Controls.Add(this.label18);
            this.common.Controls.Add(this.label17);
            this.common.Controls.Add(this.label16);
            this.common.Controls.Add(this.label15);
            this.common.Controls.Add(this.label14);
            this.common.Controls.Add(this.label7);
            this.common.Controls.Add(this.Regnamer);
            this.common.Controls.Add(this.Birthnamer);
            this.common.Controls.Add(this.Prof);
            this.common.Controls.Add(this.Socialnamer);
            this.common.Controls.Add(this.Emailnamer);
            this.common.Controls.Add(this.Adnamer);
            this.common.Controls.Add(this.Worknamer);
            this.common.Controls.Add(this.Lastnamer);
            this.common.Controls.Add(this.Sunamer);
            this.common.Controls.Add(this.Namer);
            this.common.Controls.Add(this.Phonenamer);
            this.common.Location = new System.Drawing.Point(12, 12);
            this.common.Name = "common";
            this.common.Size = new System.Drawing.Size(504, 328);
            this.common.TabIndex = 62;
            // 
            // w
            // 
            this.w.AutoSize = true;
            this.w.Location = new System.Drawing.Point(407, 30);
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(72, 17);
            this.w.TabIndex = 5;
            this.w.TabStop = true;
            this.w.Text = "Женский";
            this.w.UseVisualStyleBackColor = true;
            // 
            // m
            // 
            this.m.AutoSize = true;
            this.m.Location = new System.Drawing.Point(296, 30);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(71, 17);
            this.m.TabIndex = 4;
            this.m.TabStop = true;
            this.m.Text = "Мужской";
            this.m.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(293, 268);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 13);
            this.label24.TabIndex = 20;
            this.label24.Text = "Социальные сети";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(163, 268);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Email";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 268);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "Контактный телефон";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 216);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Место работы";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 163);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Домашний адрес";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(293, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Дата регстрации";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(293, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Дата рождения";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(163, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Отчество";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(163, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Фамилия";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Имя";
            // 
            // Regnamer
            // 
            this.Regnamer.Location = new System.Drawing.Point(296, 130);
            this.Regnamer.Name = "Regnamer";
            this.Regnamer.Size = new System.Drawing.Size(183, 20);
            this.Regnamer.TabIndex = 7;
            // 
            // Birthnamer
            // 
            this.Birthnamer.Location = new System.Drawing.Point(296, 80);
            this.Birthnamer.Name = "Birthnamer";
            this.Birthnamer.Size = new System.Drawing.Size(183, 20);
            this.Birthnamer.TabIndex = 6;
            // 
            // Prof
            // 
            this.Prof.Image = ((System.Drawing.Image)(resources.GetObject("Prof.Image")));
            this.Prof.Location = new System.Drawing.Point(20, 15);
            this.Prof.Name = "Prof";
            this.Prof.Size = new System.Drawing.Size(124, 135);
            this.Prof.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Prof.TabIndex = 8;
            this.Prof.TabStop = false;
            this.Prof.Click += new System.EventHandler(this.Prof_Click_1);
            // 
            // Socialnamer
            // 
            this.Socialnamer.Location = new System.Drawing.Point(296, 284);
            this.Socialnamer.Name = "Socialnamer";
            this.Socialnamer.Size = new System.Drawing.Size(183, 20);
            this.Socialnamer.TabIndex = 12;
            // 
            // Emailnamer
            // 
            this.Emailnamer.Location = new System.Drawing.Point(166, 284);
            this.Emailnamer.Name = "Emailnamer";
            this.Emailnamer.Size = new System.Drawing.Size(111, 20);
            this.Emailnamer.TabIndex = 11;
            // 
            // Adnamer
            // 
            this.Adnamer.Location = new System.Drawing.Point(20, 179);
            this.Adnamer.Name = "Adnamer";
            this.Adnamer.Size = new System.Drawing.Size(459, 20);
            this.Adnamer.TabIndex = 8;
            // 
            // Worknamer
            // 
            this.Worknamer.Location = new System.Drawing.Point(20, 232);
            this.Worknamer.Name = "Worknamer";
            this.Worknamer.Size = new System.Drawing.Size(459, 20);
            this.Worknamer.TabIndex = 9;
            // 
            // Lastnamer
            // 
            this.Lastnamer.Location = new System.Drawing.Point(166, 130);
            this.Lastnamer.Name = "Lastnamer";
            this.Lastnamer.Size = new System.Drawing.Size(111, 20);
            this.Lastnamer.TabIndex = 3;
            // 
            // Sunamer
            // 
            this.Sunamer.Location = new System.Drawing.Point(166, 79);
            this.Sunamer.Name = "Sunamer";
            this.Sunamer.Size = new System.Drawing.Size(111, 20);
            this.Sunamer.TabIndex = 2;
            // 
            // Namer
            // 
            this.Namer.Location = new System.Drawing.Point(166, 29);
            this.Namer.Name = "Namer";
            this.Namer.Size = new System.Drawing.Size(111, 20);
            this.Namer.TabIndex = 1;
            // 
            // Phonenamer
            // 
            this.Phonenamer.Location = new System.Drawing.Point(20, 284);
            this.Phonenamer.Name = "Phonenamer";
            this.Phonenamer.Size = new System.Drawing.Size(111, 20);
            this.Phonenamer.TabIndex = 10;
            // 
            // UserImage
            // 
            this.UserImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserImage.Image = ((System.Drawing.Image)(resources.GetObject("UserImage.Image")));
            this.UserImage.Location = new System.Drawing.Point(13, 14);
            this.UserImage.Name = "UserImage";
            this.UserImage.Size = new System.Drawing.Size(138, 139);
            this.UserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserImage.TabIndex = 72;
            this.UserImage.TabStop = false;
            this.UserImage.Click += new System.EventHandler(this.UserImage_Click);
            // 
            // Patient_ADD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(532, 389);
            this.Controls.Add(this.common);
            this.Controls.Add(this.Forward);
            this.MaximizeBox = false;
            this.Name = "Patient_ADD";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Регистрация нового пациента";
            this.common.ResumeLayout(false);
            this.common.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Prof)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker patient_birthdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.RadioButton Men;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton Women;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox patient_address;
        private System.Windows.Forms.DateTimePicker patient_reg_date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox patient_work;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox patient_phone;
        private System.Windows.Forms.PictureBox UserImage;
        private System.Windows.Forms.TextBox patient_Name;
        private System.Windows.Forms.TextBox patient_Surname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox patient_Lastname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox patient_email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox patient_social;
        private System.Windows.Forms.Panel common;
        private System.Windows.Forms.RadioButton w;
        private System.Windows.Forms.RadioButton m;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker Regnamer;
        private System.Windows.Forms.DateTimePicker Birthnamer;
        private System.Windows.Forms.PictureBox Prof;
        private System.Windows.Forms.TextBox Socialnamer;
        private System.Windows.Forms.TextBox Emailnamer;
        private System.Windows.Forms.TextBox Adnamer;
        private System.Windows.Forms.TextBox Worknamer;
        private System.Windows.Forms.TextBox Lastnamer;
        private System.Windows.Forms.TextBox Sunamer;
        private System.Windows.Forms.TextBox Namer;
        private System.Windows.Forms.TextBox Phonenamer;

    }
}