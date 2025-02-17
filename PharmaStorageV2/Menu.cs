using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmaStorageV2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
        }

        //
        public void SetText(string text)
        {
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Purchase form = new Purchase();
            form.ShowDialog();
        //    LogIn form = new LogIn();
        //    form.ShowDialog();
        //    this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manufacturer form1 = new Manufacturer();
            form1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Day form2 = new Day();
            form2.SetText(textBox1.Text);
            form2.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Show();
        }
    }
}
