using MediatR;

namespace StudentManagment.Application.Features.Commands.Exam;
public class ExamDeleteCommandRequest : IRequest<ExamDeleteCommandResponse>
{
    public int id { get; set; }
}
