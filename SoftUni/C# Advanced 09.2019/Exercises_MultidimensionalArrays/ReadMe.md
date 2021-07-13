1.	Diagonal Difference

Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).

|     |col 0| col 1 | col 2 |
|   - |-    | -     | -     |
|row 0|11   | 2     | 4     |
|row 1|4    | 5     | 6     |
|row2 |10   | 8     |-12    |

primary diagonal

sum = 11 + 5 - 12 = 4

|     |col 0| col 1 | col 2 |
|   - |-    | -     | -     |
|row 0|11   | 2     | 4     |
|row 1|4    | 5     | 6     |
|row2 |10   | 8     |-12    |

secondary diagonal

sum = 4 + 5 + 10 = 19



Input

•	On the first line, you are given the integer N – the size of the square matrix

•	The next N lines holds the values for every row – N numbers separated by a space

Output

•	Print the absolute difference between the sums of the primary and the secondary diagonal

Examples

INPUT:
___

3

11 2 4

4 5 6

10 8 -12


OUTPUT:
___

15

COMMENT:
___


Primary diagonal: sum = 11 + 5 + (-12) = 4

Secondary diagonal: sum = 4 + 5 + 10 = 19

Difference: |4 - 19| = 15


____

2.	2x2 Squares in Matrix

Find the count of 2 x 2 squares of equal chars in a matrix.

Input

•	On the first line, you are given the integers rows and cols – the matrix’s dimensions

•	Matrix characters come at the next rows lines (space separated)

Output

•	Print the number of all the squares matrixes you have found

Examples

INPUT:
___

3 4
A B B D
E B B B
I J B B

OUTPUT:
___

2


COMMENT:
___


Two 2 x 2 squares of equal cells:

A [B B] D 
  
E [B B] B 

I J B B 

___

A B B D

E B [B B]

I J [B B]


INPUT:
___


2 2

a b

c d


OUTPUT:
___


0


COMMENT:
___

No 2 x 2 squares of equal cells exist.

___


3.	Maximal Sum

Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

Input

•	On the first line, you will receive the rows N and columns M. On the next N lines you will receive each row with its columns

Output

•	Print the elements of the 3 x 3 square as a matrix, along with their sum

Examples


INPUT:
___


4 5

1 5 5 2 4

2 1 4 14 3

3 7 11 2 8

4 8 12 16 4


MATRIX
____


| c0| c1| c2| c3| c4|
| - | - | - | - | - |
| 1 | 5 | 5 | 2 | 4 |
| 2 | 1 | 4 | 14| 3 |
| 3 | 7 | 11| 2 | 8 |
| 4 | 8 | 12| 16| 4 |


OUTPUT:
___


Sum = 75

1 4 14

7 11 2

8 12 16


___



4.	Matrix shuffling

Write a program which reads a string matrix from the console and performs certain operations with its elements. User input is provided in a similar way like in the problems above – first you read the dimensions and then the data. 

Your program should then receive commands in format: "swap row1 col1 row2c col2" where row1, row2, col1, col2 are coordinates in the matrix. In order for a command to be valid, it should start with the "swap" keyword along with four valid coordinates (no more, no less). You should swap the values at the given coordinates (cell [row1, col1] with cell [row2, col2]) and print the matrix at each step (thus you'll be able to check if the operation was performed correctly). 

If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or the given coordinates do not exist), print "Invalid input!" and move on to the next command. Your program should finish when the string "END" is entered.

Examples

INPUT:
___


2 3

1 2 3

4 5 6

swap 0 0 1 1

swap 10 9 8 7

swap 0 1 1 0

END


OUTPUT:
___


5 2 3

4 1 6

Invalid input!

5 4 3

2 1 6


INPUT:
___


1 2

Hello World

0 0 0 1

swap 0 0 0 1

swap 0 1 0 0

END


OUTPUT:
___


Invalid input!

World Hello

Hello World


___


5.	Snake Moves

You are walking in the park and you encounter a snake! You are terrified, and you start running zig-zag, so the snake starts following you. 

