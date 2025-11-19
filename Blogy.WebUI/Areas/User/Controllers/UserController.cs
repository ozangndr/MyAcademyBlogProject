using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserLayout()
        {
            return View();
        }
    }
}
