namespace StudentManagment.Application.DTOs;
public class StudentDTO
{
	public int Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public decimal Class { get; set; }
	public bool isDeleted { get; set; }
}
