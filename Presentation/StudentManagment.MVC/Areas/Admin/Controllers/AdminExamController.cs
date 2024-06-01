using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.Features.Commands.Exam;
using StudentManagment.Application.Features.Queries.Exam;
using StudentManagment.Application.Features.Queries.Lesson;

namespace StudentManagment.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminExamController : Controller
    {
        private readonly IMediator _mediator;
        public AdminExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllExamQueryRequest());
            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            var response = await _mediator.Send(new GetAllLessonQueryRequest());
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ExamCreateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess) { return RedirectToAction(nameof(Index)); }
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] ExamDeleteCommandRequest request) 
        {
            var response = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
