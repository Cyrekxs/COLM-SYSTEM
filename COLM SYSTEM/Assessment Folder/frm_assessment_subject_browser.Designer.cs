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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgSubjects = new System.Windows.Forms.DataGridView();
            this.clmCurriculumSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjPriceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjectPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAdditionalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPickSched = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSubjects
            // 
            this.dgSubjects.AllowUserToAddRows = false;
            this.dgSubjects.AllowUserToDeleteRows = false;
            this.dgSubjects.AllowUserToResizeColumns = false;
            this.dgSubjects.AllowUserToResizeRows = false;
            this.dgSubjects.BackgroundColor = System.Drawing.Color.White;
            this.dgSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSubjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCurriculumSubjectID,
            this.clmSubjectCode,
            this.clmSubjectDesc,
            this.clmSubjDesc,
            this.clmSubjPriceID,
            this.clmSubjectPrice,
            this.clmAdditionalFee,
            this.Column7,
            this.clmPickSched});
            this.dgSubjects.Location = new System.Drawing.Point(9, 9);
            this.dgSubjects.Name = "dgSubjects";
            this.dgSubjects.ReadOnly = true;
            this.dgSubjects.RowHeadersVisible = false;
            this.dgSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSubjects.Size = new System.Drawing.Size(639, 458);
            this.dgSubjects.TabIndex = 2;
            // 
            // clmCurriculumSubjectID
            // 
            this.clmCurriculumSubjectID.HeaderText = "CURRICULUM SUBJECT ID";
            this.clmCurriculumSubjectID.Name = "clmCurriculumSubjectID";
            this.clmCurriculumSubjectID.ReadOnly = true;
            this.clmCurriculumSubjectID.Visible = false;
            // 
            // clmSubjectCode
            // 
            this.clmSubjectCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjectCode.HeaderText = "Code";
            this.clmSubjectCode.Name = "clmSubjectCode";
            this.clmSubjectCode.ReadOnly = true;
            this.clmSubjectCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubjectCode.Width = 40;
            // 
            // clmSubjectDesc
            // 
            this.clmSubjectDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmSubjectDesc.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmSubjectDesc.HeaderText = "Subject";
            this.clmSubjectDesc.Name = "clmSubjectDesc";
            this.clmSubjectDesc.ReadOnly = true;
            this.clmSubjectDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubjectDesc.Width = 53;
            // 
            // clmSubjDesc
            // 
            this.clmSubjDesc.HeaderText = "Description";
            this.clmSubjDesc.Name = "clmSubjDesc";
            this.clmSubjDesc.ReadOnly = true;
            // 
            // clmSubjPriceID
            // 
            this.clmSubjPriceID.HeaderText = "SUBJECT PRICE ID";
            this.clmSubjPriceID.Name = "clmSubjPriceID";
            this.clmSubjPriceID.ReadOnly = true;
            this.clmSubjPriceID.Visible = false;
            // 
            // clmSubjectPrice
            // 
            this.clmSubjectPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkGreen;
            this.clmSubjectPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmSubjectPrice.HeaderText = "Subject Fee";
            this.clmSubjectPrice.Name = "clmSubjectPrice";
            this.clmSubjectPrice.ReadOnly = true;
            this.clmSubjectPrice.Width = 93;
            // 
            // clmAdditionalFee
            // 
            this.clmAdditionalFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkGreen;
            this.clmAdditionalFee.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmAdditionalFee.HeaderText = "Add\'l Fee";
            this.clmAdditionalFee.Name = "clmAdditionalFee";
            this.clmAdditionalFee.ReadOnly = true;
            this.clmAdditionalFee.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAdditionalFee.Width = 81;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "Type";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 56;
            // 
            // clmPickSched
            // 
            this.clmPickSched.ActiveLinkColor = System.Drawing.Color.DarkSlateGray;
            this.clmPickSched.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmPickSched.HeaderText = "Pick";
            this.clmPickSched.LinkColor = System.Drawing.Color.DarkSlateGray;
            this.clmPickSched.Name = "clmPickSched";
            this.clmPickSched.ReadOnly = true;
            this.clmPickSched.Text = "Pick";
            this.clmPickSched.UseColumnTextForLinkValue = true;
            this.clmPickSched.VisitedLinkColor = System.Drawing.Color.DarkSlateGray;
            this.clmPickSched.Width = 36;
            // 
            // frm_assessment_subject_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 487);
            this.Controls.Add(this.dgSubjects);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_assessment_subject_browser";
            this.Text = "LIST OF AVAILABLE SUBJECTS";
            ((System.ComponentModel.ISupportInitialize)(this.dgSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjPriceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAdditionalFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn clmPickSched;
    }
}