using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ExampleApp.Shared;
using ExampleApp.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ExampleApp.Client.Data
{
    public class AuthenticationUserService : IAuthenticateUserService
    {
        private readonly IHttpService _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;
        private const string ROUTE = "/api/authenticate/";
        private string _userKey = "user";

        public AuthenticationUserService(IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpClient = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<AuthUser> Login(LoginModel model)
        {
            var tokenResponse = await _httpClient.Post<AuthUser>($"{ROUTE}login", model);
            await _localStorageService.SetItem(_userKey, tokenResponse);
            return tokenResponse;
        }

        public async Task<Response> Register(RegisterModel model)
        {
            var response = await _httpClient.Post<Response>($"{ROUTE}register", model);            
            return response;
        }

    }
}