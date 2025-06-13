﻿using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace AraviPortal.Backend.UnitsOfWork.Interfaces;

public interface IUsersUnitOfWork
{
    Task<User> GetUserAsync(string email);

    Task<IdentityResult> AddUserAsync(User user, string password);

    Task CheckRoleAsync(string roleName);

    Task AddUserToRoleAsync(User user, string roleName);

    Task<bool> IsUserInRoleAsync(User user, string roleName);

    Task<SignInResult> LoginAsync(LoginDTO model);

    Task LogoutAsync();
}