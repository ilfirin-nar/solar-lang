package parser

import (
	"evergreen-lang/lexer"
	"testing"
)

func TestParse(t *testing.T) {
	t.Run("print statement", func(t *testing.T) {
		t.Run("number", func(t *testing.T) {
			tokens, _ := lexer.Lex("print 42")
			ast, err := Parse(tokens)
			if err != nil {
				t.Fatalf("Parse error: %s", err.Error())
			}
			if ast == nil {
				t.Fatalf("Empty AST")
			}
		})
	})
}
