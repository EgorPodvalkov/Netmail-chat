namespace PL.Models
{
    public class ArticlesModel
    {
        public int ArticlesAmount { get; set; }
        public int TotalArticlesAmount { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
    }

    public class ArticleModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SendTime { get; set; }
        public string EditorName { get; set; }
    }
}
