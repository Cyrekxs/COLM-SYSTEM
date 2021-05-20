namespace COLM_SYSTEM.Curriculum_Folder
{
    partial class frm_duplicate_entry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCourseStrand = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurriculumCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNoofSubjects = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNoofSubjects);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbCourseStrand);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCurriculumCode);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbEducationLevel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 419);
            this.panel1.TabIndex = 1;
            // 
            // cmbCourseStrand
            // 
            this.cmbCourseStrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseStrand.FormattingEnabled = true;
            this.cmbCourseStrand.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbCourseStrand.Location = new System.Drawing.Point(12, 69);
            this.cmbCourseStrand.Name = "cmbCourseStrand";
            this.cmbCourseStrand.Size = new System.Drawing.Size(263, 23);
            this.cmbCourseStrand.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Course / Strand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // txtCurriculumCode
            // 
            this.txtCurriculumCode.Location = new System.Drawing.Point(12, 113);
            this.txtCurriculumCode.Name = "txtCurriculumCode";
            this.txtCurriculumCode.Size = new System.Drawing.Size(263, 23);
            this.txtCurriculumCode.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 157);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(263, 120);
            this.txtDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Curriculum Code";
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(12, 26);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(263, 23);
            this.cmbEducationLevel.TabIndex = 5;
            this.cmbEducationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbEducationLevel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Education Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "No of subject to save in this curriulum";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(123, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "PROCESS";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtNoofSubjects
            // 
            this.txtNoofSubjects.Location = new System.Drawing.Point(12, 307);
            this.txtNoofSubjects.Name = "txtNoofSubjects";
            this.txtNoofSubjects.ReadOnly = true;
            this.txtNoofSubjects.Size = new System.Drawing.Size(263, 23);
            this.txtNoofSubjects.TabIndex = 10;
            // 
            // frm_duplicate_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 519);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_duplicate_entry";
            this.Text = "CURRICULUM DUPLICATE";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCourseStrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurriculumCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoofSubjects;
        private System.Windows.Forms.Button button1;
    }
}