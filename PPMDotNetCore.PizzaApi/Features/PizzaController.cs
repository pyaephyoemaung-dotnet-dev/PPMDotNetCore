using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPMDotNetCore.PizzaApi.Db;

namespace PPMDotNetCore.PizzaApi.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AddDbContext _appContext;
        public PizzaController()
        {
            _appContext = new AddDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appContext.Pizza.ToListAsync();
            return Ok(lst);
        }
        [HttpGet("Extra")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var lst = await _appContext.PizzaExtra.ToListAsync();
            return Ok(lst);
        }
        [HttpPost]
        public async Task<IActionResult> OrderRequestAsync(OrderRequest orderRequest)
        {
            var item = await _appContext.Pizza.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var pizzaPrice = item.Price;
            if(orderRequest.Extra.Length > 0)
            {
                var lstExtra = await _appContext.PizzaExtra.Where(x => orderRequest.Extra.Contains(x.PizzaExtraId)).ToListAsync();
                pizzaPrice += lstExtra.Sum(x => x.Price);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = pizzaPrice
            };
            List<PizzaOrderDetailModel> pizzaOrderDetailModels = orderRequest.Extra.Select(extraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();
            await _appContext.PizzaOrders.AddAsync(pizzaOrderModel);
            await _appContext.PizzaOrderDetails.AddRangeAsync(pizzaOrderDetailModels);
            await _appContext.SaveChangesAsync();
            OrderMessage orderMessage = new OrderMessage()
            {
                InvoiceNo = invoiceNo,
                message = "Thank ykou your order!!",
                TotalAmount = pizzaPrice
            };
            return Ok(orderRequest);
        }
    }
}
