namespace BLL.DTOs
{
    public class EditorDTO : BaseDTO
    {
        public string Name { get; set; }
        public IEnumerable<ArticleDTO>? Articles { get; set; }
    }
}
