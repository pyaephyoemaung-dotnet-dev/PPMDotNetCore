using PPMDotNetCore.Shared;
using PPMDotNetCore.WinFormsApp.BlogQuery;
using PPMDotNetCore.WinFormsApp.Models;

namespace PPMDotNetCore.WinFormsApp
{
    public partial class FormBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FormBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }

        private void FormBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }
        private void BlogList()
        {
            List<BlogsModel> lst = _dapperService.Query<BlogsModel>(BlogQueries.BlogList);
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);
            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                formBlog blog = new formBlog(blogId);
                blog.ShowDialog();
                BlogList();
            }
            else if(e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.Yes) return;
                
                DeleteBlog(blogId);
            }
            BlogList();
        }
        private void DeleteBlog (int id)
        {
            string query = @"Delete From [dbo].[Tbl_blog] where BlogId = @BlogId";

            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Delete Successful" : "Delete Fail";
            MessageBox.Show(message);
        }
    }
}
