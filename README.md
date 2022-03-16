# StringTheory
C# Class Library for sequencing text strings dynamically.

Create a new Sequence, add events to it, run the sequence.

You can add sequences to sequences, and you can run events on their own.

e.g.

```
Console.CursorVisible = false;

int testInt = 0;

Sequence test = new Sequence();
test.AddEvent(new DynamicString(". . . ", clearScreen: true, delay: 500, delayPerChar: true));
test.AddEvent(new DynamicString("Welcome . . ", delay: 45, delayPerChar: true));
test.AddEvent(new Pause(500));

Sequence test2 = new Sequence();
test2.AddEvent(new DynamicString("We've been waiting for you", clearScreen: true, delay: 250));
test2.AddEvent(new Pause(500));
test2.AddEvent(new DynamicString("Have cake.", delay: 500, colour: ConsoleColor.DarkRed));
test2.AddEvent(new Choose(new string[] { "Eat cake", "Don't eat cake" }, ref testInt));

test.AddSequence(test2);

test.StartSequence();

new DynamicString("I am not part of a sequence!", delay: 55, delayPerChar: true).Run();
```

## Events
### Choose
### DynamicString
Creates a new string
```
string text = "Some text to display"
ConsoleColour colour = ConsoleColor.White // use the ConsoleColor enum to pick the forground text colour.
bool newLine = true // define if the console cursor should move to the next line after rendering this text.
int delay = 0 // define the amount of time to delay, affects delayPerChar (See Below)
bool delayPerChar // defines if the delay should be between words, or between characters.
bool clearScreen = false // define is the console screen should be cleared before rendering this string.
```
### Function
Accepts a single argument of type STFunc which is an anonymous method with no return type. This lets you sequence some operation to be performed.
### Path
Not currently in use.
### Pause
Creates a pause between events.
```
int ms = 500 //amount of time in miliseconds to sleep before.
bool skippable // define if this event and be skipped by pressing return or space.
```
### PressContinue
Creates an event that requests the user press return or spacebar to continue execution of the application.
```
string prompt = ">\tContinue" // Default string, can be overridden.
```
