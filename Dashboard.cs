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
    public partial class Dashboard : KryptonForm
    {
        private  int userId = 0;

        public Dashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            Console.WriteLine(userId);
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            KryptonForm welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            KryptonForm AdminCars = new AdminCars();
            AdminCars.Show();
            this.Hide();
        }
    }
}
