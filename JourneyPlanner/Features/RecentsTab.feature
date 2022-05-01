Feature: Recents tab
         As a traveller
	     I want to check my recent travel history
	     So that I can easily plan in future to travel to specified locations.

Background:
	Given I have entered locations
		| From Location                        | To Location |
		| Hounslow Central Underground Station | Wembley     |
	When I press Plan my Journey
	

@TC5_recentstabonwidget
Scenario: Recents Tabs Widget	
	And I clicked Edit journey
	And I edit my Journey
	When I press Update journey
	Then widget displays a list of recently planned journeys.