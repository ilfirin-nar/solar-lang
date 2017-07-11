package parser

import (
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
		return node, nil
	}
	return node, nil
}

func parseStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	token := tokens.GetCurrent()
	switch token.LexemeType {
	case grammar.PrintKeyword:
		return parsePrintStatement(tokens)
	case grammar.Identifier:
		return parseAssignmentStatement(tokens)
	}
	return nil, fmt.Errorf("Missed statement")
}

func parsePrintStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementPrint)

	if token, ok := checkNextToken(tokens, grammar.Space); !ok {
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

func parseAssignmentStatement(tokens *lexer.TokenStream) (*ast.Node, error) {
	node := ast.NewNode(ast.StatementAssignment)
	variableToken := tokens.GetCurrent()
	appendLeaf(node, variableToken, ast.Variable)

	if token, ok := checkNextToken(tokens, grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", token.LexemeType)
	}
	if token, ok := checkNextToken(tokens, grammar.Assignment); !ok {
		return nil, fmt.Errorf("Missed assignment operator: %s", token.LexemeType)
	}
	if token, ok := checkNextToken(tokens, grammar.Space); !ok {
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
	var (
		firstOperand  *ast.Node
		operator      *ast.Node
		secondOperand *ast.Node
	)

	token := tokens.GetCurrent()
	switch token.LexemeType {
	case grammar.NewLine:
		return nil, fmt.Errorf("Missed expression")
	case grammar.NumericLiteral:
		firstOperand = ast.NewLeafNode(ast.Number, token)
		break
	case grammar.Identifier:
		firstOperand = ast.NewLeafNode(ast.Variable, token)
		break
	default:
		return nil, fmt.Errorf("Missed expression")
	}

	if isExprEnds(tokens) {
		node.AppendChild(firstOperand)
		return node, nil
	}

	if spaceToken, ok := checkNextToken(tokens, grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", spaceToken.LexemeType)
	}

	operatorToken, err := tokens.GetNext()
	if err != nil {
		return nil, fmt.Errorf("Missed operator")
	}

	if operatorToken.LexemeType != grammar.Addition &&
		operatorToken.LexemeType != grammar.Subtraction &&
		operatorToken.LexemeType != grammar.Multiplication &&
		operatorToken.LexemeType != grammar.Division {
		return nil, fmt.Errorf("Missed operator")
	}
	operator = ast.NewNode(ast.OperatorAddition)

	if spaceToken, ok := checkNextToken(tokens, grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", spaceToken.LexemeType)
	}

	_, err = tokens.GetNext()
	if err != nil {
		return nil, fmt.Errorf("Missed second operand")
	}
	secondOperand, err = parseExpression(tokens)
	if err != nil {
		return nil, err
	}

	operator.AppendChild(firstOperand)
	operator.AppendChild(secondOperand)
	node.AppendChild(operator)
	return node, nil
}

func checkNextToken(tokens *lexer.TokenStream, lexemeType grammar.LexemeType) (*lexer.Token, bool) {
	token, err := tokens.GetNext()
	if err != nil {
		return nil, false
	}
	return token, token.LexemeType == lexemeType
}

func appendLeaf(node *ast.Node, token *lexer.Token, nodeType ast.NodeType) *ast.Node {
	childNode := ast.NewLeafNode(nodeType, token)
	node.AppendChild(childNode)
	return childNode
}

func isExprEnds(tokens *lexer.TokenStream) bool {
	_, ok := checkNextToken(tokens, grammar.NewLine)
	return ok || tokens.IsEnd()
}
