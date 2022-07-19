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
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (textBoxName.Text == null)
            {
                MessageBox.Show("Customer Name is empty");
            }
            if (textBoxAddress.Text == null)
            {
                MessageBox.Show("Address is empty");

            }
            if (textBoxStatus.Text == null)
            {
                MessageBox.Show("Address is empty");

            }
            if (btnAdd.Text == "Add")
            {

                OrderRepository repo = new OrderRepository();
                Order order = new Order(textBoxName.Text, textBoxAddress.Text, 0, DateTime.Now, Int32.Parse(textBoxStatus.Text));
                repo.createOrder(order);
                MessageBox.Show("Add successfully");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
