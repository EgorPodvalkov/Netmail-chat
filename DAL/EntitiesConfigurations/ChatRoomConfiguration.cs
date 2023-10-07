using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(room => room.Messages)
                .WithOne(message => message.ChatRoom)
                .HasForeignKey(message => message.ChatRoomID)
                .HasPrincipalKey(room => room.ID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
