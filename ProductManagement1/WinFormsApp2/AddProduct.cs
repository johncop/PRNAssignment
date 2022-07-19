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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (textBoxName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Product name is empty");
                return;
            }
            if (textBoxPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Price is empty");
                return;
            }
            if (Int32.Parse(textBoxPrice.Text.Trim()) < 0)
            {
                MessageBox.Show("Price must not be smaller than 0");
                return;
            }
            if (textBoxCategory.Text.Trim().Length == 0)
            {
                MessageBox.Show("Category is empty");
                return;
            }
            if (textBoxStatus.Text.Trim().Length == 0)
            {
                MessageBox.Show("Status is empty");
                return;
            }
            if (btnAdd.Text == "Add")
            {
                if (MessageBox.Show("Are you sure you want to Add?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductRepository repoproduct = new ProductRepository();
                    CategoryRepository repocate = new CategoryRepository();
                        Product product = new Product(textBoxName.Text, Int32.Parse(textBoxPrice.Text.Trim()), DateTime.Now, 1, Int32.Parse(textBoxCategory.Text));
                        repoproduct.Add(product);
                        MessageBox.Show("Add successfully");

                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
