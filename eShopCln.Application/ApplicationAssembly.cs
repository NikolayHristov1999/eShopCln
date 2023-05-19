using System.Reflection;

namespace eShopCln.Application;

public static class ApplicationAssembly
{
    public static readonly Assembly Instance = typeof(ApplicationAssembly).Assembly;
}