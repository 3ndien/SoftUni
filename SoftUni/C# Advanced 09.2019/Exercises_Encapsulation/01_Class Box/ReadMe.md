
Problem 1.	Class Box Data

You are given a geometric figure box with parameters length, width and height. Model a class Box that that can be instantiated by the same three parameters. Expose to the outside world only methods for its surface area, lateral surface area and its volume (formulas: http://www.mathwords.com/r/rectangular_parallelepiped.htm).

A box’s side should not be zero or a negative number. Аdd data validation for each parameter given to the constructor. Make a private setter that performs data validation internally. 

Input

•	On the first three lines you will get the length, width and height. 

Output

•	On the next three lines print the surface area, lateral surface area and the volume of the box:

Examples

INPUT:
___

2

3

4

OUTPUT:
___

Surface Area - 52.00

Lateral Surface Area - 40.00

Volume - 24.00

INPUT:
___

1.3

1

6


OUTPUT:
___


Surface Area - 30.20

Lateral Surface Area - 27.60

Volume - 7.80


INPUT:
___


2

-3

4


OUTPUT:
___

Width cannot be zero or negative.