# Football World Cup Score Board Test
Using a partial view in your MVC Core 6.0 project can also help to promote code quality.
A partial view is a reusable view that can be shared across multiple pages in your application.
This can help to keep your code DRY (Don't Repeat Yourself) and make it easier to maintain.
Additionally, partial views can be tested in isolation from the rest of your application, 
which can make it easier to ensure that your views are working correctly.

All BBL methods have The class has a constructor that takes an ILogger<Ilogger instance> object,
which is used to log information and errors that occur during the execution of the class's methods.

This code meets the SOLID principles because it follows some important best practices:

Single Responsibility Principle: Each class in this code has a single, 
well-defined responsibility. The ImportTeamData class is responsible for importing data,
the ParseTeamStringList class is responsible for parsing data, 
the SortTeamsList class is responsible for sorting data, and the _DisplayScores method is responsible for displaying data.

Open/Closed Principle: The classes in this code are open for extension 
(i.e., new functionality can be added by creating new classes that implement the same interfaces) 
but closed for modification (i.e., existing classes do not need to be modified when new functionality is added).

Liskov Substitution Principle: This principle states that if a program is using a base class,
it should be able to use any of its derived classes without knowing it. 
This code is likely in compliance with this principle because the classes ImportTeamData, 
ParseTeamStringList, and SortTeamsList all use the same base class, Logger,
which ensures that any classes that inherit from Logger can be used in this code.

Interface Segregation Principle: This principle states that a client should not be forced to implement an interface that it doesn't use.
This code is likely in compliance with this principle because the classes ImportTeamData,
ParseTeamStringList, and SortTeamsList only use methods from the Logger interface that they actually need.

Dependency Inversion Principle: This principle states that a class should not depend on a specific implementation
of a class it relies on, but rather on an abstraction.
This code is  compliance with this principle because the _DisplayScores method creates instances of ImportTeamData,
ParseTeamStringList, and SortTeamsList using interfaces,
allowing them to use any classes that implement those interfaces, and decoupling the dependencies.

The Final Requirement  Get a summary of games by total score. Those games with the same total score will be 
returned ordered by the most recently added to our system.

The final order should be 
Germany 2 France 2
Uruguay 6 Italy 6
Argentina 3 Australia 1
Mexico 0 Canada 5
Spain 10 Brazil 2

Not as the requierment shows
The summary would provide with the following information: 
1. Uruguay 6 - Italy 6 
2. Spain 10 - Brazil 2 
3. Mexico 0 - Canada 5 
4. Argentina 3 - Australia 1 
5. Germany 2 - France 


