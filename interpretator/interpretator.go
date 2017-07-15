package interpretator

import "evergreen-lang/grammar/ast"

func Evaluate(node ast.Node) error {
	evaluator := newModuleEvaluator(node)
	return evaluator.run()
}
