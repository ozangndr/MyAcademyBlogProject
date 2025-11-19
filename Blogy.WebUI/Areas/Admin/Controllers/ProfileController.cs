using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =Roles.Admin)]
    public class ProfileController(UserManager<AppUser> _userManager,IMapper _mapper) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            var editUser=_mapper.Map<EditProfileDto>(user);
            return View(editUser);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EditProfileDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var passwordCorrect=await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (!passwordCorrect)
            {
                ModelState.AddModelError("", "Girilen mevcut şifreniz hatalı!");
                return View(model);
            }
            if(model.ImageFile is not null)
            {
                var currentDirectory=Directory.GetCurrentDirectory();
                var extention=Path.GetExtension(model.ImageFile.FileName);
                var imageName=Guid.NewGuid()+extention;
                var saveLocation=Path.Combine(currentDirectory,"wwwroot/Images",imageName);
                using var stream=new FileStream(saveLocation,FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);
                user.Imageurl="/Images/"+imageName;
            }
            user.FirstName=model.FirstName;
            user.LastName=model.LastName;
            user.Title=model.Title;
            user.Email=model.Email;
            user.UserName=model.UserName;
            user.PhoneNumber=model.PhoneNumber;
            var result=await _userManager.UpdateAsync(user);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Profil güncellenirken bir hata oluştu.Lütfen tüm alanları doğru doldurduğunuzdan emin olun.");
                return View(model);
            }
            return RedirectToAction("Index","Blog",new {area=Roles.Admin});
        }
    }

    
}
