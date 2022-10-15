using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockForceLauncher
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Server.Auth.Login authEnticator = new Server.Auth.Login(this.txtUsername.Text, this.txtPassword.Text);
            MessageBox.Show(authEnticator.GetToken().ToString());
        }
    }
}
