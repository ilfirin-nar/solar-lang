# Solar language design
## Literals
### Brackets
#### Parentheses
`(`, `)`
* Group expressions: `(3 - 2) + 4` equal `5`, but `3 - (2 + 4)` equal `-3`
* Method declaration: `someMethod()`, `someAnotherMethod(param1 Integer, param2 String)`
* Method call: `someMethod()`, `someAnotherMethod(42, 'foo')`

#### Square brackets
`[`, `]`
* Array definition: `[1..10]`
* Iterators or access by index: `someArray[3]`

#### Angle brackets
`<`, `>`
#### Braces
`{`, `}`
* Into some statemets such as conditional statement, cycles, type/method declaration, ect
* String interpolation

### Number
* `42` — integer number
* `3.14` — real number
* `0x4fd2` — HEX form of number

### Characters and strings
#### Characters
`'d'`, `'S'`, `'5'`
#### Strings
`'Some string'`, `'Some string with numbers: 42!'`
##### String escape sequences
* `'\n'`
* `'\t'`
* `'\v'`
* `'\\'`
* `'\''`

###### String interpolation
```
firstName <- 'Mary'
lastName <- 'Kass'
age <- 24
'Is {firstName} {lastName} loved me? She is {age} years old.'
```

## Operators
### Unary
#### Infix
* `-` — inverse sign
* `!` — negation
#### Postfix
* `++` — increment
* `--` — decrement

### Binary
* `<-` — assigment
* `+` — addition
* `-` — subtraction
* `*` — multiplication
* `/` — division
* `%` — modulo
* `=` — equality
* `>>` — bitwise right shift 
* `<<` — bitwise left shift 
* `&` — bitwise conjunction
* `|` — bitwise (inclusive) disjunction
* `^` — bitwise exclusive disjunction
* `and` — logical conjunction
* `or` — logical (inclusive) disjunction
* `xor` — logical exclusive disjunction


## Statements
### Expressions
#### Expressions is a statemets!
```
(3.14 * (2 + 2 - 1) + 2) / 0.5`
'Some' + ' ' + 'string'
getNumber(3)
```
#### Expressions contains of another expressions or literals
```
(2 + 2) * getNumber(3) + 4*('42' to Int)
```

### Declare local variable
#### Declare and initialize variable statement
```
someVar <- 3.14
anotherVar <- 's'
andYetAnotherVar <- 'And yet another string variable'
```
#### Declare uninitialized variable statement
```
someVar
someAnotherVar <- 42
someVar <- someAnotherVar
```
### Conditional statement
Presentet in one of next forms:
```
codition ? doSomething()
```
```
condition ? {
    doSomething()
}
```
```
condition ? doSomething() : doAnotherThing()
```
```
condition
    ? doSomethingWithLongLongLongName()
    : doAnotherThingWithLongLongLongName()
```
```
condition ? {
    doSomething()
} : {
    doAnotherThing()
}
```
## Types
### Interfaces
```
interface Person {
	id -> Integer                               // read only property (method, which only returns a value)
	name => String                              // readable and writable property
	say(word String "Anything") >> String       // method with parameter word type of String and return value type of String
	greet -> String                             // method without parameters
	go(direction Direction)                     // method without return value
	lookAround                                  // method without parameters and return value
}

...

person <- get new Person                      // get some new object, which implements Person interface
output <- get Output                      // get some registered output, console, for example
greeting <- person.greet
output.write(greeting)

output.writeLine("Person name is ")
person.name != "Chandler" ? {
    output.write(person.name)
    person.name <- "Chandler"
} : output.write(person.name)
    
...
```
## Other
```
/*
model John is Person {
	Id -> string {
		name.Length == 0 ?
			"This is empty name"
			"This is " + name
	}

	Name -> string
		<= name + namePostfix
		=>

	namePostfix -> "is a Person"
}

interface Reader(TPerson) {
	Read -> TPerson
}

service GroupReader is Reader(Group) {
	Read -> Group {
		var group = get Group

	}
}
*/
```
