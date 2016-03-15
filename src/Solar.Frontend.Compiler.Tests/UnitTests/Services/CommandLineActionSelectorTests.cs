using DryIoc;
using Xunit;

namespace Solar.Frontend.Compiler.Tests.UnitTests.Services
{
    public class CommandLineActionSelectorTests
    {

        //public static void Configure(IServiceContainer container)
        //{
        //    //container.RegisterInstance(new Mock<ICommandLineAction>().Object);
        //}

        //[Theory, InjectData]
        //internal void Select_ValidResult(ICommandLineActionSelector selector)
        //{
        //    Assert.True(true); // TODO Fix it
        //}
        [Fact]
        internal void Select_ValidResult()
        {
            var container = new Container();
            container.RegisterMany(new[] { GetType().Assembly }, type => type == typeof(IService));
            var foo = container.Resolve<IFoo>();
            Assert.NotNull(foo);
        }

        internal interface IService { }
        internal interface IFoo : IService { }
        internal class Foo : IFoo {}
        internal interface IBar : IService { }
        internal class Bar : IBar { }
    }
}