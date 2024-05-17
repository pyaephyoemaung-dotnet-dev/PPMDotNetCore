using PPMDotNetCore.Shared;
using PPMDotNetCore.WinFormsApp.BlogQuery;
using PPMDotNetCore.WinFormsApp.Models;

namespace PPMDotNetCore.WinFormsApp
{
    public partial class formBlog : Form
    {
        private readonly DapperService _dapperServices;
        public formBlog()
        {
            InitializeComponent();
            _dapperServices = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
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
                if(result > 0)
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
    }
}
