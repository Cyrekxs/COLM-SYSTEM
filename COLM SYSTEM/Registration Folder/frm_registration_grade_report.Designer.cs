namespace SEMS.Registration_Folder
{
    partial class frm_registration_grade_report
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clmCurriculumSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 79);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quijano Anthony Ramos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "BSIT 2019-2020";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 386);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCurriculumSubjectID,
            this.clmSubjectCode,
            this.clmSubjectDesc,
            this.clmUnits});
            this.dataGridView1.Location = new System.Drawing.Point(19, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(868, 296);
            this.dataGridView1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "School Year";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2021-2022",
            "2022-2023",
            "2023-2024",
            "2024-2025",
            "2025-2026"});
            this.comboBox1.Location = new System.Drawing.Point(91, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester"});
            this.comboBox2.Location = new System.Drawing.Point(336, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(173, 23);
            this.comboBox2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Semester";
            // 
            // clmCurriculumSubjectID
            // 
            this.clmCurriculumSubjectID.HeaderText = "Curriculum Subject ID";
            this.clmCurriculumSubjectID.Name = "clmCurriculumSubjectID";
            this.clmCurriculumSubjectID.ReadOnly = true;
            this.clmCurriculumSubjectID.Visible = false;
            // 
            // clmSubjectCode
            // 
            this.clmSubjectCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjectCode.HeaderText = "Subject Code";
            this.clmSubjectCode.Name = "clmSubjectCode";
            this.clmSubjectCode.ReadOnly = true;
            this.clmSubjectCode.Width = 102;
            // 
            // clmSubjectDesc
            // 
            this.clmSubjectDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSubjectDesc.HeaderText = "Description";
            this.clmSubjectDesc.Name = "clmSubjectDesc";
            this.clmSubjectDesc.ReadOnly = true;
            // 
            // clmUnits
            // 
            this.clmUnits.HeaderText = "Units";
            this.clmUnits.Name = "clmUnits";
            this.clmUnits.ReadOnly = true;
            // 
            // frm_registration_grade_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_registration_grade_report";
            this.Text = "Student Grade Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnits;
    }
}