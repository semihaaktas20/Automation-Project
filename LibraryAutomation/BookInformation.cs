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
    public partial class BookInformation : Form
    {
        public BookInformation()
        {
            InitializeComponent();
        }

      

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        LibraryContext context= new LibraryContext();
        public void Book_list()
        {
            dataGridView1.DataSource= context.Books.ToList();
        }

        private void BookInformation_Load(object sender, EventArgs e)
        {
            Book_list();
        }
        public void clear()
        {
            txtBookName.Text = txtPages.Text = txtLanguage.Text = txtEdition.Text = txtAuthor.Text = string.Empty;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book= new Book();
            book.BookName= txtBookName.Text;
            book.Pages= txtPages.Text;
            book.Language= txtLanguage.Text;
            book.Edition = txtEdition.Text;
            book.Author = txtAuthor.Text;
            context.Books.Add(book);
            context.SaveChanges();
            MessageBox.Show("New book information registered", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Book_list();
            clear();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label_Id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBookName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPages.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLanguage.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEdition.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAuthor.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(label_Id.Text);
            var book = context.Books.FirstOrDefault(x => x.Id == Id);
            context.Books.Remove(book); 
            context.SaveChanges();
            clear();
            Book_list();
            MessageBox.Show("Book information deleted", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(label_Id.Text);
            var book = context.Books.FirstOrDefault(x => x.Id == Id);
            book.BookName = txtBookName.Text;
            book.Pages = txtPages.Text;
            book.Language = txtLanguage.Text;
            book.Edition = txtEdition.Text;
            book.Author = txtAuthor.Text;
            context.SaveChanges();
            MessageBox.Show("Book information successfuly updated", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Book_list();
            clear();

        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBook.Text != string.Empty)
            {
                var SearchBook = context.Books.Where(x => x.BookName.Contains(txtSearchBook.Text));
                dataGridView1.DataSource= SearchBook.ToList();
            }
            else
            {
                Book_list();
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
