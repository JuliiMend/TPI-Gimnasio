# TPIGimnasio

El **Sistema de Gestión de Gimnasio (SGG)** registra y administra las actividades operativas del establecimiento en torno a las entidades principales de Socios, Profesores, Planes, Clases y Equipamiento.

Tanto los **Socios** como los **Administradores** tienen datos en común, tales como DNI, Nombre, Apellido, Email y Teléfono, entre otros.

Los planes de entrenamiento incluyen distintos **Tipos de Actividad** (denominación utilizada para evitar confusiones en el modelo) y tienen un precio definido. El pago de las cuotas asociadas a estos planes se procesa mediante una integración con la **API Sandbox de Mercado Pago**.

La dirección del gimnasio crea las **Clases** para cada actividad, a las que se les asigna un **Turno** (días y horarios) y un cupo definido. Cada Clase tiene asignado un **Profesor** a cargo.

Los Socios se inscriben a las diferentes Clases. Al hacerlo, el sistema deberá registrar los datos de dicha inscripción y solo permitirá inscripciones a Clases que no tengan el cupo agotado. Por otro lado, el gimnasio controla su infraestructura mediante el registro de **Máquinas y Materiales**, llevando adelante una registro de mantenimiento de cada máquina.

## Funcionalidades a implementar

Teniendo en cuenta este modelo, las funcionalidades a implementar son las siguientes:

1. Alta, Baja, Modificaciones y Consulta de Administradores
2. Alta, Baja, Modificaciones y Consulta de Socios
3. Alta, Baja, Modificaciones y Consulta de Equipamiento (Máquinas y Materiales)
4. Alta, Baja, Modificaciones y Consulta de Profesores *(ABM simple, sin dependencias de regularidad)*
5. Alta, Baja, Modificaciones y Consulta de Planes y Tipos de Actividad
6. Alta, Baja, Modificaciones y Consulta de Turnos
7. Alta, Baja, Modificaciones y Consulta de Clases
8. Inscripciones de Socios a Clases
9. Registro y Cobro de Cuotas *(Integración con Mercado Pago)*
10. Reporte de Mantenimiento de Máquinas *(Fechas de inicio, fin esperado y fin real)*
11. Listado de Histórico de Sueldos *(Solo lectura/listado)*

## Modelo de Dominio <img width="1763" height="997" alt="MD TPI-Gimnasio" src="https://github.com/user-attachments/assets/52d98d33-294a-4609-83d3-ef545a903fce" />
