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
service Foo
[
  logger is Logger
  
  foo:
  {
    SomethingHappens !
  }
  
  bar:
  {
    foo() ?! log
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
