Feature: 03ValidJourneyPlanner

A short summary of the feature


Scenario: Verify a View details
	
	
	Given I have navigated to the TFL journey planner
	When I enter 'Leicester Square' in the From field
	And I enter 'Covent Garden' in the To field
	And I click the Plan My Journey button
	And I click on the Edit preferences dropdown
	And I checked Routes with least walking checkbox
	And I click on the Update journey button
	And I click on the View details button
	Then I should see access information at Covent Garden Underground Station

