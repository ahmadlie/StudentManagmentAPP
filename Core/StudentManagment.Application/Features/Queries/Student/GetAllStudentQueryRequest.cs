using MediatR;

namespace StudentManagment.Application.Features.Queries.Student;
public class GetAllStudentQueryRequest : IRequest<IList<GetAllStudentQueryResponse>>
{
}
