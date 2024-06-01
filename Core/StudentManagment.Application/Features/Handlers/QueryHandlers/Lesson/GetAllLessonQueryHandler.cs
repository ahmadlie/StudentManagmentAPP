using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Queries.Lesson;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.QueryHandlers.Lesson;
public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonQueryRequest, IList<GetAllLessonQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllLessonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IList<GetAllLessonQueryResponse>> Handle(GetAllLessonQueryRequest request, CancellationToken cancellationToken)
    {
        var lessons = await _unitOfWork.GetReadRepository<Domain.Entities.Lesson>().GetAllAsync(l => l.IsDeleted == false);
        var response = _mapper.Map<IList<GetAllLessonQueryResponse>>(lessons);
        return response;
    }
}
