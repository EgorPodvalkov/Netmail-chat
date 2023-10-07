namespace DAL.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SendTime { get; set; }
        public Guid EditorID { get; set; }

        public virtual Editor? Editor { get; set; }
    }
}
