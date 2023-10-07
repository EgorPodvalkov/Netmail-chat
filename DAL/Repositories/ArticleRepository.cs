using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(NetmailChatDatabaseContext db) : base(db) { }

        public async Task<IEnumerable<Article>> GetArticlesWithEditorsAsync(int skip = 0, int? take = null)
        {
            var articles = _db.Set<Article>()
                .Include(x => x.Editor)
                .OrderByDescending(x => x.SendTime)
                .Skip(skip);

            if (take is not null)
                articles = articles.Take(take.Value);

            return await articles.ToListAsync();
        }

        public async Task<int> GetArticlesAmountAsync()
        {
            return await _db.Set<Article>().CountAsync();
        }
    }
}
