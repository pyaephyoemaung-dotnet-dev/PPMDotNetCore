using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.ModelViewControllerApp.Database;
using PPMDotNetCore.ModelViewControllerApp.Models;

namespace PPMDotNetCore.ModelViewControllerApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blogs.ToListAsync();
            return View(lst);
        }
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            await _db.Blogs.AddAsync(blog);
            var result = await _db.SaveChangesAsync();
            return Redirect("/Blog");
        }
    }
}
