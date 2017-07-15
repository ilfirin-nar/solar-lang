package ast

import (
	"evergreen-lang/lexer"
)

func NewLeafNode(nodeType LeafType, token *lexer.Token) Node {
	return &LeafNode{token: token, nodeType: nodeType}
}

type LeafNode struct {
	nodeType LeafType
	token    *lexer.Token
}

func (n *LeafNode) GetChildren() []Node {
	return nil
}

func (n *LeafNode) AppendChild(node Node) {
	panic("Appending child nodes to leaf-node is impossible")
}

func (n *LeafNode) GetNodeType() NodeType {
	return Leaf
}

func (n *LeafNode) GetLeafType() LeafType {
	return n.nodeType
}

func (n *LeafNode) GetToken() *lexer.Token {
	return n.token
}
