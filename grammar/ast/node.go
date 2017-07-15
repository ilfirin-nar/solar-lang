package ast

type Node interface {
	GetChildren() []Node
	AppendChild(node Node)
	GetNodeType() NodeType
}
