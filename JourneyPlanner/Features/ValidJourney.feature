Feature: Valid Journey Planner
         As a traveller
	     I want to travel by searching by simple locations
	     So that I can easily commute to specified locations.

Background:
	Given I have entered locations
		| From Location                        | To Location |
		| Hounslow Central Underground Station | Wembley     |
	When I press Plan my Journey

@TC1_validjourney
Scenario: Valid Journey Planned
	Then I should see valid Journey results and a valid journey can be planned