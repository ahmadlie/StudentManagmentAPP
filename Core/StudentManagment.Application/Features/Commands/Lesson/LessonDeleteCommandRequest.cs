using MediatR;

namespace StudentManagment.Application.Features.Commands.Lesson;
public class LessonDeleteCommandRequest : IRequest<LessonDeleteCommandResponse>
{
    public string? Id { get; set; }
}
