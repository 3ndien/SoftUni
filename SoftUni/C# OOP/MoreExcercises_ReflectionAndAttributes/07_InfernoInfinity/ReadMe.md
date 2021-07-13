
Problem 9.	*Refactoring - Bonus

Refactor your Inferno Infinity problem code according to all HQC standards.

•	Think about the proper naming of all your variables, methods, classes and interfaces.

•	Review all of your methods and make sure they are doing only one highly concrete thing.

•	Review your class hierarchy and make sure you have no duplicating code.

•	Consider making your classes less dependent of each other. If you have the new keyword anywhere inside the body of a non-factory or main class, think about how to remove it. Read about dependency injection.

•	Consider adding independent classes for reading input and writing output.

•	Create a repository class that stores all weapon data.

•	Create an engine, weapon creator and so on. Try using design patterns like command and factory.

•	Make your classes highly cohesive and loosely coupled.



Problem 7.	Inferno Infinity

If you've been involved with the creation of Inferno III last year, you may be informed of the disastrous critic reception it has received. Nevertheless, your company is determined to satisfy its fan base, so a sequel is coming and yeah, you will develop the crafting module of the game using the latest OOP trends.

You have three different weapons (Axe, Sword and Knife), which have base stats and a name. The base stats are min damage, max damage and number of sockets (sockets are basically holes, in which you can insert gems). Below are the base stats for the three weapon types:

•	Axe (5-10 damage, 4 sockets)

•	Sword (4-6 damage, 3 sockets)

•	Knife (3-4 damage, 2 sockets) 

What’s more, every weapon comes with a different level of rarity (how rare it is to come across such an item). Depending on its rarity, a weapon’s maximum and minimum damage can be modified.

•	Common (increases damage x1)

•	Uncommon (increases damage x2)

•	Rare (increases damage x3)

•	Epic (increases damage x5)

So a Common Axe would have its damage modified in the following way: minimum damage = 5 *1, maximum damage = 10 *1. Whereas an Epic Axe would look like this: minimum damage = 5 * 5, maximum damage = 10 * 5.

Additionally, every weapon provides a bonus to three magical stats - strength, agility and vitality. At first the bonus of every magical stat is zero and can be increased with gems, which are inserted into the weapon.

Every gem provides a bonus to all three of the magical stats. There are three different kind of gems:

•	Ruby (+7 strength, +2 agility, +5 vitality) 

•	Emerald (+1strength, +4 agility, +9 vitality)

•	Amethyst (+2 strength, +8 agility, +4 vitality)

Every point of strength adds +2 to min damage and +3 to max damage. Every point of agility adds +1 to min damage and +4 to max damage. Vitality does not add damage.

Furthermore, every gem comes in different levels of clarity (basically level of quality). Depending on its level of clarity, a gem’s stats can be modified in the following manner:

•	Chipped (increases each stat by 1)

•	Regular (increases each stat by 2)

•	Perfect (increases each stat by 5)

•	Flawless (increases each stat by 10)

So a Chipped Amethyst will have its stats modified like this: strength = 2 + 1, agility = 8 + 1, vitality = 4 + 1. Whilst a Perfect Emerald would look like this: strength = 1 + 5, agility = 4 + 5, vitality = 9 + 5.

Your job is to implement the functionality to read some weapons from the console and optionally to insert or remove gems at different socket indexes until you receive the END command.

Also, upon the Print command, in order to print correct final stats for a given weapon, first calculate the weapon’s base stats, taking into account its type and rarity. Afterwards, calculate the stats of each of its gems, based on their clarity and finally add everything together. For the specific format of printing refer to the Output section.

Note

If you add a gem on top of another, just overwrite it. If you add a gem to an invalid index, nothing happens. If you try to remove a gem from an empty socket or from invalid index, nothing happens. Upon receiving the END command, print the weapons in order of their appearance in the format provided below.

Input

Each line consists of three types of commands, in which the tokens are separated by ";".

Command types:

•	Create;\{weapon type};\{weapon name}

•	Add;\{weapon name};\{socket index};\{gem type}

•	Remove;\{weapon name};\{socket index}

•	Print;\{weapon name}

Output

Print weapons in the given format:

"\{weapon's name}: \{min damage}-\{max damage} Damage, +\{points} Strength, +\{points} Agility, +\{points} Vitality"

Examples

INPUT:
___


Create;Common Axe;Axe of Misfortune

Add;Axe of Misfortune;0;Chipped Ruby

Print;Axe of Misfortune

END


OUTPUT:
___

Axe of Misfortune: 24-46 Damage, +8 Strength, +3 Agility, +6 Vitality

INPUT:
___


Create;Common Axe;Axe of Misfortune

Add;Axe of Misfortune;0;Flawless Ruby

Remove;Axe of Misfortune;0

Print;Axe of Misfortune

END


OUTPUT:
___


Axe of Misfortune: 5-10 Damage, +0 Strength, +0 Agility, +0 Vitality