using Evergreen.Domain.Grammar.EntityFactories.RawData;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Analysis.Lexical.Services.Parsing
{
    internal interface ITokenTypeClarifier : IDomainService
    {
        bool TryToClarifyTokenType(string checkedLexeme, TokenRawData tokenRawData);
    }
}