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
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel Order = new PizzaOrderModel
            {
                PizzaId = order.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = pizzaPrice
            };
            List<PizzaOrderDetailModel> detail = order.Extra.Select(x => new PizzaOrderDetailModel
            {
                PizzaExtraId = x,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();
            await _db.PizzaOrder.AddAsync(Order);
            await _db.PizzaDetail.AddRangeAsync(detail);
            await _db.SaveChangesAsync();
            OrderMessage Message = new OrderMessage
            {
                message = "Thank you for choosing our pizzas",
                InvoiceNo = invoiceNo,
                TotalAmount = pizzaPrice
            };
            return Ok(Message);
        }
        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult>GetDetailOrderAsync(string invoiceNo)
        {
            var item = await _db.PizzaOrder.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            if (item is null) return NotFound("No Pizza Found.");
            return Ok(item);
        }
    }
}
