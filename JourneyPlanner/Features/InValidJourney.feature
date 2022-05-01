Feature: In Valid Journey Planner
         As a traveller
	     I want to travel by searching by some locations
	     So that I can easily plan where travel options are available or not to specified locations.

@TC2_invalidjourney
Scenario: Invalid Journey Planned
	Given I have entered invalid value into the From Field
	And I have entered invalid value into the To Field
	When I press Plan my Journey
	Then I should see the widget is unable to provide results when an invalid journey is planned.