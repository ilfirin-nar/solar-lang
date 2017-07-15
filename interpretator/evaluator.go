package interpretator

import (
	"evergreen-lang/grammar/ast"
	"fmt"
)

func Evaluate(node ast.Node) {
	evaluator := newModuleEvaluator(node)
	evaluator.start()
}

func newModuleEvaluator(moduleNode ast.Node) *moduleEvaluator {
	if node.GetNodeType() != ast.Module {
		panic(fmt.Sprintf("Only module can be evaluated, but received %s", node.GetNodeType()))
	}

	return &moduleEvaluator{
		moduleNode: moduleNode,
		stack:      evaluationStack{},
	}
}

type moduleEvaluator struct {
	moduleNode ast.Node
	stack      evaluationStack
}

func (e *moduleEvaluator) start() {
	e.eval(e.moduleNode)
}

func (e *moduleEvaluator) eval(node ast.Node) {
	for _, childNode := range node.GetChildren() {
		switch childNode.GetNodeType() {
		case ast.Statement:
			statementNode := childNode.(*ast.StatementNode)
			switch statementNode.GetStatementType() {
			case ast.StatementPrint:
				e.eval(statementNode)
				e.stack.Print()
				break
			case ast.StatementAssignment:
				panic("Not implemented")
				break
			}
			break
		case ast.Expression:
			expressionNode := childNode.(*ast.ExpressionNode)
			e.eval(expressionNode)
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
			leafNode := childNode.(*ast.LeafNode)
			e.stack.Push(leafNode.GetValue())
			break
		default:
			panic("Evaluation: invalid AST node type")
		}
	}
}
