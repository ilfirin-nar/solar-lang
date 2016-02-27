using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis
{
    internal interface IContentAnalyzer : IDomainService
    {
        void Analyse(string content);
    }
}