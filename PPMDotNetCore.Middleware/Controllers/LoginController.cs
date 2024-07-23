using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.Middleware.Models;

namespace PPMDotNetCore.Middleware.Controllers
{
    public class LoginController : Controller
    {
        [ActionName("Index")]
        public IActionResult LoginIndex()
        {
            return View("LoginView");
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult Index(LoginDataRequestModel requestModel)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append("name", requestModel.UserName, option);
            return Redirect("/Home");
        }
    }
}
