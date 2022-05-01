Feature: No Locations are entered
         As a traveller
	     I want to travel without searching locations
	     So that I can easily view search results are showing or not.

@TC3_nolocationsentered
Scenario: No Locations Entered
	When I press Plan my Journey
	Then widget is unable to plan a journey if no locations are entered into the widget.