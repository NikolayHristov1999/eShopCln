﻿using System.Reflection;

namespace eShopCln.Domain;

public static class DomainAssembly
{
    public static readonly Assembly Instance = typeof(DomainAssembly).Assembly;
}