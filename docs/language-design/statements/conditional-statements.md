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
