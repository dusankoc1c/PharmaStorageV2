using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaStorageV2
{
    public partial class Form1 : Form
    {
        /*
         buttons color : 174, 203, 201
         background color : 23, 63, 73       
         */
        Thread tr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*buton 1 design*/
            btn_enter.Padding = new Padding(6);
            btn_enter.FlatStyle = FlatStyle.Flat;
            btn_enter.FlatAppearance.BorderSize = 0;
            /*button 2 design*/
            btn_contact.Padding = new Padding(6);
            btn_contact.FlatStyle = FlatStyle.Flat;
            btn_contact.FlatAppearance.BorderSize = 0;
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            this.Close();
            tr = new Thread(opennewform);
            tr.SetApartmentState(ApartmentState.STA);
            tr.Start();
            /*
            Menu form = new Menu();
            form.ShowDialog();
            */
        }
        private void opennewform(object obj) 
        {
            Application.Run(new LogIn());
        }
        private void btn_contact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Show();
        }
    }
}
