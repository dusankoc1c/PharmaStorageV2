using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaStorageV2
{
    public partial class LogIn : Form
    {
        public string password;
        public string username;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=PharmaStorage;Integrated Security=True");
        public LogIn()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string query = "Select Passw0rd from Users where NameAndId = @NameAndId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NameAndId", textBox1.Text);
                password = (string)cmd.ExecuteScalar();
                //MessageBox.Show(provera);
                string query1 = "Select NameAndId from Users where NameAndId = @NameAndId";
                SqlCommand cmd1 = new SqlCommand( query1, conn);
                cmd1.Parameters.AddWithValue("@NameAndId", textBox1.Text);
                username = (string)cmd1.ExecuteScalar();
                if(textBox2.Text != password.ToString())
                {
                    MessageBox.Show("Wrong user password, try again");
                    textBox2.Text = "";
                }
                else if(textBox2.Text == "")
                {
                    MessageBox.Show("You must enter the password");
                    textBox2.Text = "";
                }
                else if(textBox1.Text != username.ToString())
                {
                    MessageBox.Show("This username does not exist, try again");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if(textBox1.Text == "")
                {
                    MessageBox.Show("You must enter the username");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    Menu form2 = new Menu();
                    form2.SetText(textBox1.Text);
                    form2.Show();
                    this.Hide();    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wrong password or username, try again ");
            }
            conn.Close();
        }
    }
}
