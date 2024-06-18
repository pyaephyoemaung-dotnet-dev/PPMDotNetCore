using PPMDotNetCore.NLayer.DataAccess.Models;
using PPMDotNetCore.NLayer.DataAccess.Services;

namespace PPMDotNetCore.RestApiWithNLayer.Feature.Blog
{
    public class Basic_logic
    {
        private readonly DataAccess _dataAccess;
        public Basic_logic()
        {
            _dataAccess = new DataAccess();
        }
         public List<BlogsModel> GetBlogs()
        {
            var lst = _dataAccess.GetBlogs();
            return lst;
        }


                                            // Check data from table by id



        public BlogsModel GetBlog(int id)
        {
            var lst = _dataAccess.GetBlog(id);
            return lst;
        }
        


                                            // Check data after create data from user request



        public int CreateBlog(BlogsModel requestModel)
        {
            var result = _dataAccess.CreateBlog(requestModel);
            return result;
        }
        


                                            // Check data after update data from user request



        public int UpdateBlog(int id, BlogsModel requestModel)
        {
            var result = _dataAccess.UpdateBlog(id,requestModel);
            return result;
        }



                                             // Check data after delete data from user



        public int DeleteBlog(int id)
        {
            var result = _dataAccess.DeleteBlog(id);
            return result;
        }
    }
}
