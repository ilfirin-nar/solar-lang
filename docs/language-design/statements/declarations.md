# Declarations
## Compile-time
```

```

## Runtime
Declaring a local variable is runtime mutable/immutable assignation expression from right side to variable name literal at the left side. Maybe used in declaration scope (by only immutable assignation) and in execution scope (by both immutable and mutable assignations).

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

### Local functions with parameteres
```
greet <- x => {
    console.print(x)
}
greet('Hello!')
```
or inline syntax
```
greet <- x => console.print(x)
greet('Hello!')
```
### Local functions without parameteres
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
