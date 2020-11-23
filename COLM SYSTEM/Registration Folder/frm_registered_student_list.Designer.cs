namespace COLM_SYSTEM.registration
{
    partial class frm_registered_student_list
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
            this.txtRecords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clmRegisteredStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeSection = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmAssessment = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRecords
            // 
            this.txtRecords.Location = new System.Drawing.Point(941, 548);
            this.txtRecords.Name = "txtRecords";
            this.txtRecords.ReadOnly = true;
            this.txtRecords.Size = new System.Drawing.Size(75, 24);
            this.txtRecords.TabIndex = 13;
            this.txtRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(875, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "RECORDS";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 31);
            this.button2.TabIndex = 11;
            this.button2.Text = "NEW REGISTRATION";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRegisteredStudentID,
            this.clmStudentID,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.clmYearLevelID,
            this.Column1,
            this.Column7,
            this.clmSectionID,
            this.Column4,
            this.clmChangeSection,
            this.clmAssessment});
            this.dataGridView1.Location = new System.Drawing.Point(15, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1001, 491);
            this.dataGridView1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(941, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "SEARCH";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(811, 24);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "SEARCH STUDENT";
            // 
            // clmRegisteredStudentID
            // 
            this.clmRegisteredStudentID.HeaderText = "RegisteredStudentID";
            this.clmRegisteredStudentID.Name = "clmRegisteredStudentID";
            this.clmRegisteredStudentID.ReadOnly = true;
            this.clmRegisteredStudentID.Visible = false;
            // 
            // clmStudentID
            // 
            this.clmStudentID.HeaderText = "StudentID";
            this.clmStudentID.Name = "clmStudentID";
            this.clmStudentID.ReadOnly = true;
            this.clmStudentID.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "LRN";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "NAME (last name, first name)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "GENDER";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "MOBILE NO";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // clmYearLevelID
            // 
            this.clmYearLevelID.HeaderText = "YEAR LEVEL ID";
            this.clmYearLevelID.Name = "clmYearLevelID";
            this.clmYearLevelID.ReadOnly = true;
            this.clmYearLevelID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "LEVEL";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "YEAR";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // clmSectionID
            // 
            this.clmSectionID.HeaderText = "SECTION ID";
            this.clmSectionID.Name = "clmSectionID";
            this.clmSectionID.ReadOnly = true;
            this.clmSectionID.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "SECTION";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // clmChangeSection
            // 
            this.clmChangeSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmChangeSection.HeaderText = "SECTION";
            this.clmChangeSection.Name = "clmChangeSection";
            this.clmChangeSection.ReadOnly = true;
            this.clmChangeSection.Text = "CHANGE";
            this.clmChangeSection.UseColumnTextForButtonValue = true;
            this.clmChangeSection.Width = 62;
            // 
            // clmAssessment
            // 
            this.clmAssessment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmAssessment.HeaderText = "ASSESSMENT";
            this.clmAssessment.Name = "clmAssessment";
            this.clmAssessment.ReadOnly = true;
            this.clmAssessment.Text = "ASSESSMENT";
            this.clmAssessment.UseColumnTextForButtonValue = true;
            this.clmAssessment.Width = 87;
            // 
            // frm_registered_student_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 586);
            this.Controls.Add(this.txtRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_registered_student_list";
            this.Text = "LIST OF REGISTERED STUDENTS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegisteredStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn clmChangeSection;
        private System.Windows.Forms.DataGridViewButtonColumn clmAssessment;
    }
}