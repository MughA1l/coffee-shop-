using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_shop_management_system.AllUserControls
{
    public partial class UC_employee : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=HAMZARIAZ\\SQLEXPRESS;Initial Catalog=coffeeshop;Integrated Security=True");

        public UC_employee()
        {
            InitializeComponent();
            DisplayData();

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtemail.Text != "" && txtphone.Text != "" && txtaddress.Text != "" && txtcity.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into employee (Employee_Name,Email,PhoneNo,Address,City) values(@Employee_Name,@Email,@PhoneNo,@Address,@City)", conn);
                //  cmd.Parameters.AddWithValue("@Manager_ID", txtmid.Text);
                cmd.Parameters.AddWithValue("@Employee_Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtphone.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Successfully Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Displays the data in Data Grid View  
        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from employee", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        // Clears the Data  
        private void ClearData()
        {
            // txtmid.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
            txtcity.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            if (txtname.Text != "" && txtemail.Text != "" && txtphone.Text != "" && txtaddress.Text != "" && txtcity.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update employee set Employee_Name=@Employee_Name,Email=@Email,PhoneNo=@PhoneNo,Address=@Address,City=@City where Employee_ID=@Employee_ID", conn);
                cmd.Parameters.AddWithValue("@Employee_ID", txtid.Text);
                cmd.Parameters.AddWithValue("@Employee_Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtphone.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Successfully Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtemail.Text != "" && txtphone.Text != "" && txtaddress.Text != "" && txtcity.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete employee where Employee_ID = @Employee_ID", conn);
                cmd.Parameters.AddWithValue("@Employee_ID", txtid.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtname.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            txtphone.Clear();
            txtaddress.Clear();
            txtcity.Clear();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtphone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtcity.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
