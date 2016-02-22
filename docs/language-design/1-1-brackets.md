# Brackets
## Parentheses
`(`, `)`

### Group expressions
`(3 - 2) + 4 = 5`, but `3 - (2 + 4) = -3`

### Method/function/lambda declaration
`someMethod() {}`<br/>
`someAnotherMethod(param1: Num, param2: String) {}`<br/>
`lambda <- (param: String) => console.print(param)`

### Method/function/lambda call
`someMethod()`<br/>
`someAnotherMethod(42, 'foo')`<br/>
`lambda('foo')`

## Square brackets
`[`, `]`

### Declaration list scope
Declaration list scope contains only compile-time and readonly runtime assignations.
```
[
  pi: 3.14
  add: (a, b) => a + b
  sub: (a, b) => a - b
  mul: (a, b) => a * b
  div: (a, b) => a / b
  
  foo <= get Foo
  bar <= get Bar
]
```

### Array definition
`[1..10]`<br/>
`['q', 'w', 'e', 'r', 't', 'y']`<br/>
```
[
  'q'
  'qw'
  'qwe'
  'qwer'
  'qwert'
  'qwerty'
]
```
```
[
  1.0 0.0 0.0
  0.0 1.0 0.0
  0.0 0.0 1.0
]
```
### Iterators or access by index
`someArray[3]`<br/>
`someAnotherArray['key']`

## Braces
`{`, `}`
* Statemets scopes such as conditional statement, cycles, type/method declaration, ect
* Sequence of statements
* String interpolation

## Angle brackets
`<`, `>`
