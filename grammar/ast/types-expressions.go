package ast

const (
	ExpOpEquality       = ExpressionType("oeq")
	ExpOpLessThan       = ExpressionType("olt")
	ExpOpGreatThan      = ExpressionType("ogt")
	ExpOpLessThanOrEq   = ExpressionType("olteq")
	ExpOpGreatThanOrEq  = ExpressionType("ogteq")
	ExpOpAddition       = ExpressionType("oadd")
	ExpOpSubtraction    = ExpressionType("osub")
	ExpOpMultiplication = ExpressionType("omul")
	ExpOpDivision       = ExpressionType("odiv")
	ExpValue            = ExpressionType("val")
)

type ExpressionType string
