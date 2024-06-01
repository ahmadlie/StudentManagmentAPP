using MediatR;

namespace StudentManagment.Application.Features.Commands.Lesson;
public class LessonCreateCommandRequest : IRequest<LessonCreateCommandResponse>
{
    public string Name { get; set; } = null!;
    public string Class { get; set; } = null!;
}
