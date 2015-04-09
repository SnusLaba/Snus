namespace EntityFramework_lb2
{
    partial class AddProductForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNicotine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Rate";
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(173, 100);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(147, 20);
            this.tbRate.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.DisplayMember = "Name";
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(12, 103);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(133, 21);
            this.cbType.TabIndex = 25;
            this.cbType.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(173, 60);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(147, 20);
            this.tbPrice.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nicotine";
            // 
            // tbNicotine
            // 
            this.tbNicotine.Location = new System.Drawing.Point(173, 21);
            this.tbNicotine.Name = "tbNicotine";
            this.tbNicotine.Size = new System.Drawing.Size(147, 20);
            this.tbNicotine.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Count";
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(15, 61);
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(133, 20);
            this.nudCount.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 21);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(133, 20);
            this.tbName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(12, 143);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(308, 104);
            this.tbDescription.TabIndex = 15;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNicotine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.Name = "AddProductForm";
            this.Text = "AddProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNicotine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescription;

    }
}