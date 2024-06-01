using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Student;
using StudentManagment.Application.Features.Commands.Teacher;
using StudentManagment.Application.Interfaces.UnitOfWorks;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Teacher;
public class TeacherDeleteCommandHandler : IRequestHandler<TeacherDeleteCommandRequest, TeacherDeleteCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TeacherDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<TeacherDeleteCommandResponse> Handle(TeacherDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new TeacherDeleteCommandResponse();
        var teacher = await _unitOfWork.GetReadRepository<Domain.Entities.Teacher>().GetAsync(t => t.Id == request.Id);
        teacher.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Domain.Entities.Teacher>().UpdateAsync(teacher);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
            response.ErrorMessage = "Something went Wrong!";
        }
        return response;
    }
}
