using prenatal.model;
using prenatal.model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prenatal.winUI.PanelDoctor
{
    public partial class frmPrescriptions : Form
    {
        APIservice _Prescription = new APIservice("Prescription");
        public int _choosenPatientId { get; set; } = -1;
        public int _currentUserId { get; set; } = -1;
        public frmPrescriptions()
        {
            InitializeComponent();
        }
        private bool ValidateData(object data)
        {
            ValidationContext context = new ValidationContext(data, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(data, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);

                return false;
            }
            else
            {
                MessageBox.Show("Success!!!");
                return true;
            }
        }
        private async void LoadGrid()
        {
            PrescriptionSearchRequest request = new PrescriptionSearchRequest();
            request.MedicalRecordId = _choosenPatientId;
            dgPrescription.AutoGenerateColumns = false;
            dgPrescription.DataSource = await _Prescription.Get<List<Prescription>>(request);
            
        }
        private void Clear()
        {
            textBoxId.Text = "";
            textBoxDescription.Text = "";
            textBoxDose.Text = "";
            textBoxUsage.Text = "";
            dtpDate.Value = DateTime.Now;
            textBoxNote.Text = "";
        }

        private void frmPrescriptions_Load(object sender, EventArgs e)
        {
            LoadGrid();
            Clear();
        }

        private void dgPrescription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            textBoxId.Text = dgPrescription.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxDescription.Text= dgPrescription.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxDose.Text= dgPrescription.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxUsage.Text= dgPrescription.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpDate.Value = Convert.ToDateTime(dgPrescription.Rows[e.RowIndex].Cells[4].Value.ToString());
            textBoxNote.Text= dgPrescription.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            PrescriptionUpsertRequest request = new PrescriptionUpsertRequest();
            request.MedicalRecordsId = _choosenPatientId;
            request.Description = textBoxDescription.Text;
            request.Dose = textBoxDose.Text;
            request.Usage = textBoxUsage.Text;
            request.Date = dtpDate.Value;
            request.Note = textBoxNote.Text;

            if (ValidateData(request))
            {
                await _Prescription.Insert<Prescription>(request);
                LoadGrid();
                Clear();
            }

        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "" || textBoxId.TextLength == 0 || textBoxId.Text == null) return;

            int pId = Int32.Parse(textBoxId.Text);
            PrescriptionUpsertRequest request = new PrescriptionUpsertRequest();
            request.MedicalRecordsId = _choosenPatientId;
            request.Description = textBoxDescription.Text;
            request.Dose = textBoxDose.Text;
            request.Usage = textBoxUsage.Text;
            request.Date = dtpDate.Value;
            request.Note = textBoxNote.Text;

            if (ValidateData(request))
            {
                await _Prescription.Update<Prescription>(pId,request);
                LoadGrid();
                Clear();
            }

        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "" || textBoxId.TextLength == 0 || textBoxId.Text == null) return;

            int pId = Int32.Parse(textBoxId.Text);

            await _Prescription.Delete<Prescription>(pId);
            LoadGrid();
            Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void medicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            DoctorsPanel frm = new DoctorsPanel();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void vitalSignsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmVitalSign frm = new frmVitalSign();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void ultrasoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmUltrasounds frm = new frmUltrasounds();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void therapiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmTherapies frm = new frmTherapies();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void substancesUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmSubstances frm = new frmSubstances();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void referralsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmReferrals frm = new frmReferrals();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void previousPregnanciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmPrevPregnancies frm = new frmPrevPregnancies();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void prescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            
        }
    }
}
