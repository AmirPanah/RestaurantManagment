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
    public partial class اطلاعات_کامل_سفارش : Form
    {
        زمانهای_مجالس f1 = new زمانهای_مجالس();
        public اطلاعات_کامل_سفارش(زمانهای_مجالس ff)
        {
            InitializeComponent();
            f1 = ff;
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
        //    dataGridView1.Columns[0].HeaderText = "نام غذا";
        //    dataGridView1.Columns[1].HeaderText = "تعداد";
        //    dataGridView1.Columns[2].HeaderText = "قیمت";
        //    dataGridView1.Columns[3].HeaderText = "جمع قیمت";
        //    dataGridView1.Columns[4].HeaderText = "سود هر غذا";
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
            
            lblday.Text = objdatarow1["SabtDay"].ToString();
            lblyear.Text = objdatarow1["SabtYear"].ToString();
            lblmonth.Text = objdatarow1["SabtMonth"].ToString();

            if (objdatarow1["halat"].ToString() == "1")
            {

                lblhalat.Text = "این سفارش  بایگانی نشده است";
            }
            else
            {
                lblhalat.Text = "این سفارش  بایگانی شده است";
            }
        }
        public void sumprice(string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
            Int64 takhfifi;
            string takhfif = txtProtakhfif.TextValue.ToString();
            if (takhfif == "")
            {
                takhfifi = Int64.Parse("0");
                
            }
            else
            {
                takhfifi = Int64.Parse(txtProtakhfif.TextValue.ToString());
            }

            txtProsum.Text = objdatarow1["SUM"].ToString();
            Int64 sum = Int64.Parse(txtProsum.TextValue.ToString());
            Int64 sumnahaei = sum - takhfifi;
            txtProfinishsum.Text = sumnahaei.ToString();
            txtProsood.Text = objdatarow1["sood"].ToString();
            Int64 sood = Int64.Parse(txtProsood.TextValue.ToString());
            Int64 soodnahaei = sood - takhfifi;
            txtProfinishsood.Text = soodnahaei.ToString();
            
        }
        public void bedehkar()
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter("  Select SUM(Money)as SUMMoney from SefareshMoney where Sefareshid='" + Int64.Parse(f1.textBox1.Text) + "' ", objcon1);
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
            
        }

        private void اطلاعات_کامل_سفارش_Load(object sender, EventArgs e)
        {
         
            try
            {
                string ids = f1.textBox1.Text;
                Int64 id = Int64.Parse(ids);
                
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select * from Sefaresh where Sefareshid='" + id+ "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                if (hasrows == "ok")
                {
                    //clearform();
                    search("Select Name,Number,Price,SumPrice from Sefaresh where Sefareshid='" + id + "'");
                    search2("Select Money,MoneyDate from SefareshMoney where Sefareshid='" +id+ "'");
                    select("Select * from Sefaresh where Sefareshid='" + id + "'");
                    sumprice("Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + id + "'  ");
                    
                    bedehkar();

                }


                else
                {
                    MessageBox.Show("سفارشی با این شماره یافت نشده است");
                }

            }
            catch
            {
                MessageBox.Show("امکان انجام عملیات مقدور نمی باشد", "توجه");
            }
        }
    }
}
