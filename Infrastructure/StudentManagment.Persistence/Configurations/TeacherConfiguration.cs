using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Persistence.Configurations;
public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(t => t.FirstName)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(t => t.LastName)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasOne(t => t.Lesson)
               .WithMany(t => t.Teachers)
               .HasForeignKey(t => t.LessonId);

        builder.HasMany(t => t.Students)
               .WithMany(t => t.Teachers); 
    }
}
