package parsing

import (
	"evergreen-lang/grammar/ast"
	"evergreen-lang/lexer"
)

func appendLeaf(node ast.Node, token *lexer.Token, nodeType ast.LeafType) ast.Node {
	childNode := ast.NewLeafNode(nodeType, token)
	node.AppendChild(childNode)
	return childNode
}
