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
    public partial class FormAddOrder : Form
    {
        public FormAddOrder()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                OrderRepository repo = new OrderRepository();
                var or = new Order()
                {
                    CustomerName = txtCusName.Text,
                    Address = txtAddress.Text,
                    Price = int.Parse(txtPrice.Text),
                    OrderDate = DateTime.Now,
                    Status = int.Parse(txtStatus.Text),
                };
                repo.createOrder(or);
                this.Close();
            }
            else
            {
                MessageBox.Show("Your input is not valid!");
            }
            
        }

        private bool checkValid()
        {
            if (int.Parse(txtPrice.Text) < 0)
            {
                return false;
            }

            return true;
        }
    }
}
