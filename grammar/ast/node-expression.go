package ast

func NewExpressionNode(expressionType ExpressionType) Node {
	return &ExpressionNode{expressionType: expressionType}
}

type ExpressionNode struct {
	children       []Node
	expressionType ExpressionType
}

func (n *ExpressionNode) GetChildren() []Node {
	return n.children
}

func (n *ExpressionNode) AppendChild(node Node) {
	n.children = append(n.children, node)
}

func (n *ExpressionNode) GetNodeType() NodeType {
	return Expression
}

func (n *ExpressionNode) GetExpressionType() ExpressionType {
	return n.expressionType
}
