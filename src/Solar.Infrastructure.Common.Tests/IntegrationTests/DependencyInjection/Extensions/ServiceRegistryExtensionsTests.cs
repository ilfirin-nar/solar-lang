using System.Collections.Generic;
using System.Linq;
using LightInject;
using LightInject.xUnit2;
using Solar.Infrastructure.Common.DependencyInjection.Extensions;
using Solar.Infrastructure.Common.DependencyInjection.Registration;
using Xunit;

namespace Solar.Infrastructure.Common.Tests.IntegrationTests.DependencyInjection.Extensions
{
    public class ServiceRegistryExtensionsTests
    {
        internal static void Configure(IServiceContainer container)
        {
            container.Register<ITestService>(typeof (ITestService).Assembly, LifeTimeFactory.PerContainer);
        }

        [Theory, InjectData]
        internal void Register_InjectByDirectImplType_ValidType(A service)
        {
            Assert.NotNull(service);
        }

        [Theory, InjectData]
        internal void Register_InjectByDirectInterface_ValidType(IC service)
        {
            Assert.True(service is C);
        }

        [Theory, InjectData]
        internal void Register_InjectEnumerableServicesByBaseInterface_ValidCount(IEnumerable<ITestService> testServices)
        {
            Assert.Equal(4, testServices.Count());
        }

        [Theory, InjectData]
        internal void Register_InjectEnumerableServicesByDirectInterface_ValidCount(IEnumerable<IC> testServices)
        {
            Assert.Equal(1, testServices.Count());
        }

        internal class A : ITestService {}
        internal class B : ITestService {}
        internal  class C : IC {}
        internal  class D : ID { }
        internal  interface IC : ITestService { }
        internal interface ID : ITestService { }
        internal interface ITestService {}
    }
}