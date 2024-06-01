using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.Features.Commands.Teacher;
using StudentManagment.Application.Features.Queries.Lesson;
using StudentManagment.Application.Features.Queries.Teacher.GetAllTeacher;

namespace StudentManagment.MVC.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class AdminTeacherController : Controller
	{
		private readonly IMediator _mediator;

		public AdminTeacherController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var response = await _mediator.Send(new GetAllTeacherQueryRequest());
			return View(response);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var response = await _mediator.Send(new GetAllLessonQueryRequest());
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] TeacherCreateCommandRequest request) 
		{
			var response = await _mediator.Send(request);
			if (response.IsSuccess) { return RedirectToAction(nameof(Index)); }
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Delete([FromRoute] TeacherDeleteCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));         
        }


    }
}
