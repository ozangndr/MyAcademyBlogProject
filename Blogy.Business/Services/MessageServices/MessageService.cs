using AutoMapper;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.DTOs.MessageDtos;
using Blogy.DataAccess.Repositories.MessageRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.MessageServices
{
    public class MessageService(IMessageRepository _messageRepository,IMapper _mapper) : IMessageService
    {
        public async Task CreateAsync(CreateMessageDto createDto)
        {
            var message= _mapper.Map<Message>(createDto);
            await _messageRepository.CreateAsync(message);

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultMessageDto>> GetAllAsync()
        {
            var messages = await _messageRepository.GetAllAsync();
            return _mapper.Map<List<ResultMessageDto>>(messages);
        }

        public Task<UpdateMessageDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultMessageDto> GetSingleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateMessageDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
