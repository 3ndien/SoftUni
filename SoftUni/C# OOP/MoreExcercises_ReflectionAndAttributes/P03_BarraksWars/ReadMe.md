
Problem 3.	BarracksWars - A New Factory

You are given a small console based project called Barracks (the code for it is included in the provided skeleton).

The general functionalities of the project are adding new units to its repository and printing a report with statistics about the units currently in the repository. First let's go over the original task before the project was created:

Input

The input consists of commands each on a separate line. Commands that execute the functionality are:

•	add <Archer/Swordsman/Pikeman/{…}> - adds a unit to the repository.

•	report - prints a lexicological ordered statistic about the units in the repository.

•	fight - ends the input.

Output

Each command except fight should print output on the console.

•	add should print: "<Archer/Swordsman/Pikeman/{…}> added!"

•	report should print all the info in the repository in the format: "\<UnitType> -> \<UnitQuantity>", sorted by UnitType

Constraints

•	Input will consist of no more than 1000 lines

•	report command will never be given before any valid add command was provided

Your task

1) You have to study the code of the project and figure out how it works. However, there are parts of it that are not implemented (left with TODOs). You must implement the functionality of the CreateUnit method in the UnitFactory class so that it creates a unit based on the unit type received as parameter. Implement it in such way, that whenever you add a new unit, it will be creatable without the need to change anything in the UnitFactory class (psst - use reflection). You can use the approach called Simple Factory.

2) Add two new unit classes (there will be tests that require them) - Horseman with 50 health and 10 attack and Gunner with 20 health and 20 attack.

If you complete everything correctly for this problem, you should add code only inside the Factories and Units folders.

Examples

INPUT:
___


add Swordsman

add Archer

add Pikeman

report

add Pikeman

add Pikeman

report

fight


OUTPUT:
___


Swordsman added!

Archer added!

Pikeman added!

Archer -> 1

Pikeman -> 1

Swordsman -> 1

Pikeman added!

Pikeman added!

Archer -> 1

Pikeman -> 3

Swordsman -> 1


INPUT:
___


add Pikeman

add Pikeman

add Gunner

add Horseman

add Archer

add Gunner

add Gunner

add Horseman

report

fight


OUTPUT:
___


Pikeman added!

Pikeman added!

Gunner added!

Horseman added!

Archer added!

Gunner added!

Gunner added!

Horseman added!

Archer -> 1

Gunner -> 3

Horseman -> 2

Pikeman -> 2

____



Problem 4.	BarracksWars - The Commands Strike Back

Provided skeleton.

As you might have noticed commands in the project from Problem 3 are implemented via a switch case with method calls in the Engine class. Although this approach works it is flawed when you add a new command because you have to add a new case for it. In some projects, you might not have access to the engine and this would not work. Imagine this project will be outsourced and the outsourcing firm will not have access to the engine. Make it so whenever they want to add a new command they won't have to change anything in the Engine.

To do so employ the design pattern called Command Pattern. Use the provided Executable interface as a frame for the command classes. Put the new command classes in the provided commands package inside core. You can also make a Command Interpreter to decouple that functionality from the Engine. Here is how the base (abstract) command should look like:

___

![CommandClass](https://github.com/3ndien/SoftUni/blob/master/C%23%20OOP/MoreExcercises_ReflectionAndAttributes/P03_BarraksWars/CommandClass.png "CommandClass")

___


Notice how all of the commands that extend this one will have both a Repository and a UnitFactory, although not all of them need these. Leave it like this for this problem, because for the reflection to work we need all of the constructors to accept the same parameters. We will see how to go around this issue in problem 5.

Once you've implemented the pattern, add a new command. It will have the following syntax:

•	retire \<UnitType> - All it has to do is remove a unit of the provided type from the repository.

o	If there are no such units currently in the repository print: "No such units in repository."

o	If there is such a unit currently in the repository, print: "\<UnitType> retired!"

To implement this command, you will also have to implement a corresponding method in the UnitRepository.

If you do everything correctly for this problem, you should write/refactor code only in the Core and Data packages.

Examples

INPUT:
___


retire Archer

add Pikeman

add Pikeman

add Gunner

add Horseman

add Archer

add Gunner

add Gunner

add Horseman

report

retire Gunner

retire Archer

report

retire Swordsman

retire Archer

fight


OUTPUT:
___



No such units in repository.

Pikeman added!

Pikeman added!

Gunner added!

Horseman added!

Archer added!

Gunner added!

Gunner added!

Horseman added!

Archer -> 1

Gunner -> 3

Horseman -> 2

Pikeman -> 2

Gunner retired!

Archer retired!

Archer -> 0

Gunner -> 2

Horseman -> 2

Pikeman -> 2

No such units in repository.

No such units in repository.

___


Problem 5. BarracksWars - Return of the Dependencies

In the final part of this epic problem trilogy, we will resolve the issue where all Commands received all utility classes as parameters in their constructors. We can accomplish this by using an approach called dependency injection container. This approach is used in many frameworks.

We will do a little twist on that approach. Remove all fields from the abstract command except the data. Instead put whatever fields each command needs in the concrete class. Create an attribute called Inject and make it so it can be used only on fields. Put the attribute over the fields we need to set trough reflection. Once you've prepared all of this, write the necessary reflection code in the Command Interpreter (which you should have refactored out from the engine in problem 4).

You can use the same example as in Problem 4 to check if you completed the task correctly.
