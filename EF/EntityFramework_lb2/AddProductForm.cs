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
    public partial class AddProductForm : Form
    {
       
        public AddProductForm()
        {
            InitializeComponent();
            using (var Repository = new SnusDb())
            {
                cbType.Items.AddRange(Repository.Types.Where(x => x is ProductType).Select(x => x.Name).ToArray());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var Repository = new SnusDb())
            {
                var product = new Product()
                {
                    Name = tbName.Text,
                    Nicotine = tbNicotine.Text,
                    Count = (int?)nudCount.Value,
                    Price = decimal.Parse(tbPrice.Text),
                    Type = cbType.SelectedItem != null ? Repository.Types.FirstOrDefault(x => x.Name == cbType.SelectedItem.ToString()) as ProductType : null,
                    Rating = int.Parse(tbRate.Text),
                    Description = tbDescription.Text
                };

                Repository.Products.Add(product);
                Repository.Save();
            }
            this.Close();
        }
    }
}
