<a name="readme-top"></a>

<div align="center">

## Proyecto - Gestión de Event Logs

</div>

## STACK
<div align="center">

![Angular][angular-badge]
![DotNet][dotnet-badge]
![CSharp][csharp-badge]
![SQLServer][sqlserver-badge]

</div>

## INICIO

- BACKEND: API REST construida con ASP.NET Core 8 y Entity Framework Core.
- FRONTEND: SPA construida con Angular (Standalone Components) que consume la API y muestra los eventos con filtros.

## CONFIGURACION INICIAL

- git clone: https://github.com/ronaldtro/test_logsAdmin_finaktiva

## BACKEND

- cd /backend

- Abre la solución de .net.

- Ajusta la cadena de conexión local en appsettings.json:
"Connection": "Server=(Tu instancia)\\SQLEXPRESS; DataBase=(Registration); Trusted_Connection=True; TrustServerCertificate=True;"


Instala las dependencias y compila la solición:

- Click derecho a la solución y restaurar paquetes NuGet.
- Compilar solución y ejecutar.


Detalles de Diseño:

- Arquitectura: Mediante Controladores, Servicios y Data Context (EF Core) desacoplado.

- Transaccionalidad: Uso de BeginTransactionAsync() en operaciones de escritura.

- DTOs: Salida tipada con EventLogDto, EventTypeDto y EventLogListResponse.

- Logging: Inyección de ILogger<> en Controller y Service para capturar excepciones.

- Filtros: Consulta de logs en base de datos aplicando filtros EventTypeId, DateFrom, DateTo.


## FRONTEND

- cd /frontend

Instalar dependencias:

- npm install ó yarn install


Ejecucion servidor local:

- ng serve 


Detalles del Diseño:

- Standalone Components: Uso de @Component({ standalone: true }) para reducir módulos.

- Service Layer: EventLogApi centraliza llamadas HTTP usando HttpClient.

- Formulario de Filtros: Permite seleccionar tipo de evento y rango de fechas, enviando query params al backend.

- Manejo de Errores: Alertas globales (WarningAlert, DangerAlert) y botón de carga deshabilitado.

- UX: Indicadores de carga y mensajes.


<p align="right">(<a href="#readme-top">back to top</a>)</p>

### BY

 [![ronaldtro](https://avatars.githubusercontent.com/u/72902488?s=64&amp;v=4)](http://github.com/ronaldtro) 


<p align="right">(<a href="#readme-top">back to top</a>)</p>

[dotnet-badge]: https://img.shields.io/badge/-.NET-5632d5?style=for-the-badge
[angular-badge]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge
[csharp-badge]: https://img.shields.io/badge/C%23-690081?style=for-the-badge
[sqlserver-badge]: https://img.shields.io/badge/SQL%20Server-1f72b8?style=for-the-badge