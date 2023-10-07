using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IEditorService
    {
        Task<EditorDTO?> GetEditorIDByPassAsync(string pass);
    }
}
