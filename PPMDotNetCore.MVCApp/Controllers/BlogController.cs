using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.MVCApp.Db;
using PPMDotNetCore.MVCApp.Models;

namespace PPMDotNetCore.MVCApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AddDbContext _db;

        public BlogController(AddDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blogs.AsNoTracking().OrderByDescending(x => x.BlogId).ToListAsync();
            return View(lst);
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
            return Redirect("/Blog");

        }
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if(item is null)
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

            await _db.SaveChangesAsync();
            return Redirect("/Blog");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }
            _db.Blogs.Remove(item);
            await _db.SaveChangesAsync();
            return Redirect("/Blog");
        }
    }
}
