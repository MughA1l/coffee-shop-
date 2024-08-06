using DGVPrinterHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_shop_management_system.AllUserControls
{
    public partial class placeorder : UserControl
    {
        Function fn = new Function();
        string query;
        public placeorder()
        {
            InitializeComponent();
        }

        private void txtcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = txt_combo.Text;
            query = "select ItemName from items where Category = '" + category+ "' ";
            show(query);
        }
        private void show(string query)
        {
            listBox2.Items.Clear();
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string category = txt_combo.Text;
            query = "select ItemName from items where Category = '" + category + "' and ItemName like '" + txt_search.Text + "%'";
            show(query);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_quanity.ResetText();
            txt_total.Clear();

            string text = listBox2.GetItemText(listBox2.SelectedItem);
            txt_name.Text = text;
            query = "select Itemcost from items where ItemName = '" + text + "'";
            DataSet ds = fn.getData(query);
            try
            {
                txt_price.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            {

            }
        }

        private void txtquantity_ValueChanged(object sender, EventArgs e)
        {

            Int64 quan = Int64.Parse(txt_quanity.Value.ToString());
            Int64 price = Int64.Parse(txt_price.Text);
            txt_total.Text = (quan * price).ToString();
        }
        protected int n, total = 0;
        int amount;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch { }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DGVPrinter dGVPrinter = new DGVPrinter();
            dGVPrinter.Title = "customer Bill";
            dGVPrinter.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            dGVPrinter.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            dGVPrinter.PageNumbers = true;
            dGVPrinter.PageNumberInHeader = false;
            dGVPrinter.PorportionalColumns = true;
            dGVPrinter.HeaderCellAlignment = StringAlignment.Near;
            dGVPrinter.Footer = "Total Payment Amount : " +txt_totalamount.Text;
            dGVPrinter.FooterSpacing = 15;
            dGVPrinter.PrintDataGridView(dataGridView2);

            total = 0;
            dataGridView2.Rows.Clear();
            txt_totalamount.Text = "Rs. " + total;
        }

        private void btnaddtocart_Click(object sender, EventArgs e)
        {
            if (txt_total.Text != "0" && txt_total.Text != "")
            {
                n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = txt_name.Text;
                dataGridView2.Rows[n].Cells[1].Value = txt_price.Text;
                dataGridView2.Rows[n].Cells[2].Value = txt_quanity.Text;
                dataGridView2.Rows[n].Cells[3].Value = txt_total.Text;

                total += int.Parse(txt_total.Text);
                txt_totalamount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quanity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void placeorder_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            txt_totalamount.Text = "Rs. " + total;
        }

        
    }
}
