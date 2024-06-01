using MediatR;

namespace StudentManagment.Application.Features.Queries.Lesson;
public class GetAllLessonQueryRequest : IRequest<IList<GetAllLessonQueryResponse>>
{
}
