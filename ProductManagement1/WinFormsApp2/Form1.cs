using ProductManagement1.Data;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductRepository repo = new ProductRepository();
            List<Product> list = new List<Product>();
            list = repo.Get();
            dataGridView1.DataSource = list;
            dataGridView1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductRepository repo = new ProductRepository();
            List<Product> list = new List<Product>();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    repo.Delete(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    MessageBox.Show("Delete Successfully");
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {

                if (MessageBox.Show("Are you sure you want to Update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Product product = new Product(
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()),
                        DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()),
                        Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()),
                        Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()));
                    repo.Update(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()), product);
                }
            }
            repo = new ProductRepository();
            list = repo.Get();
            dataGridView1.DataSource = list;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ProductRepository repo = new ProductRepository();
            List<Product> list = new List<Product>();
            list = repo.Get();
            dataGridView1.DataSource = list;
            dataGridView1.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderWin form = new OrderWin();
            this.Hide();
            form.ShowDialog();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            OrderDetailWinForm form = new OrderDetailWinForm();
            this.Hide();
            form.ShowDialog();
        }
    }
}
