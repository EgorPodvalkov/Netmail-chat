namespace BLL.DTOs
{
    public class ChatRoomDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<ChatMessageDTO>? Messages { get; set; }
    }
}
