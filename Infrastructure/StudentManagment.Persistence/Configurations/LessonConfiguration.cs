using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Persistence.Configurations;
public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Code);
        builder.Property(l => l.Code)
               .HasMaxLength(3);

        builder.Property(l => l.Name)
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(l => l.Class)
              .HasPrecision(2, 0);

        builder.HasMany(l => l.Teachers)
               .WithOne(l => l.Lesson)
               .HasForeignKey(l => l.LessonId);

        builder.HasMany(l => l.Exams)
               .WithOne(l => l.Lesson)
               .HasForeignKey(l => l.LessonId);
    }
}
