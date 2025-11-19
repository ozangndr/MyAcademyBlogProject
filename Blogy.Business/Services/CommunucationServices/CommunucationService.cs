using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.DTOs.CommunucationDtos;
using Blogy.DataAccess.Repositories.CommunucationRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.CommunucationServices
{
    public class CommunucationService(ICommunucationRepository _communucationRepository,IMapper _mapper) : ICommunucationService
    {
        public Task CreateAsync(CreateCommunucationDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultCommunucationDto>> GetAllAsync()
        {
            var communucation = await _communucationRepository.GetAllAsync();
            return _mapper.Map<List<ResultCommunucationDto>>(communucation);
        }

        public async Task<UpdateCommunucationDto> GetByIdAsync(int id)
        {
            var value = await _communucationRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCommunucationDto>(value);
        }

        public Task<ResultCommunucationDto> GetSingleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateCommunucationDto updateDto)
        {
            var entity = _mapper.Map<Communucation>(updateDto);
            await _communucationRepository.UpdateAsync(entity);
        }
    }
}
