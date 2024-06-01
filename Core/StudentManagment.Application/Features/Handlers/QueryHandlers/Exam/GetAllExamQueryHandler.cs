using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Queries.Exam;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.QueryHandlers.Exam;
public class GetAllExamQueryHandler : IRequestHandler<GetAllExamQueryRequest, IList<GetAllExamQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllExamQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IList<GetAllExamQueryResponse>> Handle(GetAllExamQueryRequest request, CancellationToken cancellationToken)
    {
        var exams = await _unitOfWork.GetReadRepository<Domain.Entities.Exam>().GetAllAsync(e => e.IsDeleted == false);
        foreach (var exam in exams)
        {
            if (exam.LessonId is not null)
            {
                var lesson = await _unitOfWork.GetReadRepository<Domain.Entities.Lesson>().GetAsync(l => l.Code == exam.LessonId);
                exam.Lesson = lesson;
            }
        }
        var response = _mapper.Map<IList<GetAllExamQueryResponse>>(exams);
        return response;
    }
}
