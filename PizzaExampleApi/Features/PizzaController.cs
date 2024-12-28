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
        [HttpGet("Extra")]
        public async Task<IActionResult> GetPizzasExtraAsync()
        {
            var lst = await _db.PizzaExtra.ToListAsync();
            return Ok(lst);
        }
        [HttpPost("AddPizza")]
        public async Task<IActionResult> AddPizzaAsync(PizzaModel pizza)
        {
            await _db.Pizza.AddAsync(pizza);
            var result = _db.SaveChangesAsync();
            if (pizza.PizzaName!.Length < 0) return NotFound("No Pizza added.");
            return Ok(result);
        }
        [HttpPost("AddExtraPizza")]
        public async Task<IActionResult>AddExtraPizza(PizzaExtraModel pizzaExtra)
        {
            await _db.PizzaExtra.AddAsync(pizzaExtra);
            await _db.SaveChangesAsync();
            if (pizzaExtra.PizzaExtraName!.Length < 0) return NotFound("No Pizza Added");
            return Ok("Pizza Adding Succeful.");
        }
        [HttpPost("OrderRequest")]
        public async Task<IActionResult>OrderRequestAsync(OrderRequest order)
        {
            var item = await _db.Pizza.FirstOrDefaultAsync(x => x.PizzaId == order.PizzaId);
            var pizzaPrice = item.PizzaPrice;
            if (order.Extra.Length > 0)
            {
                var lstExtra = await _db.PizzaExtra.Where(x => order.Extra.Contains(x.PizzaExtraId)).ToListAsync();
                pizzaPrice += lstExtra.Sum(x => x.PizzaPrice);
            }
        }
    }
}
