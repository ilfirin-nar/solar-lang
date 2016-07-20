using System;
using System.Collections.Generic;
using System.Linq;
using Evergreen.Infrastructure.Common.Extensions.ObjectExtensions;
using Evergreen.Infrastructure.Configuration.GlobalStateObject;
using Evergreen.Infrastructure.FileSystem.Services;

namespace Evergreen.Infrastructure.Configuration.Services
{
    internal class Configurator : IConfigurator
    {
        private const string DefaultConfigPath = "config.json";
        private readonly IEnumerable<Type> _configSectionsTypes;
        private readonly IReadOnlyList<IConfigSection> _configSections;
        private readonly IJsonFileParser _fileParser;

        public Configurator(IReadOnlyList<IConfigSection> configSections, IJsonFileParser fileParser)
        {
            _configSectionsTypes = configSections.Select(o => o.GetType());
            _configSections = configSections.ToList();
            _fileParser = fileParser;
        }

        public void Configure()
        {
            var configSections = _fileParser.ParseNestedObjectFromFile(DefaultConfigPath, _configSectionsTypes);
            RegisterConfigSections(configSections);
        }

        public void Configure(string configContent)
        {
            var configSections = _fileParser.ParseNestedObjectFromString(configContent, _configSectionsTypes);
            RegisterConfigSections(configSections);
        }

        private void RegisterConfigSections(IEnumerable<object> configSections)
        {
            foreach (var configSection in configSections)
            {
                var section = _configSections.Single(cs => cs.GetType() == configSection.GetType());
                section.MapObject(configSection);
            }
        }
    }
}