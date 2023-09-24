using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IChatRoomRepository : IBaseRepository<ChatRoom>
    {
        /// <summary>
        /// Gets room with messages by ID from db
        /// </summary>
        Task<ChatRoom?> GetByIdWithMessagesAsync(Guid id);
    }
}
