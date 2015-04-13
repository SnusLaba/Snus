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
using EntityFramework_lb2.Managers;

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

        private void ReloadTable(Expression<Func<Product, bool>> productPred = null, Expression<Func<Users, bool>> usersPred = null)
        {
            using (SnusDb repo = new SnusDb())
            {
               
                dataGridView1.DataSource = repo.Products.AsExpandable().Where(productPred ?? (x => true)).ToList().ToModelList(ProductViewModel.Converter);
                dataGridView2.DataSource = repo.Users.AsExpandable().Where(usersPred ?? (x => true)).ToList().ToModelList(ClientViewModel.Converter);
            }
        }

        private BindingList<T> GetBList<T>(List<T> list)
        {
            return new BindingList<T>(list);
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


        private void button1_Click_2(object sender, EventArgs e)
        {
            var predicate = FilterManager.GetFilterPredicate<Product>(new 
            {
                id = tbId.Text, 
                name = tbName.Text,
                description = tbDescription.Text,
                countStart = (int)nudCountStart.Value,
                countEnd = (int)nudCountEnd.Value,
                type = cbType.SelectedItem,
                priceStart = nudPriceStart.Value,
                priceEnd = nudPriceEnd.Value,
                nicotineStart = (int)nudNicotineStart.Value,
                nicotineEnd = (int)nudNicotineEnd.Value,
                ratingStart = (int)nudRateStart.Value,
                ratingEnd = (int)nudRateEnd.Value
            });
            
            ReloadTable(predicate);
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var predicate = FilterManager.GetFilterPredicate<Users>(new
            {
                id = tbId2.Text,
                firstName = tbFirstName.Text,
                secondName = tbSecondName.Text,
                ageStart = (Nullable<int>)nudAgeStart.Value,
                ageEnd = (Nullable<int>)nudAgeEnd.Value,
                role = cbRole.SelectedItem !=null ? cbRole.SelectedItem.ToString() : null,
                sex = tbSex.Text,
                email = tbEmail.Text
            });
            ReloadTable(null, predicate);
        }        
    }
}
