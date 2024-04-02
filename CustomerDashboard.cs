using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ABC_Car_Traders
{
    public partial class CustomerDashboard : KryptonForm
    {
        private int userId = 0;

        public CustomerDashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            Console.WriteLine(userId);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KryptonForm welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }
    }
}
