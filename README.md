# TestingArea
Testing Code

Menu and Opening/Closing Credits:

	All centered middle
	Opening Credits:
	
	Short story for context.
	List of all team members.
	
	Menu:
	
		Series of switch structures
		Screen refresh for each menu popup
	
	Preliminary view:
	
		Start
		Difficulty
			Current
			SetNew
			GoBack
		HighScore(read from file)
			By Difficulty(different files)
			GoBack
		Exit
	
	Closing Credits
	
		Win Screen
		Lose Screen


Missle Class (taken)

	Classes
	Methods
	
	General Overview:
	
	Variables
	
		Position data
		direction
		type (missle)
		
	
	Methods
		HitDetect
		Print
		2dMatrixPlacement
		MoveTimeProgres
	
	Constructor
		postion with direction and type
		
		

Ugrade Class(taken)

	Classes
	Methods
	
	General Overview:
	
	Variables
	
		Position data
		direction
		type
		effect
		
	
	Methods
		HitDetect
		Print
		2dMatrixPlacement
		MoveTimeProgres
	
	Constructor
		postion with direction and type
		
		
Player Class(taken)

	Classes
	Methods
	
	General Overview:
	
	Variables
	
		Position data
		lives data
		power up data
	
	Methods
		Fire
		Move
		HitDetect
		Print
		2dMatrixPlacement
	
	Default Constructor
		Middle postion
		no powerups
		full lives


Alien Class(taken)

	Classes
	Methods
	
	General Overview:
	
	Variables
	
		Position data
		lives data
		reload timer
		time remaining to reload
	
	Methods
		Fire
		HitDetect
		Print
		2dMatrixPlacement
		ReloadTimeProgress
	
	Constructor
		postion, lives from variables

Printing and Window Desing:(taken)

	Required Knowledge
		StringBuilders
		Strings
		ConsoleColor
		CursorPosition
	
	Step By Step:
		1.Create Border String using StringBuilder.
		2.Change Color
		3.PrintBorder and reset color
		4.Creat PlayingField using StringBuilder
		5.Print it.
		6.Creat Stats using StringBuilder
		7.Print Them (color set, corlor reset)
		8.After every Cycle repeat Steps 4-7;
		


Level Desing (Currently on hold)

	2d array
		Fomatig geometrical figures in a 2d array
		Print only filled positions
		should be read from file, which postions should be filled initially

	(optional)
	
	Flip a created pattern
	
	(very optional)
	
	Rearange remaining elements in new pattern

HighScore(taken)
	
	Aspects that will be required
		Writing Files
		Reading Files
		Deleting Files
		Structures
		Sorting
	
	Step By Step Method
		1.Record Top Ten Scores
		2.Score Record Should Include Name and Score
		3.Read Existing HS File and store in array
		4.Delet File
		5.Add new Score to the array
		6.Sort Score Recods by Score
		7.If there are more than 10 keep top 10
		8.Creat File
		9.Write to File(Name First Score Second)
		
	General Notes;
	
		This should be a method, so it can be easyly included in the Main Program
		Preferably use strings or stringbuilder to write to file
		No return, void method
		
		TEST-CHANGE
