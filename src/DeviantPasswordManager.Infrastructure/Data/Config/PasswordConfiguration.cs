using DeviantPasswordManager.Core.PasswordAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviantPasswordManager.Infrastructure.Data.Config;

public class PasswordConfiguration : IEntityTypeConfiguration<Password>
{
  public void Configure(EntityTypeBuilder<Password> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(p => p.Username)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(p => p.EncryptedPassword)
      .IsRequired();

    builder.Property(p => p.Url)
      .IsRequired(false);

    builder.Property(p => p.UserId)
      .IsRequired();

    builder.Property(p => p.ProjectId)
      .IsRequired();

    builder
      .HasOne(p => p.User)
      .WithMany()
      .OnDelete(DeleteBehavior.NoAction);

    builder
      .HasOne(p => p.Project)
      .WithMany()
      .OnDelete(DeleteBehavior.NoAction);
  }
}
