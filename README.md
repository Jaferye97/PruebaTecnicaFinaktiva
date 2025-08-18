# 📦 Proyecto: Gestión de Log de eventos

## 🧾 Descripción

Este proyecto implementa una solución completa para la gestión de logs de eventos, utilizando buenas prácticas de arquitectura y tecnologías modernas en el backend y frontend.

- **Backend**: .NET Core 8 con arquitectura **hexagonal**, acceso a datos mediante **Entity Framework** y base de datos **SQL Server**.
- **Frontend**: **Angular 17** con Angular Material, diseño modular y uso de formularios reactivos.
- Comunicación entre capas desacoplada y organizada bajo principios **SOLID** y **Clean Architecture**.

---

## 🚀 Características
- 📄 Registro de logs de eventos
  - Desde Formulario de eventos manuales (Frontend).
  - Automáticamente en el Backend cuando:
      - Se llama un endpoint (ActionFilter).
      - Ocurre un error (Midlleware).
      - Se ingresa o actualiza un registro en una entidad.
- 🧪 Validaciones de formularios en frontend.
- 💾 Acceso a datos con Entity Framework.
- ✅ Integración de formularios con Angular Material.
- 🎨 Diseño responsive y moderno usando Angular Material + Bootstrap.

---

## ⚙️ Tecnologías Usadas

| Backend               | Frontend          |
|----------------------|-------------------|
| .NET 8               | Angular 17        |
| C#                   | Angular Material  |
| Entity Framework     | RxJS              |
| SQL Server           | TypeScript        |
| Arquitectura Hexagonal | Formularios Reactivos |

---


## 🛠️ Estructura del Proyecto

```
/BD
└── 01. Base structure

/Backend
└── Application
│   ├── Ports
│   └── UseCases
└── Domain
│   └── Model
└── Infrastructure
    └── Adapters
        ├── In
        │   └── WebApi
        │       ├── ActionFilters
        │       └── Middlewares
        └── Out
            └── ReporitorySqlServer

/Frontend
└── src
    ├── app
    │   ├── components-general
    │   │   └── layout
    │   │       └── sidebar
    │   └── views
    │       └── eventLogs
    │       │   ├── components
    │       │   │   └── event-logs-add
    │       │   ├── interfaces
    │       │   ├── event-logs-list
    │       │   └── services
    │       └── customers
    │           ├── interfaces
    │           ├── customers-add
    │           ├── customers-list
    │           ├── customers-update
    │           └── services
    ├── environments
    ├── utils
    └── core
```

---


## 💡 Cómo Ejecutarlo

### 🗄️ Scripts de Base de Datos

Antes de ejecutar el proyecto, asegúrate de crear las tablas necesarias ejecutando los siguientes scripts ubicados en la carpeta `/DB`:

1. `01. Base structure.sql` – Script que contiene la estructura base de las tablas requeridas (customers, eventLogs).

### ⚙️ Backend (.NET)

> ⚠️ **Importante:** Asegúrate de configurar la cadena de conexión en appsettings.json.

```bash
cd Backend/WebApi
dotnet restore
dotnet run
```

### 🖥️ Frontend (Angular)

```
cd Frontend
npm install
ng serve
```

---


## 🙋 Autor

### Yeimer Andres Jaramillo Fernandez
📧 Mail: Andresjara0897@hotmail.com <br/>
💼 GitHub: https://github.com/Jaferye97 <br/>
🔗 LinkedIn: https://www.linkedin.com/in/yeimerjarafer/ <br/>

