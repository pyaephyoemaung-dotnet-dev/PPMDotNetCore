using Microsoft.AspNetCore.Mvc;

namespace PPMDotNetCore.MVCChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult RadarChart()
        {
            return View();
        }
    }
}
