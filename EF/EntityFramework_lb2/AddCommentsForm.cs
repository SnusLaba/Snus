using SnusData.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework_lb2
{
    public partial class AddCommentsForm : Form
    {
        private int ProdId { get; set; }
        public AddCommentsForm(int productId)
        {
            InitializeComponent();
            ProdId = productId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var Repository = new SnusDb())
            {
                var product = Repository.Products.FirstOrDefault(x => x.Id == ProdId);
                if (product == null) return;
                product.Coments.Add(new Coments(){ Text = tbComments.Text, Product = product});
                Repository.Save();
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
