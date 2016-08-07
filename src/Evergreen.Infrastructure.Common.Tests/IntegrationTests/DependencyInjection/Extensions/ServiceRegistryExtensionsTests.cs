using System.Collections.Generic;
using System.Linq;
using Evergreen.Infrastructure.Common.Tests.IntegrationTests.DependencyInjection.Extensions;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

[assembly: RegisterDependencies(typeof(ITestService), Lifetime.PerContainer)]

namespace Evergreen.Infrastructure.Common.Tests.IntegrationTests.DependencyInjection.Extensions
{

    public class ServiceRegistryExtensionsTests
    {
        [Theory, InjectDependency]
        internal void Register_InjectByDirectImplType_ValidType(A service)
        {
            Assert.NotNull(service);
        }

        [Theory, InjectDependency]
        internal void Register_InjectByDirectInterface_ValidType(IC service)
        {
            Assert.True(service is C);
        }

        [Theory, InjectDependency]
        internal void Register_InjectEnumerableServicesByBaseInterface_ValidCount(IEnumerable<ITestService> testServices)
        {
            Assert.Equal(4, testServices.Count());
        }

        [Theory, InjectDependency]
        internal void Register_InjectEnumerableServicesByDirectInterface_ValidCount(IEnumerable<IC> testServices)
        {
            Assert.Equal(1, testServices.Count());
        }
    }

    internal class A : ITestService { }
    internal class B : ITestService { }
    internal class C : IC { }
    internal class D : ID { }
    internal interface IC : ITestService { }
    internal interface ID : ITestService { }
    internal interface ITestService { }
}