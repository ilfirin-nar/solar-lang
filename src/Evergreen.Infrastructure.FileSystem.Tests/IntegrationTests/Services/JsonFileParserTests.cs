using System;
using System.Collections.Generic;
using System.Linq;
using Evergreen.Infrastructure.FileSystem.Services;
using Evergreen.Infrastructure.FileSystem.Services.Exceptions;
using LightInject.xUnit2;
using Newtonsoft.Json;
using Xunit;

namespace Evergreen.Infrastructure.FileSystem.Tests.IntegrationTests.Services
{
    public sealed class JsonFileParserTests : TextReadersTestsBase
    {
        private readonly Foo _foo = new Foo
        {
            Foo1 = "foo1",
            Foo2 = "foo2",
            Bar = new Bar
            {
                Bar1 = "bar1",
                Bar2 = "bar2"
            },
            Buz = new Buz
            {
                Buz1 = 42,
                Buz2 = 24
            }
        };

        protected override string FileContent => JsonConvert.SerializeObject(_foo);

        [Theory, InjectData]
        internal void ParseNestedObjectFromFile_ValidNestedJson_ValidResult(IJsonFileParser jsonFileParser)
        {
            var result = jsonFileParser.ParseNestedObjectFromFile(TestFilePath, new List<Type> { typeof (Bar), typeof(Buz) });
            Assert.Equal(_foo.Bar, result.Single(o => o is Bar));
            Assert.Equal(_foo.Buz, result.Single(o => o is Buz));
        }

        [Theory, InjectData]
        internal void ParseNestedObjectFromFile_ValidNestedJson_Exception(IJsonFileParser jsonFileParser)
        {
            try
            {
                jsonFileParser.ParseNestedObjectFromFile(TestFilePath, new List<Type> {typeof (Foo)});
                Assert.True(false);
            }
            catch (JsonNotConsistNestedObjectException)
            {
                Assert.True(true);
            }
        }

        private class Foo
        {
            public string Foo1 { get; set; }

            public string Foo2 { get; set; }

            public Bar Bar { get; set; }

            public Buz Buz { get; set; }

            private bool Equals(Foo other)
            {
                return string.Equals(Foo1, other.Foo1) && string.Equals(Foo2, other.Foo2) && Equals(Bar, other.Bar) && Equals(Buz, other.Buz);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((Foo) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = Foo1?.GetHashCode() ?? 0;
                    hashCode = (hashCode*397) ^ (Foo2?.GetHashCode() ?? 0);
                    hashCode = (hashCode*397) ^ (Bar?.GetHashCode() ?? 0);
                    hashCode = (hashCode*397) ^ (Buz?.GetHashCode() ?? 0);
                    return hashCode;
                }
            }
        }

        private class Bar
        {
            public string Bar1 { get; set; }

            public string Bar2 { get; set; }

            private bool Equals(Bar other)
            {
                return string.Equals(Bar1, other.Bar1) && string.Equals(Bar2, other.Bar2);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((Bar) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Bar1?.GetHashCode() ?? 0)*397) ^ (Bar2?.GetHashCode() ?? 0);
                }
            }
        }

        private class Buz
        {
            public int Buz1 { get; set; }

            public int Buz2 { get; set; }

            private bool Equals(Buz other)
            {
                return Buz1 == other.Buz1 && Buz2 == other.Buz2;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((Buz) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Buz1*397) ^ Buz2;
                }
            }
        }
    }
}