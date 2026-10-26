# TPIGimnasio

El **Sistema de Gestión de Gimnasio (SGG)** registra y administra las actividades operativas del establecimiento en torno a las entidades principales de Socios, Profesores, Planes, Clases y Equipamiento.

Tanto los **Socios** como los **Administradores** tienen datos en común, tales como DNI, Nombre, Apellido, Email y Teléfono, entre otros.

Los planes de entrenamiento incluyen distintos **Tipos de Actividad** y tienen un precio definido. Los socios pagan **Cuotas** mensuales, que se registran con su detalle de conceptos.

La dirección del gimnasio crea las **Clases** para cada actividad, a las que se les asigna un **Turno** (días y horarios) y un cupo definido. Cada Clase tiene asignado un **Profesor** a cargo.

Los Socios se inscriben a las diferentes Clases. Al hacerlo, el sistema deberá registrar los datos de dicha inscripción y solo permitirá inscripciones a Clases que no tengan el cupo agotado. Por otro lado, el gimnasio controla su infraestructura mediante el registro de **Máquinas y Materiales**, llevando adelante un registro de mantenimiento de cada máquina.

## Funcionalidades

Todas disponibles en las dos interfaces (Web y Escritorio):

1. Alta, Baja, Modificaciones y Consulta de Administradores (y de Usuarios del sistema)
2. Alta, Baja, Modificaciones y Consulta de Socios
3. Alta, Baja, Modificaciones y Consulta de Equipamiento (Máquinas y Materiales)
4. Alta, Baja, Modificaciones y Consulta de Profesores
5. Alta, Baja, Modificaciones y Consulta de Planes y Tipos de Actividad (un plan incluye varias actividades)
6. Alta, Baja, Modificaciones y Consulta de Turnos
7. Alta, Baja, Modificaciones y Consulta de Clases (actividad, profesor a cargo, turno y cupo)
8. Inscripciones de Socios a Clases, con control de cupo
9. Registro de Cuotas con su detalle (maestro/detalle)
10. Reporte de Mantenimiento de Máquinas *(fechas de inicio, fin esperado y fin real, con estado y días de demora)*
11. Listado de Histórico de Sueldos de los profesores

### Reportes (con gráficos)

| Reporte | Gráfico | Web | Escritorio |
|---|---|---|---|
| Ocupación de clases | Barras: inscriptos vs. cupo por clase | `/reportes/ocupacion-clases` | Reportes → Ocupación de clases |
| Mantenimiento de máquinas | Torta: mantenimientos por estado | `/reportes/mantenimientos` | Reportes → Mantenimiento de máquinas |

Gráficos: **Chart.js** en Web (copia local en `wwwroot/lib/chartjs`) y **ScottPlot** en Escritorio.

## Arquitectura

```
Domain.Model  ←  Data (EF Core + ADO.NET)  ←  Application.Services  ←  WebAPI (Minimal API + JWT)
                                                                          ↑ HTTP
                       DTOs  ←  API.Clients  ←  Blazor.Server (Web) / WindowsForms (Escritorio)
```

- **Domain.Model**: entidades del dominio.
- **Data**: `GimnasioContext` (EF Core) y repositorios. Máquinas y Materiales usan ADO.NET.
- **Application.Services**: lógica de negocio (validaciones, cupo, estados de mantenimiento) y datos de prueba.
- **WebAPI**: endpoints REST, autenticación JWT y autorización por roles.
- **API.Clients**: clientes HTTP que usan las dos interfaces. Ninguna interfaz accede a la base de datos.
- **Blazor.Server** (Web) y **WindowsForms** (Escritorio).

## Seguridad

- **Autenticación** con token JWT (`POST /api/auth/login`). El token vence a los 120 minutos; al vencer, las interfaces vuelven al login.
- **Autorización por roles**, validada en la API. Los datos "propios" se filtran según el usuario del token:

| Recurso | Admin | Profesor | Socio |
|---|---|---|---|
| ABM de socios, profesores, administradores, usuarios, actividades, turnos, máquinas, materiales, mantenimientos y reportes | ✓ | ✗ | ✗ |
| Planes | ✓ | ✗ | ve **su plan** |
| Clases | ✓ | ve **sus clases** | ve todas |
| Inscripciones | ✓ | ve las de **sus clases** | ve, se inscribe y cancela **las suyas** |
| Cuotas | ✓ | ✗ | ve **las suyas** |
| Histórico de sueldos | ✓ | ve **el suyo** | ✗ |

- **Protección contra fuerza bruta en el login**:
  - después de **5 intentos fallidos seguidos** para un mismo usuario, la cuenta queda **bloqueada 15 minutos** (la API responde `429`). Los intentos se cuentan aunque el usuario no exista, para no revelar qué usernames son válidos;
  - además, la API acepta como máximo **20 intentos de login por minuto por IP** (rate limiting de ASP.NET Core).
