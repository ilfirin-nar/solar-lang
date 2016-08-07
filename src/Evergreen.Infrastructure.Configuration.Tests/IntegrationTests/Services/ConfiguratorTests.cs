﻿using System.Collections.Generic;
using System.Linq;
using Evergreen.Infrastructure.Configuration.GlobalStateObject;
using Evergreen.Infrastructure.Configuration.Services;
using Newtonsoft.Json;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Infrastructure.Configuration.Tests.IntegrationTests.Services
{
    public class ConfiguratorTests
    {
        [Theory, InjectDependency]
        internal void Configure_ValidConfig_ValidResult(IConfigurator configurator, IFooConfig config)
        {
            var fooConfig = new FooConfig { Bar = "test " };
            var configString = $"{{ \"FooConfig\" : { JsonConvert.SerializeObject(fooConfig) } }}";

            configurator.Configure(configString);

            Assert.Equal(fooConfig, config);
        }

        [Theory, InjectDependency]
        internal void Configure_ValidIEnumerableConfig_ValidResult(IConfigurator configurator, IEnumerable<IConfigSection> configs)
        {
            var fooConfig = new FooConfig { Bar = "test " };
            var configString = $"{{ \"FooConfig\" : { JsonConvert.SerializeObject(fooConfig) } }}";

            configurator.Configure(configString);

            Assert.Equal(1, configs.Count());
        }

        public class FooConfig : IFooConfig
        {
            public string Bar { get; set; }

            protected bool Equals(FooConfig other)
            {
                return string.Equals(Bar, other.Bar);
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

        public interface IFooConfig : IConfigSection
        {
            string Bar { get; }
        }
    }
}