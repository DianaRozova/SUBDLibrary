using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Library lib = new Library();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (Library.Auterization(textBox1.Text, textBox2.Text))
                {
                    Form3 f3 = new Form3();
                    f3.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fail login: password or login false");
                }
            }
            else
            {
                MessageBox.Show("Login or password lose");
            }
        }
    }
}
