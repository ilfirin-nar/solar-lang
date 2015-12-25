# Types
## Object
All types is derived from Object

## Integrated types
### `Num`
Class of numeric types:
* bit number (can be `1` or `0`)
* integer numbers (of 8, 16, 32, 64 bits)
* real floating point numbers (of 32 or 64 bits)

### `Bool`
Can has one of two values: `true` or `false`. Equeals to bit-`Num` type and there is no need for cast bit-`Num` to `Bool` or vice versa.

### `String`
* one character (placed in stack) of 2 byte
* special type of `Array` of characters by 2 byte
 
### `Array`
```
someArray <- [-100..100]
```
Placed in a heap.

### `Lambda`
```
printNewLine <- { console.printNewLine() }
printNewLine is Lambda = true
```
```
showMessage <- m : String => console.print(m)
showMessage is Lambda = true
```
```
drawPoint <- (x : Num, y : Num) : String => painter.drawPoint(x, y)
drawPoint is Lambda = true
```

### `Const`
Constants — it is compile-time defined immutable variables.
```
const Pi: 3.14
```
```
const Six: 2 * 3
```
```
const Six: mult(2, 3)
```
where `mult(Num, Num)` — it is compile-time function:
```
mult(op1 : Num, op2 : Num) => op1 * op2
```

#### `EnumConst`
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

## User defined types
### Interfaces
```
interface Foo {
    someProperty : Num
    
    someMethod
    someAnotherMethod(parameter : String)
    yetSomeAnotherMethod(parameter : String) -> Num
    andLastAnotherMethod(
        parameter : String <- 'some param default value'
        anotherParameter : Num
    ) -> Num
}
```

### Models
```
model Chandler {
    id : Num
	name : 'Chandler'
	age <- 30
}
```

### Services
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
