using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Lesson;
using StudentManagment.Application.Features.Commands.Student;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Student;
public class StudentDeleteCommandHandler : IRequestHandler<StudentDeleteCommandRequest, StudentDeleteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public StudentDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<StudentDeleteCommandResponse> Handle(StudentDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new StudentDeleteCommandResponse();
        var student = await _unitOfWork.GetReadRepository<Domain.Entities.Student>().GetAsync(s => s.Id == request.Id);
        student.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Domain.Entities.Student>().UpdateAsync(student);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
            response.ErrorMessage = "Something went Wrong!";
        }
        return response;
    }
}
