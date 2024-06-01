using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.Features.Commands.Lesson;
using StudentManagment.Application.Features.Queries.Lesson;

namespace StudentManagment.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminLessonController : Controller
    {
        private readonly IMediator _mediator;

        public AdminLessonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllLessonQueryRequest());
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LessonCreateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess) { return RedirectToAction(nameof(Index)); }
            else { return View(); }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] LessonDeleteCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

    }
}
