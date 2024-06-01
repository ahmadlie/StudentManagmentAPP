using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Exam;
using StudentManagment.Application.Features.Commands.Lesson;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Exam;
public class ExamCreateCommandHandler : IRequestHandler<ExamCreateCommandRequest, ExamCreateCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ExamCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ExamCreateCommandResponse> Handle(ExamCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new ExamCreateCommandResponse();
        var exam = _mapper.Map<Domain.Entities.Exam>(request);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Exam>().AddAsync(exam);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
            response.ErrorMessage = "Something went Wrong!";
        }
        return response;
    }
}
