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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);
           
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ویرایش_غذا objform = new ویرایش_غذا();
            objform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            گزارشات objform = new گزارشات();
            objform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            ثبت_سفارش objform = new ثبت_سفارش();
            objform.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

           // گزارشات_سفارش objform = new گزارشات_سفارش();
           //objform.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2(this);
            f1.Text = textBox1.Text;
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            حسابداری objform = new حسابداری();
           objform.Show();
        }

       
       

        private void button9_Click(object sender, EventArgs e)
        {
            
            Int64 a = Int64.Parse(txtProNet1.TextValue.ToString());
            Int64 b = Int64.Parse(txtProNet2.TextValue.ToString());
            Int64 c = a + b;

            txtProNet3.Text = c.ToString();
          
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 objform = new Form3();
            objform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            لیست_فاکتور objlist = new لیست_فاکتور();
            objlist.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            تغییر_فاکتور obj = new تغییر_فاکتور();
            obj.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            گزارش_غذا obj = new گزارش_غذا();
            obj.Show();
        }
    }
}
