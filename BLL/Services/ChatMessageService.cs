using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UoW;

namespace BLL.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IMapper _mapper;
        private readonly IUoW _uow;
        private readonly IChatMessageRepository _repo;

        public ChatMessageService(IUoW uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
            _repo = uow.GetChatMessageRepository();
        }

        public async Task<int> GetAmountAsync(bool uniq = false)
        {
            return await _repo.GetAmountAsync(uniq);
        }

        public async Task<ChatMessageDTO?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);

            var dto = _mapper.Map<ChatMessageDTO>(entity);
            return dto;
        }

        public async Task CreateAsync(ChatMessageDTO dto)
        {
            var entity = _mapper.Map<ChatMessage>(dto);

            await _repo.AddAsync(entity);
        }

        public async Task AddMessageAsync(Guid chatRoomID, string content, string? NickName)
        {
            var message = new ChatMessage
            {
                ChatRoomID = chatRoomID,
                Content = content,
                NickName = NickName,
                SendTime = DateTime.Now
            };

            await _repo.AddAsync(message);
            await _uow.SaveAsync();
        }

    }
}
