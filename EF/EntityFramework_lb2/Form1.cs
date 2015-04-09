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
using System.Reflection;
using System.Data.Entity;
using System.Collections;
using System.Data.Entity.Core.Objects;
using EntityFramework_lb2.Model;
using System.Linq.Expressions;
using LinqKit;

namespace EntityFramework_lb2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SnusDb repo = new SnusDb())
            {
                var list = ((BindingList<Users>)dataGridView2.DataSource).ToList();
                foreach (var item in list)
                {
                    bool flag = true;
                    foreach (var itemDb in repo.Users.ToList())
                    {
                        if (item.FirstName == itemDb.FirstName && 
                            item.SecondName == itemDb.SecondName)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        repo.Users.Add(item);
                    }
                }
                repo.Save();
                dataGridView2.DataSource = GetBList(repo.Users.ToList());
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadTable();
        }

        private void ReloadTable(Expression<Func<Product, bool>> productPred = null)
        {
            using (SnusDb repo = new SnusDb())
            {
               
                dataGridView1.DataSource = repo.Products.Where(productPred != null ? productPred : x => true).ToList();//.ToModelList(ProductViewModel.Converter);
                dataGridView2.DataSource = repo.Users.ToList().ToModelList(ClientViewModel.Converter);
            }
        }

        private BindingList<T> GetBList<T>(List<T> list)
        {
            return new BindingList<T>(list);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SnusDb repo = new SnusDb())
            {
                var list = ((BindingList<Product>)dataGridView1.DataSource).ToList();
                foreach (var item in list)
                {
                    bool flag = true;
                    foreach (var itemDb in repo.Products.ToList())
                    {
                        if (item.Name == itemDb.Name)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        repo.Products.Add(item);
                    }
                }
                repo.Save();
                dataGridView1.DataSource = GetBList(repo.Products.ToList());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProductForm();
            addProductForm.Show();
            addProductForm.FormClosed += ReloadTable;
        }

        private void ReloadTable(object sender, FormClosedEventArgs e)
        {
            ReloadTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var addClientProduct = new AddClientForm();
            addClientProduct.Show();
            addClientProduct.FormClosed += ReloadTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var Repository = new SnusDb())
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    for(int i =0; i < dataGridView2.SelectedRows.Count; i++)
                    {
                        var id = ((ClientViewModel)dataGridView2.SelectedRows[i].DataBoundItem).Id;
                        var user = Repository.Users.FirstOrDefault(x => x.Id == id);
                        if (user != null)
                        {
                            Repository.Users.Remove(user);
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Кліента з таким id[{0}] не знайдено!", id));
                        }
                    }
                    Repository.Save();
                    ReloadTable();
                }
                else
                {
                    MessageBox.Show("Виберіть рядок.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var Repository = new SnusDb())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        var id = ((ProductViewModel)dataGridView1.SelectedRows[i].DataBoundItem).Id;
                        var product = Repository.Products.FirstOrDefault(x => x.Id == id);
                        if (product != null)
                        {
                            Repository.Products.Remove(product);
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Кліента з таким id[{0}] не знайдено!", id));
                        }
                    }
                    Repository.Save();
                    ReloadTable();
                }
                else
                {
                    MessageBox.Show("Виберіть рядок.");
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
            Expression<Func<Product, bool>> predicate = x => x.Id == 5;
            if(!string.IsNullOrWhiteSpace(tbId.Text))
            {
                var id = int.Parse(tbId.Text);
                predicate = predicate.And(x => x.Id == 5);
            }

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                predicate = predicate.And(x => x.Name.Contains(tbName.Text));
            }
            if (nudCountStart.Value > 0)
            {
                predicate = predicate.And(x => x.Count >= nudCountStart.Value);
            }
            if (nudCountEnd.Value > 0)
            {
                predicate = predicate.And(x => x.Count <= nudCountEnd.Value);
            } 
            if (cbType.SelectedItem != null && !string.IsNullOrWhiteSpace(cbType.SelectedItem.ToString()))
            {
                predicate = predicate.And(x => x.Type != null && x.Type.Name == cbType.SelectedItem.ToString());
            }
            if (!string.IsNullOrWhiteSpace(tbPriceStart.Text) && Extension.DecimalTryParce(tbPriceStart.Text))
            {
                predicate = predicate.And(x => x.Price >= decimal.Parse(tbPriceStart.Text));
            }
            if (!string.IsNullOrWhiteSpace(tbPriceEnd.Text) && Extension.DecimalTryParce(tbPriceEnd.Text))
            {
                predicate = predicate.And(x => x.Price <= decimal.Parse(tbPriceEnd.Text));
            }
            if (!string.IsNullOrWhiteSpace(tbNicotineStart.Text) && Extension.IntTryParce(tbNicotineStart.Text))
            {
                predicate = predicate.And(x => int.Parse(x.Nicotine) >= int.Parse(tbNicotineStart.Text));
            }
            if (!string.IsNullOrWhiteSpace(tbNicotineEnd.Text) && Extension.DecimalTryParce(tbNicotineEnd.Text))
            {
                predicate = predicate.And(x => int.Parse(x.Nicotine) <= int.Parse(tbNicotineEnd.Text));
            }
            if (!string.IsNullOrWhiteSpace(tbRateStart.Text) && Extension.IntTryParce(tbRateStart.Text))
            {
                predicate = predicate.And(x => x.Rating >= int.Parse(tbRateStart.Text));
            }
            if (!string.IsNullOrWhiteSpace(tbRateStart.Text) && Extension.DecimalTryParce(tbRateStart.Text))
            {
                predicate = predicate.And(x => x.Rating <= int.Parse(tbRateStart.Text));
            }
            if (!string.IsNullOrWhiteSpace(tbDescription.Text))
            {
                predicate = predicate.And(x => x.Description.Contains(tbDescription.Text));
            }
            ReloadTable(predicate);
        }        
    }
}
