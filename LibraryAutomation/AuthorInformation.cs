using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAutomation.LibraryCodeFirstEntity;

namespace LibraryAutomation
{
    public partial class AuthorInformation : Form
    {
        public AuthorInformation()
        {
            InitializeComponent();
        }
        LibraryContext context = new LibraryContext();

        public void Author_list()
        {
            dataGridView1.DataSource = context.Authors.ToList();
        }

        private void AuthorInformation_Load(object sender, EventArgs e)
        {
            Author_list();
        }
        public void clear()
        {
            txtAuthorName.Text = txtCountry.Text = txtGender.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.AuthorName = txtAuthorName.Text;
            author.Country = txtCountry.Text;
            author.Gender = txtGender.Text;
            context.Authors.Add(author);
            context.SaveChanges();
            MessageBox.Show("New author information registered", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Author_list();
            clear();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAuthorName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGender.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(labelID.Text);
            var author = context.Authors.FirstOrDefault(x => x.Id == Id);
            context.Authors.Remove(author);
            context.SaveChanges();
            clear();
            Author_list();
            MessageBox.Show("Author information deleted", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(labelID.Text);
            var author = context.Authors.FirstOrDefault(x => x.Id == Id);
            author.AuthorName = txtAuthorName.Text;
            author.Country = txtCountry.Text;
            author.Gender = txtGender.Text;
            context.SaveChanges();
            MessageBox.Show("Author information successfuly updated", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Author_list();
            clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtSearchAuthor_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchAuthor.Text != string.Empty)
            {
                var SearchAuthor = context.Authors.Where(x => x.AuthorName.Contains(txtSearchAuthor.Text));
                dataGridView1.DataSource = SearchAuthor.ToList();
            }
            else
            {
                Author_list();
            }
        }
    }
}
