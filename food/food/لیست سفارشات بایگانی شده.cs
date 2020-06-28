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
    public partial class لیست_سفارشات_بایگانی_شده : Form
    {
        public لیست_سفارشات_بایگانی_شده()
        {
            InitializeComponent();
        }

        private void لیست_سفارشات_بایگانی_شده_Load(object sender, EventArgs e)
        {
          
        
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                int halat = int.Parse("0");
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate,Des from Sefaresh where halat='" + 0 + "' and MajlesYear='" + cmbonlyyears.Text + "'", objcon);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                int halat = int.Parse("0");
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate,Des from Sefaresh where halat='" + 0 + "' and Des like N'%" + textBox1.Text + "%'", objcon);
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
    }
}
