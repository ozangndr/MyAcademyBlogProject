using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.AboutDtos
{
    public class CreateAboutDto
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string GorselUrl { get; set; }
    }
}
