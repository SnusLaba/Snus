using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADONET_L1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.dataSet1.Product);
            this.usersTableAdapter.Fill(this.dataSet1.Users);
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            productBindingSource.EndEdit();
            productTableAdapter.Update(dataSet1.Product);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                var PForm = new Product_info();
                PForm.Show();
                DataGridViewRow r = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                PForm.SetInfo(this, r);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataGridViewRow r = new DataGridViewRow();
            productBindingSource.AddNew();
            var PForm = new Product_info();
            PForm.Show();
            PForm.SetInfo(this, dataGridView1.Rows[dataGridView1.Rows.Count-1]);     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usersBindingSource.EndEdit();
            usersTableAdapter.Update(dataSet1.Users);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usersBindingSource.RemoveCurrent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            usersBindingSource.AddNew();
            var UForm = new Clients();
            UForm.Show();
            UForm.SetInfo(dataGridView2.Rows[dataGridView2.Rows.Count - 1]);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                var UForm = new Clients();
                UForm.Show();
                UForm.SetInfo(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex]);
            }
        }
    }
}
