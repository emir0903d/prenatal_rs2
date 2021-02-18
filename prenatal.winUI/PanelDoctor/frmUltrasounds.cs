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
    public partial class frmUltrasounds : Form
    {                  
        APIservice _us = new APIservice("Ultrasound");
        
        public int _choosenPatientId { get; set; }
        public int _currentUserId { get; set; }
        public frmUltrasounds()
        {
            InitializeComponent();
        }

        private void medicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoctorsPanel frm = new DoctorsPanel();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();


        }
        private async void LoadGrid()
        {
            UltrasoundSearchRequest tsearch = new UltrasoundSearchRequest();
            tsearch.MedicalRecordId = _choosenPatientId;
            if(await _us.Get<List<Ultrasound>>(tsearch) != null)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = await _us.Get<List<Ultrasound>>(tsearch);
            }
            

        }
        private void frmUltrasounds_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void Clear()
        {
            textBoxAbdominalCircumference.Text = "";
            textBoxFemurLength.Text = "";
            textBoxHeadCircumference.Text = "";
            textBoxHeadDiameter.Text = "";
            textBoxHeartbeats.Text = "";
            textBoxId.Text = "";
            textBoxLenght.Text = "";
            textBoxNote.Text = "";
            checkBoxAnomalies.Checked = false;
            checkBoxMovement.Checked = false;
            checkBoxNuhalScan.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            UltrasoundUpsertRequest x = new UltrasoundUpsertRequest();
            x.MedicalRecordsId = _choosenPatientId;
            x.NuchalScan = checkBoxNuhalScan.Checked;
            x.Note = textBoxNote.Text;
            x.Movement = checkBoxMovement.Checked;
            if (textBoxLenght.Text != "")
            {
                x.Length = float.Parse(textBoxLenght.Text);
            }
            if (textBoxHeartbeats.Text != "")
            {
                x.HeartBeats = Int32.Parse(textBoxHeartbeats.Text);
            }
            if (textBoxHeadDiameter.Text != "")
            {
                x.HeadDiameter = float.Parse(textBoxHeadDiameter.Text);
            }
            if (textBoxHeadCircumference.Text != "")
            {
                x.HeadCircumference = float.Parse(textBoxHeadCircumference.Text);
            }
            if (textBoxFemurLength.Text != "")
            {
                x.FemurLength = float.Parse(textBoxFemurLength.Text);
            }
            if (textBoxAbdominalCircumference.Text != "")
            {
                x.AbdominalCircumference = float.Parse(textBoxAbdominalCircumference.Text);
            }
            
            x.Date = dateTimePicker1.Value;
            

            if (ValidateData(x))
            {
                await _us.Insert<Ultrasound>(x);
                Clear();
                LoadGrid();
            }

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

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "" || textBoxId.TextLength == 0 || textBoxId.Text == null) return;

            UltrasoundUpsertRequest x = new UltrasoundUpsertRequest();
            x.MedicalRecordsId = _choosenPatientId;
            x.NuchalScan = checkBoxNuhalScan.Checked;
            x.Note = textBoxNote.Text;
            x.Movement = checkBoxMovement.Checked;
            if (textBoxLenght.Text != "")
            {
                x.Length = float.Parse(textBoxLenght.Text);
            }
            if (textBoxHeartbeats.Text != null)
            {
                x.HeartBeats = Int32.Parse(textBoxHeartbeats.Text);
            }
            if (textBoxHeadDiameter.Text != "")
            {
                x.HeadDiameter = float.Parse(textBoxHeadDiameter.Text);
            }
            if (textBoxHeadCircumference.Text != "")
            {
                x.HeadCircumference = float.Parse(textBoxHeadCircumference.Text);
            }
            if (textBoxFemurLength.Text != "")
            {
                x.FemurLength = float.Parse(textBoxFemurLength.Text);
            }
            if (textBoxAbdominalCircumference.Text != "")
            {
                x.AbdominalCircumference = float.Parse(textBoxAbdominalCircumference.Text);
            }

            x.Date = dateTimePicker1.Value;
            int usId=-1;
            if (textBoxId.Text != "")
            {
                usId = Int32.Parse(textBoxId.Text);
            }
            
            if (ValidateData(x))
            {
                await _us.Update<Ultrasound>(usId,x);
                Clear();
                LoadGrid();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            int usId = -1;
            if (textBoxId.Text != "")
            {
                usId = Int32.Parse(textBoxId.Text);
                await _us.Delete<Ultrasound>(usId);
                LoadGrid();
                Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            textBoxId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBoxHeartbeats.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            checkBoxMovement.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            textBoxLenght.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            checkBoxNuhalScan.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            checkBoxAnomalies.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            textBoxHeadDiameter.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxHeadCircumference.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBoxAbdominalCircumference.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBoxFemurLength.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBoxNote.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadGrid();
            Clear();
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
            this.Refresh();
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
            if (this._choosenPatientId == -1 || this._currentUserId == -1) return;

            frmPrescriptions frm = new frmPrescriptions();
            frm._currentUserId = this._currentUserId;
            frm._choosenPatientId = this._choosenPatientId;

            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            this.Dispose();
        }
    }
}
