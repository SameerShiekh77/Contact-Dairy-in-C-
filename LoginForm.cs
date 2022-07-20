using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContactDairy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

       

   
        private void button1_Click_1(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string pswd = textBox2.Text;
            if (userName == "Muhammad Sameer" && pswd == "batman123")
            {
                MessageBox.Show("Login Successfully");

                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password");
            }
        }
    }
}
