namespace StudentManagment.Application.Features.Commands.Lesson;
public class LessonDeleteCommandResponse
{
    public bool IsSuccess { get; set; } = true;
    public string? ErrorMessage { get; set; }
}
