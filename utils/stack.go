package utils

type Stack struct {
	array []int
}

func (s *Stack) Push(v int) {
	s.array = append(s.array, v)
}

func (s *Stack) Pop() int {
	val := s.array[len(s.array)-1]
	s.array = s.array[:len(s.array)-1]
	return val
}
