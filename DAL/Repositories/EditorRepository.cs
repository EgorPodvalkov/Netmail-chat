using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EditorRepository : BaseRepository<Editor>, IEditorRepository
    {
        public EditorRepository(NetmailChatDatabaseContext db) : base(db) { }
    }
}
