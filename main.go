package main

import (
	"evergreen-lang/evaluator"
	"evergreen-lang/lexer"
	"evergreen-lang/parser"
	"fmt"
	"os"
)

func main() {
	source := os.Args[0]

	tokens, err := lexer.Lex(source)
	if err != nil {
		fmt.Printf(err.Error())
	}

	ast, err := parser.Parse(tokens)
	if err != nil {
		fmt.Printf(err.Error())
	}

	evaluator.Evaluate(ast)
}
