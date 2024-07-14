using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.MVCChartApp.Models;

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
            HighChartModel model = new HighChartModel();
            model.Data1 = new List<double> { 16.0, 18.2, 23.1, 27.9, 32.2, 36.4, 39.8, 38.4, 35.5, 29.2,
            22.0, 17.8};
            model.Data2 = new List<double> {  -2.9, -3.6, -0.6, 4.8, 10.2, 14.5, 17.6, 16.5, 12.0, 6.5,
            2.0, -0.9};
            model.Series = new List<string>()
            {
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep",
            "Oct", "Nov", "Dec"
            };
            return View(model);
        }
    }
}
