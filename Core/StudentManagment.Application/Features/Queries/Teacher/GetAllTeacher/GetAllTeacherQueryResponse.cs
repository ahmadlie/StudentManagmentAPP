using StudentManagment.Application.DTOs;

namespace StudentManagment.Application.Features.Queries.Teacher.GetAllTeacher;
public class GetAllTeacherQueryResponse
{
	public int Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public bool isDeleted { get; set; }
	public LessonDTO Lesson { get; set; }
}
