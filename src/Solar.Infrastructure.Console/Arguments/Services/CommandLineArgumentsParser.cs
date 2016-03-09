using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Console.Arguments.Attributes;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;
using Solar.Infrastructure.Console.Arguments.Services.Exceptions;

namespace Solar.Infrastructure.Console.Arguments.Services
{
    internal class CommandLineArgumentsParser<TCommandLineArguments> : ICommandLineArgumentsParser<TCommandLineArguments>
        where TCommandLineArguments : ICommandLineArguments, new()
    {
        private const string OptionPrefix = "-";
        private static readonly IReadOnlyDictionary<ConsoleOptionAttribute, PropertyInfo> OptionsProperties;

        static CommandLineArgumentsParser()
        {
            var type = typeof (TCommandLineArguments);
            OptionsProperties = type.GetPropertiesWith<ConsoleOptionAttribute>()
                .ToDictionary(p => p.GetFirstAttribute<ConsoleOptionAttribute>(), p => p);
        }

        public TCommandLineArguments Parse(IEnumerable<string> args)
        {
            var options = GetOptionWithValues(args);
            var result = new TCommandLineArguments();
            foreach (var option in options)
            {
                var optionProperty = OptionsProperties.FirstOrDefault(op => op.Key.Option == option.Key);
                if (optionProperty.Equals(default(KeyValuePair<ConsoleOptionAttribute, PropertyInfo>)))
                {
                    throw new UnrecognizedCommandLineOptionException(option.Key);
                }
                var value = SetResultValue(option, optionProperty.Key);
                optionProperty.Value.SetValue(result, value);
            }
            return result;
        }

        private static IDictionary<string, IList<string>> GetOptionWithValues(IEnumerable<string> args)
        {
            var map = new Dictionary<string, IList<string>>();
            var valuesList = new List<string>();
            foreach (var argument in args)
            {
                if (argument.StartsWith(OptionPrefix))
                {
                    valuesList = new List<string>();
                    map.Add(argument.Substring(1), valuesList);
                }
                else
                {
                    valuesList.Add(argument);
                }
            }
            return map;
        }

        private static object SetResultValue(KeyValuePair<string, IList<string>> optionValue, ConsoleOptionAttribute optionPropertyAttribute)
        {
            ValidateValue(optionValue, optionPropertyAttribute);
            object value;
            if (optionValue.Value.Count == 1)
            {
                value = optionValue.Value.Single();
            }
            else
            {
                value = optionValue.Value;
            }
            return value;
        }

        private static void ValidateValue(KeyValuePair<string, IList<string>> optionValue, ConsoleOptionAttribute optionPropertyAttribute)
        {
            if (optionValue.Value.Count == 0 || (!optionPropertyAttribute.AllowMultiple && optionValue.Value.Count > 1))
            {
                throw new InvalidCommandLineOptionValuesCountException(optionValue.Key, optionValue.Value.Count, optionPropertyAttribute.AllowMultiple);
            }
        }
    }
}