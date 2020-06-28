using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.SqlServer.Server;


namespace food
{
    public partial class backup : Form
    {
        public backup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             string filename = string.Empty;

             saveFileDialog1.OverwritePrompt = true;

             saveFileDialog1.DefaultExt = "";

             saveFileDialog1.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";

             saveFileDialog1.FilterIndex = 1;

           string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);//بر اساس تاریخ شمسی ذخیره می کند

           saveFileDialog1.FileName = DateDay.Replace("/", "") + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString()+".bak";

           saveFileDialog1.Title = "Backup SQL File";

           if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {

                filename = saveFileDialog1.FileName;

                Backup(filename);

            }




        }
        private void Backup(string filename)
        {

            try
            {
               
                string command = @"Backup DataBase FoodDB To Disk='" + filename + "'";

                this.Cursor = Cursors.WaitCursor;

                SqlCommand ocommand = null;

                SqlConnection oconnection = null;

                oconnection = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");

               // if (oconnection.State != ConnectionState.Open)

                    oconnection.Open();

                ocommand = new SqlCommand(command, oconnection);

                ocommand.ExecuteNonQuery();

                this.Cursor = Cursors.Default;

                MessageBox.Show("تهیه نسخه پشتیبان از اطلا عات با موفقیت انجام شد");

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error : ", ex.Message);

            }

        }

        //private void Restore(string filename)

        //{

        //    try

        //    {

        //        string command = @"ALTER DATABASE FoodDB  SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE FoodDB FROM DISK= N'" + filename + "'";

        //        //string command = @"RESTORE DATABASE  DBName FROM DISK ='" + filename + "' ";

        //        this.Cursor = Cursors.WaitCursor;

        //        SqlCommand ocommand = null;

        //        SqlConnection oconnection = null;

        //        oconnection = new SqlConnection("Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True");

        //        if (oconnection.State != ConnectionState.Open)

        //            oconnection.Open();

        //        ocommand = new SqlCommand(command, oconnection);

        //        ocommand.ExecuteNonQuery();

        //        this.Cursor = Cursors.Default;

        //        MessageBox.Show("بازیابی اطلاعات از  نسخه پشتیبان   با موفقیت انجام شد");

        //    }

        //    catch (Exception ex)

        //    {

        //        MessageBox.Show("Error : ", ex.Message);

        //    }

        //}







        private void button2_Click(object sender, System.EventArgs e)
        {
             
        }

        private void button3_Click(object sender, System.EventArgs e)
        {

           // string filename = string.Empty;

           //             openFileDialog1.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";

           //             openFileDialog1.FilterIndex = 1;

           //             openFileDialog1.Filter = @"SQL Backup Files (*.*)|";

 

           // string DateDay = FarsiLibrary.Utils.PersianDate.Now.ToString().Substring(0, 10);

           //openFileDialog1.FileName = DateDay.Replace("/", "") + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();

           // if (openFileDialog1.ShowDialog() == DialogResult.OK)

           // {
           //     if (MessageBox.Show("آیا اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
           //     filename =  openFileDialog1.FileName;

           //     Restore(filename);

           // }



        }




       
    }
}
