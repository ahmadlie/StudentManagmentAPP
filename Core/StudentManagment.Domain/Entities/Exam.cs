using StudentManagment.Domain.Common;

namespace StudentManagment.Domain.Entities;
public class Exam : BaseEntity  
{
    public int Id { get; set; }
    public string LessonId {  get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public Lesson Lesson { get; set; }
    public ICollection<Student> Students { get; set; } 

}
