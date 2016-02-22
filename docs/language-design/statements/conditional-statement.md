# Conditional statement
## With one branch
```
condition ? {
    doSomething()
}
```

## With many branches
### 2-branches case
```
condition ? {
  doSomething()
} ! {
  doAnotherThing()
}
```

### N-branches case
```
firstcondition ? {
    doSomething()
} secondCondition ? {
    doAnotherThing()
} thirdCondition ? {
    doYetAnotherThing()
} ... ! {
    doLastAnotherThing()
}
```

## Inline form
Allows only as an expressions
```
codition ? doSomething()
```
```
condition ? doSomething() ! doAnotherThing()
```
