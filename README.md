<a name="readme-top"></a>

<div align="center">

## Proyecto prueba desarrollador - Proyecto de Gestión de Event Logs

</div>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Inicio

Este repositorio contiene una aplicación completa de gestión de eventos (Event Logs) con dos capas principales:

- Backend: API REST construida con ASP.NET Core 8 y Entity Framework Core para la persistencia.
- Frontend: SPA construida con Angular (Standalone Components) que consume la API y muestra los eventos con filtros.

## BACKEND

Clona el repositorio:

git clone: https://github.com/ronaldtro/test_logsAdmin_finaktiva

Ajusta la cadena de conexión en appsettings.json:

"ConnectionStrings": {
  "RegistrationDb": "Server=TU_SERVIDOR;Database=Registration;User Id=xx;Password=yy;TrustServerCertificate=True;"
}

Instala las dependencias y aplica migraciones:

dotnet restore
dotnet ef database update

Ejecución:

Para levantar la API en modo desarrollo:

cd backend
dotnet run

Por defecto se publicará en https://localhost:5001 y http://localhost:5000.
Accede a Swagger UI en https://localhost:5001/swagger.

Detalles de Diseño:

- Arquitectura: Mediante Controladores, Servicios y Data Context (EF Core) desacoplado.

- Transaccionalidad: Uso de BeginTransactionAsync() en operaciones de escritura.

- DTOs: Salida tipada con EventLogDto, EventTypeDto y EventLogListResponse.

- Logging: Inyección de ILogger<> en Controller y Service para capturar excepciones.

- Filtros: Consulta de logs en base de datos aplicando filtros EventTypeId, DateFrom, DateTo.

## FRONTEND

El frontend es una SPA en Angular que consume la API y muestra los logs con filtros dinámicos.

Configuración (Frontend)

Navega a la carpeta del cliente:

cd tu-repo/frontend

Instala dependencias:

npm install
o
yarn install

Ejecución (Frontend)

Para levantar el servidor de desarrollo Angular:

Dentro del frontend
npm start
o
ng serve --open

El cliente correrá por defecto en http://localhost:4200 y se comunicará con el backend en el puerto 5001.

Detalles de Diseño (Frontend):

- Standalone Components: Uso de @Component({ standalone: true }) para reducir módulos.

- Service Layer: EventLogApi centraliza llamadas HTTP usando HttpClient.

- Formulario de Filtros: Permite seleccionar tipo de evento y rango de fechas, enviando query params al backend.

- Manejo de Errores: Alertas globales (WarningAlert, DangerAlert) y botón de carga deshabilitado.

- UX: Indicadores de carga y mensajes cuando no hay coincidencias.


<p align="right">(<a href="#readme-top">back to top</a>)</p>

### By

 [![ronaldtro](https://avatars.githubusercontent.com/u/72902488?s=64&amp;v=4)](http://github.com/ronaldtro) 

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Stack

[![Angular][angular-badge]][badge-empty-url]
[![DotNet][dotnet-badge]][badge-empty-url]
[![CSharp][csharp-badge]][badge-empty-url]
[![SQLServer][sqlserver-badge]][badge-empty-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

[dotnet-badge]: https://img.shields.io/badge/-.NET-5632d5?style=for-the-badge
[angular-badge]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge
[csharp-badge]: https://img.shields.io/badge/C%23-690081?style=for-the-badge
[sqlserver-badge]: https://img.shields.io/badge/SQL%20Server-1f72b8?style=for-the-badge
[badge-empty-url]: #!
