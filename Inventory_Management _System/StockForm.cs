using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management__System
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbMSDataSet3.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.dbMSDataSet3.Users);
            // TODO: This line of code loads data into the 'dbMSDataSet2.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.dbMSDataSet2.Supplier);
            // TODO: This line of code loads data into the 'dbMSDataSet1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dbMSDataSet1.Product);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockForm obj = new StockForm();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserForm obj = new UserForm();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm obj = new ProductForm();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
