using StudentManagment.Domain.Common;

namespace StudentManagment.Domain.Entities;
public class Lesson : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Class { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Exam> Exams { get; set; }
}
