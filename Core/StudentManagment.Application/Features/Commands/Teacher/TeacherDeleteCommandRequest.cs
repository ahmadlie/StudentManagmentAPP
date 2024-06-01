using MediatR;

namespace StudentManagment.Application.Features.Commands.Teacher;
public class TeacherDeleteCommandRequest : IRequest<TeacherDeleteCommandResponse>
{
    public int Id { get; set; }
}
