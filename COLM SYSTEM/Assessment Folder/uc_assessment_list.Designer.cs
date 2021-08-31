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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmAssessmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegisteredStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEducationLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourseStrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEnrollmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emailStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAssessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reAssessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAssessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.clmPaymentMode,
            this.clmAssessor,
            this.clmAssessmentDate,
            this.clmEnrollmentStatus,
            this.clmAction});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(9, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1196, 443);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.clmEducationLevel.HeaderText = "Education Level";
            this.clmEducationLevel.Name = "clmEducationLevel";
            this.clmEducationLevel.ReadOnly = true;
            this.clmEducationLevel.Width = 106;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmTotalDue.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmTotalDue.HeaderText = "Total Due";
            this.clmTotalDue.Name = "clmTotalDue";
            this.clmTotalDue.ReadOnly = true;
            this.clmTotalDue.Width = 85;
            // 
            // clmPaymentMode
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPaymentMode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmPaymentMode.HeaderText = "Payment Mode";
            this.clmPaymentMode.Name = "clmPaymentMode";
            this.clmPaymentMode.ReadOnly = true;
            this.clmPaymentMode.Width = 115;
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
            // clmEnrollmentStatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmEnrollmentStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmEnrollmentStatus.HeaderText = "Enrollment Status";
            this.clmEnrollmentStatus.Name = "clmEnrollmentStatus";
            this.clmEnrollmentStatus.ReadOnly = true;
            this.clmEnrollmentStatus.Width = 130;
            // 
            // clmAction
            // 
            this.clmAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmAction.HeaderText = "Action";
            this.clmAction.Image = global::SEMS.Properties.Resources.Data;
            this.clmAction.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clmAction.Name = "clmAction";
            this.clmAction.ReadOnly = true;
            this.clmAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAction.Width = 66;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(869, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search | Student Name or LRN";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(872, 14);
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
            this.label2.Location = new System.Drawing.Point(716, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter : Education level";
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEducationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationLevel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "All",
            "Pre Elementary",
            "Elementary",
            "Junior High",
            "Senior High",
            "College"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(719, 14);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(145, 23);
            this.cmbEducationLevel.TabIndex = 4;
            this.cmbEducationLevel.SelectionChangeCommitted += new System.EventHandler(this.cmbEducationLevel_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1067, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 30);
            this.button1.TabIndex = 21;
            this.button1.Text = "+ NEW ASSESSMENT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmbEducationLevel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 40);
            this.panel1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "MASTER LIST OF STUDENT ASSESSMENT";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(721, 522);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(484, 30);
            this.lblCount.TabIndex = 25;
            this.lblCount.Text = "Record Count(s) :";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailStudentToolStripMenuItem,
            this.printAssessmentToolStripMenuItem,
            this.reAssessToolStripMenuItem,
            this.removeAssessmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 132);
            // 
            // emailStudentToolStripMenuItem
            // 
            this.emailStudentToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailStudentToolStripMenuItem.Image = global::SEMS.Properties.Resources.Send;
            this.emailStudentToolStripMenuItem.Name = "emailStudentToolStripMenuItem";
            this.emailStudentToolStripMenuItem.Size = new System.Drawing.Size(191, 32);
            this.emailStudentToolStripMenuItem.Text = "Email Student";
            this.emailStudentToolStripMenuItem.Click += new System.EventHandler(this.emailStudentToolStripMenuItem_ClickAsync);
            // 
            // printAssessmentToolStripMenuItem
            // 
            this.printAssessmentToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.printAssessmentToolStripMenuItem.Image = global::SEMS.Properties.Resources.Print;
            this.printAssessmentToolStripMenuItem.Name = "printAssessmentToolStripMenuItem";
            this.printAssessmentToolStripMenuItem.Size = new System.Drawing.Size(191, 32);
            this.printAssessmentToolStripMenuItem.Text = "Print Assessment";
            this.printAssessmentToolStripMenuItem.Click += new System.EventHandler(this.printAssessmentToolStripMenuItem_Click);
            // 
            // reAssessToolStripMenuItem
            // 
            this.reAssessToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reAssessToolStripMenuItem.Image = global::SEMS.Properties.Resources.Document_Edit;
            this.reAssessToolStripMenuItem.Name = "reAssessToolStripMenuItem";
            this.reAssessToolStripMenuItem.Size = new System.Drawing.Size(191, 32);
            this.reAssessToolStripMenuItem.Text = "View / Reassess";
            this.reAssessToolStripMenuItem.Click += new System.EventHandler(this.reAssessToolStripMenuItem_Click);
            // 
            // removeAssessmentToolStripMenuItem
            // 
            this.removeAssessmentToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeAssessmentToolStripMenuItem.Image = global::SEMS.Properties.Resources.Document_Delete;
            this.removeAssessmentToolStripMenuItem.Name = "removeAssessmentToolStripMenuItem";
            this.removeAssessmentToolStripMenuItem.Size = new System.Drawing.Size(191, 32);
            this.removeAssessmentToolStripMenuItem.Text = "Remove Assessment";
            this.removeAssessmentToolStripMenuItem.Click += new System.EventHandler(this.removeAssessmentToolStripMenuItem_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewImageColumn1.HeaderText = "Action";
            this.dataGridViewImageColumn1.Image = global::SEMS.Properties.Resources.Data;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.ForeColor = System.Drawing.Color.Red;
            this.lblTotalRecords.Location = new System.Drawing.Point(10, 43);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(491, 30);
            this.lblTotalRecords.TabIndex = 26;
            this.lblTotalRecords.Text = "The sort function is modified by assessment date then by student name for optimiz" +
    "ation";
            this.lblTotalRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uc_assessment_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "uc_assessment_list";
            this.Size = new System.Drawing.Size(1212, 564);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printAssessmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reAssessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAssessmentToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegisteredStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEducationLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourseStrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEnrollmentStatus;
        private System.Windows.Forms.DataGridViewImageColumn clmAction;
        private System.Windows.Forms.Label lblTotalRecords;
    }
}
