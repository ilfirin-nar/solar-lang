# Signals
## About
Signals float up by call stack.
```
signal SomethingHappens
[
  message: 'Something happens!'
]
```

## Throw signal
```
service Foo is IFoo
[
  logger is ILogger
  
  someString: 'It\'s foo!'
  
  foo:
  {
    SomethingHappens !
    <- someString
  }
  
  bar:
  {
    fooResult <- foo() ?! log
    fooResult = someString ?
  }
  
  log: signal =>
  {
    logger.log(signal.message)
  }
]
```

## Content
1. [Exceptions](signals/exceptions.md)
2. [Events](signals/events.md)
