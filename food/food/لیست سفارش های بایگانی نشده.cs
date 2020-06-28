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
    public partial class لیست_سفارش_ها : Form
    {
        public لیست_سفارش_ها()
        {
            InitializeComponent();
        }

        private void لیست_سفارش_ها_Load(object sender, EventArgs e)
        {
           
        
        }

        private void button4_Click(object sender, System.EventArgs e)
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
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }

        private void cmbonlyyears_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void label10_Click(object sender, System.EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            تغییر_سفارش2 f1 = new تغییر_سفارش2(this);
            f1.Text = textBox1.Text;
            f1.Show();

        }

        private void button1_Click(object sender, System.EventArgs e)
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
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }
    }
}
