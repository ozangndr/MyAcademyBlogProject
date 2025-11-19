using Blogy.Business.DTOs.CommunucationDtos;
using Blogy.Business.Services.CommunucationServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class CommunucationController(ICommunucationService _communucationService) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var values= await _communucationService.GetAllAsync();
            var value = values.OrderByDescending(x => x.Id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCommunucation(UpdateCommunucationDto communucationDto)
        {
            if (!ModelState.IsValid)
            {
                return View(communucationDto);
            }
            await _communucationService.UpdateAsync(communucationDto);
            TempData["SuccessMessage"] = "İletişim bilgileri başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
