namespace COLM_SYSTEM.Assessment_Folder
{
    partial class frm_assessment_old_peeker
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.txtYearLevel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCourseStrand = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEducationlevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalDue = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clmSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSemester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmView = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "List of Assessment in 2020-2021";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSchoolYear,
            this.clmSemester,
            this.clmDate,
            this.clmView});
            this.dataGridView1.Location = new System.Drawing.Point(15, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(400, 139);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assessment Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.txtDiscountAmount);
            this.panel1.Controls.Add(this.txtYearLevel);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtCourseStrand);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtEducationlevel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTotalDue);
            this.panel1.Controls.Add(this.txtStudentName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(15, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 286);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCancel.Location = new System.Drawing.Point(257, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 36);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtDiscountAmount.Location = new System.Drawing.Point(16, 131);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(357, 23);
            this.txtDiscountAmount.TabIndex = 19;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtYearLevel
            // 
            this.txtYearLevel.BackColor = System.Drawing.SystemColors.Control;
            this.txtYearLevel.Location = new System.Drawing.Point(258, 73);
            this.txtYearLevel.Name = "txtYearLevel";
            this.txtYearLevel.ReadOnly = true;
            this.txtYearLevel.Size = new System.Drawing.Size(115, 23);
            this.txtYearLevel.TabIndex = 18;
            this.txtYearLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(255, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Year Level";
            // 
            // txtCourseStrand
            // 
            this.txtCourseStrand.BackColor = System.Drawing.SystemColors.Control;
            this.txtCourseStrand.Location = new System.Drawing.Point(137, 73);
            this.txtCourseStrand.Name = "txtCourseStrand";
            this.txtCourseStrand.ReadOnly = true;
            this.txtCourseStrand.Size = new System.Drawing.Size(115, 23);
            this.txtCourseStrand.TabIndex = 16;
            this.txtCourseStrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(134, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Course / Strand";
            // 
            // txtEducationlevel
            // 
            this.txtEducationlevel.BackColor = System.Drawing.SystemColors.Control;
            this.txtEducationlevel.Location = new System.Drawing.Point(16, 73);
            this.txtEducationlevel.Name = "txtEducationlevel";
            this.txtEducationlevel.ReadOnly = true;
            this.txtEducationlevel.Size = new System.Drawing.Size(115, 23);
            this.txtEducationlevel.TabIndex = 14;
            this.txtEducationlevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Education Level";
            // 
            // txtTotalDue
            // 
            this.txtTotalDue.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalDue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDue.Location = new System.Drawing.Point(16, 179);
            this.txtTotalDue.Name = "txtTotalDue";
            this.txtTotalDue.ReadOnly = true;
            this.txtTotalDue.Size = new System.Drawing.Size(356, 31);
            this.txtTotalDue.TabIndex = 11;
            this.txtTotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStudentName
            // 
            this.txtStudentName.BackColor = System.Drawing.SystemColors.Control;
            this.txtStudentName.Location = new System.Drawing.Point(16, 29);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(357, 23);
            this.txtStudentName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Total Due";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Discount Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Student Name";
            // 
            // clmSchoolYear
            // 
            this.clmSchoolYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSchoolYear.HeaderText = "School Year";
            this.clmSchoolYear.Name = "clmSchoolYear";
            this.clmSchoolYear.ReadOnly = true;
            this.clmSchoolYear.Width = 95;
            // 
            // clmSemester
            // 
            this.clmSemester.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSemester.HeaderText = "Semester";
            this.clmSemester.Name = "clmSemester";
            this.clmSemester.ReadOnly = true;
            this.clmSemester.Width = 81;
            // 
            // clmDate
            // 
            this.clmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDate.HeaderText = "Date";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            this.clmDate.Width = 57;
            // 
            // clmView
            // 
            this.clmView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmView.HeaderText = "View";
            this.clmView.Name = "clmView";
            this.clmView.ReadOnly = true;
            this.clmView.Text = "View";
            this.clmView.UseColumnTextForButtonValue = true;
            this.clmView.Width = 39;
            // 
            // frm_assessment_old_peeker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 482);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_assessment_old_peeker";
            this.Text = "OLD ASSESSMENT PEEKER";
            this.Load += new System.EventHandler(this.frm_assessment_old_peeker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalDue;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtCourseStrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEducationlevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYearLevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSemester;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewButtonColumn clmView;
    }
}