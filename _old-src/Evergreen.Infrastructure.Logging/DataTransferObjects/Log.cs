using System;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Evergreen.Infrastructure.Logging.DataTransferObjects
{
    internal class Log : IDataTransferObject
    {
        public DateTime DateTime { get; set; }

        public string Level { get; set; }

        public object Message { get; set; }
    }
}