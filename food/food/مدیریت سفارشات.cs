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
    public partial class مدیریت_سفارشات : Form
    {
        public مدیریت_سفارشات()
        {
            InitializeComponent();
        }

        public void search(string search)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(search, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Sefaresh");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "Sefaresh";
            //dataGridView1.Columns[0].HeaderText = "شماره";
            dataGridView1.Columns[0].HeaderText = "تاریخ واریزی";
            dataGridView1.Columns[1].HeaderText = "مبلغ واریزی";
        }
        public void search2(string search)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(search, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "SefareshMoney");
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = objset;
            dataGridView2.DataMember = "SefareshMoney";
            dataGridView1.Columns[0].HeaderText = "نام غذا";
            dataGridView1.Columns[1].HeaderText = "تعداد";
            dataGridView1.Columns[2].HeaderText = "قیمت هر غذا";
            dataGridView1.Columns[3].HeaderText = "جمع قیمت";
        }
       public void select(string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
            lblsefareshid.Text = objdatarow1["Sefareshid"].ToString();

            txtProtakhfif.Text = objdatarow1["Takhfif"].ToString();
            txtdes.Text = objdatarow1["Des"].ToString();
            cmbday0.Text = objdatarow1["MajlesDay"].ToString();
            cmbmonth0.Text = objdatarow1["MajlesMonth"].ToString();
            cmbyear0.Text = objdatarow1["MajlesYear"].ToString();
            
            lblday.Text=objdatarow1["SabtDay"].ToString();
            lblyear.Text=objdatarow1["SabtYear"].ToString();
            lblmonth.Text=objdatarow1["SabtMonth"].ToString();
            string halat = objdatarow1["halat"].ToString();
            if (halat == "1")
            {

                lblhalat.Text = "این سفارش   بایگانی نشده است";
            }
            else
            {
                if (halat == "0")
                {
                    lblhalat.Text = "این سفارش  بایگانی شده است";
                }
            }
        }
       public void selectfinishdate(string where)
       {
           SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
           SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
           DataSet objset1 = new DataSet();
           objadapter1.Fill(objset1, "SefareshMoney");
           DataRow objdatarow1 = objset1.Tables["SefareshMoney"].Rows[0];
           comboBox1.Text = objdatarow1["FinishDay"].ToString();

           comboBox2.Text = objdatarow1["FinishMonth"].ToString();
           comboBox3.Text = objdatarow1["FinishYear"].ToString();
         
       }
       public void sumprice(string where)
       {
           SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
           SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
           DataSet objset1 = new DataSet();
           objadapter1.Fill(objset1, "Sefaresh");
           DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
           Int64 takhfif = Int64.Parse(txtProtakhfif.TextValue.ToString());

           txtProsum.Text = objdatarow1["SUM"].ToString();
           Int64 sum = Int64.Parse(txtProsum.TextValue.ToString());
           Int64 sumnahaei = sum - takhfif;
           txtProfinishsum.Text = sumnahaei.ToString();

           txtProsood.Text = objdatarow1["sood"].ToString();
           Int64 sood = Int64.Parse(txtProsood.TextValue.ToString());
           Int64 soodnahaei = sood - takhfif;
           txtProfinishsood.Text = soodnahaei.ToString();
           
       }
        public void bedehkar()
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter("  Select SUM(Money)as SUMMoney from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ", objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "SefareshMoney");
            DataRow objdatarow1 = objset1.Tables["SefareshMoney"].Rows[0];
            string SUMMoney = objdatarow1["SUMMoney"].ToString();
            Int64 sumnahaei = Int64.Parse(txtProfinishsum.TextValue.ToString());
            Int64 summoney = Int64.Parse(SUMMoney);
            Int64 bedehkar = sumnahaei - summoney;
            txtProNet1.Text = bedehkar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                if (hasrows == "ok")
                {
                 //clearform();
                    search("Select Name,Number,Price,SumPrice from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                    DBManagment objDBClass1 = new DBManagment();
                    string selectCmd1 = string.Format("Select * from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                    string hasrows1 = objDBClass.SelectHasRows(selectCmd);
                    if (hasrows1 == "ok")
                    {
                        search2("Select MoneyDate,Money from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                    }
                    select("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                    selectfinishdate("Select * from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                    sumprice("Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
                    bedehkar();

                }


                else
                {
                    MessageBox.Show("سفارشی با این شماره یافت نشده است");
                }

            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            لیست_کل_سفارشات objform = new لیست_کل_سفارشات();
            objform.Show();
            
        }

        private void مدیریت_سفارشات_Load(object sender, EventArgs e)
        {
           
        }
    }
}
