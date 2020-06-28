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
    public partial class تغییر_فاکتور : Form
    {
        public تغییر_فاکتور()
        {
            InitializeComponent();
        }
        public void loadgridview1()
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter("Select Name,price,hazine from Foods", objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Foods");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "Foods";
            dataGridView1.Columns[0].HeaderText = "شماره";
            dataGridView1.Columns[1].HeaderText = "قیمت";
        }
        public void loadgridview2()
        {

            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter("Select Name,Number,Price,SumPrice from Factor where Factorid='" + Int64.Parse(txtfactorid.Text) + "'", objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Factor");
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = objset;
            dataGridView2.DataMember = "Factor";
            dataGridView2.Columns[0].HeaderText = "شماره";
            dataGridView2.Columns[1].HeaderText = "نام غذا";
            dataGridView2.Columns[2].HeaderText = "تعداد";
            dataGridView2.Columns[3].HeaderText = "قیمت ";
            dataGridView2.Columns[4].HeaderText = "قیمت کل";
        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            لیست_فاکتور objlist = new لیست_فاکتور();
            objlist.Show();
           

        }

        private void button6_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                //  tring name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter1 = new SqlDataAdapter("Select takhfif from Factor where Factorid='" + Int64.Parse(txtfactorid.Text) + "'", objcon1);
                DataSet objset1 = new DataSet();
                objadapter1.Fill(objset1, "Factor");
                DataRow objdatarow1 = objset1.Tables["Factor"].Rows[0];

                string takhfif = objdatarow1["takhfif"].ToString();
                SqlConnection objcon2 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter2 = new SqlDataAdapter("Select SUM(SumPrice) as sum from Factor where Factorid='" + Int64.Parse(txtfactorid.Text) + "'", objcon2);
                DataSet objset2 = new DataSet();
                objadapter2.Fill(objset2, "Factor");
                DataRow objdatarow2 = objset2.Tables["Factor"].Rows[0];


                string sum = objdatarow2["sum"].ToString();
                txtProNet1.Text = sum;
                if (takhfif == "")
                {
                    txtProtakhfif.Visible = false;
                    label7.Visible = true;
                    txtProNet2.Text = txtProNet1.Text;
                }
                else
                {

                    txtProtakhfif.Text = takhfif;
                    label7.Visible = false;
                    txtProNet2.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) - Int64.Parse(txtProtakhfif.TextValue.ToString())).ToString();
                }
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select Name,Number,Price,SumPrice from Factor where Factorid='" + Int64.Parse(txtfactorid.Text) + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {
                    loadgridview2();
                    loadgridview1();
                }
                else
                {
                    MessageBox.Show("فاکتوری با این شماره یافت نشده است");
                }

            }
            catch
            {
                MessageBox.Show("امکان انجام عملیات مقدور نمی باشد", "توجه");
            }
            
            
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            try
            {
                string name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter1 = new SqlDataAdapter("Select hazine from Foods where Name=N'" + name + "'", objcon1);
                DataSet objset1 = new DataSet();
                objadapter1.Fill(objset1, "Foods");
                DataRow objdatarow1 = objset1.Tables["Foods"].Rows[0];

                string hazine = objdatarow1["hazine"].ToString();
                Int64 hazinee = Int64.Parse(hazine);

                string tedad = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                string price = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                Int64 pricee = Int64.Parse(price);


                int tedade = int.Parse(tedad) + 1;
                Int64 sood = pricee - hazinee;
                DBManagment objdbclass = new DBManagment();

                objdbclass.Updatetable("Update Factor Set Number='" + tedade + "',SumPrice='" + tedade * pricee + "',Sood='" + sood * tedade + "'   where Name=N'" + name + "' and Factorid='" + Int64.Parse(txtfactorid.Text) + "'   ");
                loadgridview2();
                Int64 sum = pricee * tedade;
                txtProNet1.Text = sum.ToString();

                string takhfif = txtProtakhfif.TextValue.ToString();
                txtProNet2.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) - Int64.Parse(takhfif)).ToString();
            }
            catch
            {
                MessageBox.Show("امکان انجام عملیات مقدور نمی باشد", "توجه");
            }
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            try
            {
                string name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter1 = new SqlDataAdapter("Select hazine from Foods where Name=N'" + name + "'", objcon1);
                DataSet objset1 = new DataSet();
                objadapter1.Fill(objset1, "Foods");
                DataRow objdatarow1 = objset1.Tables["Foods"].Rows[0];

                string hazine = objdatarow1["hazine"].ToString();
                Int64 hazinee = Int64.Parse(hazine);

                string tedad = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                string price = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                Int64 pricee = Int64.Parse(price);


                int tedade = int.Parse(tedad) - 1;
                if (tedade > 0)
                {
                    Int64 sood = pricee - hazinee;
                    DBManagment objdbclass = new DBManagment();

                    objdbclass.Updatetable("Update Factor Set Number='" + tedade + "',SumPrice='" + tedade * pricee + "',Sood='" + sood * tedade + "'   where Name=N'" + name + "' and Factorid='" + Int64.Parse(txtfactorid.Text) + "'   ");
                    loadgridview2();
                    Int64 sum = pricee * tedade;
                    txtProNet1.Text = sum.ToString();
                    string takhfif = txtProtakhfif.TextValue.ToString();
                    txtProNet2.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) - Int64.Parse(takhfif)).ToString();
                }

                else
                {
                    MessageBox.Show("امکان کم کردن تعداد این غذا وجود ندارد", "توجه");
                }
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
                string ss = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                Int64 sumdelete = Int64.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());


                DBManagment objclass = new DBManagment();
                objclass.Deleterowtable("Delete Factor where   Name=N'" + ss + "' and Factorid='" + Int64.Parse(txtfactorid.Text) + "' ");
                loadgridview2();

                Int64 sumfactor = Int64.Parse(txtProNet1.TextValue.ToString());

                Int64 factror = sumfactor - sumdelete;
                txtProNet1.Text = factror.ToString();
                string takhfif = txtProtakhfif.TextValue.ToString();
                txtProNet2.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) - Int64.Parse(takhfif)).ToString();
            }
            catch
            {
                MessageBox.Show("امکان حذف وجود ندارد", "توجه");

            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            bool successfullCreateAccount = true;

            try
            {
                Int64 sum = Int64.Parse(txtProNet1.TextValue.ToString());

                Int64 takhfifi;
                string takhfif = txtProtakhfif.TextValue.ToString();
                if (takhfif == "")
                {
                    takhfifi = Int64.Parse("0");
                }
                else
                {
                    takhfifi = Int64.Parse(txtProtakhfif.TextValue.ToString());
                    DBManagment objdbclass = new DBManagment();
                    objdbclass.Updatetable("Update Factor Set takhfif='" + Int32.Parse(txtProtakhfif.TextValue.ToString()) + "'  , status='" + int.Parse("1") + "'  where Factorid='" + Int64.Parse(txtfactorid.Text) + "'  ");
                }

                Int64 sumnahaei = sum - takhfifi;
                txtProNet2.Text = sumnahaei.ToString();
              //  txtProNet1.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) + sum).ToString();
            }
            catch
            {
                successfullCreateAccount = false;

            }
            if (successfullCreateAccount)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                this.Close();


            }
            if (successfullCreateAccount == false)
            {
                MessageBox.Show("امکان ثبت این فاکتور وجود ندارد", "توجه");

                DBManagment objclass = new DBManagment();
                objclass.Deleterowtable("Delete Factor where  Factorid='" + Int64.Parse(txtfactorid.Text) + "' ");
                loadgridview2();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int height = 0;
            int withe = 0;
            // شمارنده حلقه که قرار است در طول سطر های دیتاگرید ویو حرکت کند
            int i = 0;
            Pen pen = new Pen(Brushes.Black, 2.5f);

            e.Graphics.DrawString("فاکتور فروش آشپزخانه رافع کوه", txtProtakhfif.Font, new SolidBrush(Color.Black), new Point(300, 30));
            e.Graphics.DrawString("شماره فاکتور:"+txtfactorid.Text+" ", lbl.Font, new SolidBrush(Color.Black), new Point(500, 70));
            
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
            //e.Graphics.Dr
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

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblname.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lbltedad.Text = "1";
            lblprice.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblhazine.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            DBManagment objDBClass = new DBManagment();
            string selectCmd = string.Format("Select * from Factor where Factorid='" + Int64.Parse(txtfactorid.Text) + "' and  Name=N'" + lblname.Text + "'");
            string hasrows = objDBClass.SelectHasRows(selectCmd);


            if (hasrows == "ok")
            {
                MessageBox.Show("این غذا را ثبت کرده اید لطفا از جدول پایینی تعداد آنرا اضافه کنید", "توجه");
            }
            else
            {
                bool successfullCreateAccount = true;
                try
                {
                    Int64 sood = Int64.Parse(lblprice.Text) - Int64.Parse(lblhazine.Text);
                    string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);
                    string Year = FarsiLibrary.Utils.PersianDate.Now.Year.ToString();
                    string Month = FarsiLibrary.Utils.PersianDate.Now.Month.ToString();
                    string Day = FarsiLibrary.Utils.PersianDate.Now.Day.ToString();
                    DBManagment objdbclass = new DBManagment();
                    string adi = "1";

                    objdbclass.Inserttable("Insert Into Factor (Factorid,Name,Number,Price,SumPrice,Sood,Date,Year,Month,Day,Type,Takhfif,status) Values (N'" + Int64.Parse(txtfactorid.Text) + "', N'" + lblname.Text + "' ,'" + Int64.Parse(lbltedad.Text) + "','" + Int64.Parse(lblprice.Text) + "','" + Int64.Parse(lblprice.Text) * Int64.Parse(lbltedad.Text) + "','" + sood * Int64.Parse(lbltedad.Text) + "','" + DateDay + "','" + Year + "','" + Month + "','" + Day + "','" + adi + "','" + Int64.Parse("0") + "','" + Int64.Parse("0") + "')");
                    loadgridview2();
                    Int64 sum = Int64.Parse(lblprice.Text) * Int32.Parse(lbltedad.Text);
                    txtProNet1.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) + sum).ToString();
                    string takhfif = txtProtakhfif.TextValue.ToString();
                    txtProNet2.Text = (Int64.Parse(txtProNet1.TextValue.ToString()) - Int64.Parse(takhfif)).ToString();
                }
                catch
                {
                    successfullCreateAccount = false;
                    MessageBox.Show("ثبت غذا امکانپذیر نمی باشد", "توجه");

                }

            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            lbltedad.Text = ((Int32.Parse(lbltedad.Text)) + 1).ToString();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (lbltedad.Text == "1")
            {
                MessageBox.Show("کمتر از یک امکان پذیر نمی باشد", "توجه");
            }
            else
            {
                if (((Int32.Parse(lbltedad.Text)) - 1 >= 1))
                {
                    lbltedad.Text = ((Int32.Parse(lbltedad.Text)) - 1).ToString();

                }
                else
                {
                    MessageBox.Show("کمتر از یک امکان پذیر نمی باشد", "توجه");
                }
            }
        }

        private void تغییر_فاکتور_Load(object sender, System.EventArgs e)
        {
            string status = "0";
            DBManagment objclass = new DBManagment();
            objclass.Deleterowtable("Delete Factor where  status='" + int.Parse(status) + "' ");
        } 
    }
}
