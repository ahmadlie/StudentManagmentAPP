using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Exam;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Exam;
public class ExamDeleteCommandHandler : IRequestHandler<ExamDeleteCommandRequest, ExamDeleteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ExamDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ExamDeleteCommandResponse> Handle(ExamDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new ExamDeleteCommandResponse();
        var exam = await _unitOfWork.GetReadRepository<Domain.Entities.Exam>().GetAsync(e => e.Id == request.id);
        exam.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Domain.Entities.Exam>().UpdateAsync(exam);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
            response.ErrorMessage = "Something went Wrong!";
        }
        return response;
    }
}
