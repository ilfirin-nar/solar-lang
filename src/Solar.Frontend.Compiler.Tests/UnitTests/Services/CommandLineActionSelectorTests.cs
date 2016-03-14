using System;
using System.Collections.Generic;
using LightInject;
using LightInject.Mocking;
using LightInject.xUnit2;
using Moq;
using Solar.Frontend.Compiler.Services;
using Solar.Frontend.Compiler.Services.Actions;
using Xunit;

namespace Solar.Frontend.Compiler.Tests.UnitTests.Services
{
    public class CommandLineActionSelectorTests //: IDisposable
    {
        //private static IServiceContainer _container;

        //public CommandLineActionSelectorTests()
        //{
        //    var commandLineActionMock = new Mock<ICommandLineAction>();
        //    _container.StartMocking(() => commandLineActionMock.Object);
        //}

        public static void Configure(IServiceContainer container)
        {
            //_container = container;
            var commandLineActionMock = new Mock<IReadOnlyList<ICommandLineAction>>();
            container.StartMocking(() => commandLineActionMock.Object);
        }

        //public void Dispose()
        //{
        //    _container.EndMocking<ICommandLineAction>();
        //}

        [Theory, InjectData]
        internal void Select_ValidResult(ICommandLineActionSelector selector)
        {
            Assert.True(false);
        }
    }
}