using Evergreen.Domain.Grammar.Entities;
using Evergreen.Domain.Grammar.EntityFactories.RawData;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Grammar.EntityFactories
{
    public interface ITokenFactory : IEntityFactory<Token, TokenRawData> {}
}