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
    public partial class Form1 : Form
    {
        Landing l = new Landing();
        public Form1()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            try
            {
                string un = textBox1.Text;
                string pa = textBox2.Text;
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\Mohandes_Nazer\Mohandes_Nazer\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand comm = new SqlCommand("SELECT password FROM user1 WHERE username='" + un + "'", sc);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string pass = reader["password"].ToString();
                if (pa == pass)
                {
                    l.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Incorrect");
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect");
            }
        }
    }
}
