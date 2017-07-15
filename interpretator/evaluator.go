package interpretator

import (
	"evergreen-lang/grammar/ast"
	"fmt"
	"strconv"
)

func newModuleEvaluator(moduleNode ast.Node) *moduleEvaluator {
	if moduleNode.GetNodeType() != ast.Module {
		panic(fmt.Sprintf("Only module can be evaluated, but received %s", moduleNode.GetNodeType()))
	}

	return &moduleEvaluator{
		moduleNode: moduleNode,
		stack:      newEvaluationStack(),
		variables:  make(map[string]int),
	}
}

type moduleEvaluator struct {
	moduleNode ast.Node
	stack      *evaluationStack
	variables  map[string]int
}

func (e *moduleEvaluator) run() error {
	if err := e.eval(e.moduleNode); err != nil {
		return err
	}
	return nil
}

func (e *moduleEvaluator) evalChildren(node ast.Node) error {
	for _, childNode := range node.GetChildren() {
		if err := e.eval(childNode); err != nil {
			return err
		}
	}
	return nil
}

func (e *moduleEvaluator) eval(node ast.Node) error {
	switch node.GetNodeType() {
	case ast.Module:
		if err := e.evalChildren(node); err != nil {
			return err
		}
		break
	case ast.Statement:
		statementNode := node.(*ast.StatementNode)
		switch statementNode.GetStatementType() {
		case ast.StatementPrint:
			if err := e.evalChildren(statementNode); err != nil {
				return err
			}
			e.stack.Print()
			break
		case ast.StatementAssignment:
			assignmentChildren := statementNode.GetChildren()
			if err := e.eval(assignmentChildren[1]); err != nil {
				return err
			}
			identifier := assignmentChildren[0].(*ast.LeafNode).GetValue()
			e.variables[identifier] = e.stack.Pop()
			break
		}
		break
	case ast.Expression:
		expressionNode := node.(*ast.ExpressionNode)
		if err := e.evalChildren(expressionNode); err != nil {
			return err
		}
		switch expressionNode.GetExpressionType() {
		case ast.ExpOpAddition:
			e.stack.Add()
			break
		case ast.ExpOpSubtraction:
			e.stack.Sub()
			break
		case ast.ExpOpMultiplication:
			e.stack.Mul()
			break
		case ast.ExpOpDivision:
			e.stack.Div()
			break
		}
		break
	case ast.Leaf:
		leafNode := node.(*ast.LeafNode)
		leafValue := leafNode.GetValue()
		switch leafNode.GetLeafType() {
		case ast.LeafNumber:
			value, _ := strconv.Atoi(leafValue)
			e.stack.Push(value)
			break
		case ast.LeafIdentifier:
			value, ok := e.variables[leafValue]
			if !ok {
				panic(fmt.Sprintf("Evaluation: not declared identifier '%s'", leafValue))
			}
			e.stack.Push(value)
			break
		}
		break
	default:
		panic("Evaluation: invalid AST node type")
	}
	return nil
}
