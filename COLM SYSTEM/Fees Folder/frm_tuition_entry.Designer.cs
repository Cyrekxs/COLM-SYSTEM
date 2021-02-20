﻿namespace COLM_SYSTEM.fees_folder
{
    partial class frm_tuition_entry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.cmbCourseStrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.dgTuition = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCurriculumCode = new System.Windows.Forms.ComboBox();
            this.dgMiscellaneous = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.dgOtherFees = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalTuition = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSubjects = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalAdditional = new System.Windows.Forms.TextBox();
            this.txtTotalMiscellaneous = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalOtherFees = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clmMiscFeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmOtherFeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOtherFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOtherAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOtherRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmSubjPriceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurriculumSubjID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLecUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLabUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAdditionalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAdditionalSettings = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMiscellaneous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOtherFees)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Education Level";
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
            this.cmbEducationLevel.Location = new System.Drawing.Point(15, 29);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(121, 25);
            this.cmbEducationLevel.TabIndex = 1;
            this.cmbEducationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbEducationLevel_SelectedIndexChanged);
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
            this.cmbCourseStrand.Location = new System.Drawing.Point(399, 29);
            this.cmbCourseStrand.Name = "cmbCourseStrand";
            this.cmbCourseStrand.Size = new System.Drawing.Size(121, 25);
            this.cmbCourseStrand.TabIndex = 3;
            this.cmbCourseStrand.SelectedIndexChanged += new System.EventHandler(this.cmbCourseStrand_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Course / Strand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year Level";
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
            this.cmbYearLevel.Location = new System.Drawing.Point(526, 29);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(121, 25);
            this.cmbYearLevel.TabIndex = 5;
            this.cmbYearLevel.SelectedIndexChanged += new System.EventHandler(this.cmbYearLevel_SelectedIndexChanged);
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
            this.clmLecUnits,
            this.clmLabUnits,
            this.clmUnit,
            this.clmSubjPrice,
            this.clmAdditionalFee,
            this.clmAdditionalSettings});
            this.dgTuition.Location = new System.Drawing.Point(15, 91);
            this.dgTuition.Name = "dgTuition";
            this.dgTuition.Size = new System.Drawing.Size(876, 231);
            this.dgTuition.TabIndex = 6;
            this.dgTuition.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgTuition.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(735, 659);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 13;
            this.button3.Text = "CANCEL";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(816, 659);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 12;
            this.button4.Text = "SAVE";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Curriculum Code";
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
            this.cmbCurriculumCode.Location = new System.Drawing.Point(142, 29);
            this.cmbCurriculumCode.Name = "cmbCurriculumCode";
            this.cmbCurriculumCode.Size = new System.Drawing.Size(251, 25);
            this.cmbCurriculumCode.TabIndex = 16;
            this.cmbCurriculumCode.SelectedIndexChanged += new System.EventHandler(this.cmbCurriculumCode_SelectedIndexChanged);
            // 
            // dgMiscellaneous
            // 
            this.dgMiscellaneous.AllowUserToAddRows = false;
            this.dgMiscellaneous.AllowUserToDeleteRows = false;
            this.dgMiscellaneous.BackgroundColor = System.Drawing.Color.White;
            this.dgMiscellaneous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMiscellaneous.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMiscFeeID,
            this.clmMiscFee,
            this.clmMiscAmount,
            this.clmMiscRemove});
            this.dgMiscellaneous.Location = new System.Drawing.Point(15, 388);
            this.dgMiscellaneous.Name = "dgMiscellaneous";
            this.dgMiscellaneous.Size = new System.Drawing.Size(427, 224);
            this.dgMiscellaneous.TabIndex = 17;
            this.dgMiscellaneous.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMiscellaneous_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tuition Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Miscellaneous Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(461, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Other Fees";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel1.Location = new System.Drawing.Point(806, 71);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 17);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "+ Add Subject";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.SeaGreen;
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel2.Location = new System.Drawing.Point(318, 368);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(124, 17);
            this.linkLabel2.TabIndex = 23;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "+ Add Miscellaneous";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.LinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel3.Location = new System.Drawing.Point(786, 368);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(105, 17);
            this.linkLabel3.TabIndex = 24;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "+ Add Other Fees";
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.SeaGreen;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // dgOtherFees
            // 
            this.dgOtherFees.AllowUserToAddRows = false;
            this.dgOtherFees.AllowUserToDeleteRows = false;
            this.dgOtherFees.BackgroundColor = System.Drawing.Color.White;
            this.dgOtherFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOtherFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmOtherFeeID,
            this.clmOtherFee,
            this.clmOtherAmount,
            this.clmOtherRemove});
            this.dgOtherFees.Location = new System.Drawing.Point(464, 389);
            this.dgOtherFees.Name = "dgOtherFees";
            this.dgOtherFees.Size = new System.Drawing.Size(427, 224);
            this.dgOtherFees.TabIndex = 25;
            this.dgOtherFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOtherFees_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total Tuition Fee";
            // 
            // txtTotalTuition
            // 
            this.txtTotalTuition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalTuition.Location = new System.Drawing.Point(565, 328);
            this.txtTotalTuition.Name = "txtTotalTuition";
            this.txtTotalTuition.ReadOnly = true;
            this.txtTotalTuition.Size = new System.Drawing.Size(100, 24);
            this.txtTotalTuition.TabIndex = 27;
            this.txtTotalTuition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "No of Subjects";
            // 
            // txtSubjects
            // 
            this.txtSubjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSubjects.Location = new System.Drawing.Point(103, 328);
            this.txtSubjects.Name = "txtSubjects";
            this.txtSubjects.ReadOnly = true;
            this.txtSubjects.Size = new System.Drawing.Size(38, 24);
            this.txtSubjects.TabIndex = 29;
            this.txtSubjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(671, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "Total Additional Fee";
            // 
            // txtTotalAdditional
            // 
            this.txtTotalAdditional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalAdditional.Location = new System.Drawing.Point(791, 328);
            this.txtTotalAdditional.Name = "txtTotalAdditional";
            this.txtTotalAdditional.ReadOnly = true;
            this.txtTotalAdditional.Size = new System.Drawing.Size(100, 24);
            this.txtTotalAdditional.TabIndex = 31;
            this.txtTotalAdditional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalMiscellaneous
            // 
            this.txtTotalMiscellaneous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalMiscellaneous.Location = new System.Drawing.Point(342, 618);
            this.txtTotalMiscellaneous.Name = "txtTotalMiscellaneous";
            this.txtTotalMiscellaneous.ReadOnly = true;
            this.txtTotalMiscellaneous.Size = new System.Drawing.Size(100, 24);
            this.txtTotalMiscellaneous.TabIndex = 33;
            this.txtTotalMiscellaneous.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(203, 621);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 17);
            this.label11.TabIndex = 32;
            this.label11.Text = "Total Miscellaneous Fee";
            // 
            // txtTotalOtherFees
            // 
            this.txtTotalOtherFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalOtherFees.Location = new System.Drawing.Point(791, 619);
            this.txtTotalOtherFees.Name = "txtTotalOtherFees";
            this.txtTotalOtherFees.ReadOnly = true;
            this.txtTotalOtherFees.Size = new System.Drawing.Size(100, 24);
            this.txtTotalOtherFees.TabIndex = 35;
            this.txtTotalOtherFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(695, 623);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 17);
            this.label12.TabIndex = 34;
            this.label12.Text = "Total Other Fee";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clmMiscFeeID
            // 
            this.clmMiscFeeID.HeaderText = "FeeID";
            this.clmMiscFeeID.Name = "clmMiscFeeID";
            this.clmMiscFeeID.Visible = false;
            // 
            // clmMiscFee
            // 
            this.clmMiscFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMiscFee.HeaderText = "Fee";
            this.clmMiscFee.Name = "clmMiscFee";
            this.clmMiscFee.ReadOnly = true;
            // 
            // clmMiscAmount
            // 
            this.clmMiscAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmMiscAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmMiscAmount.HeaderText = "Amount";
            this.clmMiscAmount.Name = "clmMiscAmount";
            this.clmMiscAmount.Width = 76;
            // 
            // clmMiscRemove
            // 
            this.clmMiscRemove.ActiveLinkColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmMiscRemove.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmMiscRemove.HeaderText = "Remove";
            this.clmMiscRemove.LinkColor = System.Drawing.Color.Firebrick;
            this.clmMiscRemove.Name = "clmMiscRemove";
            this.clmMiscRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmMiscRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmMiscRemove.Text = "Remove";
            this.clmMiscRemove.UseColumnTextForLinkValue = true;
            this.clmMiscRemove.VisitedLinkColor = System.Drawing.Color.Firebrick;
            this.clmMiscRemove.Width = 65;
            // 
            // clmOtherFeeID
            // 
            this.clmOtherFeeID.HeaderText = "FeeID";
            this.clmOtherFeeID.Name = "clmOtherFeeID";
            this.clmOtherFeeID.Visible = false;
            // 
            // clmOtherFee
            // 
            this.clmOtherFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmOtherFee.HeaderText = "Fee";
            this.clmOtherFee.Name = "clmOtherFee";
            this.clmOtherFee.ReadOnly = true;
            // 
            // clmOtherAmount
            // 
            this.clmOtherAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmOtherAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmOtherAmount.HeaderText = "Amount";
            this.clmOtherAmount.Name = "clmOtherAmount";
            this.clmOtherAmount.Width = 76;
            // 
            // clmOtherRemove
            // 
            this.clmOtherRemove.ActiveLinkColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmOtherRemove.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmOtherRemove.HeaderText = "Remove";
            this.clmOtherRemove.LinkColor = System.Drawing.Color.Firebrick;
            this.clmOtherRemove.Name = "clmOtherRemove";
            this.clmOtherRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmOtherRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmOtherRemove.Text = "Remove";
            this.clmOtherRemove.UseColumnTextForLinkValue = true;
            this.clmOtherRemove.VisitedLinkColor = System.Drawing.Color.Firebrick;
            this.clmOtherRemove.Width = 65;
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
            // clmLecUnits
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLecUnits.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmLecUnits.HeaderText = "Lec Units";
            this.clmLecUnits.Name = "clmLecUnits";
            this.clmLecUnits.ReadOnly = true;
            this.clmLecUnits.Width = 81;
            // 
            // clmLabUnits
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLabUnits.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmLabUnits.HeaderText = "Lab Units";
            this.clmLabUnits.Name = "clmLabUnits";
            this.clmLabUnits.ReadOnly = true;
            this.clmLabUnits.Width = 83;
            // 
            // clmUnit
            // 
            this.clmUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.Width = 55;
            // 
            // clmSubjPrice
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmSubjPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmSubjPrice.HeaderText = "Amount";
            this.clmSubjPrice.Name = "clmSubjPrice";
            this.clmSubjPrice.Width = 76;
            // 
            // clmAdditionalFee
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmAdditionalFee.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmAdditionalFee.HeaderText = "Additional Fee";
            this.clmAdditionalFee.Name = "clmAdditionalFee";
            this.clmAdditionalFee.ReadOnly = true;
            this.clmAdditionalFee.Width = 110;
            // 
            // clmAdditionalSettings
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmAdditionalSettings.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmAdditionalSettings.HeaderText = "View / Set";
            this.clmAdditionalSettings.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.clmAdditionalSettings.Name = "clmAdditionalSettings";
            this.clmAdditionalSettings.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAdditionalSettings.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAdditionalSettings.Text = "View / Set";
            this.clmAdditionalSettings.UseColumnTextForLinkValue = true;
            this.clmAdditionalSettings.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.clmAdditionalSettings.Width = 86;
            // 
            // frm_tuition_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 701);
            this.Controls.Add(this.txtTotalOtherFees);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotalMiscellaneous);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalAdditional);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSubjects);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalTuition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgOtherFees);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgMiscellaneous);
            this.Controls.Add(this.cmbCurriculumCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgTuition);
            this.Controls.Add(this.cmbYearLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCourseStrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEducationLevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_tuition_entry";
            this.Text = "TUITION, MISCELLANEOUS AND OTHER FEES SETTINGS";
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMiscellaneous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOtherFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.ComboBox cmbCourseStrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.DataGridView dgTuition;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCurriculumCode;
        private System.Windows.Forms.DataGridView dgMiscellaneous;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.DataGridView dgOtherFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalTuition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSubjects;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalAdditional;
        private System.Windows.Forms.TextBox txtTotalMiscellaneous;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalOtherFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscFeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscAmount;
        private System.Windows.Forms.DataGridViewLinkColumn clmMiscRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOtherFeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOtherFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOtherAmount;
        private System.Windows.Forms.DataGridViewLinkColumn clmOtherRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjPriceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLecUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAdditionalFee;
        private System.Windows.Forms.DataGridViewLinkColumn clmAdditionalSettings;
    }
}