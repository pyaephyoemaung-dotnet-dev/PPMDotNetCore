using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.MVCChartApp.Models;

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
            CanvasJsLineChart model = new CanvasJsLineChart();
            model.Series = new List<int> { };
            return View();
        }
    }
}
