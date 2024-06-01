using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using StudentManagment.Application.Features.Commands.Student;
using StudentManagment.Application.Interfaces.UnitOfWorks;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Student;
public class StudentCreateCommandHandler : IRequestHandler<StudentCreateCommandRequest, StudentCreateCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public StudentCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StudentCreateCommandResponse> Handle(StudentCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new StudentCreateCommandResponse();
        var student = _mapper.Map<Domain.Entities.Student>(request);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Student>().AddAsync(student);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
        }
        var teacherIds = JsonConvert.DeserializeObject<string[]>(request.SelectedTeacherIds!);
        student.Teachers = new List<Domain.Entities.Teacher>();
        foreach (var teacherId in teacherIds!)
        {
            student.Teachers.Add(await _unitOfWork.GetReadRepository<Domain.Entities.Teacher>().GetAsync(t => t.Id == Convert.ToInt32(teacherId)));
        }
        await _unitOfWork.GetWriteRepository<Domain.Entities.Student>().UpdateAsync(student);
        if (await _unitOfWork.SaveChangesAsync() < 1)
        {
            response.IsSuccess = false;
        }
        return response;
    }
}
