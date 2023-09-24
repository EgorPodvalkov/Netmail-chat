using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UoW
{
    public class UoW : IUoW
    {
        private readonly NetmailChatDatabaseContext _db;

        private IChatMessageRepository? _messageRepository;
        private IChatRoomRepository? _roomRepository;

        public UoW(NetmailChatDatabaseContext db)
        {
            _db = db;
        }

        public IChatMessageRepository GetChatMessageRepository()
        {
            _messageRepository ??= new ChatMessageRepository(_db);

            return _messageRepository;
        }

        public IChatRoomRepository GetChatRoomRepository()
        {
            _roomRepository ??= new ChatRoomRepository(_db);

            return _roomRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
