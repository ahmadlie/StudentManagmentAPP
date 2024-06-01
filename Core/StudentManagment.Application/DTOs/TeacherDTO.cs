namespace StudentManagment.Application.DTOs;
public class TeacherDTO
{
	public int Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public bool isDeleted { get; set; }
}
