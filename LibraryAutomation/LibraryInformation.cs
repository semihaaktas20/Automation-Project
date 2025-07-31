using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation
{
    public partial class LibraryInformation : Form
    {
        public LibraryInformation()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BookInformation form = new BookInformation();
            form.Show();
            this.Hide();

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            AuthorInformation form = new AuthorInformation();
            form.Show();
            this.Hide();

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            PublisherInformation form = new PublisherInformation();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrowersInformation form = new BorrowersInformation();
            form.Show();
            this.Hide();
        }
    }
}
