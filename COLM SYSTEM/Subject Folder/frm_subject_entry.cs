using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Windows.Forms;

namespace COLM_SYSTEM.subject
{
    public partial class frm_subject_entry : Form
    {
        private Subject _subject = new Subject();
        public frm_subject_entry()
        {
            InitializeComponent();
        }

        public frm_subject_entry(Subject subject)
        {
            InitializeComponent();
            _subject = subject;
            txtSubjCode.Text = subject.SubjCode;
            txtSubJDesc.Text = subject.SubjDesc;
            txtLecUnits.Text = subject.LecUnit.ToString();
            txtLabUnits.Text = subject.LabUnit.ToString();
        }

        private void tm_unit_calculator_Tick(object sender, EventArgs e)
        {
            try
            {
                double TotalUnits = 0;
                double lecUnits = Convert.ToDouble(txtLecUnits.Text);
                double labUnits = Convert.ToDouble(txtLabUnits.Text);

                TotalUnits = lecUnits + labUnits;

                txtTotalUnits.Text = TotalUnits.ToString();
            }
            catch (Exception)
            { /*no throw exception */ }

        }

        private void ClearControls()
        {
            txtSubjCode.Text = string.Empty;
            txtSubJDesc.Text = string.Empty;
            txtLecUnits.Text = 0.ToString();
            txtLabUnits.Text = 0.ToString();
            txtSubjCode.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.SubjID = _subject.SubjID;
            subject.SubjCode = txtSubjCode.Text;
            subject.SubjDesc = txtSubJDesc.Text;
            subject.LecUnit = Convert.ToDouble(txtLecUnits.Text);
            subject.LabUnit = Convert.ToDouble(txtLabUnits.Text);


            bool ExistingResult = Subject.IsSubjectExist(subject);
            bool ContinueSaving = true;
            if (ExistingResult == true)
            {
                if(MessageBox.Show("Program detected that your trying to create new subject that's already existing in the record! do you want to continue this action?","Duplicate Detected",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    ContinueSaving = false;
                    ClearControls();
                }                 
            }

            if (ContinueSaving == true)
            {
                bool InsertResult = Subject.InsertUpdateSubject(subject);
                if (InsertResult == true)
                {
                    if (MessageBox.Show("Subject has been successfully created! do you want to add another?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        Close();
                        Dispose();
                    }
                    else
                    {
                        ClearControls();
                    }
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
