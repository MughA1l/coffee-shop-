using System;
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
    public partial class UC_welcome : UserControl
    {
        public UC_welcome()
        {
            InitializeComponent();
        }
        int num = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(num == 0)
            {
                labelbanner.Location = new Point(80, 506);
                labelbanner.ForeColor = Color.Orange;
                num++;
            }
            else if(num == 1)
            {
                labelbanner.Location = new Point(270, 506);
                labelbanner.ForeColor = Color.Green;
                num++;
            }
            else if(num == 2)
            {
                labelbanner.Location = new Point(450, 506);
                labelbanner.ForeColor = Color.RoyalBlue;
                num=0;
            }
        }

        private void UC_welcome_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
