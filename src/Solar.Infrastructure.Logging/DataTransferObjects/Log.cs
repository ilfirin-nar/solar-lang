using System;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Logging.DataTransferObjects
{
    internal class Log : IDataTransferObject
    {
        public DateTime DateTime { get; set; }

        public string Level { get; set; }

        public object Message { get; set; }
    }
}