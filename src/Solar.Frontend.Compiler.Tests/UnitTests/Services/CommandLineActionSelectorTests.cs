using System.Collections.Generic;
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
            container.RegisterInstance(new Mock<ICommandLineAction>().Object);
        }

        [Theory, InjectData]
        internal void Select_ValidResult(ICommandLineActionSelector selector)
        {
            Assert.True(true); // TODO Fix it
        }
    }
}