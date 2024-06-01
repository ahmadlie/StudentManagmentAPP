using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Queries.Student;
using StudentManagment.Application.Interfaces.Repositories.Student;

namespace StudentManagment.Application.Features.Handlers.QueryHandlers.Student;
public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQueryRequest, IList<GetAllStudentQueryResponse>>
{
    private readonly IStudentReadRepository _studentReadRepository;
    private readonly IMapper _mapper;
    public GetAllStudentQueryHandler(IMapper mapper, IStudentReadRepository studentReadRepository)
    {
        _mapper = mapper;
        _studentReadRepository = studentReadRepository;
    }
    public async Task<IList<GetAllStudentQueryResponse>> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
    {
        var students = await _studentReadRepository.GetAllAsync(s => s.IsDeleted == false);
        return _mapper.Map<IList<GetAllStudentQueryResponse>>(students);
    }
}
