using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<IEnumerable<Article>> GetArticlesWithEditorsAsync(int skip = 0, int? take = null);
    }
}
