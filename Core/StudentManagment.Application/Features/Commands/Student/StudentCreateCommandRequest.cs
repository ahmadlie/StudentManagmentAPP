using MediatR;
using StudentManagment.Application.DTOs;

namespace StudentManagment.Application.Features.Commands.Student;

public class StudentCreateCommandRequest : IRequest<StudentCreateCommandResponse>
{
	public decimal Number { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public decimal Class { get; set; }
	public string? SelectedTeacherIds { get; set; } 
}
