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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=Heshan_Rathsara;Initial Catalog=dbMS;Integrated Security=True");


        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String name = txtname.Text;
                String address = txtaddress.Text;
                int phone = int.Parse(txtphone.Text);

                //Query
                String Insert_Query = "INSERT INTO \"Supplier\"VALUES ('" + id + "','" + name + "','" + address + "','" + phone + "')";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Insert_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Supplier Addedd Successfully !");
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
                String name = txtname.Text;
                String address = txtaddress.Text;
                int phone = int.Parse(txtphone.Text);

                string Update_Query = "UPDATE Supplier SET Sup_ID = '" + id + "', Name = '" + name + "',Address = '" + address + "', Phone = '" + phone + "' WHERE Sup_ID = '" + id + "'";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Update_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Supplier Updated Successfully !");
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
                String name = txtname.Text;
                String address = txtaddress.Text;
                int phone = int.Parse(txtphone.Text);

                string Delete_Query = "DELETE FROM Supplier WHERE Sup_ID = '" + id + "'";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Delete_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Supplier Deteled Successfully !");
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
                String Search_Query = "SELECT * FROM Supplier WHERE Sup_ID = '" + code + "'";
                SqlCommand cmnd = new SqlCommand(Search_Query, con);
                con.Open();
                SqlDataReader r = cmnd.ExecuteReader();
                while (r.Read())
                {
                    txtid.Text = r[0].ToString();
                    txtname.Text = r[1].ToString();
                    txtaddress.Text = r[2].ToString();
                    txtphone.Text = r[3].ToString();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtphone.Clear();
        }

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

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm obj = new SupplierForm();
            obj.Show();
            this.Hide();
        }
    }
}
