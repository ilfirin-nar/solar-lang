using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evergreen.Domain.Grammar.Lexis.Directories;
using Evergreen.Infrastructure.Common.Extensions;
using LightInject.xUnit2;
using Xunit;
using Xunit.Abstractions;

namespace Evergreen.Domain.Grammar.Tests.Lexical.TokenTypes
{
    public class TokenTypesConsistenceTest
    {
        private readonly ITestOutputHelper _output;

        public TokenTypesConsistenceTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private static IEnumerable<MethodInfo> LexemeRegexIsMatchTestMethods
        {
            get
            {
                var staticMethods = typeof(TokenTypesTests).GetStaticMethods();
                return staticMethods.Where(m => m.Name.EndsWith("_IsMatch"));
            }
        }

        [Theory, InjectData]
        internal void CheckConsistenceOfAllTokenTypes_Consistent(ILexicalTokenTypesDirectory lexicalTokenTypesDirectory)
        {
            var tokenTypes = lexicalTokenTypesDirectory.LexicalTokenTypes;
            Assert.NotEmpty(tokenTypes);
            foreach (var testMethod in LexemeRegexIsMatchTestMethods)
            {
                var testMethodRegexName = GetTestMethodTokenTypeName(testMethod);
                foreach (var tokenType in tokenTypes.Where(t => t.GetType().Name != testMethodRegexName))
                {
                    foreach (var value in GetTextCasesValues(testMethod))
                    {
                        var isMatch = tokenType.IsMatch(value);
                        LogResult(isMatch, testMethodRegexName, tokenType.GetType().Name, value);
                        Assert.False(isMatch);
                    }
                }
            }
        }

        private static IEnumerable<CustomAttributeData> GetTestCases(MemberInfo testMethod)
        {
            return testMethod.CustomAttributes.Where(a => a.AttributeType == typeof (InjectDataAttribute));
        }

        private static string GetTestMethodTokenTypeName(MethodInfo testMethod)
        {
            return testMethod.Name.Split('_').First();
        }

        private static IEnumerable<dynamic> GetTextCasesValues(MemberInfo testMethod)
        {
            return GetTestCases(testMethod).Select(testCase => ((dynamic) testCase.ConstructorArguments.First().Value)[0].Value);
        }

        private void LogResult(dynamic isMatch, string testMethodRegexName, string tokenType, dynamic value)
        {
            var resultString = isMatch ? "Is match! It's very bad!" : "Isn't match. Good.";
            _output.WriteLine(
                $"Test method regex name: `{testMethodRegexName}`\nTokenType name: {tokenType}\nTest case: `{value}`\nResult: {resultString}\n");
        }
    }
}