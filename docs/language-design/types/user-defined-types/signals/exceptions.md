# Exceptions
Exceptions — is an error level signals which stop current thread.
```
exception SomethingWrong
[
  message: 'Something is whrong'
]
```

## Throw exception
```
service Foo is IFoo
[
  logger is ILogger
  
  someString: 'It\'s foo!'
  
  foo:
  {
    SomethingWrong !
    <- someString
  }
  
  bar:
  {
    fooResult <- foo() ?! log
    fooResult <> someString
  }
  
  log: signal =>
  {
    logger.log(signal.message)
  }
]
```
