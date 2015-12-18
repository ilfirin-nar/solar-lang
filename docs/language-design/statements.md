# Statements
## Expressions
### Expressions is a statemets!
```
(3.14 * (2 + 2 - 1) + 2) / 0.5`
'Some' + ' ' + 'string'
getNumber(3)
```

### Expressions contains of another expressions or literals
```
(2 + 2) * getNumber(3) + 4 * ('42' to Int)
```

## Type conversion expression
`42 to String = '42'`<br/>
`'42' to Int = 42`<br/>
`(('1' to Int) to Bool) = true`

## Declare local variable
### Declare and initialize variable statement
```
someVar <- 3.14
anotherVar <- 's'
andYetAnotherVar <- 'And yet another string variable'
```

### Declare uninitialized variable statement
```
someVar
someAnotherVar <- 42
someVar <- someAnotherVar
```
## Conditional statement
### With one branch
```
condition ? {
    doSomething()
}
```

### With many branches
#### 2-branches case
```
condition ? {
  doSomething()
} : {
  doAnotherThing()
}
```

#### N-branches case
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

### Inline form
Allows only as an expressions
```
codition ? doSomething()
```
```
condition ? doSomething() : doAnotherThing()
```

## Switch statement
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

## Cycles
Cycles based on lambda functions
### N-times cycle
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

### For each cycle
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

### Conditional cycle
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

## Local functions (lambdas)
### With parameteres
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
### Without parameteres
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
### Closures
```
greeting <- 'Hello!'
greet <- {
    console.print(greeting)
}
greet()
```
