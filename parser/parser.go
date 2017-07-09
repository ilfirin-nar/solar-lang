package parser

import (
	"errors"
	"evergreen-lang/grammar"
	"evergreen-lang/lexer"
	"evergreen-lang/parser/ast"
	"fmt"
)

func Parse(tokens []*lexer.Token) (*ast.Node, error) {
	tokenStream := lexer.NewTokenStream(tokens)
	node, err := parseModule(tokenStream)
	if err != nil {
		return nil, err
	}
	return node, nil
}

func parseModule(tokens *lexer.TokenStream) (*ast.Node, error) {
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
	}
	return node, nil
}

func parseStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	token := tokens.GetCurrent()
	switch token.LexemeType {
	case grammar.PrintKeyword:
		return parsePrintStatement(tokens)
	case grammar.Variable:
		return parseAssignmentStatement(tokens)
	}
}

func parsePrintStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementPrint)

	if token, ok := checkToken(tokens, grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", token.LexemeType)
	}

	expressionNode, err := parseExpression(tokens)
	if err != nil {
		return nil, err
	}
	node.AppendChild(expressionNode)
	return node, nil
}

func parseAssignmentStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementAssignment)
	variableToken := tokens.GetCurrent()
	appendLeaf(node, variableToken, ast.Variable)

	if token, ok := checkToken(tokens, grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", token.LexemeType)
	}
	if token, ok := checkToken(tokens, grammar.Assignment); !ok {
		return nil, fmt.Errorf("Missed assignment operator: %s", token.LexemeType)
	}
	if token, ok := checkToken(tokens, grammar.Space); !ok {
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

func parseExpression(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.Expression)

	token := tokens.GetCurrent()
	switch token.LexemeType {
	case grammar.NewLine:
		return nil, fmt.Errorf("Missed expression")
	case grammar.NumericLiteral:
		return nil, nil // todo
	case grammar.Variable:
		return nil, nil // todo
	}

	// todo

	return node, nil
}

func checkToken(tokens *lexer.TokenStream, lexemeType grammar.LexemeType) (*lexer.Token, bool) {
	token, err := tokens.GetNext()
	if err != nil {
		return nil, false
	}
	return token, token.LexemeType != lexemeType
}

func appendLeaf(node *ast.Node, token *lexer.Token, nodeType ast.NodeType) *ast.Node {
	childNode := ast.NewLeafNode(nodeType, token)
	node.AppendChild(childNode)
}
