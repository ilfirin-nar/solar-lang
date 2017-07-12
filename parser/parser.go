package parser

import (
	"evergreen-lang/grammar/ast"
	"evergreen-lang/lexer"
	"evergreen-lang/parser/parsing"
)

func Parse(tokens []*lexer.Token) (*ast.Node, error) {
	tokenStream := parsing.NewTokenStateMachine(tokens)
	node, err := parsing.ParseModule(tokenStream)
	if err != nil {
		return nil, err
	}
	return node, nil
}
