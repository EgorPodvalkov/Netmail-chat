namespace PL.Models
{
    public class ChatWithMessagesModel
    {
        public string? Name { get; set; }
        public string? Error { get; set; }
        public IEnumerable<MessageModel> Messages { get; set; }
    }
}
