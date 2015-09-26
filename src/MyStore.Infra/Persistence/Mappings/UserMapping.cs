using MyStore.Domain.Account.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyStore.Infra.Persistence.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Email).IsRequired().HasMaxLength(160);
            Property(x => x.Username).IsRequired().HasMaxLength(20);
            Property(x => x.Password).IsRequired().HasMaxLength(36).IsFixedLength();
            Property(x => x.Verified);
            Property(x => x.Active);
            Property(x => x.LastLoginDate);
            Property(x => x.Role);
            Property(x => x.ActivationCode).HasMaxLength(4).IsFixedLength().IsRequired();
            Property(x => x.VerificationCode).HasMaxLength(6).IsFixedLength().IsRequired();
            Property(x => x.AuthorizationCode).HasMaxLength(4).IsFixedLength().IsRequired();
            Property(x => x.LastAuthorizationCodeRequest);
        }
    }
}
