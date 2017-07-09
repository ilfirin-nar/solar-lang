package parser

import (
	"errors"
	"evergreen-lang/grammar"
	"evergreen-lang/lexer"
	"evergreen-lang/parser/ast"
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
	node := ast.NewNode(ast.Module, nil)
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
	node := ast.NewNode(ast.StatementPrint, nil)

	if checkToken(tokens, grammar.Space) {
		return nil, errors.New("Missed space")
	}

	expressionNode, err := parseExpression(tokens)
	if err != nil {
		return nil, err
	}
	node.AppendChild(expressionNode)
	return node, nil
}

func parseAssignmentStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementPrint, nil)
	variableToken := tokens.GetCurrent()
	appendLeaf(node, variableToken, ast.Variable)

	if checkToken(tokens, grammar.Space) {
		return nil, errors.New("Missed space")
	}
	if checkToken(tokens, grammar.Assignment) {
		return nil, errors.New("Missed assignment")
	}
	if checkToken(tokens, grammar.Space) {
		return nil, errors.New("Missed space")
	}

	expressionNode, err := parseExpression(tokens)
	if err != nil {
		return nil, err
	}
	node.AppendChild(expressionNode)
	return node, nil
}

func parseExpression(tokens *lexer.TokenStream) (*ast.Node, error) {
	// todo
}

func _parseExpression(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.Statement, nil)
	for {
		token, err := tokens.GetNext()
		if err != nil {
			break
		}

		if token.LexemeType == grammar.Space {
			continue
		}
		if token.LexemeType == grammar.NewLine {
			continue
		}
		if token.LexemeType == grammar.PrintKeyword {
			// TODO
			continue
		}
		if token.LexemeType == grammar.Variable {
			// TODO
			appendLeaf(node, token, ast.Variable)
			continue
		}
		if token.LexemeType == grammar.NumericLiteral {
			appendLeaf(node, token, ast.Number)
			continue
		}
		if token.LexemeType == grammar.Assignment {
			appendLeaf(node, token, ast.OperatorAssignment)
			continue
		}
		if token.LexemeType == grammar.Equality {
			appendLeaf(node, token, ast.OperatorEquality)
			continue
		}
		if token.LexemeType == grammar.LessThan {
			appendLeaf(node, token, ast.OperatorLessThan)
			continue
		}
		if token.LexemeType == grammar.GreatThan {
			appendLeaf(node, token, ast.OperatorGreatThan)
			continue
		}
		if token.LexemeType == grammar.LessThanOrEq {
			appendLeaf(node, token, ast.OperatorLessThanOrEq)
			continue
		}
		if token.LexemeType == grammar.GreatThanOrEq {
			appendLeaf(node, token, ast.OperatorGreatThanOrEq)
			continue
		}
		if token.LexemeType == grammar.Addition {
			appendLeaf(node, token, ast.OperatorAddition)
			continue
		}
		if token.LexemeType == grammar.Subtraction {
			appendLeaf(node, token, ast.OperatorSubtraction)
			continue
		}
		if token.LexemeType == grammar.Multiplication {
			appendLeaf(node, token, ast.OperatorMultiplication)
			continue
		}
		if token.LexemeType == grammar.Division {
			appendLeaf(node, token, ast.OperatorDivision)
			continue
		}
	}
	return node, nil
}

func checkToken(tokens *lexer.TokenStream, lexemeType grammar.LexemeType) bool {
	token, err := tokens.GetNext()
	if err != nil {
		return false
	}
	if token.LexemeType != lexemeType {
		return false
	}
	return true
}

func appendLeaf(node *ast.Node, token *lexer.Token, nodeType ast.NodeType) *ast.Node {
	childNode := ast.NewNode(nodeType, token)
	node.AppendChild(childNode)
}
