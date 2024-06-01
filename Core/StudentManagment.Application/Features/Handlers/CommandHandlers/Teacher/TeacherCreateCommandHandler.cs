using AutoMapper;
using MediatR;
using StudentManagment.Application.Features.Commands.Teacher;
using StudentManagment.Application.Interfaces.UnitOfWorks;
using StudentManagment.Domain.Entities;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Teacher;
public class TeacherCreateCommandHandler : IRequestHandler<TeacherCreateCommandRequest, TeacherCreateCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	public TeacherCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
	public async Task<TeacherCreateCommandResponse> Handle(TeacherCreateCommandRequest request, CancellationToken cancellationToken)
	{
		var lesson = await _unitOfWork.GetReadRepository<Domain.Entities.Lesson>().GetAsync(l => l.Code == request.LessonCode);
		var response = new TeacherCreateCommandResponse();
		var teacher = _mapper.Map<Domain.Entities.Teacher>(request);
		teacher.LessonId = lesson.Code;
		await _unitOfWork.GetWriteRepository<Domain.Entities.Teacher>().AddAsync(teacher);
		if (await _unitOfWork.SaveChangesAsync() < 1)
		{
			response.IsSuccess = false;
			response.ErrorMessage = "Something went wrong!";
		}
		return response;
	}
}
