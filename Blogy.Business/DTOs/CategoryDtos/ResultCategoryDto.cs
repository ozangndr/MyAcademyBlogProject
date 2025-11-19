using Blogy.Business.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<ResultBlogDto> Blogs { get; set; }
    }
}
