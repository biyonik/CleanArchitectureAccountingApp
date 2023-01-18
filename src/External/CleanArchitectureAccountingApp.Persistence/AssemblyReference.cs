using System.Reflection;

namespace CleanArchitectureAccountingApp.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}