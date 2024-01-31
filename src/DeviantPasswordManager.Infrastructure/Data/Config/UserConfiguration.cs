using DeviantPasswordManager.Core.IdentityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviantPasswordManager.Infrastructure.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.Property(p => p.UserId)
      .HasMaxLength(256)
      .IsRequired();

    builder.Property(p => p.Email)
      .HasMaxLength(50)
      .IsRequired();
    
    builder.Property(p => p.PassPhrase)
      .HasMaxLength(256)
      .IsRequired();
  }
}
