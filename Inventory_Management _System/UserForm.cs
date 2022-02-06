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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        //Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=Heshan_Rathsara;Initial Catalog=dbMS;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String fname = txtname.Text;
                String address = txtaddress.Text;
                String email = txtmail.Text;
                int contact = int.Parse(txtphone.Text);
                String username = txtuser.Text;
                String password = txtpassword.Text;

                //Query
                String Insert_Query = "INSERT INTO \"Users\"VALUES ('"+id+"','"+ fname + "','"+ address + "','"+ email + "','"+ contact + "','" + username + "','"+ password + "')";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Insert_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("User Addedd Successfully !");
            }
            catch(Exception ex)
            {
                MessageBox.Show("While Adding ... " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        //Update Operation
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String fname = txtname.Text;
                String address = txtaddress.Text;
                String email = txtmail.Text;
                int contact = int.Parse(txtphone.Text);
                String username = txtuser.Text;
                String password = txtpassword.Text;

                string Update_Query = "UPDATE Users SET name = '" + fname + "',address = '" + address + "', email = '" + email + "',contact = '" + contact + "', username = '" + username + "', password = '" + password + "' WHERE id = '"+id+"'";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Update_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("User Updated Successfully !");
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

        //Delete Operation
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking data from GUI
                int id = int.Parse(txtid.Text);
                String fname = txtname.Text;
                String address = txtaddress.Text;
                String email = txtmail.Text;
                int contact = int.Parse(txtphone.Text);
                String username = txtuser.Text;
                String password = txtpassword.Text;

                string Delete_Query = "DELETE FROM Users WHERE id = '"+id+"'";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(Delete_Query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("User Deteled Successfully !");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtmail.Clear();
            txtphone.Clear();
            txtuser.Clear();
            txtpassword.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void search_Click(object sender, EventArgs e)
        {
            try 
            {
                String User_Name = txtSearch.Text;
                String Search_Query = "SELECT * FROM Users WHERE username = '" + User_Name + "'";
                SqlCommand cmnd = new SqlCommand(Search_Query,con);
                con.Open();
                SqlDataReader r = cmnd.ExecuteReader();
                while (r.Read())
                {
                    txtid.Text = r[0].ToString();
                    txtname.Text = r[1].ToString();
                    txtaddress.Text = r[2].ToString();
                    txtmail.Text = r[3].ToString();
                    txtphone.Text = r[4].ToString();
                    txtuser.Text = r[5].ToString();
                    txtpassword.Text = r[6].ToString();
                }

            }
            catch(Exception ex)
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
