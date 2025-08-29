# curso-microservicios

Repositorio hecho para compartir el material del curso de **Microservicios**.

## Requisitos técnicos para el curso

En este curso se utilizó **.NET** para los servicios.

## Uso de Postgres en lugar de SQL Server

### 1. Crear contenedor en el puerto 5434

```bash
docker run -d --name curso-microservicios \
  -p 5434:5432 \
  -v pgdata_platzi:/var/lib/postgresql/data \
  -e POSTGRES_PASSWORD=secretpass \
  -e POSTGRES_USER=user \
  -e POSTGRES_DB=microservicios \
  postgres:14
```

### 2. Acceder a la consola de Postgres

```bash
docker exec -it curso-microservicios psql -U user -d microservicios
```

### 3. Crear tabla `Adults` e insertar registros

```sql
CREATE TABLE Adults (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100),
    Lastname VARCHAR(100),
    BirthYear INT,
    ImageUrl TEXT
);

INSERT INTO Adults (Name, Lastname, BirthYear, ImageUrl) VALUES
('Juan', 'Perez', 1985, 'jperez.jpg'),
('Alan', 'Garcia', 1994, 'agarcia.jpg'),
('Monica', 'Delta', 1980, 'mdelta.jpg');
```

### 4. Connection string en el proyecto

```text
jdbc:postgresql://localhost:5434/microservicios?user=user&password=secretpass
```

### 5. Agregar paquete de Postgres al proyecto

```bash
cd curso-microservicios/src/ApiGlobal
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### 6. Configurar `Startup.cs` o `Program.cs`

```csharp
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
```

---