﻿using AraratBankRatesTest.Models;

namespace AraratBankRatesTest.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginDTO model);
        Task Logout();
    }
}