
First you will receive a sequence of integers, representing the number of ingredients in a single basket. After that you will be given another sequence of integers - the freshness level of the ingredients.
Your task is to mix them so you can produce the cocktails listed in the table below with the exact freshness level. 

Cocktail	Freshness Level needed

Mimosa	    150

Daiquiri	250

Sunshine	300

Mojito	    400

To mix a cocktail, you have to take the first ingredient value and the last freshness level value. The total freshness level is calculated by their multiplication.

•	If the product of this operation equals one of the levels described in the table, you make the cocktail and remove both ingredient and freshness value. 

•	Otherwise you should remove the freshness level, then increase the ingredient value by 5

o	Remove it from the collection and add it again, already increased by 5. 

•	In case you have an ingredient with value 0 you have to remove it and continue mixing the cocktails.

You need to stop making cocktails only when you run out of ingredients or freshness level values.
Your task is considered done if you make at least four cocktails - one of each type.

Input

•	The first line of input will represent the ingredients' values - integers, separated by single space

•	On the second line you will be given the freshness values - integers again, separated by single space


Output

•	On the first line of output - print if you've succeeded in preparing the cocktails

o	"It's party time! The cocktails are ready!"

o	"What a pity! You didn't manage to prepare all cocktails."

•	On the next output line - print the sum of the ingredients only if they are left any 

•	On the last few lines you have to print the cocktails you have made ordered alphabetically, but only the ones that were made at least once in the format:

" # {{cocktail name}} --> {{amount}}"

Constraints

•	All of the ingredients' values and freshness level values will be integers in range [0, 100]

•	We can have more than one mixed cocktails of the types specified in the table above


INPUTS:

____________

10 10 12 8 10 12

25 15 50 25 25 15

OUTPUT:

_________________

It's party time! The cocktails are ready!

\# Daiquiri --> 1
 
\# Mimosa --> 2

\# Mojito --> 1

\# Sunshine --> 2

COMMENT:

______________

First you take the first ingredient and the last freshness level value and multiply them - the result is 150 so we make Mimosa cocktail. Next we have product of 250 and the Daiquiri cocktail is ready. Then we mix the Sunshine cocktail by multiplying 12 and 25. The product of next ingredient value and freshness level value is 400 and we make Mojito cocktail. Next pair is 10 and 15, we multiply them and mix one more Mimosa. The last multiplication of 12 and 25 equals 300 and we make one more Sunshine. There are no more ingredients and freshness values so we stop mixing cocktails, but we have one of each cocktail types and print the proper message.

INPUTS:

________________

12 20 0 6 19

12 12 25


OUTPUT:

_______________

What a pity! You didn't manage to prepare all cocktails.

Ingredients left: 55

\# Sunshine --> 1

COMMENT:

___

The first pair is 12 and 25, we mix Sunshine cocktail and remove both of them. 
Next we take 20 and 12 - the product is 240 - we can't mix a cocktail, so we remove the freshness level value and increase the ingredient value with 5.
The next ingredient has value 0 - we remove it and continue. 


