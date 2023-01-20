﻿using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

public sealed class AppUser: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpires { get; set; }
}