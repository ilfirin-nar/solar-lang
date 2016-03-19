﻿using System.Collections.Generic;
using LightInject.xUnit2;
using Solar.Infrastructure.Console.Arguments.Attributes;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;
using Solar.Infrastructure.Console.Arguments.Services;
using Solar.Infrastructure.Console.Arguments.Services.Exceptions;
using Xunit;

namespace Solar.Infrastructure.Console.Tests.UnitTests.Arguments.Services
{
    public class CommandLineArgumentsParserTests
    {
        public class TestCommandLineArguments : ICommandLineArguments
        {
            public TestCommandLineArguments()
            {
                Foos = new List<string>();
            }

            [ConsoleOption(Option = "f")]
            public string Foo { get; set; }

            [ConsoleOption(Option = "fs", AllowMultiple = true)]
            public IList<string> Foos { get; set; }

            [ConsoleOption(Option = "b")]
            public string Bar { get; set; }

            [ConsoleOption(Option = "r", IsRequired = true)]
            public string Rock { get; set; }
        }

        [Theory]
        [InjectData("-f fooValue -b barValue -r rockValue", "fooValue", "barValue", "rockValue")]
        public static void Parse_ValidArgumentsWithoutArray_ValidDto(
            ICommandLineArgumentsParser<TestCommandLineArguments> parser,
            string args,
            string foo,
            string bar,
            string rock)
        {
            var result = parser.Parse(args.Split(' '));
            Assert.Equal(foo, result.Foo);
            Assert.Equal(0, result.Foos.Count);
            Assert.Equal(bar, result.Bar);
            Assert.Equal(rock, result.Rock);
        }

        [Theory, InjectData]
        public static void Parse_ValidArgumentsWithArray_ValidDto(ICommandLineArgumentsParser<TestCommandLineArguments> parser)
        {
            var args = "-f fooValue -fs foo1 foo2 foo3 -b barValue".Split(' ');
            var result = parser.Parse(args);
            Assert.Equal("fooValue", result.Foo);
            Assert.Equal(3, result.Foos.Count);
            Assert.Equal("foo1", result.Foos[0]);
            Assert.Equal("foo2", result.Foos[1]);
            Assert.Equal("foo3", result.Foos[2]);
            Assert.Equal("barValue", result.Bar);
        }

        [Theory, InjectData]
        public static void Parse_InvalidArgumentsWithoutArray_Exception(ICommandLineArgumentsParser<TestCommandLineArguments> parser)
        {
            try
            {
                parser.Parse("-f fooValue -e foo".Split(' '));
                Assert.True(false);
            }
            catch (UnrecognizedCommandLineOptionException)
            {
                Assert.True(true);
            }
        }

        [Theory, InjectData]
        public static void Parse_InvalidArgumentsWithArray_Exception(ICommandLineArgumentsParser<TestCommandLineArguments> parser)
        {
            try
            {
                parser.Parse("-f fooValue -fs -b barValue".Split(' '));
                Assert.True(false);
            }
            catch (InvalidCommandLineOptionValuesCountException)
            {
                Assert.True(true);
            }
        }

        [Theory, InjectData]
        public static void Parse_InvalidArgumentsNotAllowMultiple_Exception(ICommandLineArgumentsParser<TestCommandLineArguments> parser)
        {
            try
            {
                parser.Parse("-f foo1 foo2 foo3 -b barValue".Split(' '));
                Assert.True(false);
            }
            catch (InvalidCommandLineOptionValuesCountException)
            {
                Assert.True(true);
            }
        }
    }
}