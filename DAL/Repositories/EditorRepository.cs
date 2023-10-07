using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EditorRepository : BaseRepository<Editor>, IEditorRepository
    {
        public EditorRepository(NetmailChatDatabaseContext db) : base(db) { }

        public async Task<Guid?> GetEditorIDByPassAsync(string pass)
        {
            return (await _db.Set<Editor>().FirstOrDefaultAsync(x => x.Pass == pass))?.ID;
        }
    }
}
