# SOLID API Demo - ASP.NET Core 8

Proyecto desarrollado en **ASP.NET Core Web API (.NET 8)** 
para demostrar la aplicación práctica de los **cinco principios SOLID** 
utilizando la **Inyección de Dependencias (Dependency Injection)** integrada de ASP.NET Core.

## Objetivo

Este proyecto tiene fines educativos y muestra una arquitectura sencilla basada en buenas prácticas de desarrollo, 
separando responsabilidades mediante interfaces y servicios.

## Tecnologías

- C#
- .NET 8
- ASP.NET Core Web API
- Dependency Injection
- Swagger / OpenAPI
- Visual Studio Community 2022

## Arquitectura

```
SolidApiDemo
│
├── Controllers
├── Interfaces
├── Models
├── Repository
├── Services
├── Program.cs
└── appsettings.json
```

## Principios SOLID implementados

### S - Single Responsibility Principle (SRP)

Cada clase tiene una única responsabilidad.

Ejemplos:

- `OrderRepository` → Guarda pedidos.
- `EmailService` → Envía notificaciones.
- `PremiumDiscount` → Calcula descuentos.
- `OrderService` → Coordina el procesamiento del pedido.

---

### O - Open/Closed Principle (OCP)

El sistema puede extenderse sin modificar el código existente.

Por ejemplo, para agregar un nuevo tipo de descuento solo es necesario crear una nueva implementación de `IDiscount`.

```csharp
public class BlackFridayDiscount : IDiscount
{
    public decimal Apply(decimal total)
    {
        return total * 0.60m;
    }
}
```

---

### L - Liskov Substitution Principle (LSP)

Cualquier implementación de `IDiscount` puede sustituir a otra sin afectar el comportamiento del sistema.

---

### I - Interface Segregation Principle (ISP)

Las interfaces son pequeñas y específicas.

- IRepository
- IMessageService
- IDiscount

Cada clase implementa únicamente los métodos que necesita.

---

### D - Dependency Inversion Principle (DIP)

`OrderService` depende de interfaces y no de implementaciones concretas.

Las dependencias son resueltas automáticamente por el contenedor de Dependency Injection de ASP.NET Core.

```csharp
builder.Services.AddScoped<IRepository, OrderRepository>();
builder.Services.AddScoped<IMessageService, EmailService>();
builder.Services.AddScoped<IDiscount, PremiumDiscount>();
```

## Flujo de la aplicación

1. El cliente realiza una petición HTTP POST.
2. El controlador recibe el pedido.
3. `OrderService` aplica el descuento.
4. Se guarda el pedido.
5. Se envía una notificación.
6. Se devuelve el pedido procesado.

```
Cliente
    │
    ▼
OrdersController
    │
    ▼
OrderService  ├─────────┐
	  │              			│
	  ▼              			▼
Repository   			  Discount
 │             				  │
 └──────┬───────────────┘
        ▼
	MessageService
        │
        ▼
	Respuesta HTTP
```

## Ejecutar el proyecto

Clonar el repositorio:

```bash
git clone https://github.com/tu_usuario/SolidApiDemo.git
```

Entrar al proyecto:

```bash
cd SolidApiDemo
```

Ejecutar:

```bash
dotnet run
```

Abrir Swagger:

```
https://localhost:5001/swagger
```

> El puerto puede variar según la configuración del proyecto.

## Ejemplo de petición

**POST**

```
/api/orders
```

Body

```json
{
  "id": 1,
  "customer": "Rita",
  "total": 1000
}
```

Respuesta

```json
{
  "id": 1,
  "customer": "Rita",
  "total": 850
}
```

## Características

- Arquitectura por capas
- Principios SOLID
- Interfaces
- Dependency Injection
- Repository Pattern
- Swagger para pruebas de la API
- Código simple y fácil de extender
