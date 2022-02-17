namespace SEMS.Assessment_Folder
{
    partial class frm_assessment_dropping
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.txtYearLevel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.clmAssessmentBreakdownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAssessmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Name";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(20, 48);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(266, 23);
            this.txtStudentName.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAssessmentBreakdownID,
            this.clmAssessmentID,
            this.clmItemCode,
            this.clmAmount,
            this.clmDueDate});
            this.dataGridView1.Location = new System.Drawing.Point(20, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(516, 297);
            this.dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Course";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year Level";
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(292, 48);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.ReadOnly = true;
            this.txtCourse.Size = new System.Drawing.Size(119, 23);
            this.txtCourse.TabIndex = 5;
            // 
            // txtYearLevel
            // 
            this.txtYearLevel.Location = new System.Drawing.Point(417, 48);
            this.txtYearLevel.Name = "txtYearLevel";
            this.txtYearLevel.ReadOnly = true;
            this.txtYearLevel.Size = new System.Drawing.Size(119, 23);
            this.txtYearLevel.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(417, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Confirm Drop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clmAssessmentBreakdownID
            // 
            this.clmAssessmentBreakdownID.HeaderText = "Assessment Breakdown ID";
            this.clmAssessmentBreakdownID.Name = "clmAssessmentBreakdownID";
            this.clmAssessmentBreakdownID.Visible = false;
            // 
            // clmAssessmentID
            // 
            this.clmAssessmentID.HeaderText = "Assessment ID";
            this.clmAssessmentID.Name = "clmAssessmentID";
            this.clmAssessmentID.Visible = false;
            // 
            // clmItemCode
            // 
            this.clmItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmItemCode.HeaderText = "Item Code";
            this.clmItemCode.Name = "clmItemCode";
            this.clmItemCode.ReadOnly = true;
            // 
            // clmAmount
            // 
            this.clmAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmAmount.HeaderText = "Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.Width = 74;
            // 
            // clmDueDate
            // 
            this.clmDueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDueDate.HeaderText = "Due Date";
            this.clmDueDate.Name = "clmDueDate";
            this.clmDueDate.ReadOnly = true;
            this.clmDueDate.Width = 81;
            // 
            // frm_assessment_dropping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 429);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtYearLevel);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_assessment_dropping";
            this.Text = "Student Assessment Dropping";
            this.Load += new System.EventHandler(this.frm_assessment_dropping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.TextBox txtYearLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentBreakdownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAssessmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDueDate;
    }
}