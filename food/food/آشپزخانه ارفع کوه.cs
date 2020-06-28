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
    public partial class آشپزخانه_ارفع_کوه : Form
    {
        public آشپزخانه_ارفع_کوه()
        {
            InitializeComponent();
        }

         void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "ارفع" && textBox2.Text == "1")
            {
                داشبورد objform = new داشبورد();
                objform.Show();
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
            }
        }
    }
}
