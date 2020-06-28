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
    public partial class گزارشات : Form
    {
        public گزارشات()
        {
            InitializeComponent();
        }

        public void sumprice( string where)
        {
            
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Factor");
            DataRow objdatarow1 = objset1.Tables["Factor"].Rows[0];
            txtPro2.Text = objdatarow1["SUM"].ToString();
            txtPro3.Text = objdatarow1["Sood"].ToString();
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number,Price,SumPrice from Factor where Factorid='" + Int64.Parse(textBox1.Text) + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {
                    search("Select Name,Number,Price,SumPrice from Factor where Factorid='" + Int64.Parse(textBox1.Text) + "'");

                    sumprice("Select SUM(SumPrice)as SUM,SUM(Sood)as sood from Factor where Factorid='" + Int64.Parse(textBox1.Text) + "' ");
                }
                else
                {
                    MessageBox.Show("این شماره فاکتور وجود ندارد");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void گزارشات_Load(object sender, EventArgs e)
        {
            string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);
            string Year = FarsiLibrary.Utils.PersianDate.Now.Year.ToString();
            string Month = FarsiLibrary.Utils.PersianDate.Now.Month.ToString();
            string Day = FarsiLibrary.Utils.PersianDate.Now.Day.ToString();
            cmbday.Text = Day;
            cmbmonth.Text = Month;
            cmbyear.Text = Year;
            cmbonlymonth.Text = FarsiLibrary.Utils.PersianDate.Now.Month.ToString(); ;
            cmbyearonlymonth.Text = FarsiLibrary.Utils.PersianDate.Now.Year.ToString();
            cmbonlyyears.Text = FarsiLibrary.Utils.PersianDate.Now.Year.ToString(); ;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string year = cmbyear.Text;
            string month = cmbmonth.Text;
            string day = cmbday.Text;
            string date = year + "/" + month + "/" + day;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number,Price,SumPrice from Factor where Date='" + date + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {

                    search("Select Name,Number,Price,SumPrice from Factor where Date='" + date + "'");
                    sumprice("Select SUM(SumPrice)as SUM,SUM(Sood)as Sood from Factor where Date='" + date + "' ");
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

        private void button3_Click(object sender, EventArgs e)
        {
          string month= cmbonlymonth.Text;
          string year = cmbyearonlymonth.Text;
          try
          {
              DBManagment objDBClass = new DBManagment();
              string selectCmd = string.Format("Select Name,Number,Price,SumPrice from Factor where Month='" + month + "' and Year='" + year + "'");
              string hasrows = objDBClass.SelectHasRows(selectCmd);


              if (hasrows == "ok")
              {
                  search("Select Name,Number,Price,SumPrice from Factor where Month='" + month + "' and Year='" + year + "'");
                  sumprice("Select SUM(SumPrice)as SUM,SUM(Sood)as Sood from Factor where Month='" + month + "' and Year='" + year + "' ");

              }
              else
              {
                  MessageBox.Show("در این ماه فاکتوری ثبت نشده است");
              }
          }
          catch
          {
              MessageBox.Show("جستجو امکان پذیر نیست");
          }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            string year = cmbonlyyears.Text;
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number,Price,SumPrice from Factor where  Year='" + year + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {
                    search("Select Name,Number,Price,SumPrice from Factor where  Year='" + year + "'");
                    sumprice("Select SUM(SumPrice)as SUM,SUM(Sood)as Sood from Factor where Year='" + year + "' ");
                }
                else
                {
                    MessageBox.Show("در این سال فاکتوری ثبت نشده است");
                }
            }
            catch
            {
                MessageBox.Show("جستجو امکان پذیر نیست");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 3 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
       
       
    }
}
