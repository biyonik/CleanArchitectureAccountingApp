﻿using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.AppEntities;

public sealed class Company: Entity
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? IdentityNumber { get; set; }
    public string? TaxDepartment { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string PortNumber { get; set; }
    public string ServerUserId { get; set; }
    public string ServerPassword { get; set; }
}