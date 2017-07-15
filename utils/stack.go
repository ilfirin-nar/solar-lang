package utils

type Stack []int

func (s Stack) Push(v int) {
	_ = append(s, v)
}

func (s Stack) Pop() int {
	return s[len(s)-1]
}
