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
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void blogListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBlogList blogList = new FormBlogList();
            blogList.ShowDialog();
        }

        private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBlog blog = new formBlog();
            blog.ShowDialog();
        }
    }
}
