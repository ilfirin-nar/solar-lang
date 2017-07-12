package parsing

import (
	"evergreen-lang/grammar"
	"evergreen-lang/grammar/ast"
	"fmt"
)

func parseStatement(tokens *TokenStateMachine) (*ast.Node, error) {
	token := tokens.GetCurrent()
	switch token.LexemeType {
	case grammar.PrintKeyword:
		return parsePrintStatement(tokens)
	case grammar.Identifier:
		return parseAssignmentStatement(tokens)
	}
	return nil, fmt.Errorf("Missed statement")
}

func parsePrintStatement(tokens *TokenStateMachine) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementPrint)

	if token, ok := tokens.CheckNextToken(grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", token.LexemeType)
	}

	tokens.MoveNext()
	expressionNode, err := parseExpression(tokens)
	if err != nil {
		return nil, err
	}
	node.AppendChild(expressionNode)
	return node, nil
}

func parseAssignmentStatement(tokens *TokenStateMachine) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementAssignment)
	variableToken := tokens.GetCurrent()
	appendLeaf(node, variableToken, ast.Variable)

	if token, ok := tokens.CheckNextToken(grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", token.LexemeType)
	}
	if token, ok := tokens.CheckNextToken(grammar.Assignment); !ok {
		return nil, fmt.Errorf("Missed assignment operator: %s", token.LexemeType)
	}
	if token, ok := tokens.CheckNextToken(grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", token.LexemeType)
	}

	if _, err := tokens.GetNext(); err != nil {
		return nil, err
	}
	expressionNode, err := parseExpression(tokens)
	if err != nil {
		return nil, err
	}
	node.AppendChild(expressionNode)
	return node, nil
}
