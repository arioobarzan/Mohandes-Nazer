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

namespace Mohandes_Nazer
{
    public partial class Customers : Form
    {
        public bool ins = true;
        Landing l;
        public Customers(Landing land)
        {
            l = land;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string addr = textBox2.Text;
            string mobi = textBox3.Text;
            change(name, addr, mobi, ins);
        }
        private void change(string name, string addr, string mobi, bool insert)
        {
            try
            {
                string query;
                if (ins)
                
                    query = "INSERT INTO customers (name,address,mobile)" +
                        " VALUES (@nam,@adr,@mob)";
                
                else
                    query = "UPDATE customers SET " +
                        "address='" + addr + "',mobile='" + mobi + "'" +
                        "WHERE name = '" + name + "'";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\Mohandes_Nazer\Mohandes_Nazer\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand comm = new SqlCommand(query, sc);
                if (ins)
                {
                    comm.Parameters.AddWithValue("nam", name);
                    comm.Parameters.AddWithValue("adr", addr);
                    comm.Parameters.AddWithValue("mob", mobi);
                }
                comm.ExecuteNonQuery();
                sc.Close();
                string m = (ins) ? "Insert" : "update";
                MessageBox.Show("Successfully " + m);
                textBox1.Text = textBox2.Text = textBox3.Text = "";
                this.Hide();
                l.refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void start(string name)
        {
            if (name == "")
            {
                textBox1.Text = textBox2.Text = textBox3.Text = "";
                textBox1.Enabled = true;
            }
            else
            {
                try
                {
                    textBox1.Enabled = false;
                    SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\Mohandes_Nazer\Mohandes_Nazer\Database1.mdf;Integrated Security=True");
                    sc.Open();
                    SqlCommand comm = new SqlCommand("SELECT * FROM customers WHERE name='" + name + "'", sc);
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader["name"].ToString();
                        textBox2.Text = reader["address"].ToString();
                        textBox3.Text = reader["mobile"].ToString();
                    }

                    sc.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
