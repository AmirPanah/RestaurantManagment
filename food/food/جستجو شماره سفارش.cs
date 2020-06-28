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
    public partial class جستجو_شماره_سفارش : Form
    {
        public جستجو_شماره_سفارش()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = null;
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate, Des from Sefaresh  where MajlesYear='" + cmbonlyyears.Text + "' ", objcon);
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
                MessageBox.Show("داده ای برای جستجو یافت نشد", "توجه");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate, Des from Sefaresh  where Des=N'%" + textBox1.Text + "%' ", objcon);
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
                MessageBox.Show("داده ای برای جستجو یافت نشد", "توجه");
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                string day = cmbday.Text;
                string month = cmbmonth.Text;
                string year = cmbonlyyears.Text;
                string date = year + "/" + month + "/" + day;
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select DISTINCT Sefareshid,SabtDate,MajlesDate, Des from Sefaresh  where SabtDate='" + date + "' ", objcon);
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
                MessageBox.Show("داده ای برای جستجو یافت نشد", "توجه");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void جستجو_شماره_سفارش_Load(object sender, System.EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //هزینه_سفارش f1 = new هزینه_سفارش(this);
            //f1.Text = textBox2.Text;
            //f1.Show();
        }
    }
}
