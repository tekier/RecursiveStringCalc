(1)	Create a simple String calculator with a method int Add(string numbers)

(2) The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0).
	For example “” or “1” or “1,2”

(3) Allow the Add method to handle an unknown amount of numbers.

(4) Allow the Add method to handle new lines between numbers (instead of commas).
	a.	the following input is ok:  “1\n2,3”  (will equal 6)
	b.	the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)

(5) Support different delimiters:
	a. to change a delimiter, the beginning of the string will contain a separate line that looks like this:
		“//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
		The first line is optional. all existing scenarios should still be supported.
	b. Calling Add with a negative number will throw an exception “negatives not allowed” -
		and the negative that was passed.if there are multiple negatives,
		show all of them in the exception message

@Praveen:
	Can you specifically have a look at if the recursion has been implemented correctly and also if the Exception
	message is being tested correctly. Thanks!
