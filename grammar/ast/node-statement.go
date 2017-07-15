package ast

func NewStatementNode(statementType StatementType) Node {
	return &StatementNode{statementType: statementType}
}

type StatementNode struct {
	children      []Node
	nodeType      NodeType
	statementType StatementType
}

func (n *StatementNode) GetChildren() []Node {
	return n.children
}

func (n *StatementNode) AppendChild(node Node) {
	n.children = append(n.children, node)
}

func (n *StatementNode) GetNodeType() NodeType {
	return Statement
}

func (n *StatementNode) GetStatementType() StatementType {
	return n.statementType
}
