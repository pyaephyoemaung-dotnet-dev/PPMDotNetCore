using Microsoft.AspNetCore.Mvc;

namespace PPMDotNetCore.MVCChartApp.Controllers
{
    public class HighChartsController1 : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
        public IActionResult LineChart()
        {
            return View();
        }
    }
}
