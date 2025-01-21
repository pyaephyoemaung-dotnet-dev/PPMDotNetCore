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

namespace PPMDotNetCore.WinFormsApp
{
    public partial class stud : Form
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetRevision",
            UserID = "sa",
            Password = "sasa@123"
        };
        public stud()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            conn.Open();
            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, conn);
        }

        private void listbtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            conn.Open();
            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
        }
    }
}
