package parsing

import (
	"evergreen-lang/grammar"
	"evergreen-lang/grammar/ast"
	"fmt"
)

func parseExpression(tokens *TokenStateMachine) (*ast.Node, error) {
	node := ast.NewNode(ast.Expression)
	var (
		firstOperand  *ast.Node
		operator      *ast.Node
		secondOperand *ast.Node
	)

	firstOperand, err := parseOperand(tokens)
	if err != nil {
		return nil, err
	}

	if isExprEnds(tokens) {
		node.AppendChild(firstOperand)
		return node, nil
	}

	if spaceToken, ok := tokens.CheckNextToken(grammar.Space); !ok {
		return nil, fmt.Errorf("Missed space: %s", spaceToken.LexemeType)
	}

	operatorToken, err := tokens.GetNext()
	if err != nil {
		return nil, fmt.Errorf("Missed operator")
	}

	switch operatorToken.LexemeType {
	case grammar.Addition:
		operator = ast.NewNode(ast.OperatorAddition)
		break
	case grammar.Subtraction:
		operator = ast.NewNode(ast.OperatorSubtraction)
		break
	case grammar.Multiplication:
		operator = ast.NewNode(ast.OperatorMultiplication)
		break
	case grammar.Division:
		operator = ast.NewNode(ast.OperatorDivision)
		break
	default:
		return nil, fmt.Errorf("Missed operator")
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

	operator.AppendChild(firstOperand)
	operator.AppendChild(secondOperand)
	node.AppendChild(operator)
	return node, nil
}

func isExprEnds(tokens *TokenStateMachine) bool {
	return tokens.IsEnd() || tokens.PryNext().LexemeType == grammar.NewLine
}
