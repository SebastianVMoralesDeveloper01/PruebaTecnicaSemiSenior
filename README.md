# Prueba técnica – Desarrollador Semi Senior

## Tecnologías
- .NET Core 8.0 – ASP.NET Core Web API 
- SQL Server

## Estructura
- `PruebaTecnica.Api/` – API REST
- `Script_DB/` – Scripts de base de datos

## Cómo ejecutar
1. Ejecutar los scripts de `Script_DB/` en SQL Server.
2. Ajustar la cadena de conexión en `api/appsettings.json`.
3. API: abrir la solución y ejecutar (F5), o `dotnet run` dentro de `api/`.

## Qué se implementó
- Se realizo la creación de 3 tablas en BD (TipoDocumento, Genero, Pacientes), asi como la creación de los SP (SP_Crear_Paciente, SP_Consulta_Pacientes, SP_Consulta_Pacientes_Id).
- Se realiza la creación del proyecto api, con la conexión a BD y su respectiva inyección en el controlador.

## Pendiente y cómo lo completaría
- Pendiente: >Crear los endpoints para consultas, actualización y eliminación
- Pendiente: creación del proyecto frontEnd en angular