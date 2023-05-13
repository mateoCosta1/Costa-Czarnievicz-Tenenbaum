Feature: AltaSnack

A short summary of the feature

@tag1
Scenario: Crear un snack sin descripcion
	Given que me encuentro logeado como administrador
	And me encuentro en la pestaña de creación de snacks
	And escribo un precio
	When apreto el boton de confirmar
	Then me sale un error que dice "Tiene que ingresar una descripcion para el snack"
