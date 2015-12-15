# Solar language design
## Literals
### Brackets
#### Parentheses
`(`, `)`

##### Group expressions
`(3 - 2) + 4 = 5`, but `3 - (2 + 4) = -3`

##### Method declaration
`someMethod()`<br/>
`someAnotherMethod(param1 Integer, param2 String)`

##### Method call
`someMethod()`<br/>
`someAnotherMethod(42, 'foo')`

#### Square brackets
`[`, `]`

##### Array definition
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
##### Iterators or access by index
`someArray[3]`<br/>
`someAnotherArray['key']`

#### Angle brackets
`<`, `>`

#### Braces
`{`, `}`
* Statemets scopes such as conditional statement, cycles, type/method declaration, ect
* String interpolation

### Numbers
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
* `is` — check type

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
(2 + 2) * getNumber(3) + 4 * ('42' to Int)
```

### Type conversion expression
`42 to String = '42'`<br/>
`'42' to Int = 42`<br/>
`(('1' to Int) to Bool) = true`

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
codition ? doSomething()                            # inline form only in expression variant
```
```
condition ? {
    doSomething()
}
```
```
condition ? doSomething() : doAnotherThing()        # inline form only in expression variant
```
```
condition ? {
    doSomething()
} : {
    doAnotherThing()
}
```

### Cycles
Cycles based on lambda functions
#### N-times cycle
```
a = 0
42 => {
    a++
}
```
or in inline form
```
a = 0
42 => a++
```

#### For each cycle
```
someArray = [1..10]
someArray: item => {
    item++
}
```
or in inline form
```
someArray = [1..10]
someArray: item -> item++
```

#### Conditional cycle
```
index = 0
index < 5 => {
    console.print('hello!')
    index++
}
```
or in inline form
```
index = 0
index < 5 => index++
```

### Local functions (lambdas)
#### With parameteres
```
greet <- (x : String) => {
    console.print(x)
}
greet('Hello!')
```
or inline syntax
```
greet <- (x : String) => console.print(x)
greet('Hello!')
```
#### Without parameteres
```
greet <- {
    console.print('Hello')
}
greet()
```
or inline syntax
```
greet <- { console.print('Hello') }
greet()
```

## Types
### Object
All types is derived from Object

### Integrated types
#### `Num`
Class of numeric types:
* bit number (can be `1` or `0`)
* integer numbers (of 8, 16, 32, 64 bits)
* real floating point numbers (of 32 or 64 bits)

#### `Bool`
Can has one of two values: `true` or `false`. Equeals to bit-`Num` type and there is no need for cast bit-`Num` to `Bool` or vice versa.

#### `String`
* one character (placed in stack) of 2 byte
* special type of `Array` of characters by 2 byte
 
#### `Array`
`someArray <- [-100..100]`
Placed in a heap.

### User defined types
#### Interfaces
```
interface Foo {
    someProperty : Num
    
    someMethod
    someAnotherMethod(parameter : String)
    yetSomeAnotherMethod(parameter : String) -> Num
    andLastAnotherMethod(
        parameter : String <- 'some param default vaue'
        anotherParameter : Num
    ) -> Num
}
```

#### Models
```
model Chandler {
    id : Num
	name : 'Chandler'
	age <- 30
}
```

#### Services
```
interface PersonReader {
    read(id : Num) -> Person
    read(id : Num, count : Num) -> Person
}

service ChandlerReader : PersonReader {
    get Session
    storage <= get PersonStorage
    checker <= get PersonChecker
    
    name <= 'Chandler'
    
    constructor {
        storage.initialize(session)
        checker.initialize(session)
    }
    
    read(id) -> Person {
        person <- storage.get(id)
        checker.checkName(person, name) ? {
            person
        } : {
            storage.getFirst()
        }
    }
    
    read(id, count) -> Person[] {
        persons <- storage.get(id, count)
        persons % {
            !checker.checkName($, name) ? {
                $ <- storage.getFirst()
            }
        }
        persons
    }
}
```
