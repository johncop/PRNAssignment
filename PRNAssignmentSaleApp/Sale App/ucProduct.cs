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

namespace Sale_App
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ProductRepository repo = new ProductRepository();
            var pro = repo.Get();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = pro;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this product?",
               "Delete confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                ProductRepository pro = new ProductRepository();
                pro.Delete(id);
                loadData();
            }
            else
            {
                MessageBox.Show("Please select product to delete");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddProduct formAddPro = new FormAddProduct();
            formAddPro.ShowDialog();
            //formAddCate.FormClosed += FormAddCategory_FormClosed;
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                MessageBox.Show("Search is empty");
                return;
            }
            List<Product> product = new List<Product>();
            //MessageBox.Show(txtSearch.Text);
            //string name = txtSearch.Text;
            // txtSearch.Text = name;
            ProductRepository repo = new ProductRepository();
            Product pro = new Product();
            product = repo.GetName(txtSearch.Text);
            //cate = repo.GetByName(name);
            dataGridView1.DataSource = product;
        }
    }
}
