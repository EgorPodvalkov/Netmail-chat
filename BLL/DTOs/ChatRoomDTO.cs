namespace BLL.DTOs
{
    public class ChatRoomDTO : BaseDTO
    {
        public string Name { get; set; }

        public IEnumerable<ChatMessageDTO>? Messages { get; set; }
    }
}
