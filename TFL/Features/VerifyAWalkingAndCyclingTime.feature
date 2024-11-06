Feature: 01ValidJourneyPlanner

A short summary of the feature


Scenario: Verify a walking and cycling time
	Given I have navigated to the TFL journey planner
	When I enter 'Leicester Square' in the From field
	And I enter 'Covent Garden' in the To field
	And I click the Plan My Journey button
	Then I should see walking and cycling time

