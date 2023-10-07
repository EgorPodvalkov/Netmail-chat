using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.NickName)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.SendTime)
                .IsRequired();
        }
    }
}
