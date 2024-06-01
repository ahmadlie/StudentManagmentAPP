using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagment.MVC.Controllers
{
    [Authorize]
    public class ErrorsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
