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
    public partial class ثبت_غذا : Form
    {
        public ثبت_غذا()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "";
                string resulttext1;
                DBManagment objDBClass = new DBManagment();
                string selectCmd = string.Format("SELECT * FROM Foods where Name=N'" + textBox1.Text + "' ");
                resulttext1 = objDBClass.SelectHasRows(selectCmd);

                if (resulttext1 == "ok")
                {

                    label4.Text = "نام کاربری تکراری می باشد";
                }


                if (label4.Text == "")
                {


                    DBManagment objdbclass = new DBManagment();
                    objdbclass.Inserttable("Insert Into Foods (Name,hazine,price) Values (N'" + textBox1.Text + "', '" + Int32.Parse(textBox2.Text) + "' ,'" + Int32.Parse(textBox3.Text) + "')");
                    label4.Text = "ثبت با موفقیت انجام شد";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("امکان ثبت وجود ندارد ", "توجه");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void ثبت_غذا_Load(object sender, EventArgs e)
        {

        }

       
    }
}
