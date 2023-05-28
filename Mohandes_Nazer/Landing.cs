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
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void Landing_Load(object sender, EventArgs e)
        {
            cs = new Customers(this);
            refresh();
        }
        public void refresh()
        {
            try
            {
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\Mohandes_Nazer\Mohandes_Nazer\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand comm = new SqlCommand("SELECT name FROM customers", sc);
                SqlDataReader reader = comm.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["name"].ToString());
                }
                
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Customers cs;
        private void button1_Click(object sender, EventArgs e)
        {
            cs.ins = true;
            cs.start("");
            cs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cs.ins = false;
            string name = comboBox1.Text;
            cs.Show();
            cs.start(name);

        }
    }
}
