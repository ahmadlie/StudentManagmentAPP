using MediatR;
using Microsoft.AspNetCore.Identity;
using StudentManagment.Application.Features.Commands.Login;
using StudentManagment.Domain.Entities.Identity;

namespace StudentManagment.Application.Features.Handlers.CommandHandlers.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new LoginCommandResponse();

        var resUser = await _userManager.FindByNameAsync(request.Username);
        if (resUser is not null)
        {
            var resSignIn = await _signInManager.PasswordSignInAsync(resUser, request.Password, false, false);
            if (resSignIn.Succeeded)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Incorrect Username or Password!";
            }
        }
        else
        {
            response.IsSuccess = false;
            response.ErrorMessage = "User Not Found!";
        }
        return response;
    }
}
