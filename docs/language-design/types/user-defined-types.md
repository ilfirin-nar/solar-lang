# User defined types
Into square brackets `[]` defines declarations as a data.
Into braces `{}` defines sequences of actions.

## Interfaces
```
interface Foo [
  someProperty: Number
    
  someMethod
  someAnotherMethod(String)
  yetSomeAnotherMethod(String) -> Num
  andLastAnotherMethod(
    String <- 'some param default value'
    Num
  ) -> Num
]
```

## Models
```
model Chandler [
  id: Number              # Variable (run time)
  name: 'Chandler'        # Constant (compile time)
  age <= 30               # Immutable variable (run time)
]
```

## Services
```
interface PersonReader [
  read(id: Number) -> Person
  read(id: Number, count: Number) -> Person
]

service ChandlerReader : PersonReader [
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
      not checker.checkName($, name) ? {
        $ <- storage.getFirst()
      }
    }
    persons
  }
]
```

## Attributes
```
attribute Bold
```

## Signals
Signals is... It float up by call stack.
```
signal SomethingHappens
```
### Exceptions
Exceptions — is an error level signals which stop current thread.
```
exception SomethingWrong [
  message: 'Something is whrong'
]
```

### Events
Events — it is async (in another thread) signals. 
```
event SomethingHappens
```
