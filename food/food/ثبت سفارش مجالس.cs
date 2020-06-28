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
    public partial class ثبت_سفارش : Form
    {
        public ثبت_سفارش()
        {
            InitializeComponent();
        }

        public void Loadgridview()
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter("Select Name,price,hazine from Foods", objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Foods");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "Foods";
            dataGridView1.Columns[0].HeaderText = "نام غذا";
            dataGridView1.Columns[1].HeaderText = "قیمت";
            dataGridView1.Columns[2].HeaderText = "هزینه";
        }

        public void Loadgridview2()
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter("Select Name,Number,Price,SumPrice from Sefaresh where Sefareshid='" + Int64.Parse(lbfactorid.Text) + "'", objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Sefaresh");
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = objset;
            dataGridView2.DataMember = "Sefaresh";
            dataGridView2.Columns[0].HeaderText = "ردیف";
            dataGridView2.Columns[1].HeaderText = "نام غذا";
            dataGridView2.Columns[2].HeaderText = "تعداد";
            dataGridView2.Columns[3].HeaderText = "قیمت ";
            dataGridView2.Columns[4].HeaderText = "قیمت کل";
        }
        private void ثبت_سفارش_Load(object sender, EventArgs e)
        {
            string status = "0";
            DBManagment objclass = new DBManagment();
            objclass.Deleterowtable("Delete Sefaresh where  status='" + int.Parse(status) + "' ");
            string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);

            lbfactorid.Text = DateDay.Replace("/", "") + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString();
            label8.Text = DateDay + "  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            Loadgridview();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                Int64 sood = Int64.Parse(lblprice.Text) - Int64.Parse(lblhazine.Text);
                string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);
                string Year = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 4);
                string Month = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(5, 2);
                string Day = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(8, 2);
               
                
                DBManagment objdbclass = new DBManagment();
                string majles = "0";
                int status = int.Parse("0");
                objdbclass.Inserttable("Insert Into Sefaresh (Sefareshid,Name,Number,Price,SumPrice,Sood,SabtDate,SabtYear,SabtMonth,SabtDay,OneSood,status) Values (N'" + Int64.Parse(lbfactorid.Text) + "', N'" + lblname.Text + "' ,'" + Int64.Parse(txttedad.Text) + "','" + Int64.Parse(lblprice.Text) + "','" + Int64.Parse(lblprice.Text) * Int64.Parse(txttedad.Text) + "','" + sood * Int64.Parse(txttedad.Text) + "','" + DateDay + "','" + Year + "','" + Month + "','" + Day + "','" + sood + "','" + status + "')");
                Loadgridview2();
                Int64 sum = Int64.Parse(lblprice.Text) * Int32.Parse(txttedad.Text);
                txtProNet1.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) + sum).ToString();
            }
            catch
            {
                MessageBox.Show("افزودن این غذا امکانپذیر نمی باشد", "توجه");

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblname.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            lblprice.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblhazine.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string ss = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                Int64 sumdelete = Int64.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

                DBManagment objclass = new DBManagment();
                objclass.Deleterowtable("Delete Sefaresh where   Name=N'" + ss + "' and Sefareshid='" + Int64.Parse(lbfactorid.Text) + "' ");
                Loadgridview2();

                //  text= Int64.Parse( dataGridView2.CurrentRow.Cells[3].Value.ToString());
                Int64 sumfactor=Int64.Parse(txtProNet1.TextValue.ToString());
               
                Int64 factror=sumfactor-sumdelete;
                txtProNet1.Text = factror.ToString();
            }
            catch
            {
               MessageBox.Show("امکان حذف وجود ندارد", "توجه");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblhazine_Click(object sender, EventArgs e)
        {

        }

        private void lblprice_Click(object sender, EventArgs e)
        {

        }

        private void lbfactorid_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txttedad_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtmoney_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txttakhfif_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cmbday2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbmonth2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbyear2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 2 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != this.dataGridView2.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 4 && e.RowIndex != this.dataGridView2.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  string name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter("Select SUM(Sood)as sumsood  from Sefaresh where Sefareshid='" + Int64.Parse(lbfactorid.Text) + "'" , objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
            string sood = objdatarow1["sumsood"].ToString();


            if (Int64.Parse(txtProtakhfif.TextValue.ToString()) > Int64.Parse(sood))
            {
                MessageBox.Show("امکان ثبت وجود ندارد تخفیف بیشتر از سود این فاکتور می باشد", "توجه");
            }
            else
            {
                bool successfullCreateAccount = true;
                string test;
                try
                {
                    string takhfif;
                    if (txtProtakhfif.Text == "")
                    {
                        takhfif = "0";
                    }
                    else
                    {
                        takhfif = txtProtakhfif.TextValue.ToString();
                    }
                    string type = "0";
                    string halat = "1";
                    string MajlesDate = cmbyear.Text + "/" + cmbmonth.Text + "/" + cmbday.Text;
                    string dt = cmbyear.Text + cmbmonth.Text + cmbday.Text;
                    if (txtdes.Text != "" && dt != "")
                    {
                        DBManagment objdbclass = new DBManagment();
                        objdbclass.Updatetable("Update Sefaresh Set MajlesDate='" + MajlesDate + "' ,MajlesYear='" + cmbyear.Text + "', MajlesMonth='" + cmbmonth.Text + "' ,MajlesDay='" + cmbday.Text + "',Des=N'" + txtdes.Text + "',Type='" + type + "',Takhfif='" + Int64.Parse(takhfif) + "',halat='" + Int16.Parse(halat) + "', status='" + int.Parse("1") + "'  where Sefareshid='" + Int64.Parse(lbfactorid.Text) + "'  ");

                        Int64 factor = Int64.Parse(txtProNet1.TextValue.ToString());
                        Int64 takhfifi = Int64.Parse(takhfif);
                        Int64 factornahaei = factor - takhfifi;
                        txtProNet2.Text = factornahaei.ToString();
                        printPreviewDialog1.Document = printDocument1;
                        printPreviewDialog1.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("برای ثبت نهایی سفارش نام سفارش دهنده و تاریخ مجلس را پر کنید");
                        
                    }
                }
                catch
                {
                    successfullCreateAccount = false;

                }
                
                if (successfullCreateAccount == false)
                {
                    MessageBox.Show("امکان ثبت این فاکتور وجود ندارد", "توجه");

                    DBManagment objclass = new DBManagment();
                    objclass.Deleterowtable("Delete Sefaresh where Sefareshid='" + Int64.Parse(lbfactorid.Text) + "' ");
                    Loadgridview2();

                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int height = 0;
            int withe = 0;
            // شمارنده حلقه که قرار است در طول سطر های دیتاگرید ویو حرکت کند
            int i = 0;
            Pen pen = new Pen(Brushes.Black, 2.5f);
           
            e.Graphics.DrawString("فاکتور فروش آشپزخانه رافع کوه", txtProtakhfif.Font, new SolidBrush(Color.Black), new Point(350, 30));
            e.Graphics.DrawString(label8.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(550, 60));
            e.Graphics.DrawString("سفارش دهنده:" + txtdes.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(350, 70));
            e.Graphics.DrawString(lbfactorid.Text, lbl.Font, new SolidBrush(Color.Black), new Point(200, 60));

            //برای ستون نام
            //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            //e.Graphics.DrawRectangle(pen, new Rectangle(100, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            //e.Graphics.DrawString("جمع فاکتور", dataGridView2.Font, Brushes.Black, new Rectangle(100, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));
            //نام خانوادگی
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(200, 100, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(200, 100, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[4].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(200, 100, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            // آدرس 
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(300, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[3].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(300, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            //تلفن
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(400, 100, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(400, 100, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[2].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(400, 100, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
            //

            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(500, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(500, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[1].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(500, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(600, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(600, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[0].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(600, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));


            height = 100;
            while (i < dataGridView2.Rows.Count - 1)
            {
                if (height > e.MarginBounds.Height)
                {
                    height = 100;
                    e.HasMorePages = true;
                    return;
                }
                height += dataGridView2.Rows[0].Height;


                e.Graphics.DrawRectangle(pen, new Rectangle(100 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[4].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(100 + dataGridView2.Columns[3].Width, height, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));

                //مستطیل سطر اول
                e.Graphics.DrawRectangle(pen, new Rectangle(200 + dataGridView2.Columns[3].Width, height, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
                //اطلاعات
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[3].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(200 + dataGridView2.Columns[3].Width, height, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
                //ستون بعدی
                e.Graphics.DrawRectangle(pen, new Rectangle(300 + dataGridView2.Columns[2].Width, height, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));

                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[2].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(300 + dataGridView2.Columns[2].Width, height, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
                //ستون بعدی
                e.Graphics.DrawRectangle(pen, new Rectangle(400 + dataGridView2.Columns[1].Width, height, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[1].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(400 + dataGridView2.Columns[1].Width, height, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));
                //ستون بعدی
                e.Graphics.DrawRectangle(pen, new Rectangle(500 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));

                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[0].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(500 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));

                //e.Graphics.DrawRectangle(pen, new Rectangle(400 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));
                // e.Graphics.DrawString(dataGridView2.Rows[i].Cells[4].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new Rectangle(400 + dataGridView2.Columns[4].Width, height, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));




                i++;
            }
            Int64 takhfifi;
            string takhfif = txtProtakhfif.Text;
            if (takhfif == "")
            {
                takhfifi = Int64.Parse("0");
            }
            else
            {
                takhfifi = Int64.Parse(txtProtakhfif.TextValue.ToString());
            }

            e.Graphics.DrawString("جمع فاکتور:" + txtProNet1.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(600, 130 + dataGridView2.Rows[0].Height * i));

            e.Graphics.DrawString("تخفیف:" + takhfifi.ToString() + "", lbl.Font, new SolidBrush(Color.Black), new Point(200, 130 + dataGridView2.Rows[0].Height * i));

            e.Graphics.DrawString("جمع نهایی فاکتور:" + txtProNet2.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(400, 160 + dataGridView2.Rows[0].Height * i));

            //e.Graphics.DrawRectangle(pen, new Rectangle(100, height, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            //e.Graphics.DrawString(txtProNet1.Text, dataGridView2.Font, Brushes.Black, new Rectangle(100, height, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
        }
    }
}
