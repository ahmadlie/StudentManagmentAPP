using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Queries.Teacher.GetAllTeacher;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.QueryHandlers.Teacher;
public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQueryRequest, IList<GetAllTeacherQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllTeacherQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IList<GetAllTeacherQueryResponse>> Handle(GetAllTeacherQueryRequest request, CancellationToken cancellationToken)
    {
        var teachers = await _unitOfWork.GetReadRepository<Domain.Entities.Teacher>().GetAllAsync(t => t.IsDeleted == false);
        foreach (var teacher in teachers)
        {
            if (teacher.LessonId is not null)
            {
                teacher.Lesson = await _unitOfWork.GetReadRepository<Domain.Entities.Lesson>().GetAsync(l => l.Code == teacher.LessonId);
            }
        }
        var response = _mapper.Map<List<GetAllTeacherQueryResponse>>(teachers);
        return response;
    }
}
