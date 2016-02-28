using Solar.Domain.Analysis.LexicalAnalysis.Entities;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.EntityFactories
{
    internal interface ITokenFactory : IEntityFactory<Token, TokenRawData> {}
}