﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'FoodDBDataSet.Factor' table. You can move, or remove it, as needed.
            this.FactorTableAdapter.Fill(this.FoodDBDataSet.Factor);// Fill data of user

            this.reportViewer1.RefreshReport();
        }
    }
}
