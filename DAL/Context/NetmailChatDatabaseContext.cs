using DAL.Entities;
using DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class NetmailChatDatabaseContext : DbContext
    {
        public NetmailChatDatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
            modelBuilder.ApplyConfiguration(new ChatRoomConfiguration());
            modelBuilder.ApplyConfiguration(new EditorConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
