namespace COLM_SYSTEM.registration
{
    partial class frm_registration_entry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLRN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbRegistrationStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCurriculum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txtStudentName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLRN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STUDENT INFORMATION";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(437, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "BROWSE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(151, 51);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(280, 24);
            this.txtStudentName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "STUDENT NAME";
            // 
            // txtLRN
            // 
            this.txtLRN.Location = new System.Drawing.Point(19, 51);
            this.txtLRN.Name = "txtLRN";
            this.txtLRN.ReadOnly = true;
            this.txtLRN.Size = new System.Drawing.Size(126, 24);
            this.txtLRN.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "LRN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbRegistrationStatus);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbCurriculum);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cmbEducationLevel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 293);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "REGISTRATION INFO";
            // 
            // cmbRegistrationStatus
            // 
            this.cmbRegistrationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegistrationStatus.FormattingEnabled = true;
            this.cmbRegistrationStatus.Items.AddRange(new object[] {
            "OLD STUDENT",
            "NEW STUDENT",
            "TRANSFEREE"});
            this.cmbRegistrationStatus.Location = new System.Drawing.Point(19, 155);
            this.cmbRegistrationStatus.Name = "cmbRegistrationStatus";
            this.cmbRegistrationStatus.Size = new System.Drawing.Size(258, 25);
            this.cmbRegistrationStatus.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "REGISTRATION STATUS";
            // 
            // cmbCurriculum
            // 
            this.cmbCurriculum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurriculum.FormattingEnabled = true;
            this.cmbCurriculum.Location = new System.Drawing.Point(19, 107);
            this.cmbCurriculum.Name = "cmbCurriculum";
            this.cmbCurriculum.Size = new System.Drawing.Size(258, 25);
            this.cmbCurriculum.TabIndex = 10;
            this.cmbCurriculum.SelectedIndexChanged += new System.EventHandler(this.cmbCurriculum_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "CURRICULUM";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "REGISTER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(19, 59);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(258, 25);
            this.cmbEducationLevel.TabIndex = 3;
            this.cmbEducationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbEducationLevel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "EDUCATION LEVEL";
            // 
            // frm_registration_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 420);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_registration_entry";
            this.Text = "REGISTRATION ENTRY";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLRN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbCurriculum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRegistrationStatus;
    }
}