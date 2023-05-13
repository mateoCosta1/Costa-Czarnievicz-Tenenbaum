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
Informe avance 2 - 18 de Abril 2023 



#### Link al repositorio: https://github.com/mateoCosta1/Costa-Czarnievicz-Tenenbaum

# Índice:
## Informe Avance 1:

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

## Informe Avance 2:
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

## Informe Avance 3:
- [Tercera versión del Proceso de Ingeniería]()
