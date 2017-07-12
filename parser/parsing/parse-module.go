package parsing

import (
	"evergreen-lang/grammar"
	"evergreen-lang/grammar/ast"
)

func ParseModule(tokens *TokenStateMachine) (*ast.Node, error) {
	node := ast.NewNode(ast.Module)
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
		return node, nil
	}
	return node, nil
}
