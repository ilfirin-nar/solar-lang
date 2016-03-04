using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Solar.Infrastructure.Common.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Solar.Domain.Text.Tests
{
    public class LexemeRegularExpressionsConsistenceTest
    {
        private readonly ITestOutputHelper _output;

        public LexemeRegularExpressionsConsistenceTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private static IEnumerable<MethodInfo> LexemeRegexIsMatchTestMethods
        {
            get
            {
                var staticMethods = typeof(LexemeRegularExpressionsTests).GetStaticMethods();
                return staticMethods.Where(m => m.Name.EndsWith("_IsMatch"));
            }
        }

        private static IEnumerable<FieldInfo> RegexFields => typeof (LexemRegularExpressions).GetFields();

        [Fact]
        internal void CheckConsistenceOfAllRegex_Consistent()
        {
            foreach (var testMethod in LexemeRegexIsMatchTestMethods)
            {
                var testMethodRegexName = GetTestMethodRegexName(testMethod);
                foreach (var regexFieldInfo in RegexFields.Where(f => f.Name != testMethodRegexName))
                {
                    var regex = GetRegex(regexFieldInfo);
                    foreach (var value in GetTextCasesValues(testMethod))
                    {
                        var isMatch = regex.IsMatch(value);
                        LogResult(isMatch, testMethodRegexName, regexFieldInfo, value);
                        Assert.False(isMatch);
                    }
                }
            }
        }

        private static Regex GetRegex(FieldInfo regexFieldInfo)
        {
            return (Regex) regexFieldInfo.GetValue(null);
        }

        private static IEnumerable<CustomAttributeData> GetTestCases(MemberInfo testMethod)
        {
            return testMethod.CustomAttributes.Where(a => a.AttributeType == typeof (InlineDataAttribute));
        }

        private static string GetTestMethodRegexName(MethodInfo testMethod)
        {
            return testMethod.Name.Split('_').First();
        }

        private static IEnumerable<dynamic> GetTextCasesValues(MemberInfo testMethod)
        {
            return GetTestCases(testMethod).Select(testCase => ((dynamic) testCase.ConstructorArguments.First().Value)[0].Value);
        }

        private void LogResult(dynamic isMatch, string testMethodRegexName, FieldInfo regexFieldInfo, dynamic value)
        {
            var resultString = isMatch ? "Is match! It's very bad!" : "Isn't match. Good.";
            _output.WriteLine(
                $"Test method regex name: `{testMethodRegexName}`\nRegex name: {regexFieldInfo.Name}\nTest case: `{value}`\nResult: {resultString}\n");
        }
    }
}