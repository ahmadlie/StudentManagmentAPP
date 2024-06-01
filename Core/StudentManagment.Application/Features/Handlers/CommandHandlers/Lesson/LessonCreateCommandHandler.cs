using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Lesson;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Lesson;
public class LessonCreateCommandHandler : IRequestHandler<LessonCreateCommandRequest, LessonCreateCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public LessonCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<LessonCreateCommandResponse> Handle(LessonCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new LessonCreateCommandResponse();
        var lesson = _mapper.Map<Domain.Entities.Lesson>(request);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Lesson>().AddAsync(lesson);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
            response.ErrorMessage = "Something went Wrong!";
        }
        return response;
    }
}
