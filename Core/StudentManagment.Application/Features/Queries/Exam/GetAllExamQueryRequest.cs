using MediatR;

namespace StudentManagment.Application.Features.Queries.Exam;
public class GetAllExamQueryRequest : IRequest<IList<GetAllExamQueryResponse>>
{
}
