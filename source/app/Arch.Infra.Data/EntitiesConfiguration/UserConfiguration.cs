using Arch.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Arch.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(o => o.Id);

            Property(o => o.Name)
               .IsRequired()
               .HasMaxLength(100);

            Property(o => o.LastName)
                .IsOptional()
                .HasMaxLength(100);

            Property(o => o.BirthDate)
                .IsRequired();

            Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(50);

            Property(o => o.Active)
                .IsRequired();
        }
    }
}