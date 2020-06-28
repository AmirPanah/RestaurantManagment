using System;
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
    public partial class لیست_سفارشات_بر_اساس_نام_سفارش_دهنده : Form
    {
        public لیست_سفارشات_بر_اساس_نام_سفارش_دهنده()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate, Des from Sefaresh where Des like N'" + textBox1.Text + "' ", objcon);
                DataSet objset = new DataSet();
                objadapter.Fill(objset, "Sefaresh");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = objset;
                dataGridView1.DataMember = "Sefaresh";
                dataGridView1.Columns[0].HeaderText = "شماره سفارش";
                dataGridView1.Columns[1].HeaderText = "تاریخ ثبت سفارش";
                dataGridView1.Columns[2].HeaderText = "تاریخ مجلس";
                dataGridView1.Columns[3].HeaderText = "نام سفارش دهنده";
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }

        private void لیست_سفارشات_بر_اساس_نام_سفارش_دهنده_Load(object sender, System.EventArgs e)
        {

        }
    }
}
