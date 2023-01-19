using System.Reflection;

namespace CleanArchitectureAccountingApp.Application;

public static class AssemblyReference
{
    public static readonly Assembly AssemblyHandler = typeof(Assembly).Assembly;
}