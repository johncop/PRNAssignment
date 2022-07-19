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
    public partial class FormUpdateCategory : Form
    {
        public FormUpdateCategory()
        {
            InitializeComponent();
            loadData();
        }
        private Category category;
        public void LoadCategory(Category cat)
        {
            category = cat;
            txtCatId.Text = cat.Id.ToString();
            txtCatName.Name = cat.CategoryName.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*//string name = txtCatName.Text;
            int id = int.Parse(txtCatId.Text);
            CategoryRepository repo = new CategoryRepository();
            repo.Delete(id);
            var cat = new Category()
            {              
                Id = int.Parse(txtCatId.Text),
                CategoryName = txtCatName.Text,
                Status = 1
            };
            repo.AddUpdate(cat);
            loadData();*/
        }

        private void loadData()
        {
            CategoryRepository repo = new CategoryRepository();
            var category = repo.Get();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = category;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
