# ArqWebApp

Backend REST api

# Descripción general

ArqWebApp es un backend que tiene un CRUD desarrollado en .NET 10 con una arquitectura modular que separa las preocupaciones entre api, lógica de negocio y persistencia.
El objetivo principal es lograr un código mantenible, testeable y de fácil evolución, aplicando principios de arquitectura hexagonal (Ports & Adapters) dentro de un único despliegue (monolito).

🧱 Estructura de la solución

La solución está compuesta por tres proyectos principales:

ArqWebApp.Core.slnx
│
├── ArqWebApp.Api
├── ArqWebApp.Core
└── ArqWebApp.Infraestructure

Cada uno tiene una responsabilidad clara y actúa como una capa dentro de la arquitectura.

# ArqWebApp.Api

Este proyecto es la puerta de entrada de la aplicación:

✔️ Expone endpoints HTTP para operaciones CRUD.
✔️ Recibe peticiones y las transforma en comandos o consultas para el Core.
✔️ Orquesta la respuesta al cliente (JSON, códigos de estado, etc.).

👉 Aquí no se implementa lógica de negocio compleja; su foco es manejar la comunicación con el exterior (web, clientes).

# ArqWebApp.Core

Este es el núcleo de la aplicación.
Contiene:

Entidades de dominio.

Casos de uso / lógica de negocio.

Interfaces (puertos) que definen abstracciones, por ejemplo:

Repositorios

Servicios externos (si aplica)

💡 Core no depende de detalles técnicos como bases de datos o frameworks.

Esto permite:

Testear lógica de negocio de forma aislada.

Cambiar la implementación de infraestructura sin tocar el núcleo.

# ArqWebApp.Infraestructure

Este proyecto implementa los detalles técnicos concretos:

✔️ Persistencia de datos (ORM, DbContext, repositorios).
✔️ Integración con recursos externos (si los hubiera).
✔️ Implementaciones de interfaces definidas en el Core.

Infraestructura depende de Core, no al revés.
Esto mantiene la lógica de negocio independiente de cómo se almacenan o recuperan datos.

# Flujo típico de una petición

El cliente hace una petición HTTP a un endpoint de ArqWebApp.Api.

El API convierte la solicitud en una llamada a un caso de uso del Core.

El Core ejecuta la lógica de negocio solicitada.

Si se necesita persistencia, el Core invoca interfaces para repositorios.

Infraestructura implementa esos repositorios y ejecuta operaciones contra la base de datos.

El resultado vuelve al API, que genera la respuesta al cliente.

# Beneficios de esta arquitectura

✔️ Separación de responsabilidades.
✔️ Alta testeabilidad de la lógica de negocio.
✔️ Flexibilidad para cambiar infraestructura (DB, servicios externos).
✔️ Escalabilidad organizativa: nuevos adaptadores pueden añadirse (por ejemplo, gRPC, CLI, jobs).

# Requisitos y Ejecución

(Puedes completar esta sección con lo que aplique a tu proyecto: SDK requerido, variables de entorno, Instrucciones de local DB, etc.)

# Conclusión

La solución ArqWebApp aplica un patrón de arquitectura moderno que favorece el crecimiento y claridad del código, manteniendo el dominio separado de detalles técnicos.

Si estás explorando buenas prácticas en .NET 10, este proyecto es un excelente ejemplo práctico de cómo aplicar arquitectura hexagonal en un monolito bien estructurado.

Si quieres, puedo ayudarte a generar badges de CI/CD, añadir ejemplos de endpoints o un diagrama visual de la arquitectura para este README.
