namespace COLM_SYSTEM.Curriculum_Folder
{
    partial class frm_curriculum_entry
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCourseStrand = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurriculumCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmCurriculumSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLecUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLabUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBridging = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmSemester = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iNSERTSUBJECTBELOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNSERTSUBJECTABOVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHANGESUBJECTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEMOVESUBJECTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLOSEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cmbDepartment);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbCourseStrand);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCurriculumCode);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbEducationLevel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 59);
            this.panel1.TabIndex = 0;
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
            this.cmbCourseStrand.Location = new System.Drawing.Point(308, 26);
            this.cmbCourseStrand.Name = "cmbCourseStrand";
            this.cmbCourseStrand.Size = new System.Drawing.Size(142, 23);
            this.cmbCourseStrand.TabIndex = 7;
            this.cmbCourseStrand.SelectedIndexChanged += new System.EventHandler(this.cmbCourseStrand_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Course / Strand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // txtCurriculumCode
            // 
            this.txtCurriculumCode.Location = new System.Drawing.Point(464, 26);
            this.txtCurriculumCode.Name = "txtCurriculumCode";
            this.txtCurriculumCode.Size = new System.Drawing.Size(164, 23);
            this.txtCurriculumCode.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(634, 26);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(320, 23);
            this.txtDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 8);
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
            this.cmbEducationLevel.Size = new System.Drawing.Size(142, 23);
            this.cmbEducationLevel.TabIndex = 5;
            this.cmbEducationLevel.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 491);
            this.panel2.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkSlateGray;
            this.linkLabel1.Location = new System.Drawing.Point(809, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(145, 15);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "+ Browse to Add Subjects";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.DarkSlateGray;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            this.clmCurriculumSubjectID,
            this.clmSubjectID,
            this.clmSubjCode,
            this.clmSubjDesc,
            this.clmLecUnit,
            this.clmLabUnit,
            this.clmTotalUnit,
            this.clmBridging,
            this.clmYearLevel,
            this.clmSemester,
            this.clmAction});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(942, 445);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // clmCurriculumSubjectID
            // 
            this.clmCurriculumSubjectID.HeaderText = "CurriculumSubjectID";
            this.clmCurriculumSubjectID.Name = "clmCurriculumSubjectID";
            this.clmCurriculumSubjectID.Visible = false;
            // 
            // clmSubjectID
            // 
            this.clmSubjectID.HeaderText = "Subject ID";
            this.clmSubjectID.Name = "clmSubjectID";
            this.clmSubjectID.Visible = false;
            // 
            // clmSubjCode
            // 
            this.clmSubjCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjCode.HeaderText = "Subject Code";
            this.clmSubjCode.Name = "clmSubjCode";
            this.clmSubjCode.ReadOnly = true;
            this.clmSubjCode.Width = 102;
            // 
            // clmSubjDesc
            // 
            this.clmSubjDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSubjDesc.HeaderText = "Description";
            this.clmSubjDesc.Name = "clmSubjDesc";
            this.clmSubjDesc.ReadOnly = true;
            // 
            // clmLecUnit
            // 
            this.clmLecUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLecUnit.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmLecUnit.HeaderText = "Lec Unit";
            this.clmLecUnit.Name = "clmLecUnit";
            this.clmLecUnit.ReadOnly = true;
            this.clmLecUnit.Width = 75;
            // 
            // clmLabUnit
            // 
            this.clmLabUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLabUnit.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmLabUnit.HeaderText = "Lab Unit";
            this.clmLabUnit.Name = "clmLabUnit";
            this.clmLabUnit.ReadOnly = true;
            this.clmLabUnit.Width = 77;
            // 
            // clmTotalUnit
            // 
            this.clmTotalUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmTotalUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmTotalUnit.HeaderText = "Total";
            this.clmTotalUnit.Name = "clmTotalUnit";
            this.clmTotalUnit.ReadOnly = true;
            this.clmTotalUnit.Width = 59;
            // 
            // clmBridging
            // 
            this.clmBridging.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmBridging.HeaderText = "Bridging";
            this.clmBridging.Name = "clmBridging";
            this.clmBridging.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmBridging.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmBridging.Width = 78;
            // 
            // clmYearLevel
            // 
            this.clmYearLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmYearLevel.HeaderText = "Year Level";
            this.clmYearLevel.Name = "clmYearLevel";
            this.clmYearLevel.Width = 66;
            // 
            // clmSemester
            // 
            this.clmSemester.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSemester.HeaderText = "Semester";
            this.clmSemester.Name = "clmSemester";
            this.clmSemester.Width = 62;
            // 
            // clmAction
            // 
            this.clmAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAction.ContextMenuStrip = this.contextMenuStrip1;
            this.clmAction.HeaderText = "Action";
            this.clmAction.Name = "clmAction";
            this.clmAction.Text = "Action";
            this.clmAction.UseColumnTextForButtonValue = true;
            this.clmAction.Width = 47;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNSERTSUBJECTBELOWToolStripMenuItem,
            this.iNSERTSUBJECTABOVEToolStripMenuItem,
            this.cHANGESUBJECTToolStripMenuItem,
            this.rEMOVESUBJECTToolStripMenuItem,
            this.cLOSEToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 114);
            // 
            // iNSERTSUBJECTBELOWToolStripMenuItem
            // 
            this.iNSERTSUBJECTBELOWToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.iNSERTSUBJECTBELOWToolStripMenuItem.Name = "iNSERTSUBJECTBELOWToolStripMenuItem";
            this.iNSERTSUBJECTBELOWToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.iNSERTSUBJECTBELOWToolStripMenuItem.Text = "Insert Subject Below";
            this.iNSERTSUBJECTBELOWToolStripMenuItem.Click += new System.EventHandler(this.iNSERTSUBJECTBELOWToolStripMenuItem_Click);
            // 
            // iNSERTSUBJECTABOVEToolStripMenuItem
            // 
            this.iNSERTSUBJECTABOVEToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.iNSERTSUBJECTABOVEToolStripMenuItem.Name = "iNSERTSUBJECTABOVEToolStripMenuItem";
            this.iNSERTSUBJECTABOVEToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.iNSERTSUBJECTABOVEToolStripMenuItem.Text = "Insert Subject Above";
            this.iNSERTSUBJECTABOVEToolStripMenuItem.Click += new System.EventHandler(this.iNSERTSUBJECTABOVEToolStripMenuItem_Click);
            // 
            // cHANGESUBJECTToolStripMenuItem
            // 
            this.cHANGESUBJECTToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.cHANGESUBJECTToolStripMenuItem.Name = "cHANGESUBJECTToolStripMenuItem";
            this.cHANGESUBJECTToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cHANGESUBJECTToolStripMenuItem.Text = "Change Subject";
            this.cHANGESUBJECTToolStripMenuItem.Visible = false;
            this.cHANGESUBJECTToolStripMenuItem.Click += new System.EventHandler(this.cHANGESUBJECTToolStripMenuItem_Click);
            // 
            // rEMOVESUBJECTToolStripMenuItem
            // 
            this.rEMOVESUBJECTToolStripMenuItem.ForeColor = System.Drawing.Color.Firebrick;
            this.rEMOVESUBJECTToolStripMenuItem.Name = "rEMOVESUBJECTToolStripMenuItem";
            this.rEMOVESUBJECTToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rEMOVESUBJECTToolStripMenuItem.Text = "Remove Subject";
            this.rEMOVESUBJECTToolStripMenuItem.Click += new System.EventHandler(this.rEMOVESUBJECTToolStripMenuItem_Click);
            // 
            // cLOSEToolStripMenuItem
            // 
            this.cLOSEToolStripMenuItem.Name = "cLOSEToolStripMenuItem";
            this.cLOSEToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cLOSEToolStripMenuItem.Text = "Close Menu";
            this.cLOSEToolStripMenuItem.Click += new System.EventHandler(this.cLOSEToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(827, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(12, 574);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(278, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "DELETE THIS CURRICULUM";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbDepartment.Location = new System.Drawing.Point(160, 26);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(142, 23);
            this.cmbDepartment.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Department";
            // 
            // frm_curriculum_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 618);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_curriculum_entry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curriculum Builder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCurriculumCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbCourseStrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iNSERTSUBJECTBELOWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNSERTSUBJECTABOVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEMOVESUBJECTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLOSEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHANGESUBJECTToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLecUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalUnit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmBridging;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmSemester;
        private System.Windows.Forms.DataGridViewButtonColumn clmAction;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label5;
    }
}