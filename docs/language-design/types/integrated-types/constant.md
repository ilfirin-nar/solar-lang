# `Constant`
`Constant` — it is compile-time defined immutable variables. 
```
Pi: 3.14
```
```
Six: 2 * 3
```
```
Six: mult(2, 3)
```
where `mult(Number, Number)` — it is compile-time function accessable throught interface:
```
mult: (op1, op2) => op1 * op2
```

## Enumerable `Constant`
```
Colors: Red, Green, Blue
```
```
Colors: [
  Red: 'Red color'
  Green: 'Green color'
  Blue: 'Blue color'
]
```
```
Colors: [
  Red: 1
  Green: 2
  Blue: 3
]
```
