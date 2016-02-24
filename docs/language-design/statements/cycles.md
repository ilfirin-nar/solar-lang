# Cycles
Cycles based on lambda functions
## N-times cycle
```
a <- 0
42 %
{
  a++
}
a = 42
```
or in inline form
```
a <- 0
42 % a++
a = 42
```

## For each cycle
```
someArray <= [1..10]
someArray % item =>
{
  item++
}
someArray = [2..11]
```
or in inline form
```
someArray <= [1..10]
someArray % item => item++
someArray = [2..11]
```

## Conditional cycle
```
index = 0
index < 5 % {
  console.print('hello!')
  index++
}
```
or in inline form
```
index = 0
index < 5 % { index++ }
```

## Cycle function call
```
addNumber: (array, n) => $ + m
bar: () =>
{
  numbers <= [1..100]
  addNumber(numbers, n)
}
```
