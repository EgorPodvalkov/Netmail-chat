using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IChatMessageRepository : IBaseRepository<ChatMessage>
    {
        /// <summary>
        /// Gets amount of messages in db <br/> Uniq by content
        /// </summary>
        /// <param name="uniq">If true uniq by content</param>
        Task<int> GetAmountAsync(bool uniq = false);
    }
}
