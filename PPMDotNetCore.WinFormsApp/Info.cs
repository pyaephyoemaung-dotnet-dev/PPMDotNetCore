using PPMDotNetCore.Shared;
using PPMDotNetCore.WinFormsApp.BlogQuery;
using PPMDotNetCore.WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPMDotNetCore.WinFormsApp
{
    public partial class Info : Form
    {
        private readonly DapperService _dapperService;
        public Info()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Info_Load(object sender, EventArgs e)
        {
            List<BlogsModel> lst = _dapperService.Query<BlogsModel>(BlogQueries.BlogList);
            dgv.DataSource = lst;
        }
    }
}
