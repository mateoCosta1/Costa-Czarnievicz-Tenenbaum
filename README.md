Universidad Ort Uruguay, Facultad de Ingeniería

Este documento contiene el código del gestor Arena, junto con una serie de informes de avance centrados en el desarrollo ágil. Durante el transcurso del curso de Ingeniería de Software Ágil 2, estamos aprendiendo diferentes metodologías que debemos aplicar en este proyecto para ponerlas en práctica de manera efectiva. Cada informe de avance describe nuestra propuesta para abordar la etapa en curso, detallando los acontecimientos relevantes y los aprendizajes obtenidos. Este informe corresponde a la tercera entrega de las cinco que el equipo debe realizar. Además, en este momento se encuentran disponibles los informes desde la primera entrega hasta la tercera.
# Informe Avances 


## Descripción del trabajo realizado para el Obligatorio 1 de Ingeniería de Software Ágil 2




Grupo N6A 

- Diego Tenenbaum - 228429

- Federico Czarnievicz - 201250 

- Mateo Costa - 232870

- Tutor/es: Álvaro Ortas

Informe avance 1 - 11 de Abril 2023 <br>
Informe avance 2 - 18 de Abril 2023 <br>
Informe avance 3 - 12 de Mayo 2023 <br>
Informe avance 4 - 23 de Mayo 2023



#### Link al repositorio: https://github.com/mateoCosta1/Costa-Czarnievicz-Tenenbaum

