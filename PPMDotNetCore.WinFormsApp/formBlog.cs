using PPMDotNetCore.Shared;
using PPMDotNetCore.WinFormsApp.BlogQuery;
using PPMDotNetCore.WinFormsApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace PPMDotNetCore.WinFormsApp
{
    public partial class formBlog : Form
    {
        private readonly DapperService _dapperServices;
        private readonly int _blogId;
        public formBlog()
        {
            InitializeComponent();
            _dapperServices = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public formBlog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _dapperServices = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var model = _dapperServices.QueryFirstOrDefault<BlogsModel>("select * from tbl_blog where blogid = @BlogId", new BlogsModel { BlogId = _blogId });
            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogsModel blog = new BlogsModel();
                blog.BlogTitle = txtTitle.Text.Trim();
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text.Trim();

                int result = _dapperServices.Execute(BlogQueries.BlogCreate, blog);
                string message = result > 0 ? "Saving success" : "Saving fail";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
                if (result > 0)
                    ClearControll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControll();
        }
        private void ClearControll()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogsModel
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };
                string query = @"UPDATE [dbo].[Tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

                using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
                int result = _dapperServices.Execute(query, item);

                string message = result > 0 ? "Updating success" : "Updating fail";
                MessageBox.Show(message);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }        }
    }
}
