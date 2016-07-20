using System.Collections.Generic;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Common.Services;
using LightInject.xUnit2;
using Xunit;

namespace Evergreen.Infrastructure.Common.Tests.UnitTests.Services
{
    public class MapperTests
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
        public static void Map_DtoToWiderDto_ValidResult(IMapper<Foo, Bar> mapper)
        {
            var foo = new Foo()
            {
                A = "test",
                B = new List<string> { "a", "b", "c" },
                C = 42,
                D = true
            };
            var bar = mapper.Map(foo);
            Assert.Equal(foo.A, bar.A);
            Assert.Equal(foo.B, bar.B);
            Assert.Equal(foo.C, bar.C);
            Assert.Equal(foo.D, bar.D);
        }

        [Theory, InjectData]
        public static void Map_WiderDtoToDto_ValidResult(IMapper<Bar, Foo> mapper)
        {
            var bar = new Bar()
            {
                A = "test",
                B = new List<string> { "a", "b", "c" },
                C = 42,
                D = true
            };
            var foo = mapper.Map(bar);
            Assert.Equal(bar.A, foo.A);
            Assert.Equal(bar.B, foo.B);
            Assert.Equal(bar.C, foo.C);
            Assert.Equal(bar.D, foo.D);
            Assert.Null(bar.E);
        }
    }
}