# Índice:
[Informe Avance 1](#informe-avance-1)
[Informe Avance 2](#informe-avance-2)
[Informe Avance 3](#informe-avance-3)
[Informe Avance 4](#informe-avance-4)

# Informe Avance 1:<a name="avance1"></a>

- [Definición del marco general de KANBAN](/Informe%20Avance%201/Definicion%20de%20marco%20general%20de%20KANBAN.pdf)
- [Primera versión del Proceso de Ingeniería](/Informe%20Avance%201/Primera%20version%20del%20proceso%20de%20ingenieria.pdf)
    - Definition of Done
    - Definición de roles del equipo
- [Mantenimiento del repositorio](/Informe%20Avance%201/Mantenimiento%20del%20repositorio.pdf)
- [Análisis de deuda técnica](/Informe%20Avance%201/Analisis%20deuda%20tecnica.pdf)    
    - Clasificación de las issues
    - Resultados del análisis del código estático
        - ReSharper: Testeo del código del backend realizado con C#
        - ESLint: Testeo del código del frontend realizado con angular y typescript
- [Resumen de las issues](/Informe%20Avance%201/Resumen%20de%20las%20issues.pdf)
- [Registro de esfuerzo](/Informe%20Avance%201/Registro%20de%20esfuerzo.pdf)
- [Retrospectiva](/Informe%20Avance%201/Retrospectiva.pdf)
- [Bibliografía](#bibliografia) 
- [Anexo](#anexo)
    - Report de ReSharper(Backend)
    - Report de ESLint (Frontend)
<hr>

# Informe Avance 2:<a name="avance2"></a>
- [Segunda versión del Proceso de Ingeniería](/InformeAvance%202/Segunda%20version%20proceso%20de%20ingenieria.pdf)
    - Planificación
    - Selección de bugs
    - Definición de requerimientos
    - Creación de test unitarios
    - Codificación
    - Review con el PO (Product Owner)
    - Check
    - Definition of done
        - Planificación
        - Selección de bugs
        - Definición de requerimientos
        - Creación de test unitarios
        - Codificación
        - Review con el PO
        - Check
- [Explicación del tablero y su vínculo con el proceso de ingeniería](/InformeAvance%202/Explicacion%20del%20tablero%20y%20su%20vinculo%20con%20el%20proceso%20de%20ingenieria.pdf)
    - Explicación del tablero KANBAN Sustentable
    - Vínculo del tablero con el proceso de ingeniería:
- [Configuración del pipeline y su vínculo con el tablero](/InformeAvance%202/Configuracion%20del%20pipeline.pdf)
- [Justificación de los bugs seleccionados en función de la clasificación proporcionada](/InformeAvance%202/Justificacion%20de%20los%20bugs%20seleccionados%20.pdf)
    - Justificación de la selección de bugs
    - Justificación de la prioridad asignada a esos bugs
- [Evidencia de ejecución de casos de prueba](/InformeAvance%202/Evidencia%20de%20ejecucion%20de%20casos%20de%20prueba%20.pdf)
    - Evidencia de TDD
        - Para la correción del error: Error al cerrar sesión con un usuario de rol artista
        - Para la corrección del error: Dar baja a un género como administrador
- [Retrospectiva](/InformeAvance%202/Retrospectiva.pdf)
    - Link al tablero de la retro: https://metroretro.io/BO3AFKD3W0FL
    - Tablero de la retro
    - DAKI
- [Review con el Product Owner](/InformeAvance%202/Review%20con%20el%20PO.pdf)
- [Registro de esfuerzo por tipo de tarea](/InformeAvance%202/Registro%20esfuerzo.pdf)
- [Herramientas](#herramientas)
- [Lecciones aprendidas en esta etapa](#lecciones)
- [Bibliografía](#bibliografia) 

<hr>

## Herramientas:<a name="herramientas"></a>
- Metroretro: https://metroretro.io/

## Lecciones aprendidas en esta etapa: <a name="lecciones"></a>

Durante esta etapa, se han aprendido valiosas lecciones sobre la configuración del pipeline con Github Actions.

En primer lugar, se ha comprendido la importancia de planificar el pipeline cuidadosamente antes de comenzar a implementarlo. Es crucial tener una idea clara de las tareas que deben realizarse y del orden en que deben ejecutarse para asegurarse de que el pipeline sea eficiente.Además, se ha aprendido que es importante tener una comprensión sólida de los conceptos básicos de Github Actions, como los workflows, los jobs y las acciones. Estos elementos forman la base del pipeline y es esencial comprender cómo funcionan juntos para lograr los objetivos del proyecto.

Estos conceptos los hemos incorporado también a partir del error de configurar el pipeline en la rama main, en lugar de develop. Pero nos sirvió de experiencia para seguir sumando nuevos aprendizajes

En resumen, la configuración del pipeline con Github Actions puede ser un proceso complejo, pero se han aprendido valiosas lecciones sobre cómo planificar, comprender y documentar eficazmente el pipeline para asegurar su éxito a largo plazo.

## Bibliografía:<a name="bibliografia"></a>

- Material brindado por los docentes mediante las clases, aulas y microsoft teams.
- ESLint: https://eslint.org/docs/latest/ 
- ReSharper: https://www.jetbrains.com/resharper/documentation/documentation.html 
- Creación de build validation GitHub workflow: https://learn.microsoft.com/en-us/dotnet/devops/dotnet-build-github-action
## Anexo:<a name="anexo"></a>
 - [Report de ReSharper:](/Obligatorio/codigo/ArenaGestor/reportReSharper.xml) 
 - [Rerport de ESLint:](/Obligatorio/codigo/ArenaGestorFront/reportESLint.txt)

<hr>

# Informe Avance 3:<a name="avance3"></a>

  - [Objetivo](#objetivo3)
- [Proceso de Ingeniería(3ra versión)](/InformeAvance3/Proceso%20de%20ingenieria%20(3ra%20version).pdf)
    - Planificación
    - Definición de requerimientos
    - Implementación de casos de test
    - Codificación
    - Test de integración
    - Review con el PO (Product Owner)
    - Done
    - <b>Definition of Done</b>
    - Planificación 
    - Definición de requerimientos
    - Implementación de casos de test
    - Codificación
    - Test de integración
    - Review con el PO (Product Owner)
    - Done
- [Explicación del tablero y su vínculo con el proceso de ingeniería](/InformeAvance3/Explicacion%20del%20tablero%20y%20su%20vinculo%20con%20el%20proceso%20de%20ingenieria-1.pdf)
    - Explicación del tablero KANBAN sustentable
    - Vínculo del tablero con el proceso de ingeniería
- [Configuración del pipline y su vínculo con el tablero](/InformeAvance3/Configuracion%20del%20pipeline%20y%20su%20vinculo%20con%20el%20tablero-1.pdf)
- [Definición de requerimientos](/InformeAvance3/Definicion%20de%20Requerimientos.pdf)
    - Mantenimiento de snacks
        - User story 1
        - User story 2
    - Comprar snacks
        - User story 3
- [Implementación de los casos de prueba con Specflow](/InformeAvance3/Implementacion%20de%20los%20casos%20de%20prueba%20con%20Specflow.pdf)
    - Features
    - Implementación de los casos de prueba
    - Implementación del código de backend
- [Evidencia de ejecución de los casos de prueba](/InformeAvance3/Evidencia%20de%20ejecuci%C3%B3n%20de%20los%20casos%20de%20prueba.pdf)
    - Casos deprueba ejecutados pasando
    - Evidencia de BDD por historial de commits
- [Review con el Product Owner](/InformeAvance3/Review%20con%20el%20Product%20Owner.pdf)
- [Total registro de esfuerzo por la entrega](/InformeAvance3/Total%20registro%20de%20esfuerzo%20por%20la%20entrega-1.pdf)
- [Retrospectiva](/InformeAvance3/Retrospectiva-1.pdf)
- [Lecciones aprendidas en esta etapa](#lecciones3)
- [Backlog](#backlog3)

<hr>

## Objetivo informe avance 3:<a name="objetivo3"></a>

El objetivo para esta tercera entrega es aplicar las metodologías de DevOps en este caso basadas en BDD para el desarrollo de dos nuevas funcionalidades y adaptar dichos elementos al tablero.

+ Mantenimiento de snacks
El usuario administrador puede realizar alta y baja de snacks con descripción y precio (datos obligatorios).
<br>
+ Comprar snacks
<br>
Antes de finalizar una compra de tickets, se ofrece la posibilidad de comprar Snacks. El espectador puede agregar distintas cantidades de snacks, se calcula el subtotal de snacks y se suma al de tickets.
<br>
Además se destaca como relevante el aprendizaje y utilización de herramientas como Gherkin, Specflow, Github Actions, que permiten automatizar las pruebas funcionales en el marco BDD. Gherkin contribuyó en la creación de los escenarios de los test funcionales corridos con Specflow. Las Github Actions se relacionan con la configuración del pipeline automatizado. 

## Lecciones aprendidas en esta etapa:<a name="lecciones3"></a>
La configuración del Pipeline ha conllevado un tiempo y esfuerzo más alto de lo esperado y aún detectamos algún problema menor en él. Hemos tenido problema con el manejo de versiones de node en la instalación de las dependencias del build y también en cuanto a los test unitarios de reflection que estaban mal implementados, por lo que decidimos quitarlos del proyecto.
Creemos que la configuración del pipeline es ideal para hacer en un proyecto desde cero, ya que al hacerlo en uno empezado y que nos fue entregado también nos trajo sus complicaciones por fuera de lo que es el aprendizaje de una nueva herramienta. De todas maneras, consideramos que es aporta gran valor al flujo de trabajo. 
Manejo de las nuevas herramientas propuestas en el curso como Gherkin, Specflow.
La utilización y el poder aprovechar el marco de BDD como herramienta para obtener mayor agilidad en el proceso de ingeniería.
Darle mayor relevancia a la retrospectiva como una etapa en la que se puede realmente reflexionar como equipo sobre qué se puede mejorar y cómo acercarse más a los objetivos planeados.  

## Backlog:<a name="backlog3"></a>
| Tarea                                                                                                                                 | Prioridad/Severidad | Detalles                                                                            |
|---------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------------------------------------------------------------------|
| Tabla resumen con issues detectados ordenados por prioridad y/o severidad                                                             | Media               | Quedó pendiente de las entregas anteriores y es feedback recibido por los clientes. |
| Issues con analizadores estáticos de código carecen de descripción                                                                    | Media               | Quedó pendiente de las entregas anteriores y es feedback recibido por los clientes. |
| Excepción controlada al ingresar un precio null pero no personalizadamente, por lo que el mensaje de error es una excepción genérica. | Baja                | Quedó pendiente, luego de la review con el PO.                                      |
| Mejora a futuro, mostrar el snack comprado junto al ticket y el total sumado de dicha compra.                                         | Baja                | Quedó pendiente, luego de la review con el PO.                                      |
| Mejorar estilos del front                                                                                                             | Baja                | Quedó pendiente, luego de la review con el PO.                                      |

<hr>

# Informe Avance 4:<a name="avance4"></a>

  - [Objetivo](#objetivo4)
  - [Mejoras de iteraciones anteriores](/InformeAvance4/Mejoras%20de%20iteraciones%20anteriores.pdf)
    - Actualizamos cómo se mueven las tarjetas en el tablero
    - Arreglo de la configuración del pipeline
- [Proceso de Ingeniería(4ta versión)](/InformeAvance4/Proceso%20de%20ingenieria%20(4%20version).pdf)
    - Planificación
    - Definición de requerimientos
    - Implementación de casos de test
    - Codificación
    - Test de integración
    - Review con el PO (Product Owner)
    - Done
    - <b>Definition of Done</b>
    - Planificación 
    - Definición de requerimientos
    - Implementación de casos de test
    - Codificación
    - Test de integración
    - Review con el PO (Product Owner)
    - Check
- [Explicación del tablero y su vínculo con el proceso de ingeniería](/InformeAvance4/Explicacion%20del%20tablero%20y%20su%20vinculo%20con%20el%20proceso%20de%20ingenieria.pdf)
    - Explicación del tablero KANBAN sustentable
    - Vínculo del tablero con el proceso de ingeniería
- [Evidencia de ejecución de casos de prueba](/InformeAvance4/Evidencia%20de%20ejecucion%20de%20casos%20de%20prueba.pdf)
- [Métricas de DevOps](/InformeAvance4/Metricas%20de%20DevOps.pdf)
    - Definición de uso de las métricas
    - Informe de Análisis de Métricas de DevOps para el Equipo
- [Review con el Product Owner](/InformeAvance4/Review%20con%20el%20Product%20Owner%20(2).pdf)
- [Retrospectiva](/InformeAvance4/Retrospectiva%20(5).pdf)
- [Total registro de esfuerzo por la entrega](/InformeAvance4/Total%20registro%20de%20esfuerzo%20por%20la%20entrega%20(1).pdf)
- [Lecciones aprendidas en esta etapa](/InformeAvance4/Lecciones%20aprendidas%20en%20esta%20etapa.pdf)
- [Backlog](#backlog4)

<hr>

## Objetivo informe avance 4:<a name="objetivo4"></a>

El objetivo para esta cuarta entrega es lograr la automatización de los test exploratorios que hasta el momento eran manuales. Los test exploratorios para ambos bugs resueltos y las dos nuevas funcionalidades deben de automatizarse utilizando Selenium como herramienta.
A su vez, se propone como meta confeccionar y analizar ciertas métricas utilizadas en el contexto de DevOps según nuestro proceso de ingeniería.


## Backlog:<a name="backlog4"></a>
| Tarea                                                                                                                                 | Prioridad/Severidad | Detalles                                                                            |
|---------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------------------------------------------------------------------|
|Integrar test de Selenium al pipeline | Media | Quedó pendiente durante la entrega debido a una decisión tomada por el equipo  |
| Excepción controlada al ingresar un precio null pero no personalizadamente, por lo que el mensaje de error es una excepción genérica. | Baja                | Quedó pendiente, luego de la review con el PO.                                      |
| Mejora a futuro, mostrar el snack comprado junto al ticket y el total sumado de dicha compra.                                         | Baja                | Quedó pendiente, luego de la review con el PO.                                      |
| Mejorar estilos del front                                                                                                             | Baja                | Quedó pendiente, luego de la review con el PO.                                      |