You have a task to visualize the snake’s path in a square form. A snake is represented by a string. The isle is a rectangular matrix of size NxM. A snake starts climbing the stairs from the bottom-right corner and slithers its way up in a zigzag – first it moves left until it reaches the left wall, it climbs on the next row and starts moving right, then on the third row, moving left again and so on. The first cell (bottom-right corner) is filled with the first symbol of the snake, the second cell (to the left of the first) is filled with the second symbol, etc. The snake is as long as it takes in order to fill the stairs completely – if you reach the end of the string representing the snake, start again at the beginning. After you fill the matrix with the snake’s path, you should print it.



Input

•	The input data should be read from the console. It consists of exactly three lines

•	On the first line, you’ll receive the dimensions of the stairs in format: "N M", where N is the number of rows, and M is the number of columns. They’ll be separated by a single space

•	On the second line you’ll receive the string representing the snake



Output

•	The output should be printed on the console. It should consist of N lines

•	Each line should contain a string representing the respective row of the matrix



Constraints

•	The dimensions N and M of the matrix will be integers in the range [1 … 12]

•	The snake will be a string with length in the range [1 … 20] and will not contain any whitespace characters

Examples

INPUT:
___

5 6

SoftUni


OUTPUT:
___


SoftUn

iSoftU

niSoft

UniSof

tUniSo

____


6.	Bomb the Basement

You are angry with your neighbor and you wish to get back on him for the constant noise complaints that he files against you. The most valuable things he has are stored in his basement. You have a plan – designing small bombs to bomb it. The basement is in the form of a square. It is full of cells with items. 

You will be given the dimensions of the basement. After that you will be given the coordinates of the cells that store the most valuable items – you should bomb them. When a bomb explodes it has an impact and it destroys all of the items in a certain radius, which will be given to you. The items should be represented by 0. You can check whether a cell is inside the blast radius using the Pythagorean Theorem. The bomb leaves the cells without an item. You should use the number 1 to represent that. The items above the exploded area start falling down until they land on another symbol (meaning an item moves down a row as long as there is a -1 below). When the horror ends, print on the console the resulting basement, each row on a new line. You should check out the examples.

Input

•	The input data should be read from the console. It consists of exactly three lines

•	On the first line, you’ll receive the dimensions of the stairs in format: "N M", where N is the number of rows, and M is the number of columns. They’ll be separated by a single space

•	On the second line, you’ll receive the bomb parameters (target row, target column and radius), all separated by a single space

•	The input data will always be valid and in the format described. There is no need to check it explicitly



Output

•	The output should be printed on the console. It should consist of N lines

•	Each line should contain a string representing the respective row of the final matrix



Constraints

•	The dimensions N and M of the matrix will be integers in the range [1 … 12]

•	The items will represent characters

•	The shot’s impact row and column will always be valid coordinates in the matrix – they will be integers in the range [0 … N – 1] and [0 … M – 1] respectively

•	The shot’s radius will be an integer in the range [0 … 4]


INPUT:
___

5 6

2 3 2

OUTPUT:
___


011111

001110

001110

000100

000100

COMMENT:
___

The matrix has 5 rows and 6 columns. Fill it with zeros:

| c0| c1| c2| c3| c4| c5|
| - | - | - | - | - | - |
| 0 | 0 | 0 | 0 | 0 | 0 |
| 0 | 0 | 0 | 0 | 0 | 0 |
| 0 | 0 | 0 | 0 | 0 | 0 |
| 0 | 0 | 0 | 0 | 0 | 0 |
| 0 | 0 | 0 | 0 | 0 | 0 |

The shot lands on cell (2,3). It has a radius of 2 cells. The impact cell is shaded black and the other cells within the shot radius are shaded grey.

| c0| c1| c2| c3| c4| c5|
| - | - | - | - | - | - |
| 0 | 0 | 0 |   | 0 | 0 |
| 0 | 0 |   |   |   | 0 |
| 0 |   |   |   |   |   |
| 0 | 0 |   |   |   | 0 |
| 0 | 0 | 0 |   | 0 | 0 |

Replace all zeros in the blast area with 1:

| c0| c1| c2| c3| c4| c5|
| - | - | - | - | - | - |
| 0 | 0 | 0 | 1 | 0 | 0 |
| 0 | 0 | 1 | 1 | 1 | 0 |
| 0 | 1 | 1 | 1 | 1 | 1 |
| 0 | 0 | 1 | 1 | 1 | 0 |
| 0 | 0 | 0 | 1 | 0 | 0 |


The resulting matrix should look like this:

