# TaskManager

Aplicación web ASP.NET Core MVC para la gestión de tareas (CRUD).  
Prueba técnica para desarrollador Full Stack C#.

## Tecnologías

- .NET 8
- ASP.NET Core MVC (Razor Views)
- Entity Framework Core 8 + SQL Server
- Bootstrap 5

## Arquitectura

```
Controllers → Services → Repositories → EF Core → SQL Server
```

- **Controllers**: Reciben peticiones HTTP, usan ViewModels y delegan al servicio.
- **Services**: Lógica de negocio (validaciones, reglas).
- **Repositories**: Acceso a datos vía EF Core.
- **ViewModels**: Modelos de vista con Data Annotations para validación.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local o Docker)

### SQL Server con Docker (Linux)

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Admin1234!' \
  -p 1433:1433 --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

## Base de datos

Ejecutar el script `TaskManager/Data/script.sql` contra tu instancia de SQL Server para crear la base de datos y la tabla `ProjectTasks`:

```bash
sqlcmd -S localhost,1433 -U sa -P 'Admin1234!' -i TaskManager/Data/script.sql
```

O desde Docker:

```bash
docker exec -i sqlserver /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U sa -P 'Admin1234!' -C \
  -d TaskManagerDb -i TaskManager/Data/script.sql
```

## Configurar conexión

La connection string se puede configurar de dos formas:

### Opción 1: User Secrets

```bash
dotnet user-secrets init --project TaskManager/TaskManager.csproj
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=TaskManagerDb;User Id=sa;Password=Admin1234!;TrustServerCertificate=True;" --project TaskManager/TaskManager.csproj
```

### Opción 2: Editar appsettings.json

En `TaskManager/appsettings.json`, reemplazar `TU_CONTRA_AQUI` con la contraseña real:

```json
"DefaultConnection": "Server=localhost,1433;Database=TaskManagerDb;User Id=sa;Password=TU_CONTRA_AQUI;TrustServerCertificate=True;"
```
## Clonar Repositorio
```bash
git clone -b master https://github.com/LuisHV935/Prueba_Tecnica_ASP.NET_FullStack_EntryLevel.git
```

## Compilar y ejecutar

```bash
# Compilar
dotnet build TaskManager/TaskManager.csproj

# Ejecutar
dotnet run --project TaskManager/TaskManager.csproj
```

Abrir `http://localhost:5000` en el navegador.

## Estructura del proyecto

```
TaskManager/
├── Controllers/
│   ├── HomeController.cs
│   └── TasksController.cs        # CRUD de tareas
├── Data/
│   ├── AppDbContext.cs            # Contexto de EF Core
│   └── script.sql                 # Script de creación de BD
├── Models/
│   └── ProjectTask.cs             # Entidad ProjectTasks
├── Repositories/
│   ├── ITaskRepository.cs         # Contrato del repositorio
│   └── TaskRepository.cs          # Acceso a datos
├── Services/
│   ├── ITaskService.cs            # Contrato del servicio
│   └── TaskService.cs             # Lógica de negocio
├── ViewModels/
│   └── TaskViewModel.cs           # ViewModel con validaciones
├── Views/
│   ├── Home/                      # Páginas estáticas
│   └── Tasks/                     # Vistas del CRUD
│       ├── Index.cshtml           # Lista de tareas
│       ├── Details.cshtml         # Detalle
│       ├── Create.cshtml          # Crear tarea
│       ├── Edit.cshtml            # Editar tarea
│       └── Delete.cshtml          # Confirmar eliminación
├── Program.cs                     # Punto de entrada y DI
└── appsettings.json               # Configuración
```
