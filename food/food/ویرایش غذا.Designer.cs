namespace food
{
    partial class ویرایش_غذا
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtProhazine = new TextBoxtest.TxtProNet();
            this.txtProforosh = new TextBoxtest.TxtProNet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(434, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(655, 398);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox2.Location = new System.Drawing.Point(637, 255);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 31);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("IranNastaliq", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(23, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "ویرایش";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::food.Properties.Resources._2ص6;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(296, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 55);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(784, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "نام غذا";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(791, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "هزینه";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(766, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "قیمت فروش";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("IranNastaliq", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.Location = new System.Drawing.Point(112, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 55);
            this.button3.TabIndex = 8;
            this.button3.Text = "افزودن غذای جدید";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtProhazine
            // 
            this.txtProhazine.AutoSprator = true;
            this.txtProhazine.EnterToTab = true;
            this.txtProhazine.EscToClose = true;
            this.txtProhazine.FocusBackColor = System.Drawing.Color.Yellow;
            this.txtProhazine.FocusFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtProhazine.FocusForeColor = System.Drawing.Color.Blue;
            this.txtProhazine.FocusTextSelect = true;
            this.txtProhazine.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtProhazine.Location = new System.Drawing.Point(637, 302);
            this.txtProhazine.MaxLength = 15;
            this.txtProhazine.MessageEmptyShowDialog = false;
            this.txtProhazine.MessegeEmpty = "";
            this.txtProhazine.MessegeEmptyInFormRight = true;
            this.txtProhazine.MessegeEmptyShowInForm = false;
            this.txtProhazine.Name = "txtProhazine";
            this.txtProhazine.Size = new System.Drawing.Size(118, 31);
            this.txtProhazine.TabIndex = 107;
            this.txtProhazine.TypeAllChar = false;
            this.txtProhazine.TypeDateShamsi = false;
            this.txtProhazine.TypeEnglishOnly = false;
            this.txtProhazine.TypeFarsiOnly = false;
            this.txtProhazine.TypeNumricOnly = true;
            this.txtProhazine.TypeOtherChar = "-";
            // 
            // txtProforosh
            // 
            this.txtProforosh.AutoSprator = true;
            this.txtProforosh.EnterToTab = true;
            this.txtProforosh.EscToClose = true;
            this.txtProforosh.FocusBackColor = System.Drawing.Color.Yellow;
            this.txtProforosh.FocusFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtProforosh.FocusForeColor = System.Drawing.Color.Blue;
            this.txtProforosh.FocusTextSelect = true;
            this.txtProforosh.Font = new System.Drawing.Font("B Zar", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtProforosh.Location = new System.Drawing.Point(637, 349);
            this.txtProforosh.MaxLength = 15;
            this.txtProforosh.MessageEmptyShowDialog = false;
            this.txtProforosh.MessegeEmpty = "";
            this.txtProforosh.MessegeEmptyInFormRight = true;
            this.txtProforosh.MessegeEmptyShowInForm = false;
            this.txtProforosh.Name = "txtProforosh";
            this.txtProforosh.Size = new System.Drawing.Size(118, 31);
            this.txtProforosh.TabIndex = 108;
            this.txtProforosh.TypeAllChar = false;
            this.txtProforosh.TypeDateShamsi = false;
            this.txtProforosh.TypeEnglishOnly = false;
            this.txtProforosh.TypeFarsiOnly = false;
            this.txtProforosh.TypeNumricOnly = true;
            this.txtProforosh.TypeOtherChar = "-";
            // 
            // ویرایش_غذا
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::food.Properties.Resources._9;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 540);
            this.Controls.Add(this.txtProforosh);
            this.Controls.Add(this.txtProhazine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ویرایش_غذا";
            this.Text = "ویرایش_غذا";
            this.Load += new System.EventHandler(this.ویرایش_غذا_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private TextBoxtest.TxtProNet txtProhazine;
        private TextBoxtest.TxtProNet txtProforosh;
    }
}