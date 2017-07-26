package main

import (
	"evergreen-lang/interpretator"
	"evergreen-lang/lexer"
	"evergreen-lang/parser"
	"fmt"
	"os"
)

func main() {
	if len(os.Args) <= 1 {
		fmt.Println("Missing source path")
		os.Exit(1)
		return
	}

	source := os.Args[1]
	if source == "" {
		fmt.Println("Source is empty")
		os.Exit(1)
		return
	}

	tokens, err := lexer.Lex(source)
	if err != nil {
		fmt.Printf(err.Error())
	}

	ast, err := parser.Parse(tokens)
	if err != nil {
		fmt.Printf(err.Error())
	}

	interpretator.Evaluate(ast)
}
