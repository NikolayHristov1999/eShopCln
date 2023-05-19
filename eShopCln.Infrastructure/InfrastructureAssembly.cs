using System.Reflection;

namespace eShopCln.Infrastructure;

public static class InfrastructureAssembly
{
    public static readonly Assembly Instance = typeof(InfrastructureAssembly).Assembly;
}