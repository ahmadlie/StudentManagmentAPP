namespace StudentManagment.Application.DTOs;
public class LessonDTO
{
	public string Code { get; set; } = null!;
	public string Name { get; set; } = null!;
	public bool isDeleted { get; set; }
}
