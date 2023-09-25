using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IChatRoomService
    {
        /// <summary>
        /// Gets chat room with messages by ID
        /// </summary>
        Task<ChatRoomDTO?> GetWithMessagesByIDAsync(Guid id);

        /// <summary>
        /// Gets chat room with messages by name
        /// </summary>
        Task<ChatRoomDTO?> GetWithMessagesByNameAsync(string name);

        /// <summary>
        /// Gets amount of all chat rooms
        /// </summary>
        Task<int> GetAmountAsync();

        /// <summary>
        /// Gets room chat ID by name from DB, otherwise creates new room with this name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Guid> GetChatIDByName(string name);

        /// <summary>
        /// Adds chat room to db 
        /// </summary>
        Task CreateAsync(ChatRoomDTO dto);

        /// <summary>
        /// Modifies chat room in db
        /// </summary>
        Task UpdateAsync(ChatRoomDTO dto);

        /// <summary>
        /// Removes chat room from db by ID
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
