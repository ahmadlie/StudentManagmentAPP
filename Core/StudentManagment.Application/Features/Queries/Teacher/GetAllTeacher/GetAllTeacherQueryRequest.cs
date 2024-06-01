using MediatR;

namespace StudentManagment.Application.Features.Queries.Teacher.GetAllTeacher;
public class GetAllTeacherQueryRequest : IRequest<IList<GetAllTeacherQueryResponse>>
{
}
