namespace COLM_SYSTEM.Discounts
{
    partial class frm_discount_entry_amount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOFee = new System.Windows.Forms.TextBox();
            this.txtMFee = new System.Windows.Forms.TextBox();
            this.txtTFee = new System.Windows.Forms.TextBox();
            this.ch_OFee = new System.Windows.Forms.CheckBox();
            this.ch_MFee = new System.Windows.Forms.CheckBox();
            this.ch_TFee = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDiscountCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtAmountValue = new System.Windows.Forms.TextBox();
            this.cmbCourseStrand = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.datagridview1 = new System.Windows.Forms.DataGridView();
            this.clmDiscountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEducationLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourseStrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.chkSpecific = new System.Windows.Forms.CheckBox();
            this.panelList = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnDeleteDiscount = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDiscountType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).BeginInit();
            this.panelList.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtOFee);
            this.panel1.Controls.Add(this.txtMFee);
            this.panel1.Controls.Add(this.txtTFee);
            this.panel1.Controls.Add(this.ch_OFee);
            this.panel1.Controls.Add(this.ch_MFee);
            this.panel1.Controls.Add(this.ch_TFee);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(15, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 142);
            this.panel1.TabIndex = 46;
            // 
            // txtOFee
            // 
            this.txtOFee.Enabled = false;
            this.txtOFee.Location = new System.Drawing.Point(194, 103);
            this.txtOFee.Name = "txtOFee";
            this.txtOFee.Size = new System.Drawing.Size(71, 23);
            this.txtOFee.TabIndex = 9;
            this.txtOFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMFee
            // 
            this.txtMFee.Enabled = false;
            this.txtMFee.Location = new System.Drawing.Point(194, 77);
            this.txtMFee.Name = "txtMFee";
            this.txtMFee.Size = new System.Drawing.Size(71, 23);
            this.txtMFee.TabIndex = 7;
            this.txtMFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTFee
            // 
            this.txtTFee.Enabled = false;
            this.txtTFee.Location = new System.Drawing.Point(194, 52);
            this.txtTFee.Name = "txtTFee";
            this.txtTFee.Size = new System.Drawing.Size(71, 23);
            this.txtTFee.TabIndex = 5;
            this.txtTFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ch_OFee
            // 
            this.ch_OFee.AutoSize = true;
            this.ch_OFee.Location = new System.Drawing.Point(22, 103);
            this.ch_OFee.Name = "ch_OFee";
            this.ch_OFee.Size = new System.Drawing.Size(82, 19);
            this.ch_OFee.TabIndex = 8;
            this.ch_OFee.Text = "Other fees";
            this.ch_OFee.UseVisualStyleBackColor = true;
            this.ch_OFee.CheckedChanged += new System.EventHandler(this.ch_OFee_CheckedChanged);
            // 
            // ch_MFee
            // 
            this.ch_MFee.AutoSize = true;
            this.ch_MFee.Location = new System.Drawing.Point(22, 79);
            this.ch_MFee.Name = "ch_MFee";
            this.ch_MFee.Size = new System.Drawing.Size(107, 19);
            this.ch_MFee.TabIndex = 6;
            this.ch_MFee.Text = "Miscellaneous";
            this.ch_MFee.UseVisualStyleBackColor = true;
            this.ch_MFee.CheckedChanged += new System.EventHandler(this.ch_MFee_CheckedChanged);
            // 
            // ch_TFee
            // 
            this.ch_TFee.AutoSize = true;
            this.ch_TFee.Location = new System.Drawing.Point(22, 56);
            this.ch_TFee.Name = "ch_TFee";
            this.ch_TFee.Size = new System.Drawing.Size(63, 19);
            this.ch_TFee.TabIndex = 4;
            this.ch_TFee.Text = "Tuition";
            this.ch_TFee.UseVisualStyleBackColor = true;
            this.ch_TFee.CheckedChanged += new System.EventHandler(this.ch_TFee_CheckedChanged);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(6, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 32);
            this.label12.TabIndex = 45;
            this.label12.Text = "Check fee if you want to make it affected by this discount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Affected Fees";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(554, 361);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 27);
            this.button3.TabIndex = 17;
            this.button3.Text = "CANCEL";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(671, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 27);
            this.button1.TabIndex = 16;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDiscountCode
            // 
            this.txtDiscountCode.Location = new System.Drawing.Point(15, 28);
            this.txtDiscountCode.Multiline = true;
            this.txtDiscountCode.Name = "txtDiscountCode";
            this.txtDiscountCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiscountCode.Size = new System.Drawing.Size(285, 50);
            this.txtDiscountCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Discount Code";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Location = new System.Drawing.Point(242, 28);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(109, 23);
            this.cmbYearLevel.TabIndex = 14;
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "Pre Elementary",
            "Elementary",
            "Junior High",
            "Senior High",
            "College"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(12, 28);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(109, 23);
            this.cmbEducationLevel.TabIndex = 12;
            this.cmbEducationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbEducationLevel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Year Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 37;
            this.label1.Text = "Education Level";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(12, 125);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(101, 15);
            this.lblDiscount.TabIndex = 47;
            this.lblDiscount.Text = "Discount Amount";
            // 
            // txtAmountValue
            // 
            this.txtAmountValue.Location = new System.Drawing.Point(15, 143);
            this.txtAmountValue.Name = "txtAmountValue";
            this.txtAmountValue.Size = new System.Drawing.Size(285, 23);
            this.txtAmountValue.TabIndex = 3;
            this.txtAmountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountValue.Leave += new System.EventHandler(this.txtAmountValue_Leave);
            // 
            // cmbCourseStrand
            // 
            this.cmbCourseStrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseStrand.FormattingEnabled = true;
            this.cmbCourseStrand.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH"});
            this.cmbCourseStrand.Location = new System.Drawing.Point(127, 28);
            this.cmbCourseStrand.Name = "cmbCourseStrand";
            this.cmbCourseStrand.Size = new System.Drawing.Size(109, 23);
            this.cmbCourseStrand.TabIndex = 13;
            this.cmbCourseStrand.SelectedIndexChanged += new System.EventHandler(this.cmbCourseStrand_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 49;
            this.label5.Text = "Course / Strand";
            // 
            // datagridview1
            // 
            this.datagridview1.AllowUserToAddRows = false;
            this.datagridview1.AllowUserToDeleteRows = false;
            this.datagridview1.AllowUserToResizeColumns = false;
            this.datagridview1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.datagridview1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridview1.BackgroundColor = System.Drawing.Color.White;
            this.datagridview1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridview1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDiscountID,
            this.clmYearLevelID,
            this.clmEducationLevel,
            this.clmCourseStrand,
            this.clmYearLevel,
            this.clmRemove});
            this.datagridview1.Location = new System.Drawing.Point(12, 57);
            this.datagridview1.Name = "datagridview1";
            this.datagridview1.ReadOnly = true;
            this.datagridview1.RowHeadersVisible = false;
            this.datagridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview1.Size = new System.Drawing.Size(423, 244);
            this.datagridview1.TabIndex = 52;
            this.datagridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview1_CellContentClick);
            // 
            // clmDiscountID
            // 
            this.clmDiscountID.HeaderText = "Discount ID";
            this.clmDiscountID.Name = "clmDiscountID";
            this.clmDiscountID.ReadOnly = true;
            this.clmDiscountID.Visible = false;
            // 
            // clmYearLevelID
            // 
            this.clmYearLevelID.HeaderText = "YearLevelID";
            this.clmYearLevelID.Name = "clmYearLevelID";
            this.clmYearLevelID.ReadOnly = true;
            this.clmYearLevelID.Visible = false;
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
            // clmYearLevel
            // 
            this.clmYearLevel.HeaderText = "Year Level";
            this.clmYearLevel.Name = "clmYearLevel";
            this.clmYearLevel.ReadOnly = true;
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(367, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "ADD";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkSpecific
            // 
            this.chkSpecific.AutoSize = true;
            this.chkSpecific.ForeColor = System.Drawing.Color.Red;
            this.chkSpecific.Location = new System.Drawing.Point(505, 12);
            this.chkSpecific.Name = "chkSpecific";
            this.chkSpecific.Size = new System.Drawing.Size(251, 19);
            this.chkSpecific.TabIndex = 11;
            this.chkSpecific.Text = "Check if you want to make it only specific";
            this.chkSpecific.UseVisualStyleBackColor = true;
            this.chkSpecific.CheckedChanged += new System.EventHandler(this.chkSpecific_CheckedChanged);
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelList.Controls.Add(this.label1);
            this.panelList.Controls.Add(this.label2);
            this.panelList.Controls.Add(this.button2);
            this.panelList.Controls.Add(this.cmbEducationLevel);
            this.panelList.Controls.Add(this.datagridview1);
            this.panelList.Controls.Add(this.cmbYearLevel);
            this.panelList.Controls.Add(this.cmbCourseStrand);
            this.panelList.Controls.Add(this.label5);
            this.panelList.Location = new System.Drawing.Point(333, 40);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(449, 315);
            this.panelList.TabIndex = 55;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.ForeColor = System.Drawing.Color.Red;
            this.chkAll.Location = new System.Drawing.Point(333, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(162, 19);
            this.chkAll.TabIndex = 10;
            this.chkAll.Text = "Applied to all year levels";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnDeleteDiscount
            // 
            this.btnDeleteDiscount.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteDiscount.FlatAppearance.BorderSize = 0;
            this.btnDeleteDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDiscount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDiscount.Location = new System.Drawing.Point(12, 361);
            this.btnDeleteDiscount.Name = "btnDeleteDiscount";
            this.btnDeleteDiscount.Size = new System.Drawing.Size(315, 27);
            this.btnDeleteDiscount.TabIndex = 56;
            this.btnDeleteDiscount.Text = "DELETE THIS DISCOUNT";
            this.btnDeleteDiscount.UseVisualStyleBackColor = false;
            this.btnDeleteDiscount.Visible = false;
            this.btnDeleteDiscount.Click += new System.EventHandler(this.btnDeleteDiscount_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 58;
            this.label7.Text = "Discount Type";
            // 
            // cmbDiscountType
            // 
            this.cmbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscountType.FormattingEnabled = true;
            this.cmbDiscountType.Items.AddRange(new object[] {
            "Amount",
            "Percentage"});
            this.cmbDiscountType.Location = new System.Drawing.Point(15, 99);
            this.cmbDiscountType.Name = "cmbDiscountType";
            this.cmbDiscountType.Size = new System.Drawing.Size(285, 23);
            this.cmbDiscountType.TabIndex = 2;
            this.cmbDiscountType.SelectedIndexChanged += new System.EventHandler(this.cmbDiscountType_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbDiscountType);
            this.panel2.Controls.Add(this.txtDiscountCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblDiscount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtAmountValue);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 343);
            this.panel2.TabIndex = 59;
            // 
            // frm_discount_entry_amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 407);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnDeleteDiscount);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.chkSpecific);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_discount_entry_amount";
            this.Text = "DISCOUNT AMOUNT ENTRY";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).EndInit();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDiscountCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbEducationLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ch_OFee;
        private System.Windows.Forms.CheckBox ch_MFee;
        private System.Windows.Forms.CheckBox ch_TFee;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtAmountValue;
        private System.Windows.Forms.ComboBox cmbCourseStrand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView datagridview1;
        private System.Windows.Forms.CheckBox chkSpecific;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEducationLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourseStrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewButtonColumn clmRemove;
        private System.Windows.Forms.Button btnDeleteDiscount;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDiscountType;
        private System.Windows.Forms.TextBox txtOFee;
        private System.Windows.Forms.TextBox txtMFee;
        private System.Windows.Forms.TextBox txtTFee;
        private System.Windows.Forms.Panel panel2;
    }
}