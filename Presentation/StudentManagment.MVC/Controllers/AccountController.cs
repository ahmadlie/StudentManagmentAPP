using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.Features.Commands.Login;

namespace StudentManagment.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
		private readonly IMediator _mediator;

		public AccountController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult>  SignIn()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> SignIn([FromForm] LoginCommandRequest request)
		{
			var response = await _mediator.Send(request);
			if (response.IsSuccess)
			{
				return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
			}
			else
			{
				TempData["ErrorMessage"] = response.ErrorMessage;
				return RedirectToAction(nameof(SignIn));
			}
		}

	}
}
