using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.MinimalAPI.Db;
using PPMDotNetCore.MinimalAPI.Models;

namespace PPMDotNetCore.MinimalAPI.Features.Blog
{
    public static class BlogServices
    {
        public static void AddBlogFeatures(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blogs", async (AddDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("api/Blogs", (AddDbContext db, BlogsModel blog) =>
            {
                db.Blogs.Add(blog);
                var result = db.SaveChanges();

                string message = result > 0 ? "Saving succeful." : "Saving fail.";
                return Results.Ok(message);
            });

            app.MapPut("api/Blogs/{id}", async (AddDbContext db, int id, BlogsModel blog) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found.");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogAuthor = blog.BlogContent;
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Updating successful." : "Updating fail.";
                return Results.Ok(message);
            });

            app.MapDelete("api/Blogs/{id}", async (AddDbContext db, int id) => {
                var item = await db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No dat found.");
                }
                db.Blogs.Remove(item);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting successful." : "Deleting fail.";
                return Results.Ok(message);
            });
        }
    }
}
