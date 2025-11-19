using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.Services.AboutServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAsync();
            var value = values.OrderByDescending(x => x.Id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }
            await _aboutService.UpdateAsync(about);
            TempData["SuccessMessage"] = "Hakkımızda bilgileri başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
