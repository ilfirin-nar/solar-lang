package parser

import (
	"evergreen-lang/grammar/ast"
	"evergreen-lang/lexer"
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
				t.Fatalf("Expected 1 expression, but received %d", len(expressionsASTs))
			}
			expressionAST := expressionsASTs[0]
			if expressionAST.GetNodeType() != ast.Expression {
				t.Fatalf("Expected expression, but parsed `%s`", expressionAST.GetNodeType())
			}
			expressionChildrenAST := expressionAST.GetChildren()
			if len(expressionChildrenAST) != 1 {
				t.Fatalf("Expected 1 expr child, but received %d", len(expressionChildrenAST))
			}
			numberAST := expressionChildrenAST[0]
			if numberAST.GetNodeType() != ast.Number {
				t.Fatalf("Expected number, but parsed `%s`", numberAST.GetNodeType())
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

	t.Run("assignment statement", func(t *testing.T) {
		t.Run("number", func(t *testing.T) {
			tokens, _ := lexer.Lex("foo <- 42")
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
			assignmentStatementAST := statementsASTs[0]
			if assignmentStatementAST.GetNodeType() != ast.StatementAssignment {
				t.Fatalf("Expected print statement, but parsed `%s`", assignmentStatementAST.GetNodeType())
			}
			assignmentsChildren := assignmentStatementAST.GetChildren()
			if len(assignmentsChildren) != 2 {
				t.Fatalf("Expected 1 child, but received %d", len(assignmentsChildren))
			}
			{
				identifierAST := assignmentsChildren[0]
				if identifierAST.GetNodeType() != ast.Identifier {
					t.Fatalf("Expected identifier, but parsed `%s`", identifierAST.GetNodeType())
				}
				if identifierAST.GetChildren() != nil {
					t.Fatalf("Expected AST leaf")
				}
			}
			{
				expressionAST := assignmentsChildren[1]
				if expressionAST.GetNodeType() != ast.Expression {
					t.Fatalf("Expected expression, but parsed `%s`", expressionAST.GetNodeType())
				}
				expressionChildrenASTs := expressionAST.GetChildren()
				if len(expressionChildrenASTs) != 1 {
					t.Fatalf("Expected 1 expr child, but received %d", len(expressionChildrenASTs))
				}
				numberAST := expressionChildrenASTs[0]
				if numberAST.GetNodeType() != ast.Number {
					t.Fatalf("Expected number, but parsed `%s`", numberAST.GetNodeType())
				}
				if numberAST.GetChildren() != nil {
					t.Fatalf("Expected AST leaf")
				}
			}
		})
	})
}
