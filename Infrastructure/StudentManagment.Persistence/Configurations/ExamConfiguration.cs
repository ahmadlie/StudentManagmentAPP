using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Persistence.Configurations;
public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasOne(e => e.Lesson)
               .WithMany(e => e.Exams)
               .HasForeignKey(e => e.LessonId);

        builder.HasMany(e => e.Students)
               .WithMany(e => e.Exams);

        builder.Property(e => e.Price)
               .HasPrecision(1, 0);
    }
}
