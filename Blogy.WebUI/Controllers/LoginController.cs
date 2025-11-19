using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class LoginController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı Adı veya Şifre Hatalı");
                    return View(model);
                }
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Blog", new { area = "Admin" });
            }
            else if (roles.Contains("Writer"))
            {
                return RedirectToAction("Index", "Blog", new { area = "Writer" });
            }
            else if (roles.Contains("User"))
            {
                return RedirectToAction("Index", "Default"); // Normal kullanıcı anasayfası
            }
            else
            {
                // Rol yoksa onay bekleyen kullanıcı
                await _signInManager.SignOutAsync();
                ModelState.AddModelError(string.Empty, "Kullanıcı kaydı onay bekliyor veya rol tanımlı değil.");
                return View(model);
            }
        }


        
        public async Task<IActionResult> GoAdminPanel(LoginDto model)
        {
            var currentUserName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(currentUserName);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Blog", new { area = "Admin" });
            }
            else if (roles.Contains("Writer"))
            {
                return RedirectToAction("Index", "Blog", new { area = "Writer" });
            }
            else if (roles.Contains("User"))
            {
                return RedirectToAction("Index", "Profile", new { area = "User" });
            }
            else
            {
                // Rol yoksa onay bekleyen kullanıcı
                await _signInManager.SignOutAsync();
                ModelState.AddModelError(string.Empty, "Kullanıcı kaydı onay bekliyor veya rol tanımlı değil.");
                return View(model);
            }

        }
    }
}
