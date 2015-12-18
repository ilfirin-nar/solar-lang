# Solar language design
1. [Literals](literals.md)

## Operators
### Unary
#### Infix
Syntax | Description
-------|-------
`-` | Inverse sign
`!`| Negation

#### Postfix
Syntax | Description
-------|-------
`++` | Increment
`--` | Decrement

### Binary
Syntax | Description
-------|-------
`<-` | Assigment
`+` | Addition
`-` | Subtraction
`*` | Multiplication
`/` | Division
`%` | Modulo
`=` | Equality
`>>` | Bitwise right shift 
`<<` | Bitwise left shift 
`&` | Bitwise conjunction
`|` | Bitwise (inclusive) disjunction
`^` | Bitwise exclusive disjunction
`and` | Logical conjunction
`or` | Logical (inclusive) disjunction
`xor` | Logical exclusive disjunction
`is`| Check type

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
#### With one branch
```
condition ? {
    doSomething()
}
```

#### With many branches
##### 2-branches case
```
condition ? {
  doSomething()
} : {
  doAnotherThing()
}
```

##### N-branches case
```
firstcondition ? {
    doSomething()
} secondCondition ? {
    doAnotherThing()
} thirdCondition ? {
    doYetAnotherThing()
} ... : {
    doLastAnotherThing()
}
```

#### Inline form
Allows only as an expressions
```
codition ? doSomething()
```
```
condition ? doSomething() : doAnotherThing()
```

### Switch statement
```
value ? {
    1: {
       console.print('value = 1')
    }
    2: console.print('value = 2')
    3: console.print('value = 3')
    : console.print('value not equal 1, 2 or 3')
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
someArray: item => item++
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
#### Closures
```
greeting <- 'Hello!'
greet <- {
    console.print(greeting)
}
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
```
someArray <- [-100..100]
```
Placed in a heap.

#### `Lambda`
```
someVar <- { console.printNewLine() }
someVar is Lambda = true
```

#### `Const`
```
const Pi: 3.14
```

##### `EnumConst`
```
const Colors { Red, Green, Blue }
```
```
const Colors {
    Red: 'Red color',
    Green: 'Green color',
    Blue: 'Blue color'
}
```
```
const Colors {
    Red: 1,
    Green: 2,
    Blue: 3
}
```

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
