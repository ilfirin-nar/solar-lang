package parsing

import (
	"evergreen-lang/grammar"
	"evergreen-lang/grammar/ast"
)

func ParseModule(tokens *TokenStateMachine) (ast.Node, error) {
	node := ast.NewModuleNode()
	for {
		token, err := tokens.GetNext()
		if err != nil {
			return nil, err
		}

		if token.LexemeType == grammar.Space || token.LexemeType == grammar.NewLine {
			continue
		}

		statementNode, err := parseStatement(tokens)
		if err != nil {
			return nil, err
		}
		node.AppendChild(statementNode)
		if isStatementEnds(tokens) {
			break
		}
	}
	return node, nil
}

func isStatementEnds(tokens *TokenStateMachine) bool {
	return tokens.IsEnd() || tokens.GetCurrent().LexemeType == grammar.NewLine
}
