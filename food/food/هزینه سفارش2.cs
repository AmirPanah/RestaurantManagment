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
    public partial class هزینه_سفارش2 : Form
    {

        جستجو_برای_مالی f1 = new جستجو_برای_مالی();
        public هزینه_سفارش2(جستجو_برای_مالی ff)
        {
           // InitializeComponent();
            InitializeComponent();
            f1=ff;
        }
        public void search(string select)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(select, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "SefareshMoney");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "SefareshMoney";
            dataGridView1.Columns[0].HeaderText = "ردیف";
            dataGridView1.Columns[1].HeaderText = "شماره سفارش";
            dataGridView1.Columns[2].HeaderText = "تاریخ واریزی";
            dataGridView1.Columns[3].HeaderText = "مبلغ واریزی";

        }
        public void bedehkar()
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter("  Select SUM(Money)as SUMMoney from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ", objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "SefareshMoney");
            DataRow objdatarow1 = objset1.Tables["SefareshMoney"].Rows[0];

            string summoney = objdatarow1["SUMMoney"].ToString();
            Int64 summoneyy;
            if (summoney == "")
            {
                summoneyy = Int64.Parse("0");
            }
            else
            {
                summoneyy = Int64.Parse(objdatarow1["SUMMoney"].ToString());
            }
            Int64 sumnahaei = Int64.Parse(txtProsumnahaei.TextValue.ToString());

            Int64 bedehkar = sumnahaei - summoneyy;

            txtprodiv.Text = bedehkar.ToString();
            if (bedehkar == 0)
            {
                string Year = FarsiLibrary.Utils.PersianDate.Now.Year.ToString();
                string Month = FarsiLibrary.Utils.PersianDate.Now.Month.ToString();
                string Day = FarsiLibrary.Utils.PersianDate.Now.Day.ToString();
                DBManagment objdbclass = new DBManagment();
                int halat = int.Parse("0");
                objdbclass.Updatetable("Update SefareshMoney Set FinishYear='" + Year + "',FinishMonth='" + Month + "',FinishDay='" + Day + "'  where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");


                objdbclass.Updatetable("Update Sefaresh Set halat='" + halat + "' where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
            }
        }
        public void sumprice(string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
            txtProsum.Text = objdatarow1["SUM"].ToString();

        }
        public void takhfif(string where)
        {

            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
            // txttakhfif.Text = objdatarow1["Takhfif"].ToString();
            txtProtakhfif.Text = objdatarow1["Takhfif"].ToString();
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


            Int64 sum = Int64.Parse(txtProsum.TextValue.ToString());
            Int64 sumnahaei = sum - takhfifi;
            txtProsumnahaei.Text = sumnahaei.ToString();
        }


        private void هزینه_سفارش2_Load(object sender, EventArgs e)
        {
            txtsefareshid0.Text = f1.textBox1.Text;
            dataGridView1.DataSource = null;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {
                    search("select Sefareshid,MoneyDate,Money from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");

                    sumprice("  Select SUM(SumPrice)as SUM from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");
                    takhfif("  Select Takhfif from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");

                    bedehkar();
                }
                else
                {
                    MessageBox.Show("سفارشی با این شماره یافت نشده است");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نمی باشد");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            لیست_سفارش_ها objform = new لیست_سفارش_ها();
            objform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnsabt_Click(object sender, EventArgs e)
        {
            try
            {

                Int64 mablagh = Int64.Parse(txtPromablagh.TextValue.ToString());
                Int64 mablaghbedehi = Int64.Parse(txtprodiv.TextValue.ToString());
                if (mablagh <= mablaghbedehi)
                {
                    string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);
                    string Year = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 4);
                    string Month = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(5, 2);
                    string Day = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(8, 2);
                    DBManagment objdbclass = new DBManagment();
                    objdbclass.Inserttable("Insert Into SefareshMoney (Sefareshid,MoneyDate,MoneyYear,MoneyMonth,MoneyDay,Money) Values (N'" + Int64.Parse(txtsefareshid0.Text) + "', '" + DateDay + "' ,'" + Year + "','" + Month + "','" + Day + "','" + Int64.Parse(txtPromablagh.TextValue.ToString()) + "')");

                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    search("select Sefareshid,MoneyDate,Money from SefareshMoney where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");
                    bedehkar();

                    sumprice("  Select SUM(SumPrice)as SUM from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");
                    takhfif("  Select Takhfif from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");

                    bedehkar();

                }


                else
                {
                    MessageBox.Show("مبلغ واریزی از بدهی بیشتر است");
                }


            }
            catch
            {
                MessageBox.Show("ثبت امکان پذیر نیست");
            }
           
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }

            if (e.ColumnIndex == 6 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtsefareshid0.Text = f1.textBox1.Text;

        }
    }
}
