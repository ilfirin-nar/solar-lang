using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical.Services.Parsing
{
    internal interface ITokenTypeClarifier : IDomainService
    {
        bool TryToClarifyTokenType(string checkedLexeme, TokenRawData tokenRawData);
    }
}