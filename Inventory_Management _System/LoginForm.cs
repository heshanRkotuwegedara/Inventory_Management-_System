using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management__System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

      
        private void btnLogin_Click(object sender, EventArgs e)
        {

            String user = txtUser.Text;
            String password = txtPassword.Text;

            if (user == "Admin" && password == "123")
            {
                MessageBox.Show("Login Successful !");
                MainForm obj = new MainForm();
                obj.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Login Unsuccessful !");
                this.Hide();

            }
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShow.Checked ==  false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
