Feature: Edit Journey Planner
         As a traveller
	     I want to travel by editing journey preferences
	     So that I can easily commute to specified locations.

Background:
	Given I have entered locations
		| From Location                        | To Location |
		| Hounslow Central Underground Station | Wembley     |
	When I press Plan my Journey

@TC4_editjourney
Scenario: Edit Planned Journey
	And I clicked Edit journey
	And I edit my Journey
	When I press Update journey
	Then I should see valid amended Journey results and a valid journey can be planned