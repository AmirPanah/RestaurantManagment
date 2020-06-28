namespace food
{
    partial class گزارشات
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(گزارشات));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbday = new System.Windows.Forms.ComboBox();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbyearonlymonth = new System.Windows.Forms.ComboBox();
            this.cmbonlymonth = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbonlyyears = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPro2 = new TextBoxtest.TxtProNet();
            this.txtPro3 = new TextBoxtest.TxtProNet();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(90, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 45);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 51);
            this.panel2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(73, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 45);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(506, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره فاکتور";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Zar", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(207, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(429, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(563, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "جمع فاکتور";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbday);
            this.panel3.Controls.Add(this.cmbmonth);
            this.panel3.Controls.Add(this.cmbyear);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(90, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(646, 40);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(73, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 40);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(536, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "تاریخ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "/";
            // 
            // cmbday
            // 
            this.cmbday.FormattingEnabled = true;
            this.cmbday.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbday.Location = new System.Drawing.Point(417, 12);
            this.cmbday.Name = "cmbday";
            this.cmbday.Size = new System.Drawing.Size(46, 21);
            this.cmbday.TabIndex = 3;
            // 
            // cmbmonth
            // 
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbmonth.Location = new System.Drawing.Point(356, 11);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(43, 21);
            this.cmbmonth.TabIndex = 2;
            // 
            // cmbyear
            // 
            this.cmbyear.FormattingEnabled = true;
            this.cmbyear.Items.AddRange(new object[] {
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399",
            "1400"});
            this.cmbyear.Location = new System.Drawing.Point(211, 9);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(121, 21);
            this.cmbyear.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(575, 467);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "جمع سود";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.cmbyearonlymonth);
            this.panel4.Controls.Add(this.cmbonlymonth);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(90, 115);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(646, 45);
            this.panel4.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(399, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "/";
            // 
            // cmbyearonlymonth
            // 
            this.cmbyearonlymonth.FormattingEnabled = true;
            this.cmbyearonlymonth.Items.AddRange(new object[] {
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399",
            "1400"});
            this.cmbyearonlymonth.Location = new System.Drawing.Point(263, 11);
            this.cmbyearonlymonth.Name = "cmbyearonlymonth";
            this.cmbyearonlymonth.Size = new System.Drawing.Size(121, 21);
            this.cmbyearonlymonth.TabIndex = 6;
            // 
            // cmbonlymonth
            // 
            this.cmbonlymonth.FormattingEnabled = true;
            this.cmbonlymonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbonlymonth.Location = new System.Drawing.Point(417, 11);
            this.cmbonlymonth.Name = "cmbonlymonth";
            this.cmbonlymonth.Size = new System.Drawing.Size(46, 21);
            this.cmbonlymonth.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(3, 51);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 51);
            this.panel5.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(73, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 45);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(543, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "ماه";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cmbonlyyears);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(90, 161);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(646, 45);
            this.panel6.TabIndex = 8;
            // 
            // cmbonlyyears
            // 
            this.cmbonlyyears.FormattingEnabled = true;
            this.cmbonlyyears.Items.AddRange(new object[] {
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399",
            "1400"});
            this.cmbonlyyears.Location = new System.Drawing.Point(316, 10);
            this.cmbonlyyears.Name = "cmbonlyyears";
            this.cmbonlyyears.Size = new System.Drawing.Size(121, 21);
            this.cmbonlyyears.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(3, 51);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 51);
            this.panel7.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(73, -1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 45);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(532, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "سال";
            // 
            // txtPro2
            // 
            this.txtPro2.AutoSprator = true;
            this.txtPro2.EnterToTab = true;
            this.txtPro2.EscToClose = true;
            this.txtPro2.FocusBackColor = System.Drawing.Color.Yellow;
            this.txtPro2.FocusFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPro2.FocusForeColor = System.Drawing.Color.Blue;
            this.txtPro2.FocusTextSelect = true;
            this.txtPro2.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPro2.Location = new System.Drawing.Point(227, 414);
            this.txtPro2.MaxLength = 15;
            this.txtPro2.MessageEmptyShowDialog = false;
            this.txtPro2.MessegeEmpty = "";
            this.txtPro2.MessegeEmptyInFormRight = true;
            this.txtPro2.MessegeEmptyShowInForm = false;
            this.txtPro2.Name = "txtPro2";
            this.txtPro2.Size = new System.Drawing.Size(330, 31);
            this.txtPro2.TabIndex = 9;
            this.txtPro2.TypeAllChar = false;
            this.txtPro2.TypeDateShamsi = false;
            this.txtPro2.TypeEnglishOnly = false;
            this.txtPro2.TypeFarsiOnly = false;
            this.txtPro2.TypeNumricOnly = true;
            this.txtPro2.TypeOtherChar = "-";
            // 
            // txtPro3
            // 
            this.txtPro3.AutoSprator = true;
            this.txtPro3.EnterToTab = true;
            this.txtPro3.EscToClose = true;
            this.txtPro3.FocusBackColor = System.Drawing.Color.Yellow;
            this.txtPro3.FocusFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPro3.FocusForeColor = System.Drawing.Color.Blue;
            this.txtPro3.FocusTextSelect = true;
            this.txtPro3.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPro3.Location = new System.Drawing.Point(226, 467);
            this.txtPro3.MaxLength = 15;
            this.txtPro3.MessageEmptyShowDialog = false;
            this.txtPro3.MessegeEmpty = "";
            this.txtPro3.MessegeEmptyInFormRight = true;
            this.txtPro3.MessegeEmptyShowInForm = false;
            this.txtPro3.Name = "txtPro3";
            this.txtPro3.Size = new System.Drawing.Size(330, 31);
            this.txtPro3.TabIndex = 10;
            this.txtPro3.TypeAllChar = false;
            this.txtPro3.TypeDateShamsi = false;
            this.txtPro3.TypeEnglishOnly = false;
            this.txtPro3.TypeFarsiOnly = false;
            this.txtPro3.TypeNumricOnly = true;
            this.txtPro3.TypeOtherChar = "-";
            // 
            // گزارشات
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::food.Properties.Resources.images;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(846, 557);
            this.Controls.Add(this.txtPro3);
            this.Controls.Add(this.txtPro2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "گزارشات";
            this.Text = "گزارشات";
            this.Load += new System.EventHandler(this.گزارشات_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbday;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.ComboBox cmbyear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmbonlymonth;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbyearonlymonth;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbonlyyears;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private TextBoxtest.TxtProNet txtPro2;
        private TextBoxtest.TxtProNet txtPro3;
    }
}