# 🎓 Learning Management System (LMS) – ASP.NET Core Web API

![.NET](https://img.shields.io/badge/.NET-8.0-blue)  
![EF Core](https://img.shields.io/badge/EF--Core-PostgreSQL-green)  
![Identity](https://img.shields.io/badge/Identity-JWT-orange)  
![Status](https://img.shields.io/badge/Status-Development-yellow)

A structured **Learning Management System (LMS)** built with **ASP.NET Core Web API**.  
It provides authentication, authorization, course management, and user roles with a clean architecture approach.

---

## ✨ Features

- **Authentication & Authorization**
    - JWT-based authentication
    - Role-based authorization (`Admin`, `Student`)
    - Automatic seeding of roles and admin user

- **Core Functionality**
    - Course management (`CourseService`, `LessonService`)
    - Student course enrollment (`TakeCourse`)
    - User management

- **Infrastructure**
    - **Entity Framework Core + PostgreSQL**
    - **ASP.NET Core Identity**
    - **AutoMapper** for DTO ↔ Entity mapping
    - **Serilog** for logging
    - **FluentValidation** for request validation
    - **Custom Exception Handling Middleware**

- **Developer Experience**
    - OpenAPI docs powered by **Scalar** (instead of Swagger)
    - Automatic API reference UI

---

## 📂 Project Structure
```
Learning_Management_System/
├── Application/
│   ├── DTOs/                # Data Transfer Objects (Login, Register, AuthResponse, etc.)
│   ├── Interfaces/          # Service interfaces
│   ├── ProfilesForMapping/  # AutoMapper profiles
│   └── Services/            # Business logic (TokenService, UserService, etc.)
│
├── Domain/
│   ├── Entities/            # Core entities (User, Course, Lesson, etc.)
│   └── Exceptions/          # Custom domain exceptions
│
├── Infrastructure___Persistence/
│   ├── AppDbContext.cs      # EF Core DbContext
│   └── IdentitySeeder.cs    # Seeds roles and admin user
│
├── Presentation/
│   ├── Controllers/         # API controllers (AuthController, UserController, etc.)
│   ├── Middleware/          # ExceptionHandlingMiddleware
│   └── Program.cs           # App entry point & DI setup
│
└── README.md
```
---

## 🔐 Authentication & Authorization

### JWT Settings (`appsettings.json`):
```json
"JwtSettings": {
  "Secret": "your-very-strong-secret-key",
  "Issuer": "LMS",
  "Audience": "LMSClient",
  "ExpiresMinutes": 60
} 
```
# Example: Login Request
```
POST /api/auth/login
Content-Type: application/json

{
  "email": "student@example.com",
  "password": "Password123!"
}
```

# Example: Protected Endpoint
```
POST /takeCourse?courseId=123e4567-e89b-12d3-a456-426614174000
Authorization: Bearer <your_token>
```
---
🛠 Technologies Used

- **ASP.NET Core 8.0 – Web API framework**
- **Entity Framework Core – Data access**
- **PostgreSQL – Database**
- **ASP.NET Core Identity – Authentication & Roles**
- **JWT (System.IdentityModel.Tokens.Jwt) – Token-based auth**
- **AutoMapper – Object mapping**
- **Serilog – Logging**
- **FluentValidation – Input validation**
- **Scalar.AspNetCore – OpenAPI & API reference**
---

## 📌 Notes

- **GUID IDs** are auto-generated for all entities.
- **DTOs** are used to avoid exposing database entities directly to the client.
- **AutoMapper** simplifies mapping between entities and DTOs.
- **Sorting, Filtering, Pagination** are implemented with reusable `IQueryable` extensions.
- **Onion Architecture** separates core business logic from infrastructure and presentation layers.
- **Database schema** uses `snake_case` for PostgreSQL compatibility.

---

## Installation Steps

Follow these steps to get the Learning Management System running locally:

1. **Clone the repository**  
   Clone the project to your local machine:

   ```bash
   git clone https://github.com/Muradxanyann/LearningManagementSystem.git
   cd LearningManagementSystem
   
2. **Update the database connection**
   Open appsettings.json and set your PostgreSQL connection string:
    
    ```bash
      "ConnectionStrings": {
           "DefaultConnection": "Host=localhost;Database=LMSDb;Username=postgres;Password=yourpassword"
      }

3. **Apply Entity Framework Core migrations**
      Run the following commands to create the database schema and tables:

    ```bash
   dotnet ef database update
   dotnet run
   
4. **Run the project**
    ```bash
    dotnet run --project Presentation

Access OpenAPI Docs

After running the app in Development, visit:
```
https://localhost:5001/scalar/v1
```


📌 Roadmap
- **Add Unit & Integration Tests**
- **Implement Teacher role**
- **Add Course Progress Tracking**
- **Add Caching & Rate Limiting**

👨‍💻 Author

Developed with ❤️ using ASP.NET Core.
