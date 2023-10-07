using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEditorRepository : IBaseRepository<Editor>
    {
        Task<Guid?> GetEditorIDByPassAsync(string pass);
    }
}
