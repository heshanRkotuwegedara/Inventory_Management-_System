using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Inventory_Management__System
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        //Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=Heshan_Rathsara;Initial Catalog=dbMS;Integrated Security=True");

        private void btnStock_Click(object sender, EventArgs e)
        {
            StockForm obj = new StockForm();
            obj.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserForm obj = new UserForm();
            obj.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm obj = new ProductForm();
            obj.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtCode.Clear();
            txtname.Clear();
            txtquantity.Clear();
            txtprice.Clear();
            txtsupplier.Clear(); 
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String code = txtCode.Text;
                String name = txtname.Text;
                int quantity = int.Parse(txtquantity.Text);
                int price  = int.Parse(txtprice.Text);
                String supplier = txtsupplier.Text;

                //Query
                String Insert_Query = "INSERT INTO \"Product\"VALUES ('" + id + "','" + code + "','" + name + "','" + quantity + "','" + price + "','" + supplier + "')";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Insert_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Product Addedd Successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("While Adding ... " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String code = txtCode.Text;
                String name = txtname.Text;
                int quantity = int.Parse(txtquantity.Text);
                int price = int.Parse(txtprice.Text);
                String supplier = txtsupplier.Text;

                string Update_Query = "UPDATE Product SET id = '" + id + "',code = '" + code + "', name = '" + name + "',quantity = '" + quantity + "', price = '" + price + "', supplier = '" + supplier + "' WHERE id = '" + id + "'";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Update_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("While Updating ... " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String code = txtCode.Text;
                String name = txtname.Text;
                int quantity = int.Parse(txtquantity.Text);
                int price = int.Parse(txtprice.Text);
                String supplier = txtsupplier.Text;

                string Delete_Query = "DELETE FROM Product WHERE id = '" + id + "'";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Delete_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Product Deteled Successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("While Deleting ... " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                String code = txtSearch.Text;
                String Search_Query = "SELECT * FROM Product WHERE code = '" + code + "'";
                SqlCommand cmnd = new SqlCommand(Search_Query, con);
                con.Open();
                SqlDataReader r = cmnd.ExecuteReader();
                while (r.Read())
                {
                    txtid.Text = r[0].ToString();
                    txtCode.Text = r[1].ToString();
                    txtname.Text = r[2].ToString();
                    txtquantity.Text = r[3].ToString();
                    txtprice.Text = r[4].ToString();
                    txtsupplier.Text = r[5].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("While Searchhing ...." + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm obj = new SupplierForm();
            obj.Show();
            this.Close();
        }
    }
}
