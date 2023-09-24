using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.UoW;

namespace BLL.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IMapper _mapper;
        private readonly IChatMessageRepository _repo;

        public ChatMessageService(IUoW uow, IMapper mapper)
        {
            _mapper = mapper;
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
    }
}
