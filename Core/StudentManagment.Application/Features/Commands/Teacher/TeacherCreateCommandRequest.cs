using MediatR;
using StudentManagment.Application.DTOs;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Application.Features.Commands.Teacher;
public class TeacherCreateCommandRequest : IRequest<TeacherCreateCommandResponse>
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? LessonCode { get; set; }
}
