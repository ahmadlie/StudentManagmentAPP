using StudentManagment.Domain.Common;

namespace StudentManagment.Domain.Entities;
public class Teacher : BaseEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public ICollection<Student> Students { get; set; }
   
}
