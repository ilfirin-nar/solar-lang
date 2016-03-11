using System;
using System.Collections.Generic;
using System.Linq;
using Solar.Infrastructure.Config.DataTransferObjects;
using Solar.Infrastructure.Config.GlobalStateObject;
using Solar.Infrastructure.FileSystem.Services;

namespace Solar.Infrastructure.Config.Services
{
    internal class Configurator : IConfigurator
    {
        private readonly IEnumerable<Type> _configSectionsTypes;
        private readonly IJsonFileParser _fileParser;
        private readonly Configuration _configuration;

        public Configurator(
            IReadOnlyList<IConfigSection> configSections,
            IJsonFileParser fileParser,
            Configuration configuration)
        {
            _configSectionsTypes = configSections.Select(o => o.GetType());
            _fileParser = fileParser;
            _configuration = configuration;
        }

        public void Configure(string configPath)
        {
            foreach (var configSection in _fileParser.ParseNestedObject(configPath, _configSectionsTypes))
            {
                _configuration.Register((IConfigSection) configSection);
            }
        }
    }
}