namespace DAL.Entities
{
    public class ChatRoom : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<ChatMessage>? Messages { get; set; }
    }
}
