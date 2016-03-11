using System.Collections.Generic;
using System.Linq;
using Solar.Infrastructure.Config.DataTransferObjects;
using Solar.Infrastructure.Config.Exceptions;

namespace Solar.Infrastructure.Config.GlobalStateObject
{
    internal class Configuration : IConfiguration
    {
        private readonly IList<IConfigSection> _options = new List<IConfigSection>();

        public TConfigOption Get<TConfigOption>() where TConfigOption : IConfigSection
        {
            var option = _options.FirstOrDefault(o => o is TConfigOption);
            if (option == null)
            {
                throw new ConfigOptionNotFoundException<TConfigOption>();
            }
            return (TConfigOption) option;
        }

        public void Register(IConfigSection section)
        {
            var type = section.GetType();
            if (_options.Any(o => o.GetType() == type))
            {
                throw new ConfigOptionAlreadySettedException(type);
            }
            _options.Add(section);
        }
    }
}