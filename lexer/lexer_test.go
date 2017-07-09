package lexer

import (
	"testing"
)

func TestLex(t *testing.T) {
	t.Run("empty string — nil", func(t *testing.T) {
		_, err := Lex("")
		if err == nil {
			t.Fatalf("Error is nil")
		}
	})

	t.Run("one space — space lexeme", func(t *testing.T) {
		lexemes, err := Lex(" ")
		if err != nil {
			t.Fatalf("Error")
		}
		if len(lexemes) != 1 {
			t.Fatalf("Expected 1 lexeme, but received %d", len(lexemes))
		}
		if lexemes[0].LexemeType != Space {
			t.Fatalf("Expected space lexeme, but received %s", lexemes[0].LexemeType)
		}
	})

	t.Run("few spaces — space lexeme", func(t *testing.T) {
		lexemes, err := Lex("     ")
		if err != nil {
			t.Fatalf("Error")
		}
		if len(lexemes) != 1 {
			t.Fatalf("Expected 1 lexeme, but received %d", len(lexemes))
		}
		if lexemes[0].LexemeType != Space {
			t.Fatalf("Expected space lexeme, but received %s", lexemes[0].LexemeType)
		}
	})
}
