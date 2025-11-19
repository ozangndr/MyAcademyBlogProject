using Blogy.Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.MessageDtos
{
    public class UpdateMessageDto:BaseDto
    {
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public DateTime GonderimTarihi { get; set; }
    }
}
