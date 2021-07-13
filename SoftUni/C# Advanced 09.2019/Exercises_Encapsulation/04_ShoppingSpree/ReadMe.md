
Problem 3.	Shopping Spree

Create two classes: class Person and class Product. Each person should have a name, money and a bag of products. Each product should have a name and a cost. Name cannot be an empty string. Money cannot be a negative number. 

Create a program in which each command corresponds to a person buying a product. If the person can afford a product, add it to his bag. If a person doesn’t have enough money, print an appropriate message ("\{personName} can't afford \{productName}").

On the first two lines you are given all people and all products. After all purchases print every person in the order of appearance and all products that he has bought also in order of appearance. If nothing was bought, print the name of the person followed by "Nothing bought". 

In case of invalid input (negative money Exception message: "Money cannot be negative") or an empty name (empty name Exception message: "Name cannot be empty") break the program with an appropriate message. See the examples below:

Examples:
___

INPUT:
___


Pesho=11;Gosho=4

Bread=10;Milk=2;

Pesho Bread

Gosho Milk

Gosho Milk

Pesho Milk

END


OUTPUT:
___


Pesho bought Bread

Gosho bought Milk

Gosho bought Milk

Pesho can't afford Milk

Pesho - Bread

Gosho - Milk, Milk


INPUT:
___


Mimi=0

Kafence=2

Mimi Kafence

END


OUTPUT:
___

Mimi can't afford Kafence

Mimi - Nothing bought 


INPUT:
___


Jeko=-3

Chushki=1;

Jeko Chushki

END


OUTPUT:
___

Money cannot be negative