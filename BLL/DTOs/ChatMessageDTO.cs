namespace BLL.DTOs
{
    public class ChatMessageDTO : BaseDTO
    {
        public string Content { get; set; }
        public string? NickName { get; set; }
        public DateTime SendTime { get; set; }
        public Guid ChatRoomID { get; set; }

        public ChatRoomDTO? ChatRoom { get; set; }

    }
}
