namespace Denta_Pro
{
    partial class Patient_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient_Edit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Patient = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.PatientImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Patient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(250)))), ((int)(((byte)(214)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PatientImage);
            this.panel1.Controls.Add(this.Patient);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 269);
            this.panel1.TabIndex = 2;
            // 
            // Patient
            // 
            this.Patient.AllowUserToAddRows = false;
            this.Patient.AllowUserToDeleteRows = false;
            this.Patient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Patient.Location = new System.Drawing.Point(232, 16);
            this.Patient.Name = "Patient";
            this.Patient.Size = new System.Drawing.Size(363, 200);
            this.Patient.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Сохранить изменения";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PatientImage
            // 
            this.PatientImage.Image = ((System.Drawing.Image)(resources.GetObject("PatientImage.Image")));
            this.PatientImage.Location = new System.Drawing.Point(13, 16);
            this.PatientImage.Name = "PatientImage";
            this.PatientImage.Size = new System.Drawing.Size(196, 200);
            this.PatientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PatientImage.TabIndex = 9;
            this.PatientImage.TabStop = false;
            this.PatientImage.Click += new System.EventHandler(this.PatientImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Patient_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 292);
            this.Controls.Add(this.panel1);
            this.Name = "Patient_Edit";
            this.Text = "Редактирование данных пациента";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Patient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Patient;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox PatientImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}