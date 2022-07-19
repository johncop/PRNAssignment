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
    public partial class FormAddCategory : Form
    {
        public FormAddCategory()
        {
            InitializeComponent();
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            CategoryRepository repo = new CategoryRepository();
            var cat = new Category()
            {
                CategoryName = txtName.Text,
                Status = 1
            };
            repo.Add(cat);
            this.Close();
        }

        private void FormAddCategory_FormClosed(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
