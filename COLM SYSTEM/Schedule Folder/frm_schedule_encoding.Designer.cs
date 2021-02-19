namespace COLM_SYSTEM.Schedule_Folder
{
    partial class frm_schedule_encoding
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgTuition = new System.Windows.Forms.DataGridView();
            this.clmSubjectScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDay = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmTimeIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFaculty = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(614, 59);
            this.textBox1.TabIndex = 2;
            // 
            // dgTuition
            // 
            this.dgTuition.AllowUserToAddRows = false;
            this.dgTuition.AllowUserToDeleteRows = false;
            this.dgTuition.BackgroundColor = System.Drawing.Color.White;
            this.dgTuition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTuition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSubjectScheduleID,
            this.clmDay,
            this.clmTimeIN,
            this.clmTimeOut,
            this.clmRoom,
            this.clmFaculty});
            this.dgTuition.Location = new System.Drawing.Point(15, 111);
            this.dgTuition.Name = "dgTuition";
            this.dgTuition.Size = new System.Drawing.Size(614, 274);
            this.dgTuition.TabIndex = 26;
            // 
            // clmSubjectScheduleID
            // 
            this.clmSubjectScheduleID.HeaderText = "Subject Schedule ID";
            this.clmSubjectScheduleID.Name = "clmSubjectScheduleID";
            this.clmSubjectScheduleID.Visible = false;
            // 
            // clmDay
            // 
            this.clmDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDay.HeaderText = "Day";
            this.clmDay.Items.AddRange(new object[] {
            "MON",
            "TUE",
            "WED",
            "THU",
            "FRI",
            "SAT",
            "SUN"});
            this.clmDay.Name = "clmDay";
            this.clmDay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmDay.Width = 54;
            // 
            // clmTimeIN
            // 
            this.clmTimeIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTimeIN.HeaderText = "Time In";
            this.clmTimeIN.Name = "clmTimeIN";
            this.clmTimeIN.Width = 73;
            // 
            // clmTimeOut
            // 
            this.clmTimeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTimeOut.HeaderText = "Time Out";
            this.clmTimeOut.Name = "clmTimeOut";
            this.clmTimeOut.Width = 83;
            // 
            // clmRoom
            // 
            this.clmRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRoom.HeaderText = "Room";
            this.clmRoom.Name = "clmRoom";
            this.clmRoom.Width = 65;
            // 
            // clmFaculty
            // 
            this.clmFaculty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFaculty.HeaderText = "Faculty";
            this.clmFaculty.Name = "clmFaculty";
            this.clmFaculty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmFaculty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Schedules";
            // 
            // frm_schedule_encoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 397);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgTuition);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_schedule_encoding";
            this.Text = "SCHEDULE ENCODING";
            ((System.ComponentModel.ISupportInitialize)(this.dgTuition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgTuition;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjectScheduleID;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoom;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmFaculty;
        private System.Windows.Forms.Label label2;
    }
}