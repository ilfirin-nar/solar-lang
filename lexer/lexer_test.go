package lexer

import (
	"testing"
)

func TestLex(t *testing.T) {
	t.Run("counts", func(t *testing.T) {
		t.Run("empty string — nil", func(t *testing.T) {
			_, err := Lex("")
			if err == nil {
				t.Fatalf("Error is nil")
			}
		})

		t.Run("one word — one lexeme", func(t *testing.T) {
			lexemes, err := Lex("word")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 lexeme, but received %d", len(lexemes))
			}
		})

		t.Run("few words — few lexemes", func(t *testing.T) {
			lexemes, err := Lex("kjhHlJHlHlHLHlH RIdd2222")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 3 {
				t.Fatalf("Expected 2 lexemes, but received %d", len(lexemes))
			}
		})
	})

	t.Run("spaces", func(t *testing.T) {
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

		t.Run("tabs and spaces — space lexeme", func(t *testing.T) {
			lexemes, err := Lex("	  	  ")
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
	})

	t.Run("newlines", func(t *testing.T) {
		t.Run("one newline — newline lexeme", func(t *testing.T) {
			lexemes, err := Lex("\n")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 lexeme, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != NewLine {
				t.Fatalf("Expected newline lexeme, but received %s", lexemes[0].LexemeType)
			}
		})

		t.Run("two newlines — newline lexeme", func(t *testing.T) {
			lexemes, err := Lex("\n\n")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 lexeme, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != NewLine {
				t.Fatalf("Expected newline lexeme, but received %s", lexemes[0].LexemeType)
			}
		})

		t.Run("few newlines — newline lexeme", func(t *testing.T) {
			lexemes, err := Lex("\n\n\n\n\n")
			if err != nil {
				t.Fatalf("Error")
			}
			if len(lexemes) != 1 {
				t.Fatalf("Expected 1 lexeme, but received %d", len(lexemes))
			}
			if lexemes[0].LexemeType != NewLine {
				t.Fatalf("Expected newline lexeme, but received %s", lexemes[0].LexemeType)
			}
		})
	})
}
