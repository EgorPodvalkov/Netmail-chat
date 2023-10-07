namespace DAL.Entities
{
    public class Editor : BaseEntity
    {
        public string Name { get; set; }
        public string Pass { get; set; }

        public virtual IEnumerable<Article>? Articles { get; set; }
    }
}
