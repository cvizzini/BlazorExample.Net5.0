﻿using ExampleApp.Shared.Models;
using System.Threading.Tasks;

namespace ExampleApp.Shared
{
    public interface IAuthenticateUserService
    {
        Task<AuthUser> Login(LoginModel model);
        Task<Response> Register(RegisterModel model);
    }
}