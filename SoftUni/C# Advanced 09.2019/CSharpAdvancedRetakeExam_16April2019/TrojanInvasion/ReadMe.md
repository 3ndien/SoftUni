First, you will be given a number equal to the waves of Trojan warriors. On the second line you will be given the plates of the Spartan defense. Then, on each next line (for each wave), you receive the power of each Trojan warrior. Additionally, on every third wave, the Spartans build a new plate (extra line with a single integer) before the Trojan warriors attack. In order to enter the city, the Trojans have to destroy all the plates.

Until there are no more plates or warriors, the last Trojan warrior attacks the first plate:

•	If the warrior’s value is greater, he destroys the plate and lowers his value by the plate’s value, then attacks the next plate, until his value reaches 0.

•	If the plate’s value is greater, the warrior dies and the plate decreases its value by the warrior’s value.

•	If their values are equal, the warrior dies and the plate is destroyed.

Input

•	First line: integer- the number of waves

•	Second line: integers, representing the plates, separated by a single space.

•	For each wave: integers, representing the warriors, separated by a single space.

o	On every third wave, you will be given an extra line with a single integer, which will be the plate you need to add. [!] Add the plate before processing the attacks. [!]

Output

•	On the first line of output – print if the Trojans destroyed the Spartan defense:

o	True: “The Trojans successfully destroyed the Spartan defense.”

o	False: “The Spartans successfully repulsed the Trojan attack.”

•	On the second line - print all plates or warriors left, separated by comma and a white space:

o	If there are warriors: “Warriors left: \{warrior1}, \{warrior2}, \{warrior3}, (…)”

o	If there are plates: “Plates left: \{plate1}, \{plate2}, \{plate3}, (…)”

Constraints

•	All of the given numbers will be valid integers in the range [1, 100].

•	Not all waves may be needed to destroy the defense.

•	There will always be a winning side, meaning either no warriors or plates left.

Examples

INPUT:
___


3

10 20 30

4 5 1

10 5 5

10 10 10

4


OUTPUT:
___

The Spartans successfully repulsed the Trojan attack.

Plates left: 4


COMMENT:
___


•	First wave (4 5 1):

    o	Warrior (1) attacks Plate (10) => dies and plate is now 9.
    
    o	Warrior (5) attacks Plate (9) => dies and plate is now 4.
    
    o	Warrior (4) attacks Plater (4) => dies and plate is gone.

•	Second wave (10 5 5):

    o	Warrior (5) attacks Plate (20) => dies and plate is now 15.
    
    o	Warrior (5) attacks Plate (15) => dies and plate is now 10.
    
    o	Warrior (10) attacks Plate (10) => dies and plate is gone.

•	Third wave (10 10 10):

    o	Spartans build a new plate (4), plates are now: 30 4
    
    o	Warrior (10) attacks Plate (30) => dies and plate is now 20.
    
    o	Warrior (10) attacks Plate (20) => dies and plate is now 10.
    
    o	Warrior (10) attacks Plate (10) => dies and plate is gone.
    
•	We have no more waves and one plate left (4) => see the output.



INPUT:
___


5

10 30 10

3 3 4

10 10 10

5 5

5

7 6

8 6 7


OUTPUT:
___

The Trojans successfully destroyed the Spartan defense.

Warriors left: 1, 7


COMMENT:
___


•	First wave (3 3 4):

    o	Warrior (4) attacks Plate (10) => dies and plate is now 6.

    o	Warrior (3) attacks Plate (6) => dies and plate is now 3.

    o	Warrior (3) attacks Plater (3) => dies and plate is gone.

•	Second wave (10 10 10):

    o	Warrior (10) attacks Plate (30) => dies and plate is now 20.

    o	Warrior (10) attacks Plate (20) => dies and plate is now 10.

    o	Warrior (10) attacks Plate (10) => dies and plate is gone.

•	Third wave (5 5):

    o	Spartans build a new plate (5), plates are now: 10 5

    o	Warrior (5) attacks Plate (10) => dies and plate is now 5.

    o	Warrior (5) attacks Plate (5) => dies and plate is gone.

•	Fourth wave (7 6):

    o	Warrior (6) attacks Plate (5) => the warrior is now 1 and the plate is gone.

•	We have no more plates, so the waves stop coming => see the output. Also, we stop the input. (8 6 7 is not proceeded, but is in the input because the waves are 5)

