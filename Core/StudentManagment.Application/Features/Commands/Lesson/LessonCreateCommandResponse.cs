namespace StudentManagment.Application.Features.Commands.Lesson;
public class LessonCreateCommandResponse
{
    public bool IsSuccess { get; set; } = true;
    public string? ErrorMessage { get; set; }
}