- **Contraseñas**: mínimo 8 caracteres, con al menos una letra y un número. Se guardan con hash BCrypt. Si al crear un socio, profesor o administrador no se indica usuario/contraseña (como en Escritorio), ambos son el DNI.
- Un administrador no puede eliminar su propio usuario, y no se puede eliminar el último administrador.

## Validaciones y reglas de negocio

Las validaciones se hacen en dos niveles:
- **UI** (Web y Escritorio): antes de llamar a la API, con las reglas de `DTOs/ReglasValidacion.cs`.
- **Modelo de dominio**: cada entidad de `Domain.Model` tiene un método `Validar()` (formato, obligatorios, rangos). Si falla, la API responde `400` con el mensaje. Las reglas que necesitan consultar datos están en `Application.Services` y responden `409`.

| Entidad | Reglas |
|---|---|
| Persona (socio, profesor, admin) | DNI de 7-8 dígitos y único; nombre/apellido solo letras; teléfono de 6-15 dígitos; edad mínima 14 (socio) o 18 |
| Usuario | username de 3-50 caracteres y único; email con formato `nombre@dominio.com` y único |
| Socio | alta no futura y posterior al nacimiento; baja no anterior al alta; plan obligatorio |
| Plan | precio mayor a 0; al menos una actividad existente |
| Turno | día válido; hora de fin posterior a la de inicio; no se repite el mismo día y horario |
| Clase | cupo entre 1 y 200 y no menor a los inscriptos; el profesor no puede tener dos clases en turnos superpuestos |
| Inscripción | socio activo; la actividad tiene que estar incluida en el plan del socio; sin duplicados; con cupo disponible |
| Cuota | período AAAAMM válido, entre el alta y la baja del socio; una sola cuota por socio y período; fecha de pago no futura; al menos un ítem con montos mayores a 0 |
| Máquina / Material | campos obligatorios; estado de la máquina dentro de los valores válidos; stock entre 0 y 100.000 |
| Mantenimiento | fin esperado y fin real no anteriores al inicio; fin real no futuro; una máquina no puede tener dos mantenimientos abiertos |
| Histórico de sueldos | valor mayor a 0; una sola entrada por profesor y fecha |

## Cómo levantar el proyecto

### Requisitos
- .NET 8 SDK
- SQL Server (Express alcanza). Por defecto se usa `localhost\SQLEXPRESS`.

### Pasos
1. Si hace falta, ajustar la cadena de conexión `DefaultConnection` en `WebAPI/appsettings.Development.json`.
2. Levantar la **WebAPI** con el perfil `https` (`https://localhost:7209`). Al iniciar:
   - crea o actualiza la base de datos (aplica las migraciones);
   - si la base no tiene usuarios, **carga los datos de prueba**.
3. Levantar la interfaz:
   - **Web**: `Blazor.Server` con el perfil `https` (`https://localhost:7072`).
   - **Escritorio**: `WindowsFormsApp`.

Desde Visual Studio: *Propiedades de la solución → Proyectos de inicio múltiples* → WebAPI + Blazor.Server (y/o WindowsFormsApp).

Desde la línea de comandos:
```bash
dotnet run --project WebAPI --launch-profile https
dotnet run --project Blazor.Server --launch-profile https
dotnet run --project WindowsForms
```

### Usuarios de prueba

| Rol | Usuario | Contraseña |
|---|---|---|
| Admin | `admin` | `Admin123!` |
| Profesor | `lgomez`, `mdiaz`, `cruiz` | `Profesor123!` |
| Socio | `socio1` … `socio8` | `Socio123!` |

Los datos de prueba incluyen casos para validar cada funcionalidad:
- una clase llena (Spinning, 3/3);
- un socio dado de baja (`socio8`);
- un socio que debe la cuota del mes (`socio7`);
- mantenimientos en los 4 estados;
- histórico de sueldos de los 3 profesores.

Las fechas son relativas al día en que se cargan.

Para volver a cargarlos desde cero: `dotnet ef database drop --project Data --startup-project WebAPI` y volver a levantar la WebAPI. Se pueden desactivar con `"DatosDePrueba": { "Cargar": false }` en `WebAPI/appsettings.json`.

### Clave del JWT
Para desarrollo viene en `WebAPI/appsettings.Development.json`, así que no hace falta configurar nada. Si se define una con `dotnet user-secrets set "JwtSettings:SecretKey" "<clave>"` (mínimo 32 caracteres), esa tiene prioridad. En producción debe venir de una variable de entorno.

## Modelo de Dominio
![Modelo de dominio TPI-Gimnasio](docs/modelo-dominio.jpg)
