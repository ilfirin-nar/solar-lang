using System;
using Solar.Infrastructure.Config.DataTransferObjects;

namespace Solar.Infrastructure.Config.Exceptions
{
    public class ConfigOptionNotFoundException<TConfigOption> : Exception
        where TConfigOption : IConfigSection
    {
        private static readonly string ConfigOptionName;

        static ConfigOptionNotFoundException()
        {
            ConfigOptionName = typeof (TConfigOption).Name;
        }

        public override string Message => $"Config option `{ConfigOptionName}` is not found in configuration state";
    }
}