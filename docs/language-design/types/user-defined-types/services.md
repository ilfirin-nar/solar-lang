# Services
It is stateless types encapsulated only behaviors.

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
