using System.Reflection;

namespace CleanArchitectureAccountingApp.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly AssemblyHandler = typeof(Assembly).Assembly;
}