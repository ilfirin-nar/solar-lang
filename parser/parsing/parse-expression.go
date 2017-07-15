package parsing

import (
	"evergreen-lang/grammar"
	"evergreen-lang/grammar/ast"
	"fmt"
)

func parseExpression(tokens *TokenStateMachine) (ast.Node, error) {
	var (
		firstOperand           ast.Node
		operatorExpressionType ast.ExpressionType
		secondOperand          ast.Node
	)

	firstOperand, err := parseOperand(tokens)
	if err != nil {
		return nil, err
	}

	if isExprEnds(tokens) {
		node := ast.NewExpressionNode(ast.ExpValue)
		node.AppendChild(firstOperand)
		return node, nil
	}

	if spaceToken, ok := tokens.CheckNextToken(grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", spaceToken.LexemeType)
	}

	operatorToken, err := tokens.GetNext()
	if err != nil {
		return nil, fmt.Errorf("Missed operatorExpressionType")
	}

	switch operatorToken.LexemeType {
	case grammar.Addition:
		operatorExpressionType = ast.ExpOpAddition
		break
	case grammar.Subtraction:
		operatorExpressionType = ast.ExpOpSubtraction
		break
	case grammar.Multiplication:
		operatorExpressionType = ast.ExpOpMultiplication
		break
	case grammar.Division:
		operatorExpressionType = ast.ExpOpDivision
		break
	default:
		return nil, fmt.Errorf("Missed operatorExpressionType")
	}

	if spaceToken, ok := tokens.CheckNextToken(grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", spaceToken.LexemeType)
	}

	_, err = tokens.GetNext()
	if err != nil {
		return nil, fmt.Errorf("Missed second operand")
	}
	secondOperand, err = parseOperand(tokens)
	if err != nil {
		return nil, err
	}

	node := ast.NewExpressionNode(operatorExpressionType)
	node.AppendChild(firstOperand)
	node.AppendChild(secondOperand)
	return node, nil
}

func isExprEnds(tokens *TokenStateMachine) bool {
	return tokens.IsEnd() || tokens.PryNext().LexemeType == grammar.NewLine
}
