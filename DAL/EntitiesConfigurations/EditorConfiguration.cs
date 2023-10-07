using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class EditorConfiguration : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Pass)
                .IsUnique();

            builder.Property(x => x.Pass)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(edt => edt.Articles)
                .WithOne(art => art.Editor)
                .HasForeignKey(art => art.EditorID)
                .HasPrincipalKey(edt => edt.ID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
