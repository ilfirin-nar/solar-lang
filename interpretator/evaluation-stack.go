package interpretator

import (
	"evergreen-lang/utils"
	"fmt"
)

func newEvaluationStack() *evaluationStack {
	return &evaluationStack{stack: &utils.Stack{}}
}

type evaluationStack struct {
	stack *utils.Stack
}

func (s evaluationStack) Push(v int) {
	s.stack.Push(v)
}

func (s evaluationStack) Pop() int {
	return s.stack.Pop()
}

func (s evaluationStack) Add() {
	b := s.stack.Pop()
	a := s.stack.Pop()
	s.stack.Push(a + b)
}

func (s evaluationStack) Sub() {
	b := s.stack.Pop()
	a := s.stack.Pop()
	s.stack.Push(a - b)
}

func (s evaluationStack) Mul() {
	b := s.stack.Pop()
	a := s.stack.Pop()
	s.stack.Push(a * b)
}

func (s evaluationStack) Div() {
	b := s.stack.Pop()
	a := s.stack.Pop()
	s.stack.Push(a / b)
}

func (s evaluationStack) Print() {
	v := s.stack.Pop()
	fmt.Println(v)
}
