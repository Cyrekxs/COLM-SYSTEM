namespace COLM_SYSTEM.Assessment_Folder
{
    partial class uc_assessment_list
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.clmAssessmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegisteredStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEducationLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourseStrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReAssess = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAssessmentID,
            this.clmRegisteredStudentID,
            this.clmLRN,
            this.clmStudentName,
            this.clmEducationLevel,
            this.clmCourseStrand,
            this.clmYearLevel,
            this.clmTotalDue,
            this.clmAssessmentType,
            this.clmAssessor,
            this.clmAssessmentDate,
            this.clmReAssess,
            this.clmPrint,
            this.clmRemove});
            this.dataGridView1.Location = new System.Drawing.Point(9, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1019, 469);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(685, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search | Student Name or LRN";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(688, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(880, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter";
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEducationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationLevel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "ALL",
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(883, 16);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(145, 23);
            this.cmbEducationLevel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 35);
            this.button1.TabIndex = 21;
            this.button1.Text = "NEW ASSESSMENT ENTRY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbEducationLevel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 44);
            this.panel1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "ASSESSMENT LIST";
            // 
            // clmAssessmentID
            // 
            this.clmAssessmentID.HeaderText = "AssessmentID";
            this.clmAssessmentID.Name = "clmAssessmentID";
            this.clmAssessmentID.ReadOnly = true;
            this.clmAssessmentID.Visible = false;
            // 
            // clmRegisteredStudentID
            // 
            this.clmRegisteredStudentID.HeaderText = "RegisteredStudentID";
            this.clmRegisteredStudentID.Name = "clmRegisteredStudentID";
            this.clmRegisteredStudentID.ReadOnly = true;
            this.clmRegisteredStudentID.Visible = false;
            // 
            // clmLRN
            // 
            this.clmLRN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmLRN.HeaderText = "LRN";
            this.clmLRN.Name = "clmLRN";
            this.clmLRN.ReadOnly = true;
            this.clmLRN.Width = 52;
            // 
            // clmStudentName
            // 
            this.clmStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmStudentName.HeaderText = "Student Name";
            this.clmStudentName.Name = "clmStudentName";
            this.clmStudentName.ReadOnly = true;
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
            this.clmCourseStrand.HeaderText = "Course / Strand";
            this.clmCourseStrand.Name = "clmCourseStrand";
            this.clmCourseStrand.ReadOnly = true;
            this.clmCourseStrand.Width = 120;
            // 
            // clmYearLevel
            // 
            this.clmYearLevel.HeaderText = "Year Level";
            this.clmYearLevel.Name = "clmYearLevel";
            this.clmYearLevel.ReadOnly = true;
            this.clmYearLevel.Width = 85;
            // 
            // clmTotalDue
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmTotalDue.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmTotalDue.HeaderText = "Total Due";
            this.clmTotalDue.Name = "clmTotalDue";
            this.clmTotalDue.ReadOnly = true;
            this.clmTotalDue.Width = 85;
            // 
            // clmAssessmentType
            // 
            this.clmAssessmentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmAssessmentType.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmAssessmentType.HeaderText = "Assessment";
            this.clmAssessmentType.Name = "clmAssessmentType";
            this.clmAssessmentType.ReadOnly = true;
            this.clmAssessmentType.Width = 96;
            // 
            // clmAssessor
            // 
            this.clmAssessor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAssessor.HeaderText = "Assessor";
            this.clmAssessor.Name = "clmAssessor";
            this.clmAssessor.ReadOnly = true;
            this.clmAssessor.Width = 81;
            // 
            // clmAssessmentDate
            // 
            this.clmAssessmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAssessmentDate.HeaderText = "Date";
            this.clmAssessmentDate.Name = "clmAssessmentDate";
            this.clmAssessmentDate.ReadOnly = true;
            this.clmAssessmentDate.Width = 57;
            // 
            // clmReAssess
            // 
            this.clmReAssess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmReAssess.HeaderText = "Re-Assess";
            this.clmReAssess.Name = "clmReAssess";
            this.clmReAssess.ReadOnly = true;
            this.clmReAssess.Text = "Re-Assess";
            this.clmReAssess.UseColumnTextForButtonValue = true;
            this.clmReAssess.Width = 67;
            // 
            // clmPrint
            // 
            this.clmPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmPrint.HeaderText = "Report";
            this.clmPrint.Name = "clmPrint";
            this.clmPrint.ReadOnly = true;
            this.clmPrint.Text = "Print";
            this.clmPrint.UseColumnTextForButtonValue = true;
            this.clmPrint.Width = 49;
            // 
            // clmRemove
            // 
            this.clmRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmRemove.HeaderText = "Remove";
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.ReadOnly = true;
            this.clmRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmRemove.Text = "Remove";
            this.clmRemove.UseColumnTextForButtonValue = true;
            this.clmRemove.Width = 74;
            // 
            // uc_assessment_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "uc_assessment_list";
            this.Size = new System.Drawing.Size(1035, 564);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegisteredStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEducationLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourseStrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentDate;
        private System.Windows.Forms.DataGridViewButtonColumn clmReAssess;
        private System.Windows.Forms.DataGridViewButtonColumn clmPrint;
        private System.Windows.Forms.DataGridViewButtonColumn clmRemove;
    }
}
