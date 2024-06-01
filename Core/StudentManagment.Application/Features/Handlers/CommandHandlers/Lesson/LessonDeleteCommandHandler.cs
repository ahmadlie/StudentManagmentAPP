using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Exam;
using StudentManagment.Application.Features.Commands.Lesson;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Lesson;
public class LessonDeleteCommandHandler : IRequestHandler<LessonDeleteCommandRequest, LessonDeleteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public LessonDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<LessonDeleteCommandResponse> Handle(LessonDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new LessonDeleteCommandResponse();
        var lesson = await _unitOfWork.GetReadRepository<Domain.Entities.Lesson>().GetAsync(e => e.Code == request.Id);
        lesson.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Domain.Entities.Lesson>().UpdateAsync(lesson);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
            response.ErrorMessage = "Something went Wrong!";
        }
        return response;
    }
}
