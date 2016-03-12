using LightInject;
using LightInject.xUnit2;
using Newtonsoft.Json;
using Solar.Infrastructure.Common.DependencyInjection.Extensions;
using Solar.Infrastructure.Common.DependencyInjection.Registration;
using Solar.Infrastructure.Config.GlobalStateObject;
using Solar.Infrastructure.Config.Services;
using Xunit;

namespace Solar.Infrastructure.Config.Tests.IntegrationTests.Services
{
    public class ConfiguratorTests
    {
        public static void Configure(IServiceContainer container)
        {
            var type = typeof (ConfiguratorTests).Assembly;
            container.Register<IConfigSection>(type, LifeTimeFactory.PerContainer);
        }

        [Theory, InjectData]
        internal void Configure_ValidConfig_ValidResult(IConfigurator configurator, FooConfig config)
        {
            var fooConfig = new FooConfig { Bar = "test " };
            var configString = $"{{ \"FooConfig\" : {JsonConvert.SerializeObject(fooConfig)} }}";

            configurator.Configure(configString);

            Assert.Equal(fooConfig, config);
        }

        internal class FooConfig : IConfigSection
        {
            public string Bar { get; set; }

            protected bool Equals(FooConfig other)
            {
                return string.Equals(Bar, (string) other.Bar);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((FooConfig) obj);
            }

            public override int GetHashCode()
            {
                return Bar?.GetHashCode() ?? 0;
            }
        }
    }
}