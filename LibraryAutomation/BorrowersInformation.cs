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
    public partial class BorrowersInformation : Form
    {
        public BorrowersInformation()
        {
            InitializeComponent();
        }
        LibraryDbEntities3 libraryDbEntities3 = new LibraryDbEntities3();
        public void Borrowers_list()
        {
            dataGridView1.DataSource = libraryDbEntities3.BorrowersInfo.ToList();
        }
        private void BorrowersInformation_Load(object sender, EventArgs e)
        {
           Borrowers_list();

        }
        public void clear()
        {
            txtBorrowerName.Text = txtDepartment.Text = txtEmail.Text = txtPhone.Text = txtBorrowedDate.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BorrowersInfo borrower = new BorrowersInfo();
            borrower.Borrowers_Name = txtBorrowerName.Text;
            borrower.Department = txtDepartment.Text;
            borrower.Email = txtEmail.Text;
            borrower.Phone = txtPhone.Text;
            borrower.Borrowed_Date = txtBorrowedDate.Text;
            libraryDbEntities3.BorrowersInfo.Add(borrower);
            libraryDbEntities3.SaveChanges();
            MessageBox.Show("New borrower information registered", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
            Borrowers_list();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBorrowerName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtBorrowedDate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(labelID.Text);
            var borrower = libraryDbEntities3.BorrowersInfo.First(x => x.ID == id);
            libraryDbEntities3.BorrowersInfo.Remove(borrower);
            libraryDbEntities3.SaveChanges();
            clear();
            Borrowers_list();
            MessageBox.Show("Borrower information deleted", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(labelID.Text);
            var borrower = libraryDbEntities3.BorrowersInfo.First(x => x.ID == id);
            borrower.Borrowers_Name = txtBorrowerName.Text;
            borrower.Department = txtDepartment.Text;
            borrower.Email = txtEmail.Text;
            borrower.Phone = txtPhone.Text;
            borrower.Borrowed_Date = txtBorrowedDate.Text;
            libraryDbEntities3.SaveChanges();
            MessageBox.Show("Borrower information successfuly updated", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
            Borrowers_list();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtSearchBorrower_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchBorrower.Text != string.Empty)
            {
                var search_Borrower = libraryDbEntities3.BorrowersInfo.Where(x => x.Borrowers_Name.Contains(txtSearchBorrower.Text));
                dataGridView1.DataSource = search_Borrower.ToList();
            }
            else
            {
                Borrowers_list();
            }
        }
    }
}
