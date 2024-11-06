Feature: 04InvalidJourneyPlanner


Scenario: Verify invalid destination handling
	Given I have navigated to the TFL journey planner
	When I enter invalid '@@' in the From field
	And I enter invalid '@' in the To field
	And I click the Plan My Journey button
	Then I should see an error message