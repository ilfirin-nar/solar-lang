# Contexts
Context is attribute, which supporteds some namespace functionality.
```
@ Unicors
class Beauty {
  // one functionality encapsulated into class with name Beauty
}

@ Elves
class Beauty {
  // another functionality encapsulated into another class with the same name Beauty
}

module SomeModule {
  contexts Unicorns, Elves
}
```
