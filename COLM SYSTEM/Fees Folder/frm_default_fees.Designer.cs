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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgMiscellaneous = new System.Windows.Forms.DataGridView();
            this.clmMiscFeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMiscRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMiscellaneous)).BeginInit();
            this.SuspendLayout();
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
            this.clmFeeType,
            this.clmMiscAmount,
            this.clmMiscRemove});
            this.dgMiscellaneous.Location = new System.Drawing.Point(12, 82);
            this.dgMiscellaneous.Name = "dgMiscellaneous";
            this.dgMiscellaneous.Size = new System.Drawing.Size(634, 224);
            this.dgMiscellaneous.TabIndex = 18;
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
            // clmFeeType
            // 
            this.clmFeeType.HeaderText = "Fee Type";
            this.clmFeeType.Name = "clmFeeType";
            // 
            // clmMiscAmount
            // 
            this.clmMiscAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmMiscAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmMiscAmount.HeaderText = "Amount";
            this.clmMiscAmount.Name = "clmMiscAmount";
            this.clmMiscAmount.Width = 74;
            // 
            // clmMiscRemove
            // 
            this.clmMiscRemove.ActiveLinkColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmMiscRemove.DefaultCellStyle = dataGridViewCellStyle2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "DEFAULT FEE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 23);
            this.textBox1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "FEE TYPE";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Miscellaneous",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(279, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "AMOUNT";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(409, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(107, 23);
            this.textBox2.TabIndex = 26;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frm_default_fees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 519);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgMiscellaneous);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_default_fees";
            this.Text = "DEFAULT FEES";
            ((System.ComponentModel.ISupportInitialize)(this.dgMiscellaneous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMiscellaneous;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscFeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMiscAmount;
        private System.Windows.Forms.DataGridViewLinkColumn clmMiscRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}