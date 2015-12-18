# Literals
## Brackets
### Parentheses
`(`, `)`

#### Group expressions
`(3 - 2) + 4 = 5`, but `3 - (2 + 4) = -3`

#### Method/function/lambda declaration
`someMethod() {}`<br/>
`someAnotherMethod(param1: Num, param2: String) {}`<br/>
`lambda <- (param: String) => console.print(param)`

#### Method/function/lambda call
`someMethod()`<br/>
`someAnotherMethod(42, 'foo')`<br/>
`lambda('foo')`

### Square brackets
`[`, `]`

#### Array definition
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
#### Iterators or access by index
`someArray[3]`<br/>
`someAnotherArray['key']`

### Angle brackets
`<`, `>`

### Braces
`{`, `}`
* Statemets scopes such as conditional statement, cycles, type/method declaration, ect
* Sequence of statements
* String interpolation

## Numbers
* `42` — integer number
* `3.14` — real number
* `0x4fd2` — HEX form of number

## Characters and strings
### Characters
`'d'`, `'S'`, `'5'`
### Strings
`'Some string'`, `'Some string with numbers: 42!'`
#### String escape sequences
* `'\n'`
* `'\t'`
* `'\v'`
* `'\\'`
* `'\''`

#### String interpolation
```
firstName <- 'Mary'
lastName <- 'Kass'
age <- 24
'Is {firstName} {lastName} loved me? She is {age} years old.'
```
