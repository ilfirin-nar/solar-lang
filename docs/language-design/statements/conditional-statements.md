# Conditional statement
## Inline form
Allows only as an expressions
```
codition ? doSomething()
```
```
condition ? doSomething() ! doAnotherThing()
```
or
```
codition ?
  doSomething()
```
```
condition ?
  doSomething()
  ! doAnotherThing()
```

## Switch statement
```
value ?
  1 ? doSomething()
  2 ? doSecondThing()
  is Number ? doThirdThing()
  ! doAnotherThing()
```