| c0| c1| c2| c3| c4| c5|
| - | - | - | - | - | - |
| 0 | 1 | 1 | 1 | 1 | 1 |
| 0 | 0 | 1 | 1 | 1 | 0 |
| 0 | 0 | 1 | 1 | 1 | 0 |
| 0 | 0 | 0 | 1 | 0 | 0 |
| 0 | 0 | 0 | 1 | 0 | 0 |

___


7. Knight Game

Chess is the oldest game, but it is still popular these days. For this task we will use only one chess piece – the Knight. 

The knight moves to the nearest square but not on the same row, column, or diagonal. (This can be thought of as moving two squares horizontally, then one square vertically, or moving one square horizontally then two squares vertically— i.e. in an "L" pattern.) 

The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 

You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights, so there will be no knights left that can attack another knight. 

Input

On the first line, you will receive the N size of the board

On the next N lines, you will receive strings with Ks and 0s.

Output

Print a single integer with the minimum number of knights that needs to be removed

Constraints

•	Size of the board will be 0 < N < 30

•	Time limit: 0.3 sec. Memory limit: 16 MB.



Examples

INPUT:
___

5 

0K0K0

K000K

00K00

K000K 

0K0K0


OUTPUT:
___

1

INPUT:
___

2

KK

KK



OUTPUT:
___

0

INPUT:
___


8

0K0KKK00

0K00KKKK

00K0000K

KKKKKK0K

K0K0000K

KK00000K

00K0K000

000K00KK


OUTPUT:
___

12

____



8.	*Bombs

You will be given a square matrix of integers, each integer separated by a single space, and each row on a new line. Then on the last line of input you will receive indexes - coordinates to several cells separated by a single space, in the following format: row1,column1  row2,column2  row3,column3… 

On those cells there are bombs. You have to proceed every bomb, one by one in the order they were given. When a bomb explodes deals damage equal to its own integer value, to all the cells around it (in every direction and in all diagonals). One bomb can't explode more than once and after it does, its value becomes 0. When a cell’s value reaches 0 or below, it dies. Dead cells can't explode.

You must print the count of all alive cells and their sum. Afterwards, print the matrix with all of its cells (including the dead ones). 

Input

•	On the first line, you are given the integer N – the size of the square matrix.

•	The next N lines holds the values for every row – N numbers separated by a space.

•	On the last line you will receive the coordinates of the cells with the bombs in the format described above.

Output

•	On the first line you need to print the count of all alive cells in the format: 

“Alive cells: \{aliveCells}”

•	On the second line you need to print the sum of all alive cell in the format: 

“Sum: \{sumOfCells}”

•	In the end print the matrix. The cells must be separated by a single space.



Constraints

•	The size of the matrix will be between [0…1000].

•	The bomb coordinates will always be in the matrix.

•	The bomb’s values will always be greater than 0.

•	The integers of the matrix will be in range [1…10000]. 

Examples

INPUT:
___


4

8 3 2 5

6 4 7 9

9 9 3 6

6 8 1 2

1,2 2,1 2,0


OUTPUT:
___

Alive cells: 3

Sum: 12

8 -4 -5 -2

-3 -3 0 2

0 0 -4 -1

-3 -1 -1 2


COMMENT:
___

First the bomb with value 7 will explode and reduce the values of the cells around it. Next the bomb with coordinates 2,1 and value 9 will explode and reduce its neighbour cells. In the end the bomb with coordinates 2,0 and value 9 will explode. After that you have to print the count of the alive cells, which is 3, and their sum is 12. Print the matrix after the explosions.

INPUT:
___


3

7 8 4

3 1 5

6 4 9

0,2 1,0 2,2


OUTPUT:
___


Alive cells: 3

Sum: 8

4 1 0

0 -3 -8

3 -8 0


___



9.  Miner

We get as input the size of the field in which our miner moves. The field is always a square. After that we will receive the commands which represent the directions in which the miner should move. The miner starts from position – ‘s’. The commands will be: left, right, up and down. If the miner has reached a side edge of the field and the next command indicates that he has to get out of the field, he must remain on his current possition and ignore the current command. The possible characters that may appear on the screen are:

•	* – a regular position on the field.

•	e – the end of the route. 

•	c  - coal

•	s - the place where the miner starts

