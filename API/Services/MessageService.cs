using API.Extensions;
using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Message> Create(string content, int roomId, int userId)
        {
            var message = new Message
            {
                RoomId = roomId,
                UserId = userId,
                Content = content
            };
            message = await _unitOfWork.Messages.Add(message);
            return message;
        }

        public MessageViewModel GetViewModel(Message message)
        {
            return _unitOfWork.Messages.List(msg => msg.Id == message.Id).MapTo<MessageViewModel>(_mapper).FirstOrDefault();
        }
    }
}
