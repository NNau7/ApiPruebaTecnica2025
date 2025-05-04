# 📦 Api Prueba Tecnica 2025

API RESTful desarrollada con ASP.NET Core que permite la gestión de productos y sus categorías asociadas.

---

## 📑 Tabla de Contenidos

- [Tecnologías](#tecnologías)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Migraciones](#migraciones)
- [Ejecución](#ejecución)
- [Endpoints](#endpoints)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Notas](#notas)
- [Autor](#autor)

---

## 🚀 Tecnologías

Lista de tecnologías utilizadas:

- ASP.NET Core
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger / OpenAPI
- Data Annotations

---

## ⚙️ Instalación

Pasos para clonar el repositorio y trabajar localmente:

```bash
git clone <https://github.com/NNau7/ApiPruebaTecnica2025.git>
cd <ApiPruebaTecnica2025>
```

## 🔧 Configuracion

-Editar el archivo appsettings.json para definir la cadena de conexión:

-"Provider": significa el servicio de DB con la que correra el API, actualmente cuenta con soporte en SQL,MYSQL Y POSTGRESQL.
  ```java
  "DatabaseSettings": {
      "Provider": "SQL",
      "ApiConnection": "Data Source=;Database=ProductDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
    }
 ```


## 🗃️ Migraciones
```bash
dotnet ef update-database
```
o tambien en la consola de paquete NuGet:
```bash
update-database
```

## ▶️ Ejecución
- Ejecutar el proyecto:
  ```bash
  dotnet run
  ```
- La documentación Swagger estará disponible en:
  ```bash
  https://localhost:<puerto>/swagger
  ```

## 📚 Endpoints
Categorías

-POST /api/categorias → Crear categoría

-GET /api/categorias → Obtener todas las categorías

-GET /api/categorias/{id} → Obtener una categoría por ID

-DELETE /api/categorias/{id} → Eliminar una categoría (solo si no tiene productos asociados)

Productos

-POST /api/productos → Crear producto asociado a una categoría

-GET /api/productos → Obtener todos los productos (incluye datos de la categoría)

-GET /api/productos/{id} → Obtener un producto por ID

-PUT /api/productos/{id} → Editar un producto

-DELETE /api/productos/{id} → Eliminar un producto

## 🗂️ Estructura del Proyecto
```java
/Controllers          → Controladores de API
/DTOs                 → Data Transfer Objects (entrada/salida)
/Models               → Entidades del dominio (Product, Categoria)
/Profiles             → Configuración de AutoMapper
/Data                 → DbContext y configuración de EF Core
/Migrations           → Migraciones de la base de datos
```

## 📝 Notas

-La relación entre entidades es 1:N (una categoría puede tener muchos productos).

-AutoMapper se configura en Profiles/MappingProfile.cs.

-Se usan DTOs con validaciones usando Data Annotations.

-Swagger está habilitado automáticamente en entorno de desarrollo.


## 👤 Autor

Nombre: [Mauricio Ribotta]

Correo: [mauriribotta@gmail.com]
