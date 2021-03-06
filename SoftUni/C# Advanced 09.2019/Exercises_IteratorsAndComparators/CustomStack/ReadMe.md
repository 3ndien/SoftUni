
Problem 3.	Stack

Create your custom stack. You are aware of the Stack's structure. There is a collection to store the elements and two functions (not from the functional programming) - to push an element and to pop it. Keep in mind that the first element, which is popped is the last in the collection. The Push method adds an element at the top of the collection and the Pop method returns the top element and removes it. Push and Pop will be the only commands and they will come in the following format:

"Push \{element1}, \{element2}, … \{elementN}

 Pop

… "



Write your custom implementation of Stack<T> and implement IEnumerable<T> interface. Your implementation of the GetEnumerator() method should follow the rules of the Abstract Data Type – Stack (return the elements in reverse order of adding them to the stack).

Input

•	The input will come from the console as lines of commands. 

•	Push and pop will be the only possible commands, followed by integers for the push command and no another input for the pop command. 

Output

•	When you receive END, the input is over. Foreach the stack twice and print all elements each on new line.

Constraints

•	The elements in the push command will be valid integers between [2-31…231-1].

•	The commands will always be valid (always be either Push, Pop or END).

•	If Pop command could not be executed as expected (e.g. no elements in the stack), print on the console: "No elements".

Examples

INPUT:
___


Push 1, 2, 3, 4

Pop

Pop

END


OUTPUT:
___


2

1

2

1



INPUT:
___


Push 1, 2, 3, 4 

Pop

Push 1

END



OUTPUT:
___


1

3

2

1

1

3

2

1


INPUT:
___


Push 1, 2, 3, 4 

Pop

Pop

Pop

Pop

Pop

END


OUTPUT:
___

No elements

