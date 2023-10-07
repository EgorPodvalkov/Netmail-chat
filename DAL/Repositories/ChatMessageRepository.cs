using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChatMessageRepository : BaseRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(NetmailChatDatabaseContext db) : base(db) { }

        public async Task<int> GetAmountAsync(bool uniq = false)
        {
            if (uniq)
                throw new NotImplementedException("todo uniq amount");

            return await _db.Set<ChatMessage>()
                .CountAsync();
        }
    }
}
