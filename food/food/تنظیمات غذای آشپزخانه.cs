using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food
{
    public partial class تنظیمات_غذای_آشپزخانه : Form
    {
        public تنظیمات_غذای_آشپزخانه()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ثبت_غذا obj = new ثبت_غذا();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {



            ویرایش_غذا obj = new ویرایش_غذا();
            obj.Show();
        }
    }
}
