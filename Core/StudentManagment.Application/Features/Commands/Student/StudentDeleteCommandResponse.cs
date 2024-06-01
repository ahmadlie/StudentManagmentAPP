namespace StudentManagment.Application.Features.Commands.Student;
public class StudentDeleteCommandResponse
{
    public bool IsSuccess { get; set; } = true;
    public string? ErrorMessage { get; set; }
}
