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


Object Class

Classes
Methods

General Overview:

Variables

Position data
direction
type (missle, or powerup)


Methods
HitDetect
Print
2dMatrixPlacement
MoveTimeProgres

Constructor
postion with direction and type


Player Class

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


Alien Class

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

Printing:

Use data from 2d array to create a string for the entire playeble area.

Go through array, check if filled, print " " if empty, otherwise put chosen symbol


Level Desing

2d array
Fomatig geometrical figures in a 2d array
Print only filled positions
should be read from file, which postions should be filled initially

(optional)

Flip a created pattern

(very optional)

Rearange remaining elements in new pattern
