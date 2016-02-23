# Signals
Signals is... It float up by call stack.
```
signal SomethingHappens
```
## Exceptions
Exceptions — is an error level signals which stop current thread.
```
exception SomethingWrong [
  message: 'Something is whrong'
]
```

## Events
Events — it is async (in another thread) signals. 
```
event SomethingHappens
```
