using System.Reflection;

namespace eShopCln.API;

public static class AssemblyReference
{
    public static readonly Assembly Instance = typeof(AssemblyReference).Assembly;
}
