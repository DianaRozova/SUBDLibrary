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
    public partial class Form4 : Form
    {
        Library lib = new Library();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //ListBox with users
            ListBox listUsers = new ListBox();
            string[] arrayUser = Library.getListUsers().Split(',');
            for( int i = 0; i < arrayUser.Length-1; i++)
            {
                listUsers.Items.Add(arrayUser[i]);
            }
            listUsers.Width = 240;
            listUsers.Height = 100;
            listUsers.Location = new Point(12, 12);
            this.Controls.Add(listUsers);

            //TextArea with roles
            RichTextBox roles = new RichTextBox();
            roles.Width = 255;
            roles.Height = 100;
            roles.Location = new Point(260, 12);
            roles.ReadOnly = true;
            this.Controls.Add(roles);
            listUsers.Click += (Object, EventArgs) =>
            {
                roles.Text = Library.getRoles(listUsers.Items[listUsers.SelectedIndex].ToString());
            };

            //Button to previos page
            Button btn1 = new Button();
            btn1.Text = "Назад";
            btn1.Width = 95;
            btn1.Height = 44;
            btn1.Location = new Point(12, 120);
            btn1.Click += (Object, EventArgs) =>
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Close();
            };
            this.Controls.Add(btn1);
        }
    }
}
