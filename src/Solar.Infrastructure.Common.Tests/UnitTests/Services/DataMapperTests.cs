using System.Collections.Generic;
using LightInject.xUnit2;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Common.Services;
using Xunit;

namespace Solar.Infrastructure.Common.Tests.UnitTests.Services
{
    internal class DataMapperTests
    {
        public class Foo : IDataTransferObject
        {
            public string A { get; set; }

            public IList<string> B { get; set; }

            public int C { get; set; }

            public bool D { get; set; }
        }

        public class Bar : IDataTransferObject
        {
            public string A { get; set; }

            public IList<string> B { get; set; }

            public int C { get; set; }

            public bool D { get; set; }

            public string E { get; set; }
        }

        [Theory, InjectData]
        public static void Map_ValidDtoToValidDto_ValidResult(IDataMapper<Foo, Bar> mapper)
        {
            var foo = new Foo()
            {
                A = "test",
                B = new List<string> { "a", "b", "c" },
                C = 42,
                D = true
            };
            var result = mapper.Map(foo);
            Assert.Equal(foo.A, result.A);
            Assert.Equal(foo.B, result.B);
            Assert.Equal(foo.C, result.C);
            Assert.Equal(foo.D, result.D);
            Assert.Null(result.E);
        }
    }
}