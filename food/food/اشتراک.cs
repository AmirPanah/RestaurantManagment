using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace food
{
    public partial class اشتراک : Form
    {
        public اشتراک()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ثبت_اشتراک objform = new ثبت_اشتراک();
            objform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select  address,tell,mobile,name from person  where id=N'" + Int32.Parse(textBox1.Text) + "' ", objcon);
                DataSet objset = new DataSet();
                objadapter.Fill(objset, "person");
                DataRow objdatarow1 = objset.Tables["person"].Rows[0];

                txttel.Text = objdatarow1["tell"].ToString();
                txtmobile.Text = objdatarow1["mobile"].ToString();
                txtadd.Text = objdatarow1["address"].ToString();
                textBox2.Text = objdatarow1["name"].ToString();
            }
            catch
            {
                MessageBox.Show("داده ای برای جستجو یافت نشد", "توجه");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
