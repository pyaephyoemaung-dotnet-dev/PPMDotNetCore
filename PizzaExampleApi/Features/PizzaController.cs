using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaExampleApi.Db;

namespace PizzaExampleApi.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PizzaController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetPizzasAsync()
        {
            var lst = await _db.Pizza.ToListAsync();
            return Ok(lst);
        }
    }
}
