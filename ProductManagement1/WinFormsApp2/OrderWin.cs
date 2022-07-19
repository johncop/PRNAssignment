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
    public partial class OrderWin : Form
    {
        public OrderWin()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            OrderRepository repo = new OrderRepository();
            List<Order> listOrder = new List<Order>();
            listOrder = repo.Get();
            dataGridView1.DataSource = listOrder;
            dataGridView1.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            OrderRepository repo = new OrderRepository();
            List<Order> listOrder = new List<Order>();
            listOrder = repo.Get();
            dataGridView1.DataSource = listOrder;
            dataGridView1.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrder form = new AddOrder();
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderRepository repo = new OrderRepository();
            List<Order> list = new List<Order>();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {

                if (MessageBox.Show("Are you sure you want to Update?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    Order order = new Order(
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()),
                        DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()),
                        Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()));
                    repo.updateOrder(order.CustomerName,order.Address, Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    repo.deleteOrder(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    MessageBox.Show("Delete Successfully");
                }
            }
            repo = new OrderRepository();
            list = repo.Get();
            dataGridView1.DataSource = list;
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            OrderDetailWinForm form = new OrderDetailWinForm();
            this.Hide();
            form.ShowDialog();
        }
    }
}
