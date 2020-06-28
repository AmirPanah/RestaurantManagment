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
    public partial class ویرایش_غذا : Form
    {
        public ویرایش_غذا()
        {
            InitializeComponent();
        }

        public void Loadgridview()
        {
            SqlConnection objcon = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");
            SqlDataAdapter objadapter = new SqlDataAdapter("Select * from Foods", objcon);
            DataSet objset = new DataSet();
            objadapter.Fill(objset, "Foods");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objset;
            dataGridView1.DataMember = "Foods";
            dataGridView1.Columns[0].HeaderText = "کد";
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "هزینه";
            dataGridView1.Columns[3].HeaderText = "قیمت";
        }
        private void ویرایش_غذا_Load(object sender, EventArgs e)
        {
            Loadgridview();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtProhazine.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtProforosh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا برای ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                DBManagment objdbclass = new DBManagment();

                objdbclass.Updatetable("Update Foods Set Name=N'" + textBox2.Text + "', hazine='" + Int32.Parse(txtProhazine.TextValue.ToString()) + "',price='" + Int32.Parse(txtProforosh.TextValue.ToString()) + "' where id='" + Int32.Parse(textBox1.Text) + "'  ");
                Loadgridview();
            }
            catch
            {
                MessageBox.Show("ویرایش امکان پذیر نیست");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(" اطمینان دارید ؟'" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'آیا برای حذف اطلاعات", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;


                int deletecolumnid = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DBManagment objclass = new DBManagment();
                objclass.Deleterowtable("Delete Foods where id='" + deletecolumnid + "' ");
                Loadgridview();
            }
            catch
            {
                MessageBox.Show("حذف امکان پذیر نیست");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ثبت_غذا objform = new ثبت_غذا();
            objform.Show();
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
