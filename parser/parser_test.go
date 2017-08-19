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
			if printStatementAST.GetNodeType() != ast.Statement {
				t.Fatalf("Expected statement, but parsed `%s`", printStatementAST.GetNodeType())
			}
			if printStatementAST.(*ast.StatementNode).GetStatementType() != ast.StatementPrint {
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
			if numberAST.GetNodeType() != ast.Leaf {
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
			if printStatementAST.GetNodeType() != ast.Statement {
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
			{
				if expressionAST.(*ast.ExpressionNode).GetExpressionType() != ast.ExpOpAddition {
					t.Fatalf("Expected addition operator expression")
				}
				operandsASTs := expressionAST.GetChildren()
				if len(operandsASTs) != 2 {
					t.Fatalf("Expected 2 operands, but received %d", len(statementsASTs))
				}
				{
					firstOperandAST := operandsASTs[0]
					if firstOperandAST.GetNodeType() != ast.Leaf {
						t.Fatalf("Expected number as first operand, but parsed `%s`", printStatementAST.GetNodeType())
					}
					if firstOperandAST.GetChildren() != nil {
						t.Fatalf("Expected AST leaf")
					}
				}
				{
					secondOperandAST := operandsASTs[1]
					if secondOperandAST.GetNodeType() != ast.Leaf {
						t.Fatalf("Expected number as second operand, but parsed `%s`", printStatementAST.GetNodeType())
					}
					if secondOperandAST.GetChildren() != nil {
						t.Fatalf("Expected AST leaf")
					}
				}
			}
		})

		t.Run("number", func(t *testing.T) {
			tokens, _ := lexer.Lex("	print 42\n")
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
			if assignmentStatementAST.GetNodeType() != ast.Statement {
				t.Fatalf("Expected print statement, but parsed `%s`", assignmentStatementAST.GetNodeType())
			}
			assignmentsChildren := assignmentStatementAST.GetChildren()
			if len(assignmentsChildren) != 2 {
				t.Fatalf("Expected 1 child, but received %d", len(assignmentsChildren))
			}
			{
				identifierAST := assignmentsChildren[0]
				if identifierAST.GetNodeType() != ast.Leaf {
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
				if numberAST.GetNodeType() != ast.Leaf {
					t.Fatalf("Expected number, but parsed `%s`", numberAST.GetNodeType())
				}
				if numberAST.GetChildren() != nil {
					t.Fatalf("Expected AST leaf")
				}
			}
		})

		t.Run("expression with parenthesises: one statement, expr tree inside", func(t *testing.T) {
			tokens, _ := lexer.Lex("foo <- 42 + (5 - 3)")
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
			operandsASTs := statementsASTs[0].GetChildren()
			if len(operandsASTs) != 2 {
				t.Fatalf("Expected 2 operands, but received %d", len(operandsASTs))
			}
			if operandsASTs[0].GetNodeType() != ast.Leaf {
				t.Fatalf("Expected first operand is leaf, but received %d", operandsASTs[0].GetNodeType())
			}
			if operandsASTs[1].GetNodeType() != ast.Expression {
				t.Fatalf("Expected first operand is expression, but received %d", operandsASTs[1].GetNodeType())
			}
		})

		t.Run("expression, then print: two statements", func(t *testing.T) {
			tokens, _ := lexer.Lex("foo <- 42 + (5 - 3)\nprint foo")
			moduleAST, err := Parse(tokens)
			if err != nil {
				t.Fatalf("Parse error: %s", err.Error())
			}
			if moduleAST == nil {
				t.Fatalf("Empty AST")
			}
			statementsASTs := moduleAST.GetChildren()
			if len(statementsASTs) != 2 {
				t.Fatalf("Expected 2 statements, but received %d", len(statementsASTs))
			}
		})
	})
}
