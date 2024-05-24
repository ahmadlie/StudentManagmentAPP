using StudentManagment.Domain.Common;

namespace StudentManagment.Domain.Entities;
public class Student : BaseEntity
{
    public decimal Number {  get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Class { get; set; } 
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Exam> Exams { get; set; }
}
