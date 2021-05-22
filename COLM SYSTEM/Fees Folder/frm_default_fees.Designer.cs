namespace COLM_SYSTEM.Fees_Folder
{
    partial class frm_default_fees
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgFees = new System.Windows.Forms.DataGridView();
            this.clmDefaultFeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFeeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtFeeAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFeeType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgFees)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgFees
            // 
            this.dgFees.AllowUserToAddRows = false;
            this.dgFees.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgFees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgFees.BackgroundColor = System.Drawing.Color.White;
            this.dgFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDefaultFeeID,
            this.clmFee,
            this.clmFeeType,
            this.clmFeeAmount,
            this.clmIsActive,
            this.clmUpdate});
            this.dgFees.Location = new System.Drawing.Point(13, 28);
            this.dgFees.MultiSelect = false;
            this.dgFees.Name = "dgFees";
            this.dgFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFees.Size = new System.Drawing.Size(592, 423);
            this.dgFees.TabIndex = 18;
            this.dgFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFees_CellContentClick);
            // 
            // clmDefaultFeeID
            // 
            this.clmDefaultFeeID.HeaderText = "DefaultFeeID";
            this.clmDefaultFeeID.Name = "clmDefaultFeeID";
            this.clmDefaultFeeID.Visible = false;
            // 
            // clmFee
            // 
            this.clmFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFee.HeaderText = "Fee";
            this.clmFee.Name = "clmFee";
            this.clmFee.ReadOnly = true;
            // 
            // clmFeeType
            // 
            this.clmFeeType.HeaderText = "Fee Type";
            this.clmFeeType.Name = "clmFeeType";
            this.clmFeeType.ReadOnly = true;
            // 
            // clmFeeAmount
            // 
            this.clmFeeAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmFeeAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmFeeAmount.HeaderText = "Amount";
            this.clmFeeAmount.Name = "clmFeeAmount";
            this.clmFeeAmount.ReadOnly = true;
            this.clmFeeAmount.Width = 74;
            // 
            // clmIsActive
            // 
            this.clmIsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmIsActive.HeaderText = "Default";
            this.clmIsActive.Name = "clmIsActive";
            this.clmIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmIsActive.Width = 72;
            // 
            // clmUpdate
            // 
            this.clmUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmUpdate.HeaderText = "Update";
            this.clmUpdate.Name = "clmUpdate";
            this.clmUpdate.Text = "Update";
            this.clmUpdate.UseColumnTextForButtonValue = true;
            this.clmUpdate.Width = 52;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 44);
            this.panel1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "DEFAULT FEE LIST SETTINGS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.chkDefault);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.txtFeeAmount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbFeeType);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFee);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 266);
            this.panel2.TabIndex = 24;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(213, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new System.Drawing.Point(15, 180);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(124, 19);
            this.chkDefault.TabIndex = 7;
            this.chkDefault.Text = "Default Fee Status";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnNew.Location = new System.Drawing.Point(15, 214);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(79, 30);
            this.btnNew.TabIndex = 25;
            this.btnNew.Text = "NEW FEE";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtFeeAmount
            // 
            this.txtFeeAmount.Location = new System.Drawing.Point(15, 151);
            this.txtFeeAmount.Name = "txtFeeAmount";
            this.txtFeeAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFeeAmount.Size = new System.Drawing.Size(286, 23);
            this.txtFeeAmount.TabIndex = 5;
            this.txtFeeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fee Amount";
            // 
            // cmbFeeType
            // 
            this.cmbFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeeType.FormattingEnabled = true;
            this.cmbFeeType.Items.AddRange(new object[] {
            "Miscellaneous",
            "Other",
            "Additional"});
            this.cmbFeeType.Location = new System.Drawing.Point(15, 107);
            this.cmbFeeType.Name = "cmbFeeType";
            this.cmbFeeType.Size = new System.Drawing.Size(284, 23);
            this.cmbFeeType.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSave.Location = new System.Drawing.Point(114, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 30);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fee Type";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(15, 28);
            this.txtFee.Multiline = true;
            this.txtFee.Name = "txtFee";
            this.txtFee.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFee.Size = new System.Drawing.Size(286, 58);
            this.txtFee.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fee";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dgFees);
            this.panel3.Location = new System.Drawing.Point(335, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(617, 470);
            this.panel3.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "List of Default Fees";
            // 
            // frm_default_fees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 537);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_default_fees";
            this.Text = "DEFAULT FEES";
            ((System.ComponentModel.ISupportInitialize)(this.dgFees)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFees;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbFeeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFeeAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDefaultFeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFeeAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIsActive;
        private System.Windows.Forms.DataGridViewButtonColumn clmUpdate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
    }
}