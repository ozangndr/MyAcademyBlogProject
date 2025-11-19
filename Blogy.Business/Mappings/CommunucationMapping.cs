using AutoMapper;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.DTOs.CommunucationDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class CommunucationMapping : Profile
    {
        public CommunucationMapping()
        {
            CreateMap<Communucation, ResultCommunucationDto>().ReverseMap();
            CreateMap<Communucation, UpdateCommunucationDto>().ReverseMap();

        }
    }
}
