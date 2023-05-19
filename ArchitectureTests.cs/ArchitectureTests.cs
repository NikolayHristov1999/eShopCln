using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "eShopCln.Domain";
    private const string ApplicationNamespace = "eShopCln.Application";
    private const string InfrastructureNamespace = "eShopCln.Infrastructure";
    private const string ApiNamespace = "eShopCln.Api";

    [Fact]
    public void Domain_Should_Not_HaveDepencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(eShopCln.Domain.DomainAssembly).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDepencyOnOtherProjectsExceptDomain()
    {
        // Arrange
        var assembly = typeof(eShopCln.Application.ApplicationAssembly).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastrcture_Should_Not_HaveDepencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(eShopCln.Infrastructure.InfrastructureAssembly).Assembly;

        var otherProjects = new[]
        {
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}