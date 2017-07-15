package ast

const (
	Module     = NodeType("m")
	Statement  = NodeType("s")
	Expression = NodeType("e")
	Leaf       = NodeType("l")
)

type NodeType string
