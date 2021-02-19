namespace COLM_SYSTEM.Schedule_Folder
{
    partial class frm_schedule_entry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbCurriculumCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCourseStrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgTuition = new System.Windows.Forms.DataGridView();
            this.clmSubjPriceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurriculumSubjID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFaculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCurriculumCode
            // 
            this.cmbCurriculumCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurriculumCode.FormattingEnabled = true;
            this.cmbCurriculumCode.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbCurriculumCode.Location = new System.Drawing.Point(139, 37);
            this.cmbCurriculumCode.Name = "cmbCurriculumCode";
            this.cmbCurriculumCode.Size = new System.Drawing.Size(251, 25);
            this.cmbCurriculumCode.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Curriculum Code";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH",
            "COLLEGE"});
            this.cmbYearLevel.Location = new System.Drawing.Point(523, 37);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(121, 25);
            this.cmbYearLevel.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Year Level";
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
            this.cmbCourseStrand.Location = new System.Drawing.Point(396, 37);
            this.cmbCourseStrand.Name = "cmbCourseStrand";
            this.cmbCourseStrand.Size = new System.Drawing.Size(121, 25);
            this.cmbCourseStrand.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Course / Strand";
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
            this.cmbEducationLevel.Location = new System.Drawing.Point(12, 37);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(121, 25);
            this.cmbEducationLevel.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Education Level";
            // 
            // dgTuition
            // 
            this.dgTuition.AllowUserToAddRows = false;
            this.dgTuition.AllowUserToDeleteRows = false;
            this.dgTuition.BackgroundColor = System.Drawing.Color.White;
            this.dgTuition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTuition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSubjPriceID,
            this.clmCurriculumSubjID,
            this.clmSubjCode,
            this.clmSubjDesc,
            this.clmUnit,
            this.clmDay,
            this.clmTimeIn,
            this.clmTimeOut,
            this.clmRoom,
            this.clmFaculty});
            this.dgTuition.Location = new System.Drawing.Point(12, 68);
            this.dgTuition.Name = "dgTuition";
            this.dgTuition.Size = new System.Drawing.Size(960, 231);
            this.dgTuition.TabIndex = 25;
            // 
            // clmSubjPriceID
            // 
            this.clmSubjPriceID.HeaderText = "Subject Price ID";
            this.clmSubjPriceID.Name = "clmSubjPriceID";
            this.clmSubjPriceID.ReadOnly = true;
            this.clmSubjPriceID.Visible = false;
            // 
            // clmCurriculumSubjID
            // 
            this.clmCurriculumSubjID.HeaderText = "Curriculum Subject ID";
            this.clmCurriculumSubjID.Name = "clmCurriculumSubjID";
            this.clmCurriculumSubjID.ReadOnly = true;
            this.clmCurriculumSubjID.Visible = false;
            // 
            // clmSubjCode
            // 
            this.clmSubjCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjCode.HeaderText = "Subject Code";
            this.clmSubjCode.Name = "clmSubjCode";
            this.clmSubjCode.ReadOnly = true;
            this.clmSubjCode.Width = 103;
            // 
            // clmSubjDesc
            // 
            this.clmSubjDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSubjDesc.HeaderText = "Description";
            this.clmSubjDesc.Name = "clmSubjDesc";
            this.clmSubjDesc.ReadOnly = true;
            // 
            // clmUnit
            // 
            this.clmUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.Width = 55;
            // 
            // clmDay
            // 
            this.clmDay.HeaderText = "Day";
            this.clmDay.Name = "clmDay";
            // 
            // clmTimeIn
            // 
            this.clmTimeIn.HeaderText = "Time In";
            this.clmTimeIn.Name = "clmTimeIn";
            // 
            // clmTimeOut
            // 
            this.clmTimeOut.HeaderText = "Time Out";
            this.clmTimeOut.Name = "clmTimeOut";
            // 
            // clmRoom
            // 
            this.clmRoom.HeaderText = "Room";
            this.clmRoom.Name = "clmRoom";
            // 
            // clmFaculty
            // 
            this.clmFaculty.HeaderText = "Faculty";
            this.clmFaculty.Name = "clmFaculty";
            // 
            // frm_schedule_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 532);
            this.Controls.Add(this.dgTuition);
            this.Controls.Add(this.cmbCurriculumCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbYearLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCourseStrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEducationLevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_schedule_entry";
            this.Text = "SCHEDULE ENTRY";
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCurriculumCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCourseStrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgTuition;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjPriceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFaculty;
    }
}