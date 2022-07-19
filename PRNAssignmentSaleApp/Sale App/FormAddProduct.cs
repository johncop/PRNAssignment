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
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
            //loadCateId();
        }

        /*private void loadCateId()
        {
            Category cate = new Category();
            cateComboBox.DisplayMember = "CategoryName";
            cateComboBox.ValueMember = "CategoryId";
            cateComboBox.DataSource = cate.;
        }*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValid()) 
            {
                ProductRepository repo = new ProductRepository();
                var pro = new Product()
                {
                    Name = txtProName.Text,
                    Price = double.Parse(txtProPrice.Text),
                    CreateDate = DateTime.Now,
                    Status = int.Parse(txtProStatus.Text),
                    CategoryId = int.Parse(txtCateId.Text)
                };
                repo.Add(pro);
                this.Close();
            }
            else
            {
                MessageBox.Show("Your input is not valid!");
            }          
        }

        private bool checkValid()
        {
            if(int.Parse(txtProPrice.Text) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
