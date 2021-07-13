Write a program, that collects seashells from the beach. First you will be given the number of rows of the beach – an integer n. On the next n lines, you will receive the available seashells to collect for each row, separated by a single space in the format:

"{{seashell1}} {{seashell2}} … {{seashelln}}"

The positions (cells) without seashells in them are considered empty and they will be marked with a dash ('-').
After that you will start receiving commands. There are three possibilities:

•	"Collect {{row}} {{col}}":

o	You have to go to the given place if you can and collect the seashell, if there is one. 

o	When you collect it, you have to mark the place as an empty, using dash symbol.

•	"Steal {row} {col} {direction}":

o	The evil Gully lands at the given coordinates if they exist. 

o	Every time, he steals the seashell from the cell that he landed on and moves 3 steps in the given direction, if such places exist. Again, if there are seashells in those cells, he steals them.

o	When he steals seashells, he marks the cells as empty. 

o	If Gully cannot land, you are lucky - he doesn't steal seashells and continues circling around. 

o	There are four possible directions, in which Gully can go: "up", "down", "left", "right".

•	"Sunset" – it's getting late and you should stop collection seashells.

In the end, print on the console the last condition of the beach. The cells, containing a seashell or not, should be separated by single space. After that print the count of the seashells you've collected and if they are one or more - list them in order of collecting, separated by comma and space:

"Collected seashells: 
{{countOfCollectedSeashells}} -> {{seashell1}}, {{seashell2}}, …, {{seashelln}}"
Last step is to print the number of stolen by Gully seashells in the format:
"Stolen seashells: {{countOfStolenSeashells}}"

Input

•	On the first line, you will receive the number of beach's rows - integer n

•	On the next n lines, for each row, the situation of the seashells at the beach in the described format above

•	Next, until you receive "Sunset", you will get the commands in the specified format.

Output

•	Print the resulting beach - each cell separated by single space

•	On the next output line - print information for seashells you've collected in the described format

•	On the last line - print the number of seashells stolen by the seagull

Constraints

•	The number of rows will be positive integer between [1, 10]

•	The types of seashells will always be 'C', 'N', 'M' 

•	Move commands will be: "up", "down", "left", "right"

 any seashells, so we print the given final messages.


INPUT:

_______________

6

C N - M C - N

\- N - -

N - M - C N - -

\- C - M - C

M N

C M N - C

Collect 2 2

Collect 4 1

Steal 3 1 up

Collect 4 3

Collect 5 0

Collect 4 0

Steal 2 0 down

Sunset


OUTPUT:

__________________

C - - M C - N 

\- - - - 

\- - - - C N - - 

\- - - M - C 

\- - 

\- M N - C 

Collected seashells: 4 -> M, N, C, M

Stolen seashells: 4



COMMENT:

_____________

First we receive "Collect" command, we go to the given coordinates and collect the 'M' and leave its cell empty ('-'). At the same way we collect and 'N' for the next command. After that there is "Steal" command - the seagull lands at coordinates 3 1, first collects 'C', then takes 3 steps up - the first cell is empty, so he continues up, on the second step he steals 'N' and  on the third - 'N' and sets their cells as empty. The "Collect" command is next, but we don't do anything, because the coordinates are invalid. We execute the last commands in the same way. In the end we print the beach. We've collected 4 seashells, so we print them in order "M, N, C, M". The seagull managed to steal 4 seashells.


INPUT:

_______________

4

\- N M

C

M - - -

N

Collect 9 0

Collect 1 4

Steal 0 2 right

Steal 5 5 up

Sunset

OUTPUT:

_____________

\- N - 

C 

M - - - 

N 

Collected seashells: 0

Stolen seashells: 1

COMMENT:

________________

The "Collect" commands are skipped, because of the invalid coordinates. When we receive "Steal" command, the seagull steals the 'M', leaves it empty and he can't go 3 steps right, so the program continues. The next command is also "Steal" but the seagull cannot land so he doesn't steal anything. There are no more commands and the program ends.
We didn't collect any seashells, so we print the given final messages.

