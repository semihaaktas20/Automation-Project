using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAutomation.LibraryCodeFirstEntity;

namespace LibraryAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //using (LibraryContext context= new LibraryContext()) {
           // context.Database.Create();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string providedUsername = txtUserName.Text;
            string providedPassword = txtPassword.Text;

            using (var context = new LibraryContext())
            {
                bool userExists = context.Login.Any(u => u.UserName == providedUsername && u.Password == providedPassword);
                if (userExists)
                {
                    MessageBox.Show("Welcome to Library Automation");
                    LibraryInformation form = new LibraryInformation();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please Enter Correct User Name and Password");
                }
            }
        }
    }
}
