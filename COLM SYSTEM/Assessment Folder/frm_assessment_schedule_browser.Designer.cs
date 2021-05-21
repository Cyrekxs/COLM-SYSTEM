namespace COLM_SYSTEM.Assessment_Folder
{
    partial class frm_assessment_schedule_browser
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFaculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPick = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmScheduleID,
            this.clmDay,
            this.clmTimeIn,
            this.clmTimeOut,
            this.clmRoom,
            this.clmFaculty,
            this.clmPick});
            this.dataGridView1.Location = new System.Drawing.Point(13, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(820, 394);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // clmScheduleID
            // 
            this.clmScheduleID.HeaderText = "SCHEDULE ID";
            this.clmScheduleID.Name = "clmScheduleID";
            this.clmScheduleID.ReadOnly = true;
            this.clmScheduleID.Visible = false;
            // 
            // clmDay
            // 
            this.clmDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDay.HeaderText = "DAY";
            this.clmDay.Name = "clmDay";
            this.clmDay.ReadOnly = true;
            this.clmDay.Width = 52;
            // 
            // clmTimeIn
            // 
            this.clmTimeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTimeIn.HeaderText = "TIME IN";
            this.clmTimeIn.Name = "clmTimeIn";
            this.clmTimeIn.ReadOnly = true;
            this.clmTimeIn.Width = 74;
            // 
            // clmTimeOut
            // 
            this.clmTimeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTimeOut.HeaderText = "TIME OUT";
            this.clmTimeOut.Name = "clmTimeOut";
            this.clmTimeOut.ReadOnly = true;
            this.clmTimeOut.Width = 85;
            // 
            // clmRoom
            // 
            this.clmRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRoom.HeaderText = "ROOM";
            this.clmRoom.Name = "clmRoom";
            this.clmRoom.ReadOnly = true;
            this.clmRoom.Width = 68;
            // 
            // clmFaculty
            // 
            this.clmFaculty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFaculty.HeaderText = "FACULTY";
            this.clmFaculty.Name = "clmFaculty";
            this.clmFaculty.ReadOnly = true;
            this.clmFaculty.Width = 75;
            // 
            // clmPick
            // 
            this.clmPick.ActiveLinkColor = System.Drawing.Color.SeaGreen;
            this.clmPick.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmPick.HeaderText = "PICK";
            this.clmPick.LinkColor = System.Drawing.Color.SeaGreen;
            this.clmPick.Name = "clmPick";
            this.clmPick.ReadOnly = true;
            this.clmPick.Text = "PICK";
            this.clmPick.UseColumnTextForLinkValue = true;
            this.clmPick.VisitedLinkColor = System.Drawing.Color.SeaGreen;
            this.clmPick.Width = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "SUBJECT";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(13, 43);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(450, 23);
            this.txtSubject.TabIndex = 2;
            // 
            // frm_assessment_schedule_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 501);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_assessment_schedule_browser";
            this.Text = "SCHEDULE BROWSER";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFaculty;
        private System.Windows.Forms.DataGridViewLinkColumn clmPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
    }
}