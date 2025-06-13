using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bigon.WebUI.Models.Entities;

namespace Bigon.WebUI.Models.Persistences.Configurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();

            builder.ConfigureAsAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("Colors");
        }
    }
}
