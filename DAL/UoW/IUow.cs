using DAL.Interfaces;

namespace DAL.UoW
{
    public interface IUoW : IDisposable
    {
        /// <summary>
        /// Gets new or before created ChatMessageRepository
        /// </summary>
        IChatMessageRepository GetChatMessageRepository();

        /// <summary>
        /// Gets new or before created ChatRoomRepository
        /// </summary>
        IChatRoomRepository GetChatRoomRepository();
        IEditorRepository GetEditorRepository();
        IArticleRepository GetArtileRepository();

        /// <summary>
        /// Saves changes in database
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        Task<int> SaveAsync();
    }
}
