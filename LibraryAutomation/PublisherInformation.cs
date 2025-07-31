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
    public partial class PublisherInformation : Form
    {
        public PublisherInformation()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        LibraryContext context = new LibraryContext();
        public void Publisher_list()
        {
            dataGridView1.DataSource = context.Publishers.ToList();
        }
        private void PublisherInformation_Load(object sender, EventArgs e)
        {
            Publisher_list();
        }
        public void clear()
        {
            txtPublisher.Text = txtEmail.Text = txtPhone.Text = txtCity.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.PublisherName = txtPublisher.Text;
            publisher.Email= txtEmail.Text;
            publisher.Phone = txtPhone.Text;
            publisher.City = txtCity.Text;
            context.Publishers.Add(publisher);
            context.SaveChanges();
            MessageBox.Show("New publisher information registered", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Publisher_list();
            clear();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPublisher.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(labelID.Text);
            var publisher = context.Publishers.FirstOrDefault(x => x.Id == Id);
            context.Publishers.Remove(publisher);
            context.SaveChanges();
            clear();
            Publisher_list();
            MessageBox.Show("Publisher information successfuly deleted", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(labelID.Text);
            var publisher = context.Publishers.FirstOrDefault(x => x.Id == Id);
            publisher.PublisherName = txtPublisher.Text;
            publisher.Email = txtEmail.Text;
            publisher.Phone = txtPhone.Text;
            publisher.City = txtCity.Text;
            context.SaveChanges();
            MessageBox.Show("Publisher information successfuly updated", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Publisher_list();
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtSearchPublisher_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchPublisher.Text != string.Empty)
            {
                var SearchPublisher = context.Publishers.Where(x => x.PublisherName.Contains(txtSearchPublisher.Text));
                dataGridView1.DataSource = SearchPublisher.ToList();
            }
            else
            {
                Publisher_list();
            }
        }
    }

}
