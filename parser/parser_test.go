package parser

import (
	"evergreen-lang/lexer"
	"evergreen-lang/grammar/ast"
	"testing"
)

func TestParse(t *testing.T) {
	t.Run("print statement", func(t *testing.T) {
		t.Run("number", func(t *testing.T) {
			tokens, _ := lexer.Lex("print 42")
			moduleAST, err := Parse(tokens)
			if err != nil {
				t.Fatalf("Parse error: %s", err.Error())
			}
			if moduleAST == nil {
				t.Fatalf("Empty AST")
			}
			statementsASTs := moduleAST.GetChildren()
			if len(statementsASTs) != 1 {
				t.Fatalf("Expected 1 statement, but received %d", len(statementsASTs))
			}
			printStatementAST := statementsASTs[0]
			if printStatementAST.GetNodeType() != ast.StatementPrint {
				t.Fatalf("Expected print statement, but parsed `%s`", printStatementAST.GetNodeType())
			}
			expressionsASTs := printStatementAST.GetChildren()
			if len(expressionsASTs) != 1 {
				t.Fatalf("Expected 1 expression, but received %d", len(statementsASTs))
			}
			expressionAST := expressionsASTs[0]
			if expressionAST.GetNodeType() != ast.Expression {
				t.Fatalf("Expected expression, but parsed `%s`", printStatementAST.GetNodeType())
			}
			expressionChildrenAST := expressionAST.GetChildren()
			if len(expressionChildrenAST) != 1 {
				t.Fatalf("Expected 1 expr child, but received %d", len(statementsASTs))
			}
			numberAST := expressionChildrenAST[0]
			if numberAST.GetNodeType() != ast.Number {
				t.Fatalf("Expected number, but parsed `%s`", printStatementAST.GetNodeType())
			}
			if numberAST.GetChildren() != nil {
				t.Fatalf("Expected AST leaf")
			}
		})

		t.Run("binary expression", func(t *testing.T) {
			tokens, _ := lexer.Lex("print 42 + 5")
			moduleAST, err := Parse(tokens)
			if err != nil {
				t.Fatalf("Parse error: %s", err.Error())
			}
			if moduleAST == nil {
				t.Fatalf("Empty AST")
			}
			statementsASTs := moduleAST.GetChildren()
			if len(statementsASTs) != 1 {
				t.Fatalf("Expected 1 statement, but received %d", len(statementsASTs))
			}
			printStatementAST := statementsASTs[0]
			if printStatementAST.GetNodeType() != ast.StatementPrint {
				t.Fatalf("Expected print statement, but parsed `%s`", printStatementAST.GetNodeType())
			}
			expressionsASTs := printStatementAST.GetChildren()
			if len(expressionsASTs) != 1 {
				t.Fatalf("Expected 1 expression, but received %d", len(statementsASTs))
			}
			expressionAST := expressionsASTs[0]
			if expressionAST.GetNodeType() != ast.Expression {
				t.Fatalf("Expected expression, but parsed `%s`", printStatementAST.GetNodeType())
			}
			expressionChildrenAST := expressionAST.GetChildren()
			if len(expressionChildrenAST) != 1 {
				t.Fatalf("Expected 1 expr child, but received %d", len(statementsASTs))
			}
			{
				operatorAST := expressionChildrenAST[0]
				if operatorAST.GetNodeType() != ast.OperatorAddition {
					t.Fatalf("Expected number as first operand, but parsed `%s`", printStatementAST.GetNodeType())
				}
				operandsASTs := operatorAST.GetChildren()
				if len(operandsASTs) != 2 {
					t.Fatalf("Expected 2 operands, but received %d", len(statementsASTs))
				}
				{
					firstOperandAST := operandsASTs[0]
					if firstOperandAST.GetNodeType() != ast.Number {
						t.Fatalf("Expected number as first operand, but parsed `%s`", printStatementAST.GetNodeType())
					}
					if firstOperandAST.GetChildren() != nil {
						t.Fatalf("Expected AST leaf")
					}
				}
				{
					secondOperandAST := operandsASTs[1]
					if secondOperandAST.GetNodeType() != ast.Number {
						t.Fatalf("Expected number as second operand, but parsed `%s`", printStatementAST.GetNodeType())
					}
					if secondOperandAST.GetChildren() != nil {
						t.Fatalf("Expected AST leaf")
					}
				}
			}
		})
	})
}
