using PPMDotNetCore.NLayer.DataAccess.Db;
using PPMDotNetCore.NLayer.DataAccess.Models;

namespace PPMDotNetCore.NLayer.DataAccess.Services
{
    public class DataAccess
    {
        private readonly AddDbContext _context;
        public DataAccess()
        {
            _context = new AddDbContext();
        }


        // Check data from table



        public List<BlogsModel> GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return lst;
        }


        // Check data from table by id  



        public BlogsModel GetBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return item;
        }



        // Check data after create data from user request



        public int CreateBlog(BlogsModel requestModel)
        {
            _context.Blogs.Add(requestModel);
            var result = _context.SaveChanges();
            return result;
        }



        // Check data after update data from user request



        public int UpdateBlog(int id, BlogsModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogAuthor = requestModel.BlogContent;
            var result = _context.SaveChanges();
            return result;
        }



        // Check data after delete data from user



        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }

        internal int UpdateBlog(BlogsModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
