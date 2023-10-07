using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEditorRepository : IBaseRepository<Editor>
    {
        Task<Editor?> GetEditorIDByPassAsync(string pass);
    }
}
