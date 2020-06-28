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
    public partial class حذف_سفارش : Form
    {
        public حذف_سفارش()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                int halat = int.Parse("1");
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,MajlesDate, Des from Sefaresh where halat='" + 1 + "' and  MajlesYear='" + cmbonlyyears.Text + "' ", objcon);
                DataSet objset = new DataSet();
                objadapter.Fill(objset, "Sefaresh");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = objset;
                dataGridView1.DataMember = "Sefaresh";
                dataGridView1.Columns[0].HeaderText = "شماره سفارش";
                dataGridView1.Columns[1].HeaderText = "تاریخ ثبت سفارش";
                dataGridView1.Columns[2].HeaderText = "نام سفارش دهنده";
            }
            catch
            {
                MessageBox.Show("داده ای یافت نشد", "توجه");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.DataSource = null;
                int halat = int.Parse("1");
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,MajlesDate, Des from Sefaresh where halat='" + 1 + "' and  Des like N'%" + textBox2.Text + "%' ", objcon);
                DataSet objset = new DataSet();
                objadapter.Fill(objset, "Sefaresh");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = objset;
                dataGridView1.DataMember = "Sefaresh";
                dataGridView1.Columns[0].HeaderText = "شماره سفارش";
                dataGridView1.Columns[1].HeaderText = "تاریخ ثبت سفارش";
                dataGridView1.Columns[2].HeaderText = "نام سفارش دهنده";
            }
            catch
            {
                MessageBox.Show("داده ای یافت نشد", "توجه");
            }
        }

        private void حذف_سفارش_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                string ss = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                DBManagment objclass = new DBManagment();
                objclass.Deleterowtable("Delete Sefaresh  where   Sefareshid='" + Int64.Parse(ss) + "' ");
                objclass.Deleterowtable("Delete SefareshMoney where Sefareshid='" + Int64.Parse(ss) + "' ");
                dataGridView1.DataSource = null;

            }
            catch
            {
                MessageBox.Show("امکان حذف مقدور نمی باشد", "توجه");
            }
           
        }
    }
}
