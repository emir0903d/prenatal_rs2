using prenatal.winUI.PanelDoctor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prenatal.winUI
{
    public partial class FrontPanel : Form
    {
        public FrontPanel()
        {
            InitializeComponent();
        }

        private void FrontPage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        frmLogin login = null;

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Dispose();
            login = null;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrontPanel.ActiveForm.HasChildren)
            {
                foreach (Form x in FrontPanel.ActiveForm.MdiChildren)
                {
                    //if (x.ActiveControl.HasChildren)
                    //{
                    //    foreach (Form y in x.MdiChildren)
                    //    {
                    //        y.Close();
                    //        y.Dispose();
                    //    }
                    //}
                    x.Close();
                    x.Dispose();
                }
            }
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
        }

        private void loginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            login = new frmLogin();
            login.MdiParent = this;
            login.WindowState = FormWindowState.Maximized;
            login.Show();
        }
    }
}
