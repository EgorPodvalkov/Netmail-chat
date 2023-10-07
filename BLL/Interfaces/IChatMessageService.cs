using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IChatMessageService
    {
        /// <summary>
        /// Gets message by ID from db
        /// </summary>
        Task<ChatMessageDTO?> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets amount of all messages
        /// </summary>
        /// <param name="uniq">If true uniq by content</param>
        /// <returns></returns>
        Task<int> GetAmountAsync(bool uniq = false);

        /// <summary>
        /// Adds message to db 
        /// </summary>
        Task CreateAsync(ChatMessageDTO dto);

        /// <summary>
        /// Adds message to db 
        /// </summary>
        Task AddMessageAsync(Guid chatRoomID, string content, string? NickName);

        /*/// <summary>
        /// Modifies message in db
        /// </summary>
        Task UpdateAsync(ChatMessageDTO dto);

        /// <summary>
        /// Removes message from db 
        /// </summary>
        Task DeleteAsync(ChatMessageDTO dto);

        /// <summary>
        /// Removes message from db by ID
        /// </summary>
        Task DeleteAsync(Guid id);*/
    }
}
