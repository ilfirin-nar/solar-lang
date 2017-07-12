package ast

import "evergreen-lang/lexer"

func NewNode(nodeType NodeType) *Node {
	return &Node{nodeType: nodeType}
}

func NewLeafNode(nodeType NodeType, token *lexer.Token) *Node {
	return &Node{token: token, nodeType: nodeType}
}

type Node struct {
	token    *lexer.Token
	children []*Node
	nodeType NodeType
}

func (n *Node) GetChildren() []*Node {
	return n.children
}

func (n *Node) AppendChild(node *Node) {
	n.children = append(n.children, node)
}

func (n *Node) GetNodeType() NodeType {
	return n.nodeType
}
