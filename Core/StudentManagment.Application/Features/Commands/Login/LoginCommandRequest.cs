﻿using MediatR;

namespace StudentManagment.Application.Features.Commands.Login;
public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Username { get; set; }
    public string Password {  get; set; } 
}
