using DeviantPasswordManager.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviantPasswordManager.Infrastructure.Data.Config;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(p => p.AdminId)
      .IsRequired();

    builder.Property(p => p.ParentId)
      .IsRequired(false);

    builder
      .HasOne(p => p.Admin)
      .WithMany()
      .OnDelete(DeleteBehavior.Cascade);
  }
}
