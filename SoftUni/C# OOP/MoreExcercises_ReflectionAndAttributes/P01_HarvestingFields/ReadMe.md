
Problem 1.	Harvesting Fields

Provided skeleton.

You are given a HarvestingFields class with lots of fields (look at the provided skeleton). Like a good the good farmer you are, you must harvest them. Harvesting means that you must print each field in a certain format (see output).

Input

You will receive a maximum of 100 lines with one of the following commands:

•	private - print all of the private fields

•	protected - print all of the protected fields

•	public - print all of the public fields

•	all - print ALL of the declared fields

•	HARVEST - end the input

Output

For each command, you must print the fields that have the given access modifier as the one described in the input section. The format, in which the fields should be printed is:

"\<access modifier> \<field type> \<field name>"

Examples

INPUT:
___

protected

HARVEST


OUTPUT:
___


protected String testString

protected Double aDouble

protected Byte testByte

protected StringBuilder aBuffer

protected BigInteger testBigNumber

protected Single testFloat

protected Object testPredicate

protected Object fatherMotherObject

protected String moarString

protected Exception inheritableException

protected Stream moarStreamz


INPUT:
___


private

public

private

HARVEST


OUTPUT:
___


private Int32 testInt

private Int64 testLong

private Calendar aCalendar

private Char testChar

private BigInteger testBigInt

private Thread aThread

private Object aPredicate

private Object hiddenObject

private String anotherString

private Exception internalException

private Stream secretStream

public Double testDouble

public String aString

public StringBuilder aBuilder

public Int16 testShort

public Byte aByte

public Single aFloat

public Thread testThread

public Object anObject

public Int32 anotherIntBitesTheDust

public Exception justException

public Stream aStream

private Int32 testInt

private Int64 testLong

private Calendar aCalendar

private Char testChar

private BigInteger testBigInt

private Thread aThread

private Object aPredicate

private Object hiddenObject

private String anotherString

private Exception internalException

private Stream secretStream


INPUT:
___

all

HARVEST


OUTPUT:
___



private Int32 testInt

public Double testDouble

protected String testString

private Int64 testLong

protected Double aDouble

public String aString

private Calendar aCalendar

public StringBuilder aBuilder

private Char testChar

public Int16 testShort

protected Byte testByte

public Byte aByte

protected StringBuilder aBuffer

private BigInteger testBigInt

protected BigInteger testBigNumber

protected Single testFloat

public Single aFloat

private Thread aThread

public Thread testThread

private Object aPredicate

protected Object testPredicate

public Object anObject

private Object hiddenObject

protected Object fatherMotherObject

private String anotherString

protected String moarString

public Int32 anotherIntBitesTheDust

private Exception internalException

protected Exception inheritableException

public Exception justException

public Stream aStream

protected Stream moarStreamz

private Stream secretStream
