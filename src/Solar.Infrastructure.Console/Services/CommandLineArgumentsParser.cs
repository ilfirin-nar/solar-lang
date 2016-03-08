using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Console.Attributes;
using Solar.Infrastructure.Console.DataTransferObjects;
using Solar.Infrastructure.Console.Services.Exceptions;

namespace Solar.Infrastructure.Console.Services
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
                var value = SetResultValue(option);
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

        private static object SetResultValue(KeyValuePair<string, IList<string>> optionValue)
        {
            object value;
            switch (optionValue.Value.Count)
            {
                case 0:
                    throw new InvalidCommandLineOptionValuesCountException(optionValue.Key);
                case 1:
                    value = optionValue.Value.Single();
                    break;
                default:
                    value = optionValue.Value;
                    break;
            }
            return value;
        }
    }
}