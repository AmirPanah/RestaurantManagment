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
    public partial class تغییر_سفارش : Form
    {
        public تغییر_سفارش()
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

     public void clearform()
        {
         
            txttedad.Text = "";
            txtdes.Text = "";
            txtProtakhfif.Text = "";
         //   txtmoney.Text = "";
            cmbday.Text = "";
             
         cmbmonth.Text="";
  
         cmbyear.Text="";
       
         Loadgridview();

        }
        public void search(string search)
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter(search, objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Sefaresh");
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = objset;
            dataGridView2.DataMember = "Sefaresh";
            dataGridView2.Columns[0].HeaderText = "ردیف";
            dataGridView2.Columns[1].HeaderText = "شماره";
            dataGridView2.Columns[2].HeaderText = "نام غذا";
            dataGridView2.Columns[3].HeaderText = "تعداد";
            dataGridView2.Columns[4].HeaderText = "قیمت هر غذا";
            dataGridView2.Columns[5].HeaderText = "جمع قیمت";

        }


          public void select ( string where)
    {
        SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter1 = new SqlDataAdapter(where, objcon1);
            DataSet objset1 = new DataSet();
            objadapter1.Fill(objset1, "Sefaresh");
            DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];
            lblsefareshid.Text = objdatarow1["Sefareshid"].ToString();
            txtProtakhfif.Text = objdatarow1["Takhfif"].ToString();
            txtdes.Text = objdatarow1["Des"].ToString();
            cmbday.Text = objdatarow1["MajlesDay"].ToString();
            cmbmonth.Text = objdatarow1["MajlesMonth"].ToString();
            cmbyear.Text = objdatarow1["MajlesYear"].ToString();
          
           
           
           //txtmoney.Text = objdatarow1["Money"].ToString();
            lblsabtday.Text = objdatarow1["SabtDay"].ToString();
            lblsabtmonth.Text = objdatarow1["SabtMonth"].ToString();
            lblsabtyear.Text = objdatarow1["SabtYear"].ToString();
            lblsabtdate.Text = objdatarow1["SabtDate"].ToString();
            if (objdatarow1["halat"].ToString () == "1")
            {

                lblhalat.Text = "این سفارش نهایی نشده است";
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
       
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                string hasrows = objDBClass.SelectHasRows(selectCmd);


                if (hasrows == "ok")
                {
                    SqlConnection objcon1 = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                    SqlDataAdapter objadapter1 = new SqlDataAdapter("Select halat from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'", objcon1);
                    DataSet objset1 = new DataSet();
                    objadapter1.Fill(objset1, "Sefaresh");
                    DataRow objdatarow1 = objset1.Tables["Sefaresh"].Rows[0];

                    string halat = objdatarow1["halat"].ToString();

                    int halate = int.Parse(halat);
                    
                    if (halate == 1)
                    {
                        clearform();
                        search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                        select("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                        sumprice("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
                    }
                    else
                    {
                        MessageBox.Show("این سفارش بایگانی شده و قابل تغییر نیست");
                    }
                   
                    
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            لیست_سفارش_ها objform = new لیست_سفارش_ها();
            objform.Show();
        }

        

       

        private void تغییر_سفارش_Load(object sender, EventArgs e)
        {
            Loadgridview();
            string status = "0";
            DBManagment objclass = new DBManagment();
            objclass.Deleterowtable("Delete Sefaresh where  status='" + int.Parse(status) + "' ");
            
        }

        private void btnsefaresh_Click(object sender, EventArgs e)
        {
           //// if (MessageBox.Show("آیا برای ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
           // DBManagment objdbclass = new DBManagment();

           // objdbclass.Updatetable("Update Sefaresh Set Name=N'" + textBox2.Text + "', hazine='" + Int32.Parse(textBox3.Text) + "',price='" + Int32.Parse(textBox4.Text) + "' where id='" + Int32.Parse(textBox1.Text) + "' where Sefareshid  ");
           // Loadgridview();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            btbedit.Visible = true;
            panel1.Visible = true;
            panel8.Visible = false;
            panel3.Visible = false;
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel8.Visible = true;
            panel1.Visible = false;
            btbedit.Visible = false;
          
        }

        private void btbedit_Click(object sender, EventArgs e)
        {
            try
            {
                string MajlesDate = cmbyear.Text + "/" + cmbmonth.Text + "/" + cmbday.Text;
                
                Int64 sefareshid = Int64.Parse(lblsefareshid.Text);
                DBManagment objdbclass = new DBManagment();

                objdbclass.Updatetable("Update Sefaresh Set Des=N'" + txtdes.Text + "',MajlesDate='" + MajlesDate + "', MajlesDay='" + cmbday.Text + "',MajlesMonth='" + cmbmonth.Text + "',MajlesYear='" + cmbyear.Text + "',Takhfif='" + Int64.Parse(txtProtakhfif.TextValue.ToString()) + "' where Sefareshid='" + sefareshid + "'  ");
                MessageBox.Show("ویرایش با موفقیت انجام شد");
                //  Loadgridview();
            }
            catch
            {
                MessageBox.Show("  عملیات ویرایش امکان پذیر نمی باشد");
            }
        }

        private void btnedit2_Click(object sender, EventArgs e)
        {
            try
            {

                DBManagment objdbclass = new DBManagment();

                objdbclass.Updatetable("Update Sefaresh Set Number='" + Int32.Parse(txtnumberrr.Text) + "',Price='" + Int32.Parse(lblPriceeee.Text) + "',SumPrice='" + Int32.Parse(lblPriceeee.Text) * Int32.Parse(txtnumberrr.Text) + "',Sood='" + Int32.Parse(label31.Text) * Int32.Parse(txtnumberrr.Text) + "' where id='" + Int64.Parse(lbliddddd.Text) + "'  ");

                MessageBox.Show("ویرایش با موفقیت انجام شد");
                search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                select("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                sumprice("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
            }
            catch
            {
                MessageBox.Show("  عملیات ویرایش امکان پذیر نمی باشد");
            }
          
            }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            lblname.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            lblprice.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblhazine.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
                Int64 sood = Int64.Parse(lblprice.Text) - Int64.Parse(lblhazine.Text);
                string DateDay = lblsabtday.Text;
                string Year = lblsabtyear.Text;
                string Month = lblsabtmonth.Text;
                string Day = lblsabtday.Text;
                string MajlesDate = cmbyear.Text + "/" + cmbmonth.Text + "/" + cmbday.Text;
                int status;
                status = 1;
                string type = "0";
                string halat = "1";
                DBManagment objdbclass = new DBManagment();
                string majles = "0";
                string takhfif;
                if (txtProtakhfif.Text == "")
                {
                     takhfif = "0";
                }
                else
                {
                    takhfif = txtProtakhfif.TextValue.ToString();
                }

                objdbclass.Inserttable("Insert Into Sefaresh (Sefareshid,Name,Number,Price,SumPrice,Sood,SabtDate,SabtYear,SabtMonth,SabtDay,MajlesDate,MajlesYear,MajlesMonth,MajlesDay,Des,Type,Takhfif,halat,OneSood,status) Values (N'" + Int64.Parse(lblsefareshid.Text) + "', N'" + lblname.Text + "' ,'" + Int64.Parse(txttedad.Text) + "','" + Int64.Parse(lblprice.Text) + "','" + Int64.Parse(lblprice.Text) * Int64.Parse(txttedad.Text) + "','" + sood * Int64.Parse(txttedad.Text) + "','" + DateDay + "','" + Year + "','" + Month + "','" + Day + "', '" + MajlesDate + "' , '" + cmbyear.Text + "','" + cmbmonth.Text + "','" + cmbday.Text + "','" + txtdes.Text + "','" + type + "','" + Int64.Parse(takhfif)+ "','" + Int16.Parse(halat) + "','"+sood+"','"+status+"')");
               //  Loadgridview2();
                search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");

                Int64 sum = Int64.Parse(lblprice.Text) * Int32.Parse(txttedad.Text);
                //  textBox1.Text = (Int64.Parse(textBox1.Text) + sum).ToString();
               // MessageBox.Show("  ثبت با موفقیت انجام شد");


               // search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
               // select("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                sumprice("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
            //}
            //catch
            //{
            //    MessageBox.Show("  عملیات ثبت امکان پذیر نمی باشد");

            //}
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtnumberrr.Visible = true;
           // IDataAdapter,name,Number,price,sumprice
          //  txtnameeee.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnumberrr.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            lbliddddd.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            lblPriceeee.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            label31.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void lblsabtyear_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void lblsabtmonth_Click(object sender, EventArgs e)
        {

        }

        private void lblsabtday_Click(object sender, EventArgs e)
        {

        }

        private void lblsefareshid_Click(object sender, EventArgs e)
        {

        }

        private void lblhalat_Click(object sender, EventArgs e)
        {

        }

        private void lblsabtdate_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void lblhazine_Click(object sender, EventArgs e)
        {

        }

        private void lblprice_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbliddddd_Click(object sender, EventArgs e)
        {

        }

        private void txtnumberrr_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void lblPriceeee_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtsood_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void txtfinishsood_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtsum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txttedad_TextChanged(object sender, EventArgs e)
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtsefareshid0_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != this.dataGridView2.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 5 && e.RowIndex != this.dataGridView2.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 6 && e.RowIndex != this.dataGridView2.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string ss = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                Int64 sumdelete = Int64.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());

                DBManagment objclass = new DBManagment();
                objclass.Deleterowtable("Delete Sefaresh where   Name=N'" + ss + "' and Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");
                search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                sumprice("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
                //  text= Int64.Parse( dataGridView2.CurrentRow.Cells[3].Value.ToString());
                
            }
            catch
            {
                MessageBox.Show("امکان حذف وجود ندارد", "توجه");

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
            e.Graphics.DrawString("شماره فاکتور:" + txtsefareshid0.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(550, 70));
            e.Graphics.DrawString("نام سفارش دهنده:" + txtdes.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(200, 70));
        //    e.Graphics.DrawString("" + cmbyear.Text + "/" + cmbmonth.Text + "/" + cmbday.Text + "", dataGridView2.Font, new SolidBrush(Color.Black), new Point(200, 70));

            //برای ستون نام
            //e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(100, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            //e.Graphics.DrawRectangle(pen, new Rectangle(100, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            //e.Graphics.DrawString("جمع فاکتور", dataGridView2.Font, Brushes.Black, new Rectangle(100, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));
            //نام خانوادگی
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(200, 100, dataGridView2.Columns[5].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(200, 100, dataGridView2.Columns[5].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[5].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(200, 100, dataGridView2.Columns[5].Width, dataGridView2.Rows[0].Height));
            // آدرس 
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(300, 100, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(300, 100, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[4].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(300, 100, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
            //تلفن
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(400, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(400, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[3].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(400, 100, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
            //

            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(500, 100, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawRectangle(pen, new Rectangle(500, 100, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
            e.Graphics.DrawString(dataGridView2.Columns[2].HeaderText.ToString(), lbl.Font, Brushes.Black, new Rectangle(500, 100, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));

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
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[5].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(100 + dataGridView2.Columns[4].Width, height, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));

                //مستطیل سطر اول
                e.Graphics.DrawRectangle(pen, new Rectangle(200 + dataGridView2.Columns[3].Width, height, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
                //اطلاعات
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[4].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(200 + dataGridView2.Columns[4].Width, height, dataGridView2.Columns[4].Width, dataGridView2.Rows[0].Height));
                //ستون بعدی
                e.Graphics.DrawRectangle(pen, new Rectangle(300 + dataGridView2.Columns[2].Width, height, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));

                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[3].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(300 + dataGridView2.Columns[3].Width, height, dataGridView2.Columns[3].Width, dataGridView2.Rows[0].Height));
                //ستون بعدی
                e.Graphics.DrawRectangle(pen, new Rectangle(400 + dataGridView2.Columns[1].Width, height, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[2].FormattedValue.ToString(), lbl.Font, Brushes.Black, new Rectangle(400 + dataGridView2.Columns[2].Width, height, dataGridView2.Columns[2].Width, dataGridView2.Rows[0].Height));
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

            e.Graphics.DrawString("جمع فاکتور:" + txtProsum.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(600, 130 + dataGridView2.Rows[0].Height * i));

            e.Graphics.DrawString("تخفیف:" + takhfifi.ToString() + "", lbl.Font, new SolidBrush(Color.Black), new Point(200, 130 + dataGridView2.Rows[0].Height * i));

            e.Graphics.DrawString("جمع نهایی فاکتور:" + txtProfinishsum.Text + "", lbl.Font, new SolidBrush(Color.Black), new Point(400, 160 + dataGridView2.Rows[0].Height * i));
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                DBManagment objdbclass = new DBManagment();

               // objdbclass.Updatetable("Update Sefaresh Set Number='" + Int32.Parse(txtnumberrr.Text) + "',Price='" + Int32.Parse(lblPriceeee.Text) + "',SumPrice='" + Int32.Parse(lblPriceeee.Text) * Int32.Parse(txtnumberrr.Text) + "',Sood='" + Int32.Parse(label31.Text) * Int32.Parse(txtnumberrr.Text) + "' where id='" + Int64.Parse(lbliddddd.Text) + "'  ");
                objdbclass.Updatetable("Update Sefaresh Set status='" + Int32.Parse("1") + "' where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "' ");
                MessageBox.Show("ویرایش با موفقیت انجام شد");
                search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                select("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
                sumprice("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
            }
            catch
            {
                MessageBox.Show("  عملیات ویرایش امکان پذیر نمی باشد");
            }
            
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try{
            DBManagment objdbclass = new DBManagment();

            objdbclass.Updatetable("Update Sefaresh Set Number='" + Int32.Parse(txtnumberrr.Text) + "',Price='" + Int32.Parse(lblPriceeee.Text) + "',SumPrice='" + Int32.Parse(lblPriceeee.Text) * Int32.Parse(txtnumberrr.Text) + "',Sood='" + Int32.Parse(label31.Text) * Int32.Parse(txtnumberrr.Text) + "' where id='" + Int64.Parse(lbliddddd.Text) + "'  ");

            MessageBox.Show("ویرایش با موفقیت انجام شد");
            search("Select id,Name,Number,Price,SumPrice,OneSood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
            select("Select * from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'");
            sumprice("  Select SUM(SumPrice)as SUM,SUM(Sood) as sood from Sefaresh where Sefareshid='" + Int64.Parse(txtsefareshid0.Text) + "'  ");
            }
            catch
            {
                MessageBox.Show("  عملیات ویرایش امکان پذیر نمی باشد");
            }
        
        
        }

        
    }
}
