using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_shop_management_system
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            loginfrom form = new loginfrom();
            this.Hide();
            form.Show();
        }

        private void btnmanager_Click(object sender, EventArgs e)
        {
            uC_Manager1.Visible = true;  
            uC_Manager1.BringToFront();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            uC_Manager1.Visible=false;
            uC_employee1.Visible=false;
            uC_customer1.Visible=false;
            uC_ItemAdd1.Visible=false;
            placeorder1.Visible=false;
        }

        private void btnemployee_Click(object sender, EventArgs e)
        {
            uC_employee1.Visible=true;
            uC_employee1.BringToFront();
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            uC_customer1.Visible=true;
            uC_customer1.BringToFront();
        }

        private void btnadditem_Click(object sender, EventArgs e)
        {
            uC_ItemAdd1.Visible=true;
            uC_ItemAdd1.BringToFront();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            placeorder1.Visible = true;
            placeorder1.BringToFront();
        }
    }
}
