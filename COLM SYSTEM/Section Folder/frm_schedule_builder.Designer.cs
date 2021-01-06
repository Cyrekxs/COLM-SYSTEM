namespace COLM_SYSTEM.Section_Folder
{
    partial class frm_schedule_builder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEducationLevel = new System.Windows.Forms.TextBox();
            this.txtYearlevel = new System.Windows.Forms.TextBox();
            this.clmScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurriculumSubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFaculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSubjects = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Source Sans Pro SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Source Sans Pro SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Education Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Source Sans Pro SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(326, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Section";
            // 
            // txtSection
            // 
            this.txtSection.Location = new System.Drawing.Point(329, 40);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(151, 24);
            this.txtSection.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmScheduleID,
            this.clmCurriculumSubjectID,
            this.clmSubject,
            this.clmDesc,
            this.clmDay,
            this.clmTimeIn,
            this.clmTimeOut,
            this.clmRoom,
            this.clmFaculty});
            this.dataGridView1.Location = new System.Drawing.Point(15, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(885, 322);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(769, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 41);
            this.button1.TabIndex = 20;
            this.button1.Text = "SAVE SCHEDULE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEducationLevel
            // 
            this.txtEducationLevel.Location = new System.Drawing.Point(15, 40);
            this.txtEducationLevel.Name = "txtEducationLevel";
            this.txtEducationLevel.ReadOnly = true;
            this.txtEducationLevel.Size = new System.Drawing.Size(151, 24);
            this.txtEducationLevel.TabIndex = 21;
            // 
            // txtYearlevel
            // 
            this.txtYearlevel.Location = new System.Drawing.Point(172, 40);
            this.txtYearlevel.Name = "txtYearlevel";
            this.txtYearlevel.ReadOnly = true;
            this.txtYearlevel.Size = new System.Drawing.Size(151, 24);
            this.txtYearlevel.TabIndex = 22;
            // 
            // clmScheduleID
            // 
            this.clmScheduleID.HeaderText = "Schedule ID";
            this.clmScheduleID.Name = "clmScheduleID";
            this.clmScheduleID.Visible = false;
            // 
            // clmCurriculumSubjectID
            // 
            this.clmCurriculumSubjectID.HeaderText = "Curriculum Subject ID";
            this.clmCurriculumSubjectID.Name = "clmCurriculumSubjectID";
            this.clmCurriculumSubjectID.Visible = false;
            // 
            // clmSubject
            // 
            this.clmSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmSubject.HeaderText = "Subject";
            this.clmSubject.Name = "clmSubject";
            this.clmSubject.ReadOnly = true;
            this.clmSubject.Width = 73;
            // 
            // clmDesc
            // 
            this.clmDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDesc.HeaderText = "Description";
            this.clmDesc.Name = "clmDesc";
            this.clmDesc.ReadOnly = true;
            // 
            // clmDay
            // 
            this.clmDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDay.HeaderText = "Day";
            this.clmDay.Name = "clmDay";
            this.clmDay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDay.Width = 54;
            // 
            // clmTimeIn
            // 
            this.clmTimeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Format = "t";
            dataGridViewCellStyle10.NullValue = null;
            this.clmTimeIn.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmTimeIn.HeaderText = "Time In";
            this.clmTimeIn.Name = "clmTimeIn";
            this.clmTimeIn.Width = 73;
            // 
            // clmTimeOut
            // 
            this.clmTimeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Format = "t";
            dataGridViewCellStyle11.NullValue = null;
            this.clmTimeOut.DefaultCellStyle = dataGridViewCellStyle11;
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
            this.clmFaculty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmFaculty.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmFaculty.HeaderText = "Faculty";
            this.clmFaculty.Name = "clmFaculty";
            this.clmFaculty.ReadOnly = true;
            this.clmFaculty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmFaculty.Width = 72;
            // 
            // lblSubjects
            // 
            this.lblSubjects.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjects.Location = new System.Drawing.Point(758, 47);
            this.lblSubjects.Name = "lblSubjects";
            this.lblSubjects.Size = new System.Drawing.Size(142, 17);
            this.lblSubjects.TabIndex = 23;
            this.lblSubjects.Text = "No of Subjects : ";
            this.lblSubjects.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Click faculty cell to set";
            // 
            // frm_schedule_builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 454);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSubjects);
            this.Controls.Add(this.txtYearlevel);
            this.Controls.Add(this.txtEducationLevel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_schedule_builder";
            this.Text = "frm_schedule_builder";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtEducationLevel;
        private System.Windows.Forms.TextBox txtYearlevel;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurriculumSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFaculty;
        private System.Windows.Forms.Label lblSubjects;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
    }
}