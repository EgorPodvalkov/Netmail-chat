using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IChatRoomRepository : IBaseRepository<ChatRoom>
    {
        /// <summary>
        /// Gets room with messages by ID from db
        /// </summary>
        Task<ChatRoom?> GetByIdWithMessagesAsync(Guid id);

        /// <summary>
        /// Gets room with messages by Name from db
        /// </summary>
        Task<ChatRoom?> GetByNameWithMessagesAsync(string name);

        /// <summary>
        /// Gets amount of rooms in db
        /// </summary>
        Task<int> GetAmountAsync();
    }
}
