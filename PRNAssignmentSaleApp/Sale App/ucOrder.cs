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
    public partial class ucOrder : UserControl
    {
        public ucOrder()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            OrderRepository repo = new OrderRepository();
            var pro = repo.Get();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = pro;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddOrder formAddOrder = new FormAddOrder();
            formAddOrder.ShowDialog();
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this order?",
               "Delete confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                OrderRepository repo = new OrderRepository();
                repo.deleteOrder(id);
                loadData();
            }
            else
            {
                MessageBox.Show("Please select order to delete");
            }
        }
    }
}
