using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult WriterLayout()
        {
            return View();
        }
    }
}
