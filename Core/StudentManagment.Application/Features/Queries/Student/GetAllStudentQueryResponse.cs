using StudentManagment.Application.DTOs;

namespace StudentManagment.Application.Features.Queries.Student;
public class GetAllStudentQueryResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Class { get; set; }
    public bool isDeleted { get; set; }
    public ICollection<TeacherDTO>? Teachers { get; set; }  
    public ICollection<ExamDTO>? Exams { get; set; }  
}
