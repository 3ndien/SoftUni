
Problem 2.	Black Box Integer

Provided skeleton.

You are helping a buddy of yours, who is still in the OOP Basics course - his name is Peshoslav (not to be mistaken with real people or trainers). He is rather slow and made a class with all private members. Your tasks are to instantiate an object from his class (always with start value 0) and then invoke the different methods it has. Your restriction is to not change anything in the class itself (consider it a black box). You can look at his class but don't touch anything! The class itself is called BlackBoxInt. It is a wrapper for the int primitive.

The methods this class has are:

•	Add(int)

•	Subtract(int)

•	Multiply(int)

•	Divide(int)

•	LeftShift(int)

•	RightShift(int)

Input

The input will consist of lines in the form:

\<method name>_\<value>

For instance: Add_115

Input will always be valid and in the format described, so there is no need to check it explicitly. You stop receiving input when you encounter the command "END".

Output

Each command (except the END one) should print the current value of innerValue of the BlackBoxInt object you instantiated. Don't cheat by overriding ToString() in the class - you must get the value from the private field.

Examples

INPUT:
___


Add_999999

Subtract_19

Divide_4

Multiply_2

RightShift_1

LeftShift_3

END


OUTPUT:
___


999999

999980

249995

499990

249995

1999960
