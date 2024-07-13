using Microsoft.AspNetCore.Mvc;

namespace PPMDotNetCore.MVCChartApp.Controllers
{
    public class CanvasjsChartController : Controller
    {
        private readonly ILogger<CanvasjsChartController> _logger;

        public CanvasjsChartController(ILogger<CanvasjsChartController> logger)
        {
            _logger = logger;
        }

        public IActionResult PieChartswithLegends()
        {
            return View();
        }
        public IActionResult LineChart()
        {
            _logger.LogInformation("Line Chart ...");
            return View();
        }
    }
}
