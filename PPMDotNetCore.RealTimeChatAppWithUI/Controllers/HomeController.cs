using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PPMDotNetCore.RealTimeChatAppWithUI.Hubs;
using PPMDotNetCore.RealTimeChatAppWithUI.Models;
using System.Diagnostics;

namespace PPMDotNetCore.RealTimeChatAppWithUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<Notification> _hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<Notification> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> IndexAsync(DataRequestModel dataRequestModel)
        {
            await _hubContext.Clients.All.SendAsync("ClientReceiveMessage", dataRequestModel.Data);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public class DataRequestModel
        {
            public string Data { get; set; }
        }
    }
}
