using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food
{
    public partial class لیست_سفارشات : Form
    {
        public لیست_سفارشات()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            لیست_سفارشات_بایگانی_شده objform = new لیست_سفارشات_بایگانی_شده();
            objform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            لیست_سفارش_ها objform = new لیست_سفارش_ها();
            objform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            لیست_کل_سفارشات objform = new لیست_کل_سفارشات();
            objform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            لیست_سفارشات_بر_اساس_نام_سفارش_دهنده objform = new لیست_سفارشات_بر_اساس_نام_سفارش_دهنده();
            objform.Show();
        }
    }
}
