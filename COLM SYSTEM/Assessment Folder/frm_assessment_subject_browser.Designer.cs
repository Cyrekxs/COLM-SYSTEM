namespace COLM_SYSTEM.Assessment_Folder
{
    partial class frm_assessment_subject_browser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgAvailableSubjects = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCurriculumInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubjectType = new System.Windows.Forms.ComboBox();
            this.clmSubjectPriceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAdditionalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAvailableSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAvailableSubjects
            // 
            this.dgAvailableSubjects.AllowUserToAddRows = false;
            this.dgAvailableSubjects.AllowUserToDeleteRows = false;
            this.dgAvailableSubjects.AllowUserToResizeColumns = false;
            this.dgAvailableSubjects.AllowUserToResizeRows = false;
            this.dgAvailableSubjects.BackgroundColor = System.Drawing.Color.White;
            this.dgAvailableSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgAvailableSubjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgAvailableSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAvailableSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSubjectPriceID,
            this.clmCourse,
            this.clmYearLevel,
            this.clmSubjType,
            this.clmSubjectPrice,
            this.clmAdditionalFee,
            this.clmAction});
            this.dgAvailableSubjects.Location = new System.Drawing.Point(11, 55);
            this.dgAvailableSubjects.Name = "dgAvailableSubjects";
            this.dgAvailableSubjects.ReadOnly = true;
            this.dgAvailableSubjects.RowHeadersVisible = false;
            this.dgAvailableSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAvailableSubjects.Size = new System.Drawing.Size(482, 230);
            this.dgAvailableSubjects.TabIndex = 2;
            this.dgAvailableSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAvailableSubjects_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Here";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmSubjectID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView1.Location = new System.Drawing.Point(5, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(378, 230);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CURRICULUM SUBJECT ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // clmSubjectID
            // 
            this.clmSubjectID.HeaderText = "SubjectID";
            this.clmSubjectID.Name = "clmSubjectID";
            this.clmSubjectID.ReadOnly = true;
            this.clmSubjectID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(5, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(378, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblCurriculumInfo
            // 
            this.lblCurriculumInfo.AutoSize = true;
            this.lblCurriculumInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurriculumInfo.Location = new System.Drawing.Point(7, 9);
            this.lblCurriculumInfo.Name = "lblCurriculumInfo";
            this.lblCurriculumInfo.Size = new System.Drawing.Size(171, 15);
            this.lblCurriculumInfo.TabIndex = 6;
            this.lblCurriculumInfo.Text = "List of Curriculum Subjects in :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(413, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "List of Available Subjects";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(10, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 298);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.cmbSubjectType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgAvailableSubjects);
            this.panel2.Location = new System.Drawing.Point(417, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 298);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filter Subject Type";
            // 
            // cmbSubjectType
            // 
            this.cmbSubjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjectType.FormattingEnabled = true;
            this.cmbSubjectType.Items.AddRange(new object[] {
            "All",
            "Regular",
            "Irregular"});
            this.cmbSubjectType.Location = new System.Drawing.Point(346, 26);
            this.cmbSubjectType.Name = "cmbSubjectType";
            this.cmbSubjectType.Size = new System.Drawing.Size(147, 23);
            this.cmbSubjectType.TabIndex = 5;
            this.cmbSubjectType.SelectedIndexChanged += new System.EventHandler(this.cmbSubjectType_SelectedIndexChanged);
            // 
            // clmSubjectPriceID
            // 
            this.clmSubjectPriceID.HeaderText = "SubjectPriceID";
            this.clmSubjectPriceID.Name = "clmSubjectPriceID";
            this.clmSubjectPriceID.ReadOnly = true;
            this.clmSubjectPriceID.Visible = false;
            // 
            // clmCourse
            // 
            this.clmCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCourse.HeaderText = "Course";
            this.clmCourse.Name = "clmCourse";
            this.clmCourse.ReadOnly = true;
            this.clmCourse.Width = 70;
            // 
            // clmYearLevel
            // 
            this.clmYearLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmYearLevel.HeaderText = "Year Level";
            this.clmYearLevel.Name = "clmYearLevel";
            this.clmYearLevel.ReadOnly = true;
            this.clmYearLevel.Width = 85;
            // 
            // clmSubjType
            // 
            this.clmSubjType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjType.HeaderText = "Type";
            this.clmSubjType.Name = "clmSubjType";
            this.clmSubjType.ReadOnly = true;
            this.clmSubjType.Width = 56;
            // 
            // clmSubjectPrice
            // 
            this.clmSubjectPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmSubjectPrice.DefaultCellStyle = dataGridViewCellStyle15;
            this.clmSubjectPrice.HeaderText = "Amount";
            this.clmSubjectPrice.Name = "clmSubjectPrice";
            this.clmSubjectPrice.ReadOnly = true;
            this.clmSubjectPrice.Width = 74;
            // 
            // clmAdditionalFee
            // 
            this.clmAdditionalFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmAdditionalFee.DefaultCellStyle = dataGridViewCellStyle16;
            this.clmAdditionalFee.HeaderText = "Add\'l Amount";
            this.clmAdditionalFee.Name = "clmAdditionalFee";
            this.clmAdditionalFee.ReadOnly = true;
            this.clmAdditionalFee.Width = 105;
            // 
            // clmAction
            // 
            this.clmAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmAction.HeaderText = "Add to list";
            this.clmAction.Name = "clmAction";
            this.clmAction.ReadOnly = true;
            this.clmAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAction.Text = "Add to list";
            this.clmAction.UseColumnTextForButtonValue = true;
            this.clmAction.Width = 88;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(804, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 20;
            this.button1.Text = "DONE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCancel.Location = new System.Drawing.Point(679, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 36);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_assessment_subject_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 375);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurriculumInfo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_assessment_subject_browser";
            this.Text = "LIST OF AVAILABLE SUBJECTS";
            ((System.ComponentModel.ISupportInitialize)(this.dgAvailableSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAvailableSubjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblCurriculumInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectPriceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAdditionalFee;
        private System.Windows.Forms.DataGridViewButtonColumn clmAction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
    }
}