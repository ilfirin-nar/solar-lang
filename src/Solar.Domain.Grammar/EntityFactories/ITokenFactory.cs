using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.EntityFactories
{
    public interface ITokenFactory : IEntityFactory<Token, TokenRawData> {}
}