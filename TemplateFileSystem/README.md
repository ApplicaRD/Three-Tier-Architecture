# Modelo de tres capas (Three-Tier Architecture)

## Descripción de Carpetas

- Data:
    - Models: Contiene las clases de modelos de datos que representan las entidades de tu aplicación, incluyendo las
      entidades de configuración.
    - Repositories: Contiene las clases que manejan la interacción con la base de datos. Aquí implementarías el patrón
      Repository para encapsular el acceso a datos.
    - Migrations: Contiene las migraciones generadas por Entity Framework Core.
    - DbContexts: Contiene la clase DbContext que maneja la conexión a la base de datos y la configuración de las
      entidades.

- Business:
    - Services: Contiene las clases que implementan la lógica de negocio.
    - Interfaces: Contiene las interfaces para los servicios.


- Presentation:
    - Views: Contiene los archivos XAML que definen la interfaz de usuario.
    - ViewModels: Contiene las clases ViewModel que manejan la lógica de presentación.

- Utilities: Puede contener clases y métodos auxiliares que se utilizan en toda la aplicación.

- Resources: Puede contener recursos compartidos, como estilos, plantillas, y otros recursos XAML.

# Entity Framework Core Sql Lite

## Ejemplo de uso

### Instalación de paquetes por consola Package Manager (PM)

```
Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database
```

### Instalación de paquetes por consola .NET CLI

```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet ef migrations add InitialCreate
dotnet ef database update
```

###### by [José O. Lara]

- ###### Version 1.0.0
- ###### Revision 2024.08.03


