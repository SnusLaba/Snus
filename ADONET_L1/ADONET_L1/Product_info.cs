using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET_L1
{
    public partial class Product_info : Form
    {
        private Form1 sender;
        DataGridViewRow row;

        public Product_info()
        {
            InitializeComponent();
        }

        public void SetInfo(Form1 F, DataGridViewRow r)
        {
            sender = F;
            row = r;
            if (r.Cells[1].Value.ToString().Length > 0)
            {
                textBox2.Text = (string)r.Cells[1].Value;
                textBox4.Text = ((decimal)r.Cells[3].Value).ToString();
                textBox1.Text = (string)r.Cells[4].Value;
                numericUpDown1.Value = (int)r.Cells[5].Value;
                comboBox1.SelectedIndex = (int)r.Cells[6].Value-1;
                textBox3.Text = (string)r.Cells[8].Value;
                textBox5.Text = ((int)r.Cells[9].Value).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                row.Cells[1].Value = textBox2.Text;
                if (row.Cells[3].Value.ToString().Length == 0 || ((decimal)row.Cells[3].Value).ToString() != textBox4.Text)
                {
                    DataSet1.Price_HistoryRow newrow = dataSet1.Price_History.NewPrice_HistoryRow();
                    newrow.Price = Decimal.Parse(textBox4.Text);


                    dataSet1.Price_History.Rows.Add(newrow);

                    price_HistoryTableAdapter.Update(dataSet1.Price_History);

                    row.Cells[2].Value = newrow.Id;
                    row.Cells[3].Value = newrow.Price;

                    //add element to price_hist
                }
                row.Cells[4].Value = textBox1.Text;
                row.Cells[5].Value = numericUpDown1.Value;
                row.Cells[6].Value = comboBox1.SelectedIndex + 1;
                row.Cells[7].Value = comboBox1.Text;
                row.Cells[8].Value = textBox3.Text;
                row.Cells[9].Value = textBox5.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error!");
                return;
            }

            Close();
        }

        private void Product_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Price_History' table. You can move, or remove it, as needed.
            this.price_HistoryTableAdapter.Fill(this.dataSet1.Price_History);
            // TODO: This line of code loads data into the 'dataSet1.Types' table. You can move, or remove it, as needed.
            this.typesTableAdapter.Fill(this.dataSet1.Types);

        }
    }
}
