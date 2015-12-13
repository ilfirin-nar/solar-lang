# Examples of language design
## Literals
* Numbers: `42`, `3.14`, `0x4fd2`
* Characters: `'d'`, `'S'`, `'5'`
* Strings: `'Some string'`, `'Some string with numbers: 42!'`

## Operators
### Unary
* `+`
* `-`
* `!`

### Binary
* `<-`
* `+`
* `-`
* `*`
* `/`
* `%`
* `=`
* `&`
* `|`
* `^`
* `and`
* `or`
* `xor`

## Expressions
* `(3.14 * (2 + 2 - 1) + 2) / 0.5`
* `'Some' + ' ' + 'string'`

## Statements
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

## Local variable
```
someVar <- 3.14
anotherVar <- 's'
andYetAnotherVar <- 'And yet another string variable'
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
