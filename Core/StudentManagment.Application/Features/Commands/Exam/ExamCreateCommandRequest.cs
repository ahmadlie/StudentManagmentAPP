using MediatR;

namespace StudentManagment.Application.Features.Commands.Exam;
public class ExamCreateCommandRequest : IRequest<ExamCreateCommandResponse>
{
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public string LessonId { get; set; } = null!; 
}
