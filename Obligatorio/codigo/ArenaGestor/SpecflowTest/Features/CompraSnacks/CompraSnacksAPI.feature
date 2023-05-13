Feature: CompraSnacksAPI

Definicion de los casos de test para la feature "Compra de Snacks" que testeam la capa ""

@tag1
Scenario: Selecting a quantity of snacks less than or equal to 0
	Given I have selected a (non-empty) set of snacks
	And for any of the snacks I have selected a quantity of snacks less than or equal to 0
	When I press the Confirm snack purchase button
	Then an error message is displayed that says "No se puede comprar una cantidad de snacks menor o igual a 0"

@tag2
Scenario: Not selecting any snack
	Given that I didn't select any snacks
	When I press the Confirm snack purchase button
	Then an error message is displayed that says "Tiene que seleccionar al menos un snack"

@tag3
Scenario: Successful snack purchase
	Given I have selected a (non-empty) set of snacks
	And I have selected a quantity greater than 0 for each selected snack
	When I press the Confirm snack purchase button
	Then the price corresponding to the selected quantity of snacks is added to the total price of the tickets.

	
