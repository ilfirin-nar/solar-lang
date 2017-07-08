using System;
using Evergreen.Infrastructure.Configuration.GlobalStateObject;

namespace Evergreen.Infrastructure.Configuration.Exceptions
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