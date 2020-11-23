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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDiscountCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbEducationLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ch_TFee = new System.Windows.Forms.CheckBox();
            this.ch_MFee = new System.Windows.Forms.CheckBox();
            this.ch_OFee = new System.Windows.Forms.CheckBox();
            this.er = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmountValue = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.er)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ch_OFee);
            this.panel1.Controls.Add(this.ch_MFee);
            this.panel1.Controls.Add(this.ch_TFee);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(135, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 129);
            this.panel1.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "AFFECTED FEES";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 45;
            this.label12.Text = "COMPUTATION";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(199, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 31);
            this.button3.TabIndex = 44;
            this.button3.Text = "CANCEL";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(316, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 31);
            this.button1.TabIndex = 43;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDiscountCode
            // 
            this.txtDiscountCode.Location = new System.Drawing.Point(135, 28);
            this.txtDiscountCode.Multiline = true;
            this.txtDiscountCode.Name = "txtDiscountCode";
            this.txtDiscountCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiscountCode.Size = new System.Drawing.Size(292, 56);
            this.txtDiscountCode.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "DISCOUNT CODE";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Location = new System.Drawing.Point(135, 121);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(292, 25);
            this.cmbYearLevel.TabIndex = 41;
            // 
            // cmbEducationLevel
            // 
            this.cmbEducationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationLevel.FormattingEnabled = true;
            this.cmbEducationLevel.Items.AddRange(new object[] {
            "PRE ELEMENTARY",
            "ELEMENTARY",
            "JUNIOR HIGH",
            "SENIOR HIGH"});
            this.cmbEducationLevel.Location = new System.Drawing.Point(135, 90);
            this.cmbEducationLevel.Name = "cmbEducationLevel";
            this.cmbEducationLevel.Size = new System.Drawing.Size(292, 25);
            this.cmbEducationLevel.TabIndex = 40;
            this.cmbEducationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbEducationLevel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "YEAR LEVEL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "EDUCATION LEVEL";
            // 
            // ch_TFee
            // 
            this.ch_TFee.AutoSize = true;
            this.ch_TFee.Location = new System.Drawing.Point(22, 37);
            this.ch_TFee.Name = "ch_TFee";
            this.ch_TFee.Size = new System.Drawing.Size(72, 21);
            this.ch_TFee.TabIndex = 47;
            this.ch_TFee.Text = "TUITION";
            this.ch_TFee.UseVisualStyleBackColor = true;
            // 
            // ch_MFee
            // 
            this.ch_MFee.AutoSize = true;
            this.ch_MFee.Location = new System.Drawing.Point(22, 64);
            this.ch_MFee.Name = "ch_MFee";
            this.ch_MFee.Size = new System.Drawing.Size(118, 21);
            this.ch_MFee.TabIndex = 48;
            this.ch_MFee.Text = "MISCELLANEOUS";
            this.ch_MFee.UseVisualStyleBackColor = true;
            // 
            // ch_OFee
            // 
            this.ch_OFee.AutoSize = true;
            this.ch_OFee.Location = new System.Drawing.Point(22, 91);
            this.ch_OFee.Name = "ch_OFee";
            this.ch_OFee.Size = new System.Drawing.Size(65, 21);
            this.ch_OFee.TabIndex = 49;
            this.ch_OFee.Text = "OTHER";
            this.ch_OFee.UseVisualStyleBackColor = true;
            // 
            // er
            // 
            this.er.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.er.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "AMOUNT VALUE";
            // 
            // txtAmountValue
            // 
            this.txtAmountValue.Location = new System.Drawing.Point(135, 151);
            this.txtAmountValue.Name = "txtAmountValue";
            this.txtAmountValue.Size = new System.Drawing.Size(292, 24);
            this.txtAmountValue.TabIndex = 48;
            this.txtAmountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frm_discount_entry_amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 373);
            this.Controls.Add(this.txtAmountValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDiscountCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbYearLevel);
            this.Controls.Add(this.cmbEducationLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_discount_entry_amount";
            this.Text = "DISCOUNT AMOUNT ENTRY";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.er)).EndInit();
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
        private System.Windows.Forms.ErrorProvider er;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmountValue;
    }
}