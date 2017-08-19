package parsing

import (
	"evergreen-lang/grammar"
	"evergreen-lang/grammar/ast"
	"fmt"
)

func parseOperand(tokens *TokenStateMachine) (ast.Node, error) {
	token := tokens.GetCurrent()
	switch token.LexemeType {
	case grammar.NewLine:
		return nil, fmt.Errorf("Missed expression")
	case grammar.NumericLiteral:
		return ast.NewLeafNode(ast.LeafNumber, token), nil
		break
	case grammar.Identifier:
		return ast.NewLeafNode(ast.LeafIdentifier, token), nil
		break
	case grammar.LeftParenthesis:
		tokens.GetNext()
		expressionNode, err := parseExpression(tokens)
		if err != nil {
			return nil, err
		}
		exprNextToken, err := tokens.GetNext()
		if err != nil || exprNextToken.LexemeType != grammar.RightParenthesis {
			return nil, fmt.Errorf("Missed right parenthesis")
		}
		return expressionNode, nil
		break
	}
	return nil, fmt.Errorf("Missed expression")
}
