using Flurl.Http.Testing;
using prenatal.model;
using prenatal.model.Enumerations;
using prenatal.model.Requests;
using prenatal.winUI;
using prenatal.winUI.PanelDoctor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prenatal.winUI
{
    public partial class frmLogin : Form
    {
        AuthService _authService = new AuthService();
        public User auth { get; set; } = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == " " || textBoxUsername.TextLength == 0 || textBoxUsername.Text == null) return;
            if (textBoxPassword.Text == " " || textBoxPassword.TextLength == 0 || textBoxPassword.Text == null) return;

            AuthService.Username = textBoxUsername.Text;
            AuthService.Password = textBoxPassword.Text;
            UserAuthenticationRequest request = new UserAuthenticationRequest();
            request.username = AuthService.Username;
            request.password = AuthService.Password;
           
            auth= await _authService.Authenticate<User>(request);
            if (auth == null) return;
            
            auth.LoginCount++;
            auth.LastLogin = DateTime.Now;
            APIservice _users = new APIservice("User");
            APIservice.Username = AuthService.Username;
            APIservice.Password = AuthService.Password;
            await _users.Update<User>(auth.Id, auth);

            foreach (ToolStripMenuItem x in this.MdiParent.MainMenuStrip.Items)
            {
                if (x.Name== "authenticateToolStripMenuItem")
                {
                    foreach(ToolStripMenuItem y in x.DropDownItems)
                    {
                        if (y.Name == "loginToolStripMenuItem")
                        {
                            y.Enabled = false;
                        }
                        if (y.Name == "logoutToolStripMenuItem")
                        {
                            y.Text = "Logout, /" + auth.Id+" ,"+auth.Name+" "+auth.Surname;
                            y.Enabled = true;
                            
                        }
                    }
                    
                }
    
            }


            if (auth != null)
            {
                if (auth.Type == UserType.Type.Admin)
                {
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel._currentUserId = auth.Id;
                    adminPanel.WindowState = FormWindowState.Maximized;
                    adminPanel.MdiParent = this.MdiParent;
                    adminPanel.Show();
                    this.Close();
                    this.Dispose();
                }
                if (auth.Type == UserType.Type.Doctor)
                {
                    DoctorsPanel docPanel = new DoctorsPanel();
                    docPanel._currentUserId = auth.Id;
                    docPanel.WindowState = FormWindowState.Maximized;
                    docPanel.MdiParent = this.MdiParent;
                    docPanel.Show();
                    this.Close();
                    this.Dispose();
                }
                _users = null;
            }
                
        }       

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
