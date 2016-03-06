using Solar.Domain.Analysis.Lexical.EntityFactories.RawData;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical.EntityFactories
{
    internal interface ITokenFactory : IEntityFactory<Token, TokenRawData> {}
}