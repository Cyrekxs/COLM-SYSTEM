﻿namespace COLM_SYSTEM.subject
{
    partial class frm_subject_entry
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubjCode = new System.Windows.Forms.TextBox();
            this.txtSubJDesc = new System.Windows.Forms.TextBox();
            this.txtLecUnits = new System.Windows.Forms.TextBox();
            this.txtLabUnits = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTotalUnits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tm_unit_calculator = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUBJECT CODE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "DESCRIPTION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "LECTURE UNITS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "LABORATORY UNITS";
            // 
            // txtSubjCode
            // 
            this.txtSubjCode.Location = new System.Drawing.Point(137, 23);
            this.txtSubjCode.Name = "txtSubjCode";
            this.txtSubjCode.Size = new System.Drawing.Size(216, 24);
            this.txtSubjCode.TabIndex = 4;
            // 
            // txtSubJDesc
            // 
            this.txtSubJDesc.Location = new System.Drawing.Point(137, 53);
            this.txtSubJDesc.Multiline = true;
            this.txtSubJDesc.Name = "txtSubJDesc";
            this.txtSubJDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubJDesc.Size = new System.Drawing.Size(216, 70);
            this.txtSubJDesc.TabIndex = 5;
            // 
            // txtLecUnits
            // 
            this.txtLecUnits.Location = new System.Drawing.Point(137, 131);
            this.txtLecUnits.Name = "txtLecUnits";
            this.txtLecUnits.Size = new System.Drawing.Size(63, 24);
            this.txtLecUnits.TabIndex = 6;
            this.txtLecUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLabUnits
            // 
            this.txtLabUnits.Location = new System.Drawing.Point(137, 161);
            this.txtLabUnits.Name = "txtLabUnits";
            this.txtLabUnits.Size = new System.Drawing.Size(63, 24);
            this.txtLabUnits.TabIndex = 7;
            this.txtLabUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(197, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(278, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTotalUnits
            // 
            this.txtTotalUnits.Location = new System.Drawing.Point(137, 191);
            this.txtTotalUnits.Name = "txtTotalUnits";
            this.txtTotalUnits.ReadOnly = true;
            this.txtTotalUnits.Size = new System.Drawing.Size(63, 24);
            this.txtTotalUnits.TabIndex = 15;
            this.txtTotalUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "TOTAL UNITS";
            // 
            // tm_unit_calculator
            // 
            this.tm_unit_calculator.Enabled = true;
            this.tm_unit_calculator.Tick += new System.EventHandler(this.tm_unit_calculator_Tick);
            // 
            // frm_subject_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.txtTotalUnits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLabUnits);
            this.Controls.Add(this.txtLecUnits);
            this.Controls.Add(this.txtSubJDesc);
            this.Controls.Add(this.txtSubjCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_subject_entry";
            this.Text = "SUBJECT ENTRY";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubjCode;
        private System.Windows.Forms.TextBox txtSubJDesc;
        private System.Windows.Forms.TextBox txtLecUnits;
        private System.Windows.Forms.TextBox txtLabUnits;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTotalUnits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tm_unit_calculator;
    }
}