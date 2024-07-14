using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.MVCChartApp.Models;

namespace PPMDotNetCore.MVCChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult RadarChart()
        {
            ChartJsRadarChartModel model = new ChartJsRadarChartModel();
            model.Series = new List<string>()
            {
                "Eating",
                "Drinking",
                "Sleeping",
                "Designing",
                "Coding",
                "Cycling",
                "Running"
            };
            model.data1 = new List<int> { 65, 59, 90, 81, 56, 55, 40};
            model.data2 = new List<int> { 28, 48, 40, 19, 96, 27, 100 };
            return View(model);
        }
    }
}
