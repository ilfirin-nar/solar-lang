package lexer

const (
	InvalidLexemeType = LexemeType("INVALID")
	Space             = LexemeType("[[:blank:]]+")
	NewLine           = LexemeType("[\n]+")
	Variable          = LexemeType("[[:word:]]")
	Assignment        = LexemeType("<-")
	Equal             = LexemeType("=")
	lessThan          = LexemeType("<")
	GreatThan         = LexemeType(">")
	LessThanOrEq      = LexemeType("<=")
	GreatThanOrEq     = LexemeType(">=")
	Addition          = LexemeType("+")
	Subtraction       = LexemeType("-")
	Multiply          = LexemeType("*")
	Division          = LexemeType("/")
	Print             = LexemeType("print")
)

type LexemeType string
