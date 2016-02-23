# Contexts
Context is attribute, which supporteds some namespace functionality.
```
@ Unicors
model Beauty {
  // one functionality encapsulated into class with name Beauty
}

@ Elves
model Beauty {
  // another functionality encapsulated into another class with the same name Beauty
}

module SomeModule {
  contexts Unicorns, Elves
}
```
