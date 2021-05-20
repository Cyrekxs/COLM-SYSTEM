using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Windows.Forms;

namespace COLM_SYSTEM.subject
{
    public partial class frm_subject_entry : Form
    {
        private Subject _subject = new Subject();
        private string _savingstatus = string.Empty;
        public frm_subject_entry()
        {
            InitializeComponent();
            _savingstatus = "ADD";
        }

        public frm_subject_entry(Subject subject)
        {
            InitializeComponent();
            _savingstatus = "EDIT";
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

        private bool IsValid()
        {
            if (txtSubjCode.Text == string.Empty)
            {
                MessageBox.Show("Please enter subject code!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSubJDesc.Text == string.Empty)
            {
                MessageBox.Show("Please enter subject description!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLecUnits.Text == string.Empty)
            {
                MessageBox.Show("Please enter lecture units!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLabUnits.Text == string.Empty)
            {
                MessageBox.Show("Please enter laboratory units!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDouble(txtTotalUnits.Text) >= 30)
            {
                MessageBox.Show("Invalid Subject Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (IsValid() == false)
            {
                return;
            }

            Subject subject = new Subject();
            subject.SubjID = _subject.SubjID;
            subject.SubjCode = txtSubjCode.Text;
            subject.SubjDesc = txtSubJDesc.Text;
            subject.LecUnit = Convert.ToDouble(txtLecUnits.Text);
            subject.LabUnit = Convert.ToDouble(txtLabUnits.Text);
            subject.Unit = Convert.ToDouble(txtTotalUnits.Text);

            bool ContinueSaving = true;


            bool ExistingResult = false;

            if (_savingstatus == "ADD")
            {
                ExistingResult = Subject.IsSubjectExist(subject);
            }

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
                    if (MessageBox.Show("Subject has been successfully saved! do you want to add another?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
