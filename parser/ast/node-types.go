package ast

const (
	Module                 = NodeType("mod")
	Statement              = NodeType("st")
	StatementPrint         = NodeType("pr")
	StatementAssignment    = NodeType("sass")
	Expression             = NodeType("expr")
	OperatorAssignment     = NodeType("oass")
	OperatorEquality       = NodeType("eq")
	OperatorLessThan       = NodeType("lt")
	OperatorGreatThan      = NodeType("gt")
	OperatorLessThanOrEq   = NodeType("lteq")
	OperatorGreatThanOrEq  = NodeType("gteq")
	OperatorAddition       = NodeType("add")
	OperatorSubtraction    = NodeType("sub")
	OperatorMultiplication = NodeType("mul")
	OperatorDivision       = NodeType("div")
	Variable               = NodeType("var")
	Number                 = NodeType("num")
)

type NodeType string
