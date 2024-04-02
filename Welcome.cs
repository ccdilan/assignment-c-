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
    public partial class Welcome :  KryptonForm
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            KryptonForm login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KryptonForm signUp = new frmRegister();
            signUp.Show();
            this.Hide();
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
