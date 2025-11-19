using Blogy.Business.Services.MessageServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class MessageController(IMessageService _messageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values =await _messageService.GetAllAsync();
            return View(values);
        }
    }
}
