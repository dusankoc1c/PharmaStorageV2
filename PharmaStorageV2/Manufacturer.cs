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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmaStorageV2
{
    public partial class Manufacturer : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=PharmaStorage;Integrated Security=True");
        public Manufacturer()
        {
            InitializeComponent();
        }

        private void Manufacturer_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "Select * from Producer";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "insert into Producer (ProducerID, ProducerName, Country) values (@ProducerID, @ProducerName, @Country)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProducerID", textBox1.Text);
            cmd.Parameters.AddWithValue("@ProducerName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Country", textBox3.Text);
            cmd.ExecuteNonQuery();
            /*loading new values*/
            string query1 = "Select * from Producer";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query2 = "delete from Medicine where @ProducerID = ProducerID";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@ProducerID", textBox1.Text);
            cmd2.ExecuteNonQuery();
            string query1 = "delete from Producer where @ProducerID = ProducerID";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@ProducerID", textBox1.Text);
            cmd1.ExecuteNonQuery();
            /*loading new values*/
            string query = "Select * from Producer";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = (dataGridView1.SelectedCells[0].Value.ToString());
            textBox2.Text = (dataGridView1.SelectedCells[1].Value.ToString());
            textBox3.Text = (dataGridView1.SelectedCells[2].Value.ToString());
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
