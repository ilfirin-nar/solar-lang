# `Function`
Function is a sequence of actions.
```
printNewLine: { console.printNewLine() }
printNewLine is Function = true
```
```
showMessage: m => console.print(m)
showMessage is Function = true
```
```
drawPoint: (x, y) => painter.drawPoint(x, y)
drawPoint is Function = true
```
## Functions signatures
For functions
```
(x, y) => painter.getPoint(x, y)
getSomePoint: (x, y, z) => painter.getPoint(x, y) + painter.getPoint(x, z)
```
signature is
```
(Number, Number) -> Point
getSomePoint(Number, Number) -> Point
```
