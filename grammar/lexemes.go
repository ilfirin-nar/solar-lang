package grammar

const (
	InvalidLexemeType = LexemeType("INVALID")
	Space             = LexemeType("^[[:blank:]]+$")
	NewLine           = LexemeType("^[\n]+$")
	NumericLiteral    = LexemeType("^[[:digit:]]+$")
	Assignment        = LexemeType("^<-$")
	Equality          = LexemeType("^=$")
	LessThan          = LexemeType("^<$")
	GreatThan         = LexemeType("^>$")
	LessThanOrEq      = LexemeType("^<=$")
	GreatThanOrEq     = LexemeType("^>=$")
	Addition          = LexemeType("^\\+$")
	Subtraction       = LexemeType("^-$")
	Multiplication    = LexemeType("^\\*$")
	Division          = LexemeType("^/$")
	PrintKeyword      = LexemeType("^print$")
	Identifier        = LexemeType("^([a-z])+([a-zA-Z0-9])*$")
	LeftParenthesis   = LexemeType("^\\($")
	RightParenthesis  = LexemeType("^\\)$")
)

type LexemeType string
