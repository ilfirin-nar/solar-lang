using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Console.Attributes;
using Solar.Infrastructure.Console.DataTransferObjects;

namespace Solar.Infrastructure.Console.Services
{
    internal class CommandLineArgumentsParser<TCommandLineArguments> : ICommandLineArgumentsParser<TCommandLineArguments>
        where TCommandLineArguments : ICommandLineArguments
    {
        private const string OptionPrefix = "-";
        private static readonly IReadOnlyDictionary<ConsoleOptionAttribute, PropertyInfo> OptionsProperties;

        static CommandLineArgumentsParser()
        {
            var type = typeof (TCommandLineArguments);
            OptionsProperties = type.GetPropertiesWith<ConsoleOptionAttribute>()
                .ToDictionary(p => p.GetFirstAttribute<ConsoleOptionAttribute>(), p => p);
        }

        public TCommandLineArguments Parse(string[] args)
        {
            var map =  new Dictionary<string, IList<string>>();
            foreach (var argument in args)
            {
                if (argument.StartsWith(OptionPrefix))
                {
                    
                }
            }
            throw new System.NotImplementedException();
            //if (OptionsProperties.Keys.Select(c => c.Option).Contains(argument.))
        }
    }
}