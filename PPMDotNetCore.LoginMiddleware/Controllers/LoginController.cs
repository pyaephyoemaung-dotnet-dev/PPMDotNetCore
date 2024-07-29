using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.LoginMiddleware.EFDbModels;

namespace PPMDotNetCore.LoginMiddleware.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;

        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserModel user)
        {
            var item = _db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (item is null) return View();
            string sessionId = Guid.NewGuid().ToString();
            DateTime sessionExp = DateTime.Now.AddMinutes(1);
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append("UserId", item.UserId, option);
            Response.Cookies.Append("SessionId", sessionId, option);
            await _db.Login.AddAsync(new LoginModel
            {
                SessionId = sessionId,
                UserId = item.UserId,
                SessionExp = sessionExp
            });
            await _db.SaveChangesAsync();
            return Redirect("/Home");
        }
    }
}
