namespace COLM_SYSTEM.fees_folder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.clmFeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgOtherFees = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
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
            this.dgTuition.Size = new System.Drawing.Size(876, 271);
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
            this.button3.Location = new System.Drawing.Point(735, 619);
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
            this.button4.Location = new System.Drawing.Point(816, 619);
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
            this.clmFeeID,
            this.clmFee,
            this.clmAmount,
            this.dataGridViewLinkColumn1});
            this.dgMiscellaneous.Location = new System.Drawing.Point(15, 388);
            this.dgMiscellaneous.Name = "dgMiscellaneous";
            this.dgMiscellaneous.Size = new System.Drawing.Size(427, 224);
            this.dgMiscellaneous.TabIndex = 17;
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
            // 
            // clmFeeID
            // 
            this.clmFeeID.HeaderText = "FeeID";
            this.clmFeeID.Name = "clmFeeID";
            this.clmFeeID.Visible = false;
            // 
            // clmFee
            // 
            this.clmFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFee.HeaderText = "Fee";
            this.clmFee.Name = "clmFee";
            // 
            // clmAmount
            // 
            this.clmAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle17;
            this.clmAmount.HeaderText = "Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.Width = 76;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.ActiveLinkColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewLinkColumn1.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewLinkColumn1.HeaderText = "Remove";
            this.dataGridViewLinkColumn1.LinkColor = System.Drawing.Color.Firebrick;
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLinkColumn1.Text = "Remove";
            this.dataGridViewLinkColumn1.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn1.VisitedLinkColor = System.Drawing.Color.Firebrick;
            this.dataGridViewLinkColumn1.Width = 65;
            // 
            // dgOtherFees
            // 
            this.dgOtherFees.AllowUserToAddRows = false;
            this.dgOtherFees.AllowUserToDeleteRows = false;
            this.dgOtherFees.BackgroundColor = System.Drawing.Color.White;
            this.dgOtherFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOtherFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewLinkColumn2});
            this.dgOtherFees.Location = new System.Drawing.Point(464, 389);
            this.dgOtherFees.Name = "dgOtherFees";
            this.dgOtherFees.Size = new System.Drawing.Size(427, 224);
            this.dgOtherFees.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "FeeID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Fee";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 76;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.ActiveLinkColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewLinkColumn2.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewLinkColumn2.HeaderText = "Remove";
            this.dataGridViewLinkColumn2.LinkColor = System.Drawing.Color.Firebrick;
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLinkColumn2.Text = "Remove";
            this.dataGridViewLinkColumn2.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn2.VisitedLinkColor = System.Drawing.Color.Firebrick;
            this.dataGridViewLinkColumn2.Width = 65;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLecUnits.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmLecUnits.HeaderText = "Lec Units";
            this.clmLecUnits.Name = "clmLecUnits";
            this.clmLecUnits.ReadOnly = true;
            this.clmLecUnits.Width = 81;
            // 
            // clmLabUnits
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLabUnits.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmLabUnits.HeaderText = "Lab Units";
            this.clmLabUnits.Name = "clmLabUnits";
            this.clmLabUnits.ReadOnly = true;
            this.clmLabUnits.Width = 83;
            // 
            // clmUnit
            // 
            this.clmUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.Width = 55;
            // 
            // clmSubjPrice
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmSubjPrice.DefaultCellStyle = dataGridViewCellStyle14;
            this.clmSubjPrice.HeaderText = "Amount";
            this.clmSubjPrice.Name = "clmSubjPrice";
            this.clmSubjPrice.Width = 76;
            // 
            // clmAdditionalFee
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmAdditionalFee.DefaultCellStyle = dataGridViewCellStyle15;
            this.clmAdditionalFee.HeaderText = "Additional Fee";
            this.clmAdditionalFee.Name = "clmAdditionalFee";
            this.clmAdditionalFee.ReadOnly = true;
            this.clmAdditionalFee.Width = 110;
            // 
            // clmAdditionalSettings
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmAdditionalSettings.DefaultCellStyle = dataGridViewCellStyle16;
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
            this.ClientSize = new System.Drawing.Size(914, 661);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridView dgOtherFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
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