Feature: BajaSnack

A short summary of the feature

Scenario: Apretar el botón de Eliminar
Given me encuentro en la pestaña de los snacks
When apreto el boton de Eliminar
Then el snack se eliminó del listado 
And las personas que compraron este snack pueden consumir las unidades que compraron
And los espectadores no pueden comprar de ahora en adelante unidades de este producto
