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

namespace WinFormsApp1
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        public void clear()
        {
            textBoxName.Text = textBoxPrice.Text = comboBoxCategory.Text = comboBoxStatus.Text = string.Empty;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Product_Admin form = new Product_Admin();
            this.Close();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            CategoryRepository repo = new CategoryRepository();
            List<Category> list = new List<Category>();
            list = repo.Get();
            foreach(Category cate in list)
            {
                comboBoxCategory.Items.Add(cate.CategoryName);
            }
            comboBoxStatus.Items.Add("True");
            comboBoxStatus.Items.Add("False");
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            
            if(textBoxName.Text.Trim().Length == 0)
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
            if(comboBoxCategory.Text.Trim().Length == 0)
            {
                MessageBox.Show("Category is empty");
                return;
            }
            if(comboBoxStatus.Text.Trim().Length == 0)
            {
                MessageBox.Show("Status is empty");
                return;
            }
            if(btnAddProduct.Text == "Add Product")
            {
                if (MessageBox.Show("Are you sure you want to Add?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductRepository repoproduct = new ProductRepository();
                    CategoryRepository repocate = new CategoryRepository();
                    Category cate = new Category();
                    cate = repocate.GetByName(comboBoxCategory.Text);
                    if (comboBoxStatus.Text == "True")
                    {
                        Product product = new Product(textBoxName.Text, Int32.Parse(textBoxPrice.Text.Trim()), DateTime.Now, 1, cate.Id);
                        repoproduct.Add(product);
                        MessageBox.Show("Add successfully");
                        this.clear();

                    }
                }
            }
        }
    }
}
