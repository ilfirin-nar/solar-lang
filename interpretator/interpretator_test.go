package interpretator

import (
	"evergreen-lang/lexer"
	"evergreen-lang/parser"
	"testing"
)

func TestEvaluate(t *testing.T) {
	t.Run("print number", func(t *testing.T) {
		eval("print 42", t)
	})

	t.Run("print expression", func(t *testing.T) {
		eval("print 42 + 8", t)
	})

	t.Run("assign expression", func(t *testing.T) {
		eval("foo <- 42 * 8", t)
	})

	t.Run("assign expression then print", func(t *testing.T) {
		eval(
			`
				foo <- 2 + (3 - 4)
				bar <- 42 + foo
				print bar / 2`,
			t,
		)
	})
}

func eval(program string, t *testing.T) {
	tokens, _ := lexer.Lex(program)
	ast, _ := parser.Parse(tokens)
	if err := Evaluate(ast); err != nil {
		t.Fatalf(err.Error())
	}
}
