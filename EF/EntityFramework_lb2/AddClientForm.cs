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
    public partial class AddClientForm : Form
    {
        SnusDb Repository = new SnusDb();
        public AddClientForm()
        {
            InitializeComponent();
            using (var Repository = new SnusDb())
            {
                cbRole.Items.AddRange(Repository.Roles.Select(x => x.Name).ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var Repository = new SnusDb())
            {
                var client = new Users()
                {
                    FirstName = tbFirstName.Text,
                    SecondName = tbSecondName.Text,
                    Age = tbAge.Text.Parce(0),
                    Email = tbEmail.Text,
                    Role = cbRole.SelectedItem != null ? Repository.Roles.FirstOrDefault(x => x.Name == cbRole.SelectedItem.ToString()) : null,
                    Sex = tbSex.Text,
                    Location = new Locations() { Address = tbAddress.Text, Telephone = tbTelephone.Text }
                };
                Repository.Users.Add(client);
                Repository.Save();
            }
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }
}
