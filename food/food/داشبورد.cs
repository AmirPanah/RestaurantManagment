using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.SqlServer.Server;


namespace food
{
    public partial class داشبورد : Form
    {
        public داشبورد()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                         factor objform = new  factor();
            objform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            تغییر_فاکتور objform = new تغییر_فاکتور();
            objform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            ثبت_سفارش objform = new ثبت_سفارش();
            objform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            تغییر_سفارش objform = new تغییر_سفارش();
            objform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            هزینه_سفارش objform = new هزینه_سفارش();
            objform.Show();
        
        }
        private void Backup(string filename)
        {

            try
            {

                string command = @"Backup DataBase FoodDB To Disk='" + filename + "'";

                this.Cursor = Cursors.WaitCursor;

                SqlCommand ocommand = null;

                SqlConnection oconnection = null;

                oconnection = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");

                // if (oconnection.State != ConnectionState.Open)

                oconnection.Open();

                ocommand = new SqlCommand(command, oconnection);

                ocommand.ExecuteNonQuery();

                this.Cursor = Cursors.Default;

                MessageBox.Show("تهیه نسخه پشتیبان از اطلا عات با موفقیت انجام شد");

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error : ", ex.Message);

            }

        }
        private void button10_Click(object sender, EventArgs e)
        {

            string filename = string.Empty;

            saveFileDialog1.OverwritePrompt = true;

            saveFileDialog1.DefaultExt = "";

            saveFileDialog1.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";

            saveFileDialog1.FilterIndex = 1;

            string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);//بر اساس تاریخ شمسی ذخیره می کند

            saveFileDialog1.FileName = DateDay.Replace("/", "") + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".bak";

            saveFileDialog1.Title = "Backup SQL File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filename = saveFileDialog1.FileName;

                Backup(filename);

            }


            //backup objform = new backup();
            //objform.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            تنظیمات_غذای_آشپزخانه objform = new تنظیمات_غذای_آشپزخانه();
            objform.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            حسابداری objform = new حسابداری();
            objform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            لیست_فاکتور objform = new لیست_فاکتور();
            objform.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            لیست_سفارشات objform = new لیست_سفارشات();
            objform.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            گزارش_غذا objform = new گزارش_غذا();
            objform.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            زمانهای_مجالس objform = new زمانهای_مجالس();
            objform.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
        }

        private void داشبورد_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void داشبورد_Load_1(object sender, EventArgs e)
        {

          

            label3.Text = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0,10);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            مدیریت_سفارشات objform = new مدیریت_سفارشات();
            objform.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            حذف_فاکتور objform = new حذف_فاکتور();
            objform.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            حذف_سفارش objform = new حذف_سفارش();
            objform.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {



            بدهکار objform = new بدهکار();
            objform.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            اشتراک objform = new اشتراک();
            objform.Show();
        }
    }
}
