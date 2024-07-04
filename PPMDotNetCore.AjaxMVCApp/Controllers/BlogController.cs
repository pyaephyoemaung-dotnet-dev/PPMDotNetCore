using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.AjaxMVCApp.Db;
using PPMDotNetCore.AjaxMVCApp.Models;

namespace PPMDotNetCore.AjaxMVCApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AddDbContext _db;

        public BlogController(AddDbContext db)
        {
            _db = db;
        }
        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
            var lst = await _db.Blogs.AsNoTracking().OrderByDescending(x => x.BlogId).ToListAsync();
            return View("BlogIndex", lst);
        }
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogsModel blog)
        {
            await _db.Blogs.AddAsync(blog);
            var result = await _db.SaveChangesAsync();
            var message = new MessageModel() {
                IsSuccess = result > 0,
                Message = result > 0 ? "Saving succefull." : "Saving failed."
            };
            return Json(message);

        }
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }
            return View("BlogEdit", item);
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogsModel blog)
        {
            var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            var result = await _db.SaveChangesAsync();
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Updating succefull." : "Updating failed."
            };
            return Json(message);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(BlogsModel blog)
        {
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
            if (item is null)
            {
                return Redirect("/Blog");
            }
            _db.Blogs.Remove(item);
            var result = await _db.SaveChangesAsync();
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Deleting succefull." : "Deleting failed."
            };
            return Json(message);
        }
    }
}
