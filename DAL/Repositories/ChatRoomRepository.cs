﻿using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChatRoomRepository : BaseRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(NetmailChatDatabaseContext db) : base(db) { }

        public async Task<ChatRoom?> GetByIdWithMessagesAsync(Guid id)
        {
            return await _db.Set<ChatRoom>()
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
