using Blogy.Business.DTOs.CommunucationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.CommunucationServices
{
    public interface ICommunucationService: IGenericService<ResultCommunucationDto, UpdateCommunucationDto, CreateCommunucationDto>
    {
    }
}
