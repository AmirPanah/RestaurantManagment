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
    public partial class زمانهای_مجالس : Form
    {
        public زمانهای_مجالس()
        {
            InitializeComponent();
        }
        public void select(string select)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(select, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Sefaresh");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "Sefaresh";
            dataGridView1.Columns[0].HeaderText = "شماره سفارش";
            dataGridView1.Columns[1].HeaderText = "نام سفارش دهنده";
            dataGridView1.Columns[2].HeaderText = "تاریخ ثبت";
            dataGridView1.Columns[3].HeaderText = "تاریخ مجلس";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            try
            {
                string MajlesDate = cmbyear.Text + "/" + cmbmonth.Text + "/" + cmbday.Text;
                 DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("select * from Sefaresh where MajlesDate='" + MajlesDate + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                if (hasrows == "ok")
                {
                    
                    select("select DisTINCT Sefareshid,Des,SabDate,MajlesDate from Sefaresh where MajlesDate='" + MajlesDate + "'");
                }
                else
                {
                    MessageBox.Show("در این تاریخ مجلسی ثبت نشده است");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نمی باشد");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("select DisTINCT Sefareshid,Des,SabtDate,MajlesDate from Sefaresh where MajlesYear='" + cmbyearonlymonth.Text + "' and MajlesMonth='" + cmbonlymonth.Text + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                if (hasrows == "ok")
                {

                    select("select DisTINCT Sefareshid,Des,SabtDate,MajlesDate from Sefaresh where MajlesYear='" + cmbyearonlymonth.Text + "' and MajlesMonth='" + cmbonlymonth.Text + "'");

                }
                else
                {
                    MessageBox.Show("در این تاریخ مجلسی ثبت نشده است");
                }
                }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نمی باشد");
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            try
            {
                 DBManagment objDBClass = new DBManagment();
                 string selectCmd = string.Format("select DisTINCT Sefareshid,Des,SabtDate,MajlesDate from Sefaresh where MajlesYear='" + cmbonlyyears.Text + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                if (hasrows == "ok")
                {
                    select("select DisTINCT Sefareshid,Des,SabtDate,MajlesDate from Sefaresh where MajlesYear='" + cmbonlyyears.Text + "'");
                }
                else
                {
                    MessageBox.Show("در این تاریخ مجلسی ثبت نشده است");

                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نمی باشد");
            }
    }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            
            

            
        }

        private void زمانهای_مجالس_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            اطلاعات_کامل_سفارش f1 = new اطلاعات_کامل_سفارش(this);
            f1.Text = textBox1.Text;
            f1.Show();
        }

       
    }
}
