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
    public partial class ثبت_اشتراک : Form
    {
        public ثبت_اشتراک()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBManagment objdbclass = new DBManagment();
                objdbclass.Inserttable("Insert Into person (address,tell,mobile,name) Values (N'" + textBox3.Text + "', '" + Int32.Parse(textBox1.Text) + "' ,'" + Int64.Parse(textBox2.Text) + "',N'"+textBox4.Text+"')");
                MessageBox.Show("  ثبت با موفقیت انجام شد");
                SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
                SqlDataAdapter objadapter = new SqlDataAdapter("Select top 1  id  from person order by id Desc   ", objcon);
                DataSet objset = new DataSet();
              objadapter.Fill(objset, "person");
                

             
               
                DataRow objdatarow1 = objset.Tables["person"].Rows[0];

                label4.Text = objdatarow1["id"].ToString();
            }
            catch
            {
                MessageBox.Show("  عملیات ثبت امکان پذیر نمی باشد");
            }
        }
    }
}
