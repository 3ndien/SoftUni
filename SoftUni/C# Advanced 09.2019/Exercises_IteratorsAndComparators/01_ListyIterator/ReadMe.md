
Problem 1.	ListyIterator

Create a generic class ListyIterator. The collection, which it will iterate through, should be received in the constructor. You should store the elements in a List. The class should have three main functions:

•	Move - should move an internal index position to the next index in the list. The method should return true, if it had successfully moved the index and false if there is no next index.

•	HasNext - should return true, if there is a next index and false, if the index is already at the last element of the list.

•	Print - should print the element at the current internal index. Calling Print on a collection without elements should throw an appropriate exception with the message "Invalid Operation!". 

By default, the internal index should be pointing to the 0th index of the List. Your program should support the following commands:

| COMMAND           | RETURN TYPE   | DESCRIPTION   |
| -------------     | ------------- | ------------- |
| Create {e1 e2 …}  |   void        | Creates a ListyIterator from the specified collection. In case of a Create command without any elements, you should create a ListyIterator with an empty collection.|
| Move              |  boolean      | This command should move the internal index to the next index.                                                                                                      |
| Print             |  void         | This command should print the element at the current internal index.                                                                                                |
| HasNext           |  boolean      | Returns whether the collection has a next element.                                                                                                                  |
| END               |  void         | Stops the input.                                                                                                                                                    |

____


Your program should catch any exceptions thrown because of the described validations - calling Print on an empty collection - and print their messages instead.

Input

•	Input will come from the console as lines of commands. 

•	The first line will always be the Create command in the input. 

•	The last command received will always be the END command.

Output

•	For every command from the input (with the exception of the END and Create commands), print the result of that command on the console, each on a new line. 

•	In case of Move or HasNext commands, print the return value of the methods.

•	In case of a Print command you don’t have to do anything additional as the method itself should already print on the console.

Constraints

•	There will always be only one Create command and it will always be the first command passed.

•	The number of commands received will be between [1…100].

•	The last command will always be the only END command.

Examples

INPUT:
___


Create

Print

END


OUTPUT:
___

Invalid Operation!

INPUT:
___


Create Stefcho Goshky

HasNext

Print

Move

Print

END


OUTPUT:
___


True

Stefcho

True

Goshky

INPUT:
___


Create 1 2 3

HasNext

Move

HasNext

HasNext

Move

HasNext

END


OUTPUT:
___


True

True

True

True

True

False
