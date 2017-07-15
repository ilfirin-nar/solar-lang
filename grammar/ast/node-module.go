package ast

func NewModuleNode() Node {
	return &ModuleNode{}
}

type ModuleNode struct {
	children []Node
}

func (n *ModuleNode) GetChildren() []Node {
	return n.children
}

func (n *ModuleNode) AppendChild(node Node) {
	n.children = append(n.children, node)
}

func (n *ModuleNode) GetNodeType() NodeType {
	return Module
}
