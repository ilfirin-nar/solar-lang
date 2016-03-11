using System;

namespace Solar.Infrastructure.Config.Exceptions
{
    public class ConfigOptionAlreadySettedException : Exception
    {
        private readonly string _configOptionName;

        public ConfigOptionAlreadySettedException(Type type)
        {
            _configOptionName = type.Name;
        }

        public override string Message => $"Config option `{_configOptionName}` already setted to configuration state";
    }
}