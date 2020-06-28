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
    public partial class لیست_فاکتور : Form
    {
        public لیست_فاکتور()
        {
            InitializeComponent();
        }
        public void search(string search)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(search, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Factor");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "Factor";
            dataGridView1.Columns[0].HeaderText = "شماره فاکتور";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            dataGridView1.DataSource = null;
            string year = cmbyear.Text;
            string month = cmbmonth.Text;
            string day = cmbday.Text;
            string date = year + "/" + month + "/" + day;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Factorid from Factor where Date='" + date + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {
                    search("Select Factorid from Factor where Date='" + date + "'");
                }
                else
                {
                    MessageBox.Show("در این تاریخ فاکتوری ثبت نشده است");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }

        private void لیست_فاکتور_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            تغییر_اطلاعات_فاکتورها f1 = new تغییر_اطلاعات_فاکتورها(this);
            f1.Text = textBox1.Text;
            f1.Show();
           // تغییر_اطلاعات_فاکتور f1 = new تغییر_اطلاعات_فاکتور(this);
           //// f1.Text = textBox1.Text;
           // f1.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        
        }
    }
}
