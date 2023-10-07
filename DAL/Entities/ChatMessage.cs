namespace DAL.Entities
{
    public class ChatMessage : BaseEntity
    {
        public string Content { get; set; }
        public string? NickName { get; set; }
        public DateTime SendTime { get; set; }
        public Guid ChatRoomID { get; set; }

        public virtual ChatRoom? ChatRoom { get; set; }
    }
}
