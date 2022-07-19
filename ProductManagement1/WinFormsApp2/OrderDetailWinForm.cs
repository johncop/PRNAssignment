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
    public partial class OrderDetailWinForm : Form
    {
        public OrderDetailWinForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OrderDetailWinForm_Load(object sender, EventArgs e)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            List<OrderDetail> list = new List<OrderDetail>();
            list = repo.GetOrderDetails();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            List<OrderDetail> list = new List<OrderDetail>();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    repo.deleteOrderDetail(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    MessageBox.Show("Delete Successfully");
                }
            }
            repo = new OrderDetailRepository();
            list = new List<OrderDetail>();
            list = repo.GetOrderDetails();
            dataGridView1.DataSource = list;

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            List<OrderDetail> list = new List<OrderDetail>();
            list = repo.GetOrderDetails();
            dataGridView1.DataSource = list;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderWin form = new OrderWin();
            this.Hide();
            form.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
        }
    }
}
