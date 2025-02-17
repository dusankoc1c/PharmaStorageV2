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
    public partial class Day : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=PharmaStorage;Integrated Security=True");
        public Day()
        {
            InitializeComponent();
        }

        public float profit1 = 0;
        public string id;
        public int id1;

        public void SetText (string text)
        {
            textBox1.Text = text;
        }

        private void Day_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query1 = "select * from Medicine";
            SqlCommand cmd1 = new SqlCommand(query1,conn);   
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            textBox1.Text = textBox1.Text;
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox1.Enabled = false;
            textBox2.Enabled=false;
            textBox3.Enabled=false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            conn.Open();


            string query = "declare @tekst as varchar(100);\r\nset @tekst = @input;\r\nselect * from Medicine\r\nwhere MedicineName like @tekst + '%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@input", textBox8.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string upit = "Update Medicine set Quantity = Quantity - 1 where MedicineID = @MedicineID;";
            SqlCommand cmd = new SqlCommand(upit,conn);
            cmd.Parameters.AddWithValue("@MedicineID", dataGridView1.SelectedCells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            /*loading new values*/
            string query1 = "select * from Medicine";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            conn.Open();
            /*uploading the profit*/
            try
            {
                string query2 = "Select Price from Medicine where MedicineID = @MedicineID";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@MedicineID", id1);
                object result = cmd2.ExecuteScalar();
                float profit = Convert.ToSingle(result);
                profit1 += profit;
                textBox3.Text = profit1.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.SelectedCells[0].Value.ToString();
            id1 = Convert.ToInt32(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Today's profit was : " +"\n"+ textBox3.Text + "\n" + "by : " + textBox1.Text);
            this.Close();
        }
    }
}
