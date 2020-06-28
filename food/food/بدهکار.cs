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
    public partial class بدهکار : Form
    {
        public بدهکار()
        {
            InitializeComponent();
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

        private void بدهکار_Load(object sender, EventArgs e)
        {
            int halat = 1;
            bedehkarlist("  Select Sefareshid,Des from Sefaresh where   halat= '" + halat + "' ");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            اطلاعات_بدهکاران f1 = new اطلاعات_بدهکاران(this);
            f1.Text = textBox1.Text;
            f1.Show();
        }
    }
}
