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
    public partial class Form3 : Form
    {
        Library lib = new Library();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int width = 336, height = 44, i = 12;
            if (Library.inRole("admin"))
            {
                Button btn1 = new Button();
                btn1.Text = "Список пользователей";
                btn1.Width = width;
                btn1.Height = height;
                btn1.Location = new Point(12, i);
                btn1.Click += (Object, EventArgs) =>
                {
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Close();
                };
                i += height + 12;
                this.Controls.Add(btn1);
            }
            
            if (Library.inRole("libemp") || Library.inRole("admin")) 
            {
                Button btn2 = new Button();
                btn2.Text = "Список клиентов";
                btn2.Width = width;
                btn2.Height = height;
                btn2.Location = new Point(12, i);
                i += height + 12;
                this.Controls.Add(btn2);
            }
            
            if (Library.inRole("libemp") || Library.inRole("admin") || Library.inRole("user"))
            {
                Button btn3 = new Button();
                btn3.Text = "Список книг";
                btn3.Width = width;
                btn3.Height = height;
                btn3.Location = new Point(12, i);
                i += height + 12;
                this.Controls.Add(btn3);
            }
            
            if (Library.inRole("libemp") || Library.inRole("admin"))
            {
                Button btn4 = new Button();
                btn4.Text = "Услуги библиотеки";
                btn4.Width = width;
                btn4.Height = height;
                btn4.Location = new Point(12, i);
                i += height + 12;
                this.Controls.Add(btn4);
            }

            Button btn5 = new Button();
            btn5.Text = "Выйти из системы";
            btn5.Width = width;
            btn5.Height = height;
            btn5.Location = new Point(12, i);
            btn5.Click += (Object, EventArgs) =>
            {
                Form1 f1 = new Form1();
                Library.LogOut();
                f1.Show();
                this.Close();
            };
            i += height + 12;
            this.Controls.Add(btn5);

            this.Width = width + 24;
            this.Height = i + 12;
        }
    }
}
