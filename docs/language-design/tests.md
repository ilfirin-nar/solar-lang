# Tests 
## Declaraction
```
model Person {
    id -> Num
    name -> String
}

service PersonReader {
    dao <= get PersonDao
    checker <= get PersonChecker
    
    read(id : Num) -> Person {
        person <= dao.Select(id)
        checker.Check(person)
        <= person
    }
}

tests PersonReader {
    test read {
        
    }
}
```
