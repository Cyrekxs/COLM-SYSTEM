namespace SEMS.Reports_Folder
{
    partial class frm_subject_masterlist_2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEducationLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourseStrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFaculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmScheduleID,
            this.clmSubjectCode,
            this.clmSubjectDesc,
            this.clmEducationLevel,
            this.clmCourseStrand,
            this.clmYearLevel,
            this.clmSchedule,
            this.clmFaculty});
            this.dataGridView1.Location = new System.Drawing.Point(13, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(909, 466);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmScheduleID
            // 
            this.clmScheduleID.HeaderText = "Schedule ID";
            this.clmScheduleID.Name = "clmScheduleID";
            this.clmScheduleID.ReadOnly = true;
            this.clmScheduleID.Visible = false;
            // 
            // clmSubjectCode
            // 
            this.clmSubjectCode.HeaderText = "Subject Code";
            this.clmSubjectCode.Name = "clmSubjectCode";
            this.clmSubjectCode.ReadOnly = true;
            // 
            // clmSubjectDesc
            // 
            this.clmSubjectDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjectDesc.HeaderText = "Description";
            this.clmSubjectDesc.Name = "clmSubjectDesc";
            this.clmSubjectDesc.ReadOnly = true;
            this.clmSubjectDesc.Width = 95;
            // 
            // clmEducationLevel
            // 
            this.clmEducationLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmEducationLevel.HeaderText = "Education";
            this.clmEducationLevel.Name = "clmEducationLevel";
            this.clmEducationLevel.ReadOnly = true;
            this.clmEducationLevel.Width = 86;
            // 
            // clmCourseStrand
            // 
            this.clmCourseStrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCourseStrand.HeaderText = "Course / Strand";
            this.clmCourseStrand.Name = "clmCourseStrand";
            this.clmCourseStrand.ReadOnly = true;
            this.clmCourseStrand.Width = 107;
            // 
            // clmYearLevel
            // 
            this.clmYearLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmYearLevel.HeaderText = "Year Level";
            this.clmYearLevel.Name = "clmYearLevel";
            this.clmYearLevel.ReadOnly = true;
            this.clmYearLevel.Width = 78;
            // 
            // clmSchedule
            // 
            this.clmSchedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSchedule.HeaderText = "Schedule";
            this.clmSchedule.Name = "clmSchedule";
            this.clmSchedule.ReadOnly = true;
            this.clmSchedule.Width = 81;
            // 
            // clmFaculty
            // 
            this.clmFaculty.HeaderText = "Faculty";
            this.clmFaculty.Name = "clmFaculty";
            this.clmFaculty.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(421, 23);
            this.textBox1.TabIndex = 2;
            // 
            // frm_subject_masterlist_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_subject_masterlist_2";
            this.Text = "Subject Masterlist";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEducationLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourseStrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFaculty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}