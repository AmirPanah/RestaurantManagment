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
    public partial class لیست_کل_سفارشات : Form
    {
        public لیست_کل_سفارشات()
        {
            InitializeComponent();
        }

        private void لیست_کل_سفارشات_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, System.EventArgs e)
        {

            try
            {
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                int halat = int.Parse("0");
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate,Des from Sefaresh where halat='" + 0 + "' and MajlesYear='" + cmbonlyyears.Text + "'", objcon);
                DataSet objset = new DataSet();
                objadapter.Fill(objset, "Sefaresh");
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = objset;
                dataGridView2.DataMember = "Sefaresh";
                dataGridView2.Columns[0].HeaderText = "شماره سفارش";
                dataGridView2.Columns[1].HeaderText = "تاریخ ثبت سفارش";
                dataGridView2.Columns[2].HeaderText = "تاریخ مجلس";
                dataGridView2.Columns[3].HeaderText = "نام سفارش دهنده";



                int halat1 = int.Parse("1");
                SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter1 = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate, Des from Sefaresh where halat='" + 1 + "' and  MajlesYear='" + cmbonlyyears.Text + "' ", objcon1);
                DataSet objset1 = new DataSet();
                objadapter1.Fill(objset1, "Sefaresh");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = objset1;
                dataGridView1.DataMember = "Sefaresh";
                dataGridView1.Columns[0].HeaderText = "شماره سفارش";
                dataGridView1.Columns[1].HeaderText = "تاریخ ثبت سفارش";
                dataGridView1.Columns[2].HeaderText = "تاریخ مجلس";
                dataGridView1.Columns[3].HeaderText = "نام سفارش دهنده";
            }
            catch
            {
                MessageBox.Show("امکان عملیات مقدور نمی باشد");
            }
        }
    }
}
