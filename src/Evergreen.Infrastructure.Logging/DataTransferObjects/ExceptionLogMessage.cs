using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Evergreen.Infrastructure.Logging.DataTransferObjects
{
    internal class ExceptionLogMessage : IDataTransferObject
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public ExceptionLogMessage InnerException { get; set; }
    }
}