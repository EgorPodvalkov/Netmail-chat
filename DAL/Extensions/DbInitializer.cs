using DAL.Context;

namespace DAL.Extensions
{
    public static class DbInitializer
    {
        public static void Initialize(NetmailChatDatabaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
