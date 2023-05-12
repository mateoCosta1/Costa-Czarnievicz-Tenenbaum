Feature: CompraSnacksDataAccess

A short summary of the feature

@tag3
Scenario: Successful snack purchase
	Given I have selected a (non-empty) set of snacks
	And I have selected a quantity greater than 0 for each selected snack
	When I press the Confirm snack purchase button
	Then the purchase is completed successfully
