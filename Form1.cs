using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace ContactDairy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "4UHMivxxjtVU8PeRd6pL9vbk7frN9rqZZqzAFCkB",
            BasePath = "https://contactdairywithcsharp-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("There was problem in the internet");
            }
        }
        //Data Inserted 
        private void button2_Click(object sender, EventArgs e)
        {
            
            Contact cont = new Contact()
            {
                FullName = textBox1.Text,
                Email = textBox2.Text,
                Phone = textBox3.Text,
                Country= textBox4.Text,
                City= textBox5.Text,
                Address= textBox6.Text,
            };
            var setter = client.Set("Contacts/" + textBox1.Text,cont);
            MessageBox.Show("Data Inserted Successfully");
        }

        //Data Fetching
        private void button1_Click(object sender, EventArgs e)
        {
            //if you get the data from firebase just write the full name like Muhammad Sameer then click on select button

            var result = client.Get("Contacts/" + textBox1.Text);
            Contact cont = result.ResultAs<Contact>();
            textBox1.Text = cont.FullName;
            textBox2.Text = cont.Email;
            textBox3.Text = cont.Phone;
            textBox4.Text = cont.Country;
            textBox5.Text = cont.City;
            textBox6.Text = cont.Address;
            MessageBox.Show("Data Retrived");

        }

        //Data Updating
        private void button3_Click(object sender, EventArgs e)
        {
            //when you want to update data just enter full name then retrived all data after this you can update the data
            Contact cont = new Contact()
            {
                FullName = textBox1.Text,
                Email = textBox2.Text,
                Phone = textBox3.Text,
                Country = textBox4.Text,
                City = textBox5.Text,
                Address = textBox6.Text,
            };
            var setter = client.Update("Contacts/" + textBox1.Text, cont);
            MessageBox.Show("Data Updated Successfully");
        }

        //Data Deleting
        private void button4_Click(object sender, EventArgs e)
        {
            //if you want to delete the contact just write the full name which you enter then click on delete button
            var result = client.Delete("Contacts/" + textBox1.Text);
            MessageBox.Show("Data Deleted Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
