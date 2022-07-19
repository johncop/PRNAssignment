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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Fsale management system";
        }

        private ucCategory ucCategory;
        private ucProduct ucProduct;
        private ucOrder ucOrder;
        private void orderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked Order Management!");
            if(ucOrder == null)
            {
                ucOrder = new ucOrder();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(ucOrder);
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked Product Management!");
            if(ucProduct == null)
            {
                ucProduct = new ucProduct();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(ucProduct);
        }

        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked catagory Management!");
            if(ucCategory == null)
            {
                ucCategory = new ucCategory();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(ucCategory);
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked about us!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
