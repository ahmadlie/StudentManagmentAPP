using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.DTOs;
using StudentManagment.Application.Features.Queries.Exam;
using StudentManagment.Application.Features.Queries.Student;
using StudentManagment.Application.Features.Queries.Teacher.GetAllTeacher;
using StudentManagment.MVC.Areas.Admin.Models;

namespace StudentManagment.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class AdminHomeController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		public AdminHomeController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var teachers = _mapper.Map<List<TeacherDTO>>(await _mediator.Send(new GetAllTeacherQueryRequest()));
			var exams = _mapper.Map<List<ExamDTO>>(await _mediator.Send(new GetAllExamQueryRequest()));
			var students = _mapper.Map<List<StudentDTO>>(await _mediator.Send(new GetAllStudentQueryRequest()));
			var model = new HomePageVM(teachers, exams, students);
			return View(model);
		}
	}
}
