namespace COLM_SYSTEM.Fees_Folder
{
    partial class frm_tuition_entry_browse_subject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgTuition = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.clmCurriculumSubjID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLecUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLabUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddToList = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgTuition);
            this.panel1.Location = new System.Drawing.Point(15, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 406);
            this.panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(110, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(361, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search Subjects";
            // 
            // dgTuition
            // 
            this.dgTuition.AllowUserToAddRows = false;
            this.dgTuition.AllowUserToDeleteRows = false;
            this.dgTuition.BackgroundColor = System.Drawing.Color.White;
            this.dgTuition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTuition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCurriculumSubjID,
            this.clmSubjCode,
            this.clmSubjDesc,
            this.clmLecUnits,
            this.clmLabUnits,
            this.clmUnit,
            this.clmAddToList});
            this.dgTuition.Location = new System.Drawing.Point(14, 51);
            this.dgTuition.Name = "dgTuition";
            this.dgTuition.ReadOnly = true;
            this.dgTuition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTuition.Size = new System.Drawing.Size(785, 340);
            this.dgTuition.TabIndex = 7;
            this.dgTuition.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTuition_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of Curriculum Subjects";
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
            this.clmSubjCode.Width = 102;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLecUnits.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmLecUnits.HeaderText = "Lec Units";
            this.clmLecUnits.Name = "clmLecUnits";
            this.clmLecUnits.ReadOnly = true;
            this.clmLecUnits.Width = 81;
            // 
            // clmLabUnits
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLabUnits.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmLabUnits.HeaderText = "Lab Units";
            this.clmLabUnits.Name = "clmLabUnits";
            this.clmLabUnits.ReadOnly = true;
            this.clmLabUnits.Width = 83;
            // 
            // clmUnit
            // 
            this.clmUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUnit.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmUnit.HeaderText = "Unit";
            this.clmUnit.Name = "clmUnit";
            this.clmUnit.ReadOnly = true;
            this.clmUnit.Width = 55;
            // 
            // clmAddToList
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmAddToList.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmAddToList.HeaderText = "Add to list";
            this.clmAddToList.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            this.clmAddToList.Name = "clmAddToList";
            this.clmAddToList.ReadOnly = true;
            this.clmAddToList.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAddToList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAddToList.Text = "Add";
            this.clmAddToList.UseColumnTextForLinkValue = true;
            this.clmAddToList.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(113)))), ((int)(((byte)(110)))));
            // 
            // frm_tuition_entry_browse_subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 446);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_tuition_entry_browse_subject";
            this.Text = "BROWSE SUBJECT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgTuition;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLecUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit;
        private System.Windows.Forms.DataGridViewLinkColumn clmAddToList;
    }
}