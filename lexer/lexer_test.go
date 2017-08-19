package lexer

import (
	"evergreen-lang/grammar"
	"testing"
)

func TestLex(t *testing.T) {
	t.Run("counts", func(t *testing.T) {
		t.Run("empty string: nil", func(t *testing.T) {
			_, err := Lex("")
			if err == nil {
				t.Fatalf("Error is nil")
			}
		})

		t.Run("one word: one token", func(t *testing.T) {
			lexemes, err := Lex("word")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
		})

		t.Run("few words: few tokens", func(t *testing.T) {
			lexemes, err := Lex("foo2 bar3")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 3 {
				t.Fatalf("Expected 3 tokens, but received %d", len(lexemes))
			}
		})

		t.Run("complex string: many tokens", func(t *testing.T) {
			lexemes, err := Lex("foo <- a + b - c * d / e")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 21 {
				t.Fatalf("Expected 21 tokens, but received %d", len(lexemes))
			}
		})
	})

	t.Run("spaces", func(t *testing.T) {
		t.Run("one space: no tokens", func(t *testing.T) {
			lexemes, err := Lex(" ")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 0 {
				t.Fatalf("Expected 0 tokens, but received %d", len(lexemes))
			}
		})

		t.Run("few spaces: no tokens", func(t *testing.T) {
			lexemes, err := Lex("     ")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 0 {
				t.Fatalf("Expected 0 tokens, but received %d", len(lexemes))
			}
		})

		t.Run("tabs and spaces: no tokens", func(t *testing.T) {
			lexemes, err := Lex("	  	  ")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 0 {
				t.Fatalf("Expected 0 tokens, but received %d", len(lexemes))
			}
		})
	})

	t.Run("newlines", func(t *testing.T) {
		t.Run("one newline: no tokens", func(t *testing.T) {
			lexemes, err := Lex("\n")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 0 {
				t.Fatalf("Expected 0 tokens, but received %d", len(lexemes))
			}
		})

		t.Run("two newlines: no tokens", func(t *testing.T) {
			lexemes, err := Lex("\n\n")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 0 {
				t.Fatalf("Expected 0 tokens, but received %d", len(lexemes))
			}
		})

		t.Run("few newlines: no tokens", func(t *testing.T) {
			lexemes, err := Lex("\n\n\n\n\n")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 0 {
				t.Fatalf("Expected 0 tokens, but received %d", len(lexemes))
			}
		})
	})

	t.Run("variables", func(t *testing.T) {
		t.Run("one word: variable token", func(t *testing.T) {
			lexemes, err := Lex("foo")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Identifier {
				t.Fatalf("Expected newline token, but received %s", lexemes[0].LexemeType)
			}
		})

		t.Run("two words: two variables tokens", func(t *testing.T) {
			lexemes, err := Lex("foo bar")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 3 {
				t.Fatalf("Expected 3 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Identifier {
				t.Fatalf("Expected variable token, but received %s", lexemes[0].LexemeType)
			}
			if lexemes[1].LexemeType != grammar.Space {
				t.Fatalf("Expected space token, but received %s", lexemes[0].LexemeType)
			}
			if lexemes[2].LexemeType != grammar.Identifier {
				t.Fatalf("Expected variable token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("keywords", func(t *testing.T) {
		t.Run("print word: print keyword", func(t *testing.T) {
			lexemes, err := Lex("print")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.PrintKeyword {
				t.Fatalf("Expected print keyword token, but received %s", lexemes[0].LexemeType)
			}
		})

		t.Run("print and word: print keyword and variable", func(t *testing.T) {
			lexemes, err := Lex("print foo")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 3 {
				t.Fatalf("Expected 3 lexeme, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.PrintKeyword {
				t.Fatalf("Expected print keyword token, but received %s", lexemes[0].LexemeType)
			}
			if lexemes[1].LexemeType != grammar.Space {
				t.Fatalf("Expected space token, but received %s", lexemes[0].LexemeType)
			}
			if lexemes[2].LexemeType != grammar.Identifier {
				t.Fatalf("Expected variable token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("assignment", func(t *testing.T) {
		t.Run("assignment: assignment token", func(t *testing.T) {
			lexemes, err := Lex("<-")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Assignment {
				t.Fatalf("Expected assignment token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("equality", func(t *testing.T) {
		t.Run("equality: equality token", func(t *testing.T) {
			lexemes, err := Lex("=")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Equality {
				t.Fatalf("Expected equality token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("less than", func(t *testing.T) {
		t.Run("less than: less than token", func(t *testing.T) {
			lexemes, err := Lex("<")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.LessThan {
				t.Fatalf("Expected less than token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("great than", func(t *testing.T) {
		t.Run("great than: great than token", func(t *testing.T) {
			lexemes, err := Lex(">")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.GreatThan {
				t.Fatalf("Expected great than token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("less than or eq", func(t *testing.T) {
		t.Run("less than or eq: less than or eq token", func(t *testing.T) {
			lexemes, err := Lex("<=")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.LessThanOrEq {
				t.Fatalf("Expected less than or eq token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("great than or eq", func(t *testing.T) {
		t.Run("great than or eq: great than or eq token", func(t *testing.T) {
			lexemes, err := Lex(">=")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.GreatThanOrEq {
				t.Fatalf("Expected great than or eq token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("addition", func(t *testing.T) {
		t.Run("addition: addition token", func(t *testing.T) {
			lexemes, err := Lex("+")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Addition {
				t.Fatalf("Expected addition token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("subtraction", func(t *testing.T) {
		t.Run("subtraction: subtraction token", func(t *testing.T) {
			lexemes, err := Lex("-")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Subtraction {
				t.Fatalf("Expected subtraction token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("multiplication", func(t *testing.T) {
		t.Run("multiplication: multiplication token", func(t *testing.T) {
			lexemes, err := Lex("*")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Multiplication {
				t.Fatalf("Expected multiplication token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("division", func(t *testing.T) {
		t.Run("division: division token", func(t *testing.T) {
			lexemes, err := Lex("/")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.Division {
				t.Fatalf("Expected division token, but received %s", lexemes[0].LexemeType)
			}
		})
	})

	t.Run("parenthesis", func(t *testing.T) {
		t.Run("parenthesis: left", func(t *testing.T) {
			lexemes, err := Lex("(")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.LeftParenthesis {
				t.Fatalf("Expected left parenthesis token, but received %s", lexemes[0].LexemeType)
			}
		})

		t.Run("parenthesis: right", func(t *testing.T) {
			lexemes, err := Lex(")")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 token, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != grammar.RightParenthesis {
				t.Fatalf("Expected right parenthesis token, but received %s", lexemes[0].LexemeType)
			}
		})
	})
}
