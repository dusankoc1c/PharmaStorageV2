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
    public partial class Purchase : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=PharmaStorage;Integrated Security=True");

        public Purchase()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string qu1 = "select ProducerID from Producer where ProducerName = @ProducerName";
                SqlCommand q = new SqlCommand(qu1, conn);
                q.Parameters.AddWithValue("@ProducerName", textBox7.Text);
                int producerID = (int)q.ExecuteScalar();
                textBox2.Text = producerID.ToString();  
                /*Inesrting new values in Medicine*/
                string query = "insert into Medicine (MedicineID,ProducerID,MedicineName,Instructions,Quantity,ProducerName,Price) values(@MedicineID,@ProducerID,@MedicineName,@Instruction, @Quantity,@ProducerName,@Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MedicineID", textBox1.Text);
                cmd.Parameters.AddWithValue("@ProducerID", producerID);
                cmd.Parameters.AddWithValue("@MedicineName", textBox3.Text);
                cmd.Parameters.AddWithValue("@Instruction", textBox4.Text);               
                if (int.TryParse(textBox5.Text, out int intValue))
                {
                    cmd.Parameters.AddWithValue("@Quantity", textBox5.Text);
                }
                else
                {
                    MessageBox.Show("You have entered a wrong type of value for " + "'Quantity'" + " field");
                }
                cmd.Parameters.AddWithValue("@ProducerName", textBox7.Text);
                cmd.Parameters.AddWithValue("@Price", textBox9.Text);
                cmd.ExecuteNonQuery();
                /*LOading the existingt values*/
                string query1 = "select * from Medicine";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            conn.Open();
            /*deleting row from database*/
            string query = "delete from Medicine where @MedicineID = MedicineID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@MedicineID", textBox1.Text);
            command.ExecuteNonQuery();
            /*loading new values*/
            string query1 = "Select * from Medicine";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = (dataGridView1.SelectedCells[0].Value.ToString());
            textBox2.Text = (dataGridView1.SelectedCells[1].Value.ToString());
            textBox3.Text = (dataGridView1.SelectedCells[2].Value.ToString());
            textBox4.Text = (dataGridView1.SelectedCells[3].Value.ToString());
            textBox5.Text = (dataGridView1.SelectedCells[4].Value.ToString());
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            string query = "Select * from Medicine";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox6.Enabled = false;
            textBox6.Hide();
            label6.Hide();
            btn_submit.Enabled = false;
            btn_submit.Hide();
            btn_submit_minus.Hide();
            btn_submit_minus.Enabled = false;
            textBox2.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            label6.Show();
            textBox1.Enabled = false; textBox2.Enabled = false;
            textBox3.Enabled = false; textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Show();
            textBox6.Enabled = true;
            btn_submit.Enabled = true;
            btn_submit.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            /**/
            label6.Show();
            textBox1.Enabled = false; textBox2.Enabled = false;
            textBox3.Enabled = false; textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Show();
            textBox6.Enabled = true;
            btn_submit_minus.Enabled = true;
            btn_submit_minus.Show();
            /**/
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_minus_Click(object sender, EventArgs e)
        {
            conn.Open();
            /*decreasing the quantity*/
            string query = "declare @broj int;\r\nset @broj = @quantity;\r\nupdate [dbo].[Medicine] set  Quantity = Quantity - @broj\r\nwhere MedicineID = @MedicineID;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@quantity", textBox6.Text);
            command.Parameters.AddWithValue("@MedicineID", textBox1.Text);
            command.ExecuteNonQuery();
            /*loading new values*/
            string query1 = "Select * from Medicine";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            /**/
            label6.Hide();
            textBox1.Enabled = true; textBox2.Enabled = true;
            textBox3.Enabled = true; textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Hide();
            textBox6.Enabled = false;
            btn_submit.Hide();
            btn_submit.Enabled = false;
            btn_submit_minus.Hide();
            btn_submit_minus.Enabled = false;
            /**/
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            conn.Open();
            /*decreasing the quantity*/
            string query = "declare @broj int;\r\nset @broj = @quantity;\r\nupdate [dbo].[Medicine] set  Quantity = Quantity + @broj\r\nwhere MedicineID = @MedicineID;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@quantity", textBox6.Text);
            command.Parameters.AddWithValue("@MedicineID", textBox1.Text);
            command.ExecuteNonQuery();
            /*loading new values*/
            string query1 = "Select * from Medicine";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            /**/
            label6.Hide();
            textBox1.Enabled = true; textBox2.Enabled = true;
            textBox3.Enabled = true; textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Hide();
            textBox6.Enabled = false;
            btn_submit.Enabled = false;
            btn_submit.Hide();
            /**/
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            conn.Open();


            string query = "declare @tekst as varchar(100);\r\nset @tekst = @input;\r\nselect * from Medicine\r\nwhere MedicineName like @tekst + '%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@input", textBox8.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            conn.Close();
        }


    }
}
