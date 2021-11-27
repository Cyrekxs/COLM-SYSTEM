namespace COLM_SYSTEM.Payment_Folder
{
    partial class uc_payers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmAssessmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegisteredStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEducationLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourseStrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewImageColumn();
            this.viewAssessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAssessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.cmbEducationLevel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panelLoading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1117, 43);
            this.panel1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(177, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "LIST OF ASSESSED STUDENTS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cmbEducationLevel.Location = new System.Drawing.Point(770, 14);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(145, 23);
            this.cmbEducationLevel.TabIndex = 4;
            this.cmbEducationLevel.SelectionChangeCommitted += new System.EventHandler(this.cmbEducationLevel_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(918, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search | Student Name or LRN";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(921, 14);
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
            this.label2.Location = new System.Drawing.Point(767, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle51.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle51;
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
            this.clmStatus,
            this.clmTotalDue,
            this.clmPaid,
            this.clmBalance,
            this.clmAssessor,
            this.clmAssessmentDate,
            this.clmAction});
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle55;
            this.dataGridView1.Location = new System.Drawing.Point(13, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 646);
            this.dataGridView1.TabIndex = 24;
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
            // clmStatus
            // 
            this.clmStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmStatus.HeaderText = "Enrollment Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Width = 118;
            // 
            // clmTotalDue
            // 
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmTotalDue.DefaultCellStyle = dataGridViewCellStyle52;
            this.clmTotalDue.HeaderText = "Amount Due";
            this.clmTotalDue.Name = "clmTotalDue";
            this.clmTotalDue.ReadOnly = true;
            this.clmTotalDue.Width = 85;
            // 
            // clmPaid
            // 
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmPaid.DefaultCellStyle = dataGridViewCellStyle53;
            this.clmPaid.HeaderText = "Credit";
            this.clmPaid.Name = "clmPaid";
            this.clmPaid.ReadOnly = true;
            // 
            // clmBalance
            // 
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmBalance.DefaultCellStyle = dataGridViewCellStyle54;
            this.clmBalance.HeaderText = "Receivables";
            this.clmBalance.Name = "clmBalance";
            this.clmBalance.ReadOnly = true;
            // 
            // clmAssessor
            // 
            this.clmAssessor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAssessor.HeaderText = "Assesor";
            this.clmAssessor.Name = "clmAssessor";
            this.clmAssessor.ReadOnly = true;
            this.clmAssessor.Width = 75;
            // 
            // clmAssessmentDate
            // 
            this.clmAssessmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAssessmentDate.HeaderText = "Date";
            this.clmAssessmentDate.Name = "clmAssessmentDate";
            this.clmAssessmentDate.ReadOnly = true;
            this.clmAssessmentDate.Width = 57;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(605, 698);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(505, 30);
            this.lblCount.TabIndex = 28;
            this.lblCount.Text = "Record(s) : ";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAssessmentToolStripMenuItem,
            this.printAssessmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 68);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 43);
            this.label4.TabIndex = 5;
            this.label4.Text = "Loading data . . .";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Show Account";
            this.dataGridViewImageColumn1.Image = global::SEMS.Properties.Resources.Account;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmAction
            // 
            this.clmAction.HeaderText = "Action";
            this.clmAction.Image = global::SEMS.Properties.Resources.Data;
            this.clmAction.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clmAction.Name = "clmAction";
            this.clmAction.ReadOnly = true;
            this.clmAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // viewAssessmentToolStripMenuItem
            // 
            this.viewAssessmentToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewAssessmentToolStripMenuItem.Image = global::SEMS.Properties.Resources.View;
            this.viewAssessmentToolStripMenuItem.Name = "viewAssessmentToolStripMenuItem";
            this.viewAssessmentToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.viewAssessmentToolStripMenuItem.Text = "View Account";
            this.viewAssessmentToolStripMenuItem.Click += new System.EventHandler(this.viewAssessmentToolStripMenuItem_Click);
            // 
            // printAssessmentToolStripMenuItem
            // 
            this.printAssessmentToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.printAssessmentToolStripMenuItem.Image = global::SEMS.Properties.Resources.Print;
            this.printAssessmentToolStripMenuItem.Name = "printAssessmentToolStripMenuItem";
            this.printAssessmentToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.printAssessmentToolStripMenuItem.Text = "Print SOA";
            this.printAssessmentToolStripMenuItem.Click += new System.EventHandler(this.printAssessmentToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::SEMS.Properties.Resources.buffering;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.label4);
            this.panelLoading.Controls.Add(this.pictureBox1);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLoading.Location = new System.Drawing.Point(10, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(167, 43);
            this.panelLoading.TabIndex = 29;
            // 
            // uc_payers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "uc_payers";
            this.Size = new System.Drawing.Size(1117, 737);
            this.Load += new System.EventHandler(this.uc_payers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAssessmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAssessmentToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegisteredStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEducationLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourseStrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentDate;
        private System.Windows.Forms.DataGridViewImageColumn clmAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLoading;
    }
}
