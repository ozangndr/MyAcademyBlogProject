using Blogy.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class About :BaseEntity
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string GorselUrl { get; set; }
    }
}
