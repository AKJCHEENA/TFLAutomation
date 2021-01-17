Feature: VerifyAllPossibleScenariosOnTFLHomePage

Scenario Outline: Verify that widget is unable to plan a journey if no locations are entered into the widget on TFL site

	Given Navigate to home page of the TFL
	When Enter any value in "<From>" from field
	And  Enter any value in "<To>" to field
	Then Validate that widget is unable to plan a journey as incorrect locations "<From>","<To>" are entered into the widget on TFL site

	Examples:

	| From | To  |
	|      |     |
	| 123  | 456 |

	Scenario Outline: Verify that widget is able to plan a journey if correct locations are entered into the widget on TFL site

	Given Navigate to home page of the TFL
	When Enter any value in "<From>" from field
	And  Enter any value in "<To>" to field
	Then Validate that widget is able to plan a journey as correct locations "<From>","<To>","<JourneyType>" are entered into the widget on TFL site

	Examples:

	| From                   | To                    | JourneyType |
	| East India DLR Station | Westferry DLR Station | New         |
	
	Scenario Outline: Verify that widget is able to plan a journey after editing the locations into the widget on TFL site

	Given Navigate to home page of the TFL
	When Enter any value in "<From>" from field
	And  Enter any value in "<To>" to field
	And  Widget is unable to plan a journey as incorrect locations "<From>","<To>","<EditedFrom>","<EditedTo>" are entered into the widget on TFL site
	Then Validate that widget is able to plan a journey as correct locations "<EditedFrom>","<EditedTo>","<JourneyType>" are entered into the widget on TFL site
	Examples:

	| From | To  | EditedFrom             | EditedTo              | JourneyType |
	| 123  | 456 | East India DLR Station | Westferry DLR Station | Edited      |
	
	Scenario Outline: Verify that widget is able to display a list of recently planned journeys after creating and editing the locations into the widget on TFL site

	Given Navigate to home page of the TFL
	When Enter any value in "<From>" from field
	And  Enter any value in "<To>" to field
	Then Validate that widget is able to plan a journey as correct locations "<From>","<To>","<JourneyType>" are entered into the widget on TFL site
	And  Edit the to and from fields "<EditedFrom>","<EditedTo>" and enter into the widget on TFL site
	And Validate that widget is able to plan a journey as correct locations "<EditedFrom>","<EditedTo>","<JourneyType2>" are entered into the widget on TFL site
	And  Verify the recent tab on plan a journey page contains detail "<EditedFrom>","<EditedTo>" of recently planned journey
	Examples:

	| From					  | To                  | JourneyType | EditedFrom			  | EditedTo              | JourneyType2 |
	| East India DLR Station  | Beckton DLR Station |  New        |East India DLR Station | Westferry DLR Station | Edited       |
	 