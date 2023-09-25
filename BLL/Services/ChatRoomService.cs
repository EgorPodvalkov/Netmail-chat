using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UoW;

namespace BLL.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IMapper _mapper;
        private readonly IUoW _uow;
        private readonly IChatRoomRepository _repo;

        public ChatRoomService(IUoW uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
            _repo = uow.GetChatRoomRepository();
        }

        public Task<int> GetAmountAsync()
        {
            return _repo.GetAmountAsync();
        }

        public async Task<ChatRoomDTO?> GetWithMessagesByIDAsync(Guid id)
        {
            var entity = await _repo.GetByIdWithMessagesAsync(id);

            var dto = _mapper.Map<ChatRoomDTO>(entity);
            return dto;
        }

        public async Task<ChatRoomDTO?> GetWithMessagesByNameAsync(string name)
        {
            var entity = await _repo.GetByNameWithMessagesAsync(name);

            var dto = _mapper.Map<ChatRoomDTO>(entity);
            return dto;
        }

        public async Task<Guid> GetChatIDByName(string name)
        {
            var id = await _repo.GetIDByNameAsync(name);

            if (id == Guid.Empty)
            {
                var entity = new ChatRoom { Name = name };
                await _repo.AddAsync(entity);
                id = entity.ID;
            }

            return id.Value;
        }

        public async Task CreateAsync(ChatRoomDTO dto)
        {
            var entity = _mapper.Map<ChatRoom>(dto);

            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(ChatRoomDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.ID)
                ?? throw new Exception("No entity by dto ID for updating ChatRoom :(");

            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
