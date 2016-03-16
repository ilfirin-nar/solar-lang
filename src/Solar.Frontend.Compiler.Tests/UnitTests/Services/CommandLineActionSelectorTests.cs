using LightInject;
using LightInject.xUnit2;
using Moq;
using Solar.Frontend.Compiler.Services;
using Solar.Frontend.Compiler.Services.Actions;
using Xunit;

namespace Solar.Frontend.Compiler.Tests.UnitTests.Services
{
    public class CommandLineActionSelectorTests
    {
        public static void Configure(IServiceContainer container)
        {
            var mock = new Mock<ICommandLineAction>();
            container.RegisterInstance(mock.Object);
            //container.Override(r => r.ServiceType == typeof(IFoo),
            //    (f, r) => new ServiceRegistration()
            //    {
            //        ServiceType = typeof(IFoo),
            //        ImplementingType = typeof(NewFoo),
            //        Lifetime = null,
            //        ServiceName = ""
            //    });
        }

        [Theory, InjectData]
        internal void Select_ValidResult(ICommandLineActionSelector selector)
        {
            
        }
    }
}