Each time when the miner finds a coal, he collects it and replaces it with '*'. Keep track of the count of the collected coals. If the miner collects all of the coals in the field, the program stops and you have to print the following message: "You collected all coals! (\{rowIndex}, \{colIndex})".

If the miner steps at 'e' the game is over (the program stops) and you have to print the following message: "Game over! (\{rowIndex}, \{colIndex})".

If there are no more commands and none of the above cases had happened, you have to print the following message: "\{remainingCoals} coals left. (\{rowIndex}, \{colIndex})".

Input

•	Field size – an integer number.

•	Commands to move the miner – an array of strings separated by " ".

•	The field: some of the following characters (*, e, c, s), separated by whitespace (" ");

Output

•	There are three types of output:

o	If all the coals have been collected, print the following output: "You collected all coals! (\{rowIndex}, \{colIndex})"

o	If you have reached the end, you have to stop moving and print the following line: "Game over! (\{rowIndex}, \{colIndex})"

o	If there are no more commands and none of the above cases had happened, you have to print the following message: "\{totalCoals} coals left. (\{rowIndex}, \{colIndex})"

Constraints

•	The field size will be a 32-bit integer in the range [0 … 2 147 483 647].

•	The field will always have only one 's'.

•	Allowed working time for your program: 0.1 seconds.

•	Allowed memory: 16 MB.

Examples

INPUT:
___


5

up right right up right

\* * * c *

\* * * e *

\* * c * *

s * * c *

\* * c * *


OUTPUT:
___

Game over! (1, 3)

INPUT:
___


4

up right right right down

\* * * e

\* * c *

\* s * c

\* * * *


OUTPUT:
___

You collected all coals! (2, 3)


INPUT:
___


6

left left down right up left left down down down

\* * * * * *

e * * * c *

\* * c s * *

\* * * * * *

c * * * c *

\* * c * * *


OUTPUT:
___

3 coals left. (5, 0)

___


10.	*Radioactive Mutant Vampire Bunnies

Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply extremely fast. There’s also a player that has to escape from their lair. You really like the game, so you decide to port it to C# because that’s your language of choice. The last thing that is left is the algorithm that decides if the player will escape the lair or not.

First, you will receive a line holding integers N and M, which represent the rows and columns in the lair. Then you receive N strings that can only consist of “.”, “B”, “P”. The bunnies are marked with “B”, the player is marked with “P”, and everything else is free space, marked with a dot “.”. They represent the initial state of the lair. There will be only one player. Then you will receive a string with commands such as LLRRUUDD – where each letter represents the next move of the player (Left, Right, Up, Down).

After each step of the player, each of the bunnies spread to the up, down, left and right (neighboring cells marked as “.” changes their value to B). If the player moves to a bunny cell or a bunny reaches the player, the player has died. If the player goes out of the lair without encountering a bunny, the player has won.

When the player dies or wins, the game ends. All the activities for this turn continue (e.g. all the bunnies spread normally), but there are no more turns. There will be no stalemates where the moves of the player end before he dies or escapes.

Finally, print the final state of the lair with every row on a separate line. On the last line, print either “dead: \{row} \{col}” or “won: \{row} \{col}”. Row and col are the coordinates of the cell where the player has died or the last cell he has been in before escaping the lair.

Input

•	On the first line of input, the numbers N and M are received – the number of rows and columns in the lair

•	On the next N lines, each row is received in the form of a string. The string will contain only “.”, “B”, “P”. All strings will be the same length. There will be only one “P” for all the input

•	On the last line, the directions are received in the form of a string, containing “R”, “L”, “U”, “D”

Output

•	On the first N lines, print the final state of the bunny lair

•	On the last line, print the outcome – “won:” or “dead:” + \{row} \{col}

Constraints

•	The dimensions of the lair are in range [3…20]

•	The directions string length is in range [1…20]

Examples

INPUT:
___


5 8

.......B

...B....

....B..B

........

..P.....

ULLL


OUTPUT:
___



BBBBBBBB

BBBBBBBB

BBBBBBBB

.BBBBBBB

..BBBBBB

won: 3 0


INPUT:
___


4 5

.....

.....

.B...

...P.

LLLLLLLL


OUTPUT:
___



.B...

BBB..

BBBB.

BBB..

dead: 3 1


