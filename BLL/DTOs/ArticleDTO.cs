namespace BLL.DTOs
{
    public class ArticleDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SendTime { get; set; }
        public Guid EditorID { get; set; }
        public EditorDTO? Editor { get; set; }
    }
}
