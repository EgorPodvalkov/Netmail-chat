namespace BLL.Interfaces
{
    public interface IEditorService
    {
        Task<Guid?> GetEditorIDByPassAsync(string pass);
    }
}
