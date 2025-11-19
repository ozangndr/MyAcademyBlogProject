using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area(Roles.Writer)]
    [Authorize(Roles =Roles.Writer)]
    public class UsersController(SignInManager<AppUser> _signInManager) : Controller
    {
        public async Task<IActionResult> Logout()
        {
            // Cookie tabanlı kimlik doğrulama varsa:
            await _signInManager.SignOutAsync();

            // Default/Index sayfasına yönlendir
            return RedirectToAction("Index", "Default", new { area = "" });

        }
    }
}
