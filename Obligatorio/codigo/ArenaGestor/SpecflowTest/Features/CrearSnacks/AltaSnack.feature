Feature: AltaSnack

A short summary of the feature
 

Scenario: Crear un snack sin descripción
Given me encuentro en la pestaña de creación de los snacks
And escribo un precio
When apreto el boton de Confirmar
Then me sale un mensaje de error que dice "Tiene que ingresar una descripción para el snack"

Scenario: Crear un snack sin precio
Given me encuentro en la pestaña de creación de los snacks
And escribo una descripción 
When apreto el boton de Confirmar
Then me sale un mensaje de error que dice "Tiene que ingresar un precio para el snack"

Scenario: Crear un snack sin precio ni descripción
Given me encuentro en la pestaña de creación de los snacks
When apreto el boton de Confirmar
Then me sale un mensaje de error que dice "Tiene que ingresar un precio y una descripción para el snack"

Scenario: Crear un snack con un precio negativo
Given me encuentro en la pestaña de creación de los snacks
And escribo una descripción 
And escribo un precio negativo
When apreto el boton de Confirmar
Then me sale un mensaje de error que dice "Tiene que ingresar un precio mayor o igual a 0 para el snack"

Scenario: Crear un snack con un precio positivo
Given me encuentro en la pestaña de creación de los snacks
And escribo una descripción 
And escribo un precio positivo
When apreto el boton de Confirmar
Then me sale un mensaje que dice "Snack creado con éxito"


Scenario:  Crear un snack con un descripción existente
Given me encuentro en la pestaña de creación de los snacks
And escribo una descripción que ya existe previamente
And escribo un precio positivo
When apreto el boton de Confirmar
Then me sale un mensaje de error que dice "Snack creado previamente"
