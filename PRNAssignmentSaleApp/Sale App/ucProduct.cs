using ProductManagement1.Data;
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
    }
}
