using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BerrasBiograf
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "VISITOR",
                NormalizedName = "VISITOR"
            },
            new IdentityRole
            {
                Name = "USER",
                NormalizedName = "USER"
            });
        }
    }
}
