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
    public partial class حسابداری : Form
    {
        public حسابداری()
        {
            InitializeComponent();
        }
        public void select(string select)
        {
           
        }
        public void clearform ()
        {
            
            txtProforoshfactor.Text = "";
            txtProforoshsefaresh.Text = "";
            txtProkolforosh.Text = "";
            
            txtProkolsood.Text = "";
            txtProkoltakhfif.Text = "";
            txtProsoodfactor.Text = "";
            txtProsoodsefaresh.Text = "";
            txtProtakhfif.Text = "";
            
            txtProtakhfiffactor.Text = "";
            txtProsandogh.Text = "";
            
        }
        public void sumpricesefaresh(string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];


        //    txttakhfiffactor.Text = objdatarow1["Takhfif"].ToString();
            Int64 takhfif = Int64.Parse(txtProtakhfif.TextValue.ToString());
            Int64 forosh = Int64.Parse(objdatarow1["SUM"].ToString());
            Int64 foroshnahaei = forosh - takhfif;
            txtProforoshsefaresh.Text = foroshnahaei.ToString();
            Int64 sood = Int64.Parse(objdatarow1["sood"].ToString());
            Int64 soodnahaei = sood - takhfif;
            txtProsoodsefaresh.Text = soodnahaei.ToString();
            
        }
        public void sumpricefactor (string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Factor");
            DataRow objdatarow1 = objset1.Tables["Factor"].Rows[0];

         //   txttakhfiffactor.Text = objdatarow1["Takhfif"].ToString();
            Int64 takhfif = Int64.Parse(txtProtakhfiffactor.TextValue.ToString());
            Int64 forosh = Int64.Parse(objdatarow1["SUM"].ToString());
            Int64 foroshnahaei = forosh - takhfif;

            txtProforoshfactor.Text = foroshnahaei.ToString();
            Int64 sood = Int64.Parse(objdatarow1["sood"].ToString());
            Int64 soodnahaei = sood - takhfif;

            txtProsoodfactor.Text = soodnahaei.ToString();

            Int64 mablaghvarizisefaresh = Int64.Parse(textBox1.Text);
            Int64 foroshe = Int64.Parse(txtProforoshfactor.TextValue.ToString());
            Int64 varizi = foroshe + mablaghvarizisefaresh;
            txtProsandogh.Text = (varizi).ToString();
        }
        public void takhfiffactor(string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Factor");
            DataRow objdatarow1 = objset1.Tables["Factor"].Rows[0];


            txtProtakhfiffactor.Text = objdatarow1["Takhfif"].ToString();
            //Int64 takhfif = Int64.Parse(txttakhfif.Text);
            //Int64 forosh = Int64.Parse(objdatarow1["SUM"].ToString());
            //Int64 foroshnahaei = forosh - takhfif;
            //txtforoshsefaresh.Text = foroshnahaei.ToString();
            //Int64 sood = Int64.Parse(objdatarow1["sood"].ToString());
            //Int64 soodnahaei = sood - takhfif;
            //txtsoodsefaresh.Text = soodnahaei.ToString();
        }
        public void takhfifsefaresh(string where)
        {
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];


            txtProtakhfif.Text = objdatarow1["Takhfif"].ToString();
            //Int64 takhfif = Int64.Parse(txttakhfif.Text);
            //Int64 forosh = Int64.Parse(objdatarow1["SUM"].ToString());
            //Int64 foroshnahaei = forosh - takhfif;
            //txtforoshsefaresh.Text = foroshnahaei.ToString();
            //Int64 sood = Int64.Parse(objdatarow1["sood"].ToString());
            //Int64 soodnahaei = sood - takhfif;
            //txtsoodsefaresh.Text = soodnahaei.ToString();
        }
        public void summoney(string where)
        {
            DBManagment objdbclass = new DBManagment();
            string hastows = objdbclass.SelectHasRows(where);
            if (hastows == "ok")
            {
                SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
                DataSet objset1 = new DataSet();
                objadapter1.Fill(objset1, "SefareshMoney");
                DataRow objdatarow1 = objset1.Tables["SefareshMoney"].Rows[0];
                textBox1.Text = objdatarow1["SUM"].ToString();

               
            }
            else
            {

            }
            Int64 mablaghvarizisefaresh = Int64.Parse(textBox1.Text);
            Int64 forosh = Int64.Parse(txtProforoshfactor.TextValue.ToString());
            Int64 varizi = forosh + mablaghvarizisefaresh;
            txtProsandogh.Text = (varizi).ToString();
        }
        public void bedehkarlist(string select)
        {
            DBManagment objdbclass = new DBManagment();
            string hastows = objdbclass.SelectHasRows(select);
            if (hastows == "ok")
            {
                SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter1 = new SqlDataAdapter(select, objcon1);
                DataSet objset1 = new DataSet();
                objadapter1.Fill(objset1, "Sefaresh");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = objset1;
                dataGridView1.DataMember = "Sefaresh";
                dataGridView1.Columns[0].HeaderText = " شماره سفارش";
                dataGridView1.Columns[1].HeaderText = "نام سفارش دهنده";
            }
        }

          private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.DataSource = null;
                textBox1.Text = "0";

                txtProtakhfif.TextValue = 0;
                txtProtakhfiffactor.TextValue = 0;
                txtProforoshfactor.TextValue = 0;
                txtProforoshsefaresh.TextValue = 0;
                txtProsoodfactor.TextValue = 0;
                txtProsoodsefaresh.TextValue = 0;
                clearform();
                DBManagment objDBClass = new DBManagment();
                string MajlesDate = cmbyear.Text + "/" + cmbmonth.Text + "/" + cmbday.Text;
                string selectCmd = string.Format("Select * from Sefaresh where SabtDate='" + MajlesDate + "'");
                string selectCmd2 = string.Format("Select * from Factor where Date='" + MajlesDate + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                string hastrows2 = objDBClass.SelectHasRows(selectCmd2);
                int halat = 1;
                if (hasrows == "ok")
                {

                    takhfifsefaresh("select SUM(Takhfif)as takhfif from ( Select DISTINCT Sefareshid, Takhfif  from Sefaresh where SabtDate='" + MajlesDate + "'  ) as newtable ");
                    sumpricesefaresh("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where SabtDate='" + MajlesDate + "'  ");
                    summoney("  Select SUM(Money)as SUM from SefareshMoney where MoneyDate='" + MajlesDate + "'  ");
                    bedehkarlist("  Select Sefareshid,Des from Sefaresh where SabtDate='" + MajlesDate + "' and halat= '" + halat + "' ");
                }
                if (hastrows2 == "ok")
                {
                    takhfiffactor("select SUM(Takhfif)as takhfif from ( Select DISTINCT Factorid, Takhfif  from Factor where Date='" + MajlesDate + "'  ) as newtable ");
                    sumpricefactor("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Factor where Date='" + MajlesDate + "'  ");

                }


                if (hasrows != "ok" && hastrows2 != "ok")
                {


                    MessageBox.Show("در این تاریخ فاکتور و سفارشی ثبت نشد");
                }

                txtProkoltakhfif.Text = (Int64.Parse(txtProtakhfif.TextValue.ToString()) + Int64.Parse(txtProtakhfiffactor.TextValue.ToString())).ToString();
                txtProkolforosh.Text = (Int64.Parse(txtProforoshfactor.TextValue.ToString()) + Int64.Parse(txtProforoshsefaresh.TextValue.ToString())).ToString();
                txtProkolsood.Text = (Int64.Parse(txtProsoodfactor.TextValue.ToString()) + Int64.Parse(txtProsoodsefaresh.TextValue.ToString())).ToString();

            }
            catch
            {
                MessageBox.Show("امکان انجام عملیات مقدور نمی باشد", "توجه");
            }
              
              }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                textBox1.Text = "0";

                txtProtakhfif.TextValue = 0;
                txtProtakhfiffactor.TextValue = 0;
                txtProforoshfactor.TextValue = 0;
                txtProforoshsefaresh.TextValue = 0;
                txtProsoodfactor.TextValue = 0;
                txtProsoodsefaresh.TextValue = 0;
                clearform();
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select * from Sefaresh where SabtYear='" + cmbyearonlymonth.Text + "' and  SabtMonth='" + cmbonlymonth.Text + "' ");
                string selectCmd2 = string.Format("Select * from Factor where Year='" + cmbyearonlymonth.Text + "' and  Month='" + cmbonlymonth.Text + "' ");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                string hastrows2 = objDBClass.SelectHasRows(selectCmd2);
                int halat = 1;
                if (hasrows == "ok")
                {
                    takhfifsefaresh("select SUM(Takhfif)as takhfif from ( Select DISTINCT Sefareshid, Takhfif  from Sefaresh where SabtYear='" + cmbyearonlymonth.Text + "' and SabtMonth='" + cmbonlymonth.Text + "'  ) as newtable ");
                    sumpricesefaresh("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where SabtYear='" + cmbyearonlymonth.Text + "' and SabtMonth='" + cmbonlymonth.Text + "'  ");
                    summoney("  Select SUM(Money)as SUM from SefareshMoney where MoneyYear='" + cmbyearonlymonth.Text + "' and MoneyMonth='" + cmbonlymonth.Text + "' ");
                    bedehkarlist("  Select Sefareshid,Des from Sefaresh where SabtYear='" + cmbyearonlymonth.Text + "' and SabtMonth='" + cmbonlymonth.Text + "'  and halat= '" + halat + "' ");
                }
                if (hastrows2 == "ok")
                {
                    takhfiffactor("select SUM(Takhfif)as takhfif from ( Select DISTINCT Factorid, Takhfif  from Factor where Year='" + cmbyearonlymonth.Text + "' and Month='" + cmbonlymonth.Text + "'  ) as newtable ");
                    sumpricefactor("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Factor where Year='" + cmbyearonlymonth.Text + "' and Month='" + cmbonlymonth.Text + "'  ");
                }

                if (hasrows != "ok" && hastrows2 != "ok")
                {


                    MessageBox.Show("در این تاریخ فاکتور و سفارشی ثبت نشد");
                }

                txtProkoltakhfif.Text = (Int64.Parse(txtProtakhfif.TextValue.ToString()) + Int64.Parse(txtProtakhfiffactor.TextValue.ToString())).ToString();
                txtProkolforosh.Text = (Int64.Parse(txtProforoshfactor.TextValue.ToString()) + Int64.Parse(txtProforoshsefaresh.TextValue.ToString())).ToString();
                txtProkolsood.Text = (Int64.Parse(txtProsoodfactor.TextValue.ToString()) + Int64.Parse(txtProsoodsefaresh.TextValue.ToString())).ToString();

            }
            catch
            {
                MessageBox.Show("امکان انجام عملیات مقدور نمی باشد", "توجه");
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                textBox1.Text = "0";

                txtProtakhfif.TextValue = 0;
                txtProtakhfiffactor.TextValue = 0;
                txtProforoshfactor.TextValue = 0;
                txtProforoshsefaresh.TextValue = 0;
                txtProsoodfactor.TextValue = 0;
                txtProsoodsefaresh.TextValue = 0;
                clearform();
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select * from Sefaresh where SabtYear='" + cmbonlyyears.Text + "' ");
                string selectCmd2 = string.Format("Select * from Factor where Year='" + cmbonlyyears.Text + "' ");
                string hasrows = objDBClass.SelectHasRows(selectCmd);
                string hastrows2 = objDBClass.SelectHasRows(selectCmd2);
                int halat = 1;
                if (hasrows == "ok")
                {

                    takhfifsefaresh("select SUM(Takhfif)as takhfif from ( Select DISTINCT Sefareshid, Takhfif  from Sefaresh where SabtYear='" + cmbonlyyears.Text + "'  ) as newtable ");
                    sumpricesefaresh("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where SabtYear='" + cmbonlyyears.Text + "'  ");

                    summoney("  Select SUM(Money)as SUM from SefareshMoney where MoneyYear='" + cmbonlyyears.Text + "'  ");
                    bedehkarlist("  Select Sefareshid,Des from Sefaresh where  SabtYear='" + cmbonlyyears.Text + "'  and halat= '" + halat + "' ");

                }
                if (hastrows2 == "ok")
                {
                    takhfiffactor("select SUM(Takhfif)as takhfif from ( Select DISTINCT Factorid, Takhfif  from Factor where Year='" + cmbonlyyears.Text + "' ) as newtable ");
                    sumpricefactor("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Factor where  Year='" + cmbonlyyears.Text + "'   ");

                }

                if (hasrows != "ok" && hastrows2 != "ok")
                {


                    MessageBox.Show("در این تاریخ فاکتور و سفارشی ثبت نشد");
                }

                txtProkoltakhfif.Text = (Int64.Parse(txtProtakhfif.TextValue.ToString()) + Int64.Parse(txtProtakhfiffactor.TextValue.ToString())).ToString();
                txtProkolforosh.Text = (Int64.Parse(txtProforoshfactor.TextValue.ToString()) + Int64.Parse(txtProforoshsefaresh.TextValue.ToString())).ToString();
                txtProkolsood.Text = (Int64.Parse(txtProsoodfactor.TextValue.ToString()) + Int64.Parse(txtProsoodsefaresh.TextValue.ToString())).ToString();
            }
            catch
            {
                MessageBox.Show("امکان انجام عملیات مقدور نمی باشد", "توجه");
            }
            }

        private void حسابداری_Load(object sender, System.EventArgs e)
        {

        }

        private void cmbonlymonth_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
