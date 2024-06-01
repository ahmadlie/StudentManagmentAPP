using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.Features.Commands.Login;
using StudentManagment.Domain.Entities.Identity;

namespace StudentManagment.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMediator _mediator;
        public AdminAccountController(SignInManager<AppUser> signInManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn","Account", new { area = "" });
        }
    }
}
