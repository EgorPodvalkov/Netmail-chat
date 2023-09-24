namespace BLL.DTOs
{
    public class ChatMessageDTO
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string? NickName { get; set; }
        public DateTime SendTime { get; set; }
        public Guid ChatRoomID { get; set; }

        public ChatRoomDTO? ChatRoom { get; set; }

    }
}
