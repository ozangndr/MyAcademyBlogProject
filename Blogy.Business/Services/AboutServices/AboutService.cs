using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.DataAccess.Repositories.AboutRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AboutServices
{
    public class AboutService(IAboutRepository _aboutRepository, IMapper _mapper) : IAboutService
    {
        public Task CreateAsync(CreateAboutDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var about = await _aboutRepository.GetAllAsync();
            return _mapper.Map<List<ResultAboutDto>>(about);
        }

        public Task<UpdateAboutDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAboutDto> GetSingleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateAboutDto updateDto)
        {
            var about = _mapper.Map<About>(updateDto);
            await _aboutRepository.UpdateAsync(about);
        }
    }
}
