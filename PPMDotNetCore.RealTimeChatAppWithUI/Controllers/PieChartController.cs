using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PPMDotNetCore.RealTimeChatAppWithUI.Hubs;

namespace PPMDotNetCore.RealTimeChatAppWithUI.Controllers
{
    public class PieChartController : Controller
    {
        public static List<DataRequestModel> Data = new List<DataRequestModel>();
        private readonly IHubContext<Notification> _hubContext;

        public PieChartController(IHubContext<Notification> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(DataRequestModel dataRequestModel)
        {
            Data.Add(dataRequestModel);
            DataResponseModel model = new DataResponseModel()
            {
                Labels = Data.Select(x => x.Labels).ToList(),
                Series = Data.Select(x => x.Series).ToList()
            };
           string json = JsonConvert.SerializeObject(model);
          await  _hubContext.Clients.All.SendAsync("ClientReceiveMessage", json);
            return View();
        }
        public IActionResult Watch()
        {
            return View();
        }
        public class DataRequestModel
        {
            public string Labels { get; set; }
            public int Series { get; set; }
        }
        public class DataResponseModel
        {
            public List<string> Labels { get; set; }
            public List<int>Series { get; set; }
        }
    }
}
