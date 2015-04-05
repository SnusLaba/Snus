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
    public partial class Clients : Form
    {
        DataGridViewRow row;

        public Clients()
        {
            InitializeComponent();
        }

        public void SetInfo(DataGridViewRow r)
        {
            row = r;
            if (r.Cells[1].Value.ToString().Length > 0)
            {
                ordersTableAdapter.Fill(dataSet1.Orders, (int)r.Cells[0].Value);
                textBox1.Text = (string)r.Cells[1].Value;
                textBox2.Text = (string)r.Cells[2].Value;
                textBox3.Text = (string)r.Cells[3].Value;
                textBox4.Text = (string)r.Cells[6].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            row.Cells[1].Value = textBox1.Text;
            row.Cells[2].Value = textBox2.Text;
            row.Cells[3].Value = textBox3.Text;
            row.Cells[6].Value = textBox4.Text;
            Close();
        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }
    }
}
