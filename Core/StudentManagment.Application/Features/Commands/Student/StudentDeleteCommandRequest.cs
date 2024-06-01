using MediatR;

namespace StudentManagment.Application.Features.Commands.Student;
public class StudentDeleteCommandRequest  :IRequest<StudentDeleteCommandResponse>
{
    public int Id { get; set; }
}
