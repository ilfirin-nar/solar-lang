# Examples of language design
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

## Local variable
Without keywords
```
someVar <- 3.14
anotherVar <- 's'
andYetAnotherVar <- 'And yet another string variable'
```
## Statements (and expressions?)
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
