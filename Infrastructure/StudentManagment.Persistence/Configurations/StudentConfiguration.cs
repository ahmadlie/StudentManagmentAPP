using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Persistence.Configuratios;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {      
        builder.Property(s=>s.Class)
               .HasPrecision(2, 0);

        builder.Property(s => s.FirstName)
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(s => s.LastName)
               .HasMaxLength(30)
               .IsRequired();

        builder.HasMany(s => s.Teachers)
               .WithMany(s=>s.Students);

        builder.HasMany(s => s.Exams)
               .WithMany(s => s.Students);
    }
}
