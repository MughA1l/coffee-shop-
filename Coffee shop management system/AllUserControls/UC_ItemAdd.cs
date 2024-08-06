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
using System.Xml.Linq;

namespace Coffee_shop_management_system.AllUserControls
{
    public partial class UC_ItemAdd : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=HAMZARIAZ\\SQLEXPRESS;Initial Catalog=coffeeshop;Integrated Security=True");
        SqlDataAdapter adapt;
        Function fn = new Function();
        string query;
        public UC_ItemAdd()
        {
            InitializeComponent();
            DisplayData();
        }

        private void UC_ItemAdd_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtcategory.Text !="" && txtitemname.Text !="" && txtprice.Text !="")
            {
                query = " insert into items(itemName,Category,Itemcost) values('" + txtitemname.Text + "','" + txtcategory.Text + "','" + txtprice.Text + "')";
                fn.setData(query);
                MessageBox.Show("Successfully Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Empty Text Field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from items", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        // Clears the Data  
        private void ClearData()
        {
            txtcategory.Text = "";
            txtitemname.Text = "";
            txtprice.Text = "";

        }
        int id;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string Category = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string ItemName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string Itemcost = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


            txtcategory.Text = Category;
            txtitemname.Text = ItemName;
            txtprice.Text = Itemcost;
        }

        private void txtsearchitem_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where ItemName like '" + txtsearchitem.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtcategory.Text != "" && txtitemname.Text != "" && txtprice.Text != "")
            {
                query = "update items set ItemName = '" + txtitemname.Text + "', Category = '" + txtcategory.Text + "',Itemcost=" + txtprice.Text + " where id = " + id + "";
                fn.getData(query);
                MessageBox.Show("Successfully Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
            }
            else
            {
                MessageBox.Show("Empty Text Field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtcategory.Text != "" && txtitemname.Text != "" && txtprice.Text != "")
            {
                query = "delete items where id = " + id + "";
                fn.getData(query);
                MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
            }
            else
            {
                MessageBox.Show("Empty Text Field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
