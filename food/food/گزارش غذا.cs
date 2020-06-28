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
    public partial class گزارش_غذا : Form
    {
        public گزارش_غذا()
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
            dataGridView1.Columns[0].HeaderText = "نام غذا";
            dataGridView1.Columns[1].HeaderText = "تعداد";
        }
        public void search2(string search)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(search, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Sefaresh");
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = objset;
            dataGridView2.DataMember = "Sefaresh";
            dataGridView2.Columns[0].HeaderText = "نام غذا";
            dataGridView2.Columns[1].HeaderText = "تعداد";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            string year = cmbyear.Text;
            string month = cmbmonth.Text;
            string day = cmbday.Text;
            string date = year + "/" + month + "/" + day;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number from Factor where Date='" + date + "'  ");
                string hasrows = objDBClass.SelectHasRows(selectCmd);

                string selectCmd2 = string.Format("Select Name,Number from Sefaresh where MajlesDate='" + date + "'  ");
                string hasrows2 = objDBClass.SelectHasRows(selectCmd);

                if (hasrows == "ok" && hasrows2=="ok")
                {

                    search("Select Name,SUM(Number) as aa  from Factor where Date='" + date + "' group by Name");
                    search2("Select Name,SUM(Number) as aa  from Sefaresh where MajlesDate='" + date + "' group by Name");
                   // sumprice("Select SUM(SumPrice)as SUM,SUM(Sood)as Sood from Factor where Date='" + date + "' ");
                }
                else
                {
                    if (hasrows == "ok" )
                    {
                        search("Select Name,SUM(Number) as aa  from Factor where Date='" + date + "' group by Name");
                    }
                    if (hasrows2 == "ok")
                    {
                        search2("Select Name,SUM(Number) as aa  from Sefaresh where MajlesDate='" + date + "' group by Name");
                    }
                    if(hasrows != "ok" && hasrows2!="ok")
                    {
                    MessageBox.Show("در این تاریخ غذایی ثبت نشده است");
                    }
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            string month = cmbonlymonth.Text;
            string year = cmbyearonlymonth.Text;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number from Factor where Month='" + month + "' and Year='" + year + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);

                string selectCmd2 = string.Format("Select Name,Number from Sefaresh where MajlesMonth='" + month + "' and MajlesYear='" + year + "'");
                string hasrows2 = objDBClass.SelectHasRows(selectCmd);

                if (hasrows == "ok" )
                {
                    search("Select Name,SUM(Number) as aa from Factor where Month='" + month + "' and Year='" + year + "' group by Name");
                }
                if(hasrows2 == "ok")
                {
                    search2("Select Name,SUM(Number) as aa from Sefaresh where MajlesMonth='" + month + "' and MajlesYear='" + year + "' group by Name");
                }
                if (hasrows != "ok" && hasrows2 != "ok")
                {
                    MessageBox.Show("در این ماه غذایی ثبت نشده است");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            string year = cmbonlyyears.Text;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number from Factor where  Year='" + year + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);

                string selectCmd2 = string.Format("Select Name,Number from Sefaresh where  MajlesYear='" + year + "'");
                string hasrows2 = objDBClass.SelectHasRows(selectCmd);

                if (hasrows == "ok" && hasrows2 == "ok")
                {
                    search("Select Name,SUM(Number) as aa from Factor where  Year='" + year + "' group by Name");
                    search2("Select Name,SUM(Number) as aa from Sefaresh where  MajlesYear='" + year + "' group by Name");
                }
                else
                {
                    MessageBox.Show("در این سال غذایی ثبت نشده است");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }

        private void گزارش_غذا_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
