using Blogy.Business.DTOs.MessageDtos;
using Blogy.Business.Services.AiServices;
using Blogy.Business.Services.CommunucationServices;
using Blogy.Business.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class CommunucationController(ICommunucationService _communucationService ,IMessageService _messageService,AIService _aIService) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var values = await _communucationService.GetAllAsync();
            var value=values.OrderByDescending(x=>x.Id).FirstOrDefault();
            return View(value);
        }

        //[HttpPost]
        //public async Task<IActionResult> SendMessage(CreateMessageDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        TempData["MessageError"] = "Lütfen tüm alanları doldurun.";
        //        return RedirectToAction("Index");
        //    }

        //    try
        //    {
        //        await _messageService.CreateAsync(dto);
        //        TempData["MessageSuccess"] = "Mesajınız başarıyla gönderildi!";
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MessageError"] = "Mesaj gönderilirken bir hata oluştu: " + ex.Message;
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["MessageError"] = "Lütfen tüm alanları doldurun.";
                return RedirectToAction("Index");
            }

            try
            {
                // 1️⃣ Kullanıcı mesajını veritabanına kaydet
                await _messageService.CreateAsync(dto);
                TempData["MessageSuccess"] = "Mesajınız başarıyla gönderildi!";

                // 2️⃣ AI’dan otomatik yanıt al (mesajın dilini algılar ve o dilde yanıt üretir)
                string aiReply = await _aIService.GetAutoReply(dto.Mesaj);

                // 3️⃣ Yanıtı kullanıcıya göster
                TempData["AIReply"] = aiReply;
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = "Mesaj gönderilirken bir hata oluştu: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
