namespace COLM_SYSTEM.Fees_Folder
{
    partial class uc_tuition_list
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmCurriculumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurriculumCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEducationLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourseStrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTuition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscellaneous = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbEducationLevel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 541);
            this.panel1.TabIndex = 0;
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(59, 54);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(205, 25);
            this.cmbEducationLevel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "FILTER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "LIST OF TUITION FEES";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(977, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "CREATE TUITION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCurriculumID,
            this.clmCurriculumCode,
            this.clmEducationLevel,
            this.clmCourseStrand,
            this.clmYearLevelID,
            this.clmYearLevel,
            this.clmSubjects,
            this.clmTuition,
            this.clmMiscellaneous,
            this.Column1,
            this.clmEdit});
            this.dataGridView1.Location = new System.Drawing.Point(14, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1104, 444);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // clmCurriculumID
            // 
            this.clmCurriculumID.HeaderText = "CurriculumID";
            this.clmCurriculumID.Name = "clmCurriculumID";
            this.clmCurriculumID.ReadOnly = true;
            this.clmCurriculumID.Visible = false;
            // 
            // clmCurriculumCode
            // 
            this.clmCurriculumCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCurriculumCode.HeaderText = "Curriculum Code";
            this.clmCurriculumCode.Name = "clmCurriculumCode";
            this.clmCurriculumCode.ReadOnly = true;
            // 
            // clmEducationLevel
            // 
            this.clmEducationLevel.HeaderText = "Education Level";
            this.clmEducationLevel.Name = "clmEducationLevel";
            this.clmEducationLevel.ReadOnly = true;
            this.clmEducationLevel.Width = 120;
            // 
            // clmCourseStrand
            // 
            this.clmCourseStrand.HeaderText = "Course / Strand";
            this.clmCourseStrand.Name = "clmCourseStrand";
            this.clmCourseStrand.ReadOnly = true;
            this.clmCourseStrand.Width = 120;
            // 
            // clmYearLevelID
            // 
            this.clmYearLevelID.HeaderText = "Year Level ID";
            this.clmYearLevelID.Name = "clmYearLevelID";
            this.clmYearLevelID.ReadOnly = true;
            this.clmYearLevelID.Visible = false;
            // 
            // clmYearLevel
            // 
            this.clmYearLevel.HeaderText = "Year Level";
            this.clmYearLevel.Name = "clmYearLevel";
            this.clmYearLevel.ReadOnly = true;
            this.clmYearLevel.Width = 85;
            // 
            // clmSubjects
            // 
            this.clmSubjects.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmSubjects.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmSubjects.HeaderText = "Subjects";
            this.clmSubjects.Name = "clmSubjects";
            this.clmSubjects.ReadOnly = true;
            this.clmSubjects.Width = 78;
            // 
            // clmTuition
            // 
            this.clmTuition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmTuition.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmTuition.HeaderText = "Tuition";
            this.clmTuition.Name = "clmTuition";
            this.clmTuition.ReadOnly = true;
            this.clmTuition.Width = 70;
            // 
            // clmMiscellaneous
            // 
            this.clmMiscellaneous.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmMiscellaneous.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmMiscellaneous.HeaderText = "Miscellaneous";
            this.clmMiscellaneous.Name = "clmMiscellaneous";
            this.clmMiscellaneous.ReadOnly = true;
            this.clmMiscellaneous.Width = 107;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "Other Fees";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // clmEdit
            // 
            this.clmEdit.ActiveLinkColor = System.Drawing.Color.SeaGreen;
            this.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmEdit.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmEdit.HeaderText = "View / Edit";
            this.clmEdit.LinkColor = System.Drawing.Color.SeaGreen;
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.ReadOnly = true;
            this.clmEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmEdit.Text = "View / Edit";
            this.clmEdit.UseColumnTextForLinkValue = true;
            this.clmEdit.VisitedLinkColor = System.Drawing.Color.SeaGreen;
            this.clmEdit.Width = 90;
            // 
            // uc_tuition_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "uc_tuition_list";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1146, 561);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEducationLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourseStrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTuition;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscellaneous;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
    }
}
