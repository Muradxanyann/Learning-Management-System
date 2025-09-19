# Learning Management System (LMS) – ASP.NET Core Pet Project

![.NET](https://img.shields.io/badge/.NET-8-blue)
![C#](https://img.shields.io/badge/C%23-9.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue)
![EF Core](https://img.shields.io/badge/EntityFrameworkCore-8.0-blue)

## 📖 Overview
This is a **Learning Management System (LMS)** pet project built with **ASP.NET Core 8**, designed to practice and demonstrate a full-stack backend architecture using **Onion Architecture** principles.

The project includes three main models:

- **Student** – represents a student entity
- **Course** – represents a course entity
- **Lesson** – represents a lesson inside a course

The project is fully layered:
- **Domain Layer** – entities and interfaces
- **Infrastructure Layer** – database context, migrations, repository implementations
- **Service Layer** – business logic and service interfaces
- **Presentation Layer** – API controllers (CRUD + Swagger)

---

## ✨ Features

- **CRUD operations** for Student, Course, and Lesson
- **DTOs** for request/response to avoid exposing EF Core entities
- **AutoMapper** integration for clean object-to-object mapping
- **Sorting** (dynamic by any field)
- **Filtering** (query-based filtering with DTOs)
- **Pagination** (page number & page size support)
- **Swagger UI** for easy API testing
- **PostgreSQL** database integration with EF Core migrations
- **Onion Architecture** for clear separation of concerns
- **Async/await** for all database operations
- **Fluent API & Data Annotations** for EF Core model configuration
- **GUID primary keys** for all entities
- **Snake_case convention** for PostgreSQL compatibility

---

## 🏗️ Project Structure

The project follows **Onion Architecture** principles and is organized as follows:

📂 Domain
 ├── Domain.csproj
 ├── 📂 Entities
 │    ├── CourseEntity.cs
 │    ├── LessonEntity.cs
 │    ├── StudentEntity.cs
 │    └── StudentCourse.cs
 └── 📂 Exceptions
      └── NotFoundException.cs

📂 Application-Service
 ├── Application-Service.csproj
 ├── 📂 DTOs
 │    ├── 📂 CourseDto
 │    │    ├── CourseForCreationDto.cs
 │    │    ├── CourseForResponseDto.cs
 │    │    └── CourseForResponseDtoWithoutLessons.cs
 │    ├── 📂 LessonDto
 │    │    ├── LessonForCreationDto.cs
 │    │    └── LessonForResponseDto.cs
 │    ├── 📂 StudentDto
 │    │    ├── StudentCourseForCreationDto.cs
 │    │    ├── StudentForCreationDto.cs
 │    │    ├── StudentForResponseDto.cs
 │    │    └── TakeCourseDto.cs
 │    └── QueryParametersDTO.cs
 ├── 📂 Filters
 │    ├── CourseFilter.cs
 │    ├── LessonFilter.cs
 │    ├── StudentFilter.cs
 │    └── PaginationBase.cs
 ├── 📂 Extensions
 │    └── IQueryableExtensions.cs
 ├── 📂 Interfaces
 │    ├── IBaseService.cs
 │    ├── ICourseService.cs
 │    ├── ILessonService.cs
 │    ├── IStudentService.cs
 │    └── IServiceManager.cs
 ├── 📂 ProfilesForMapping
 │    ├── CourseProfile.cs
 │    ├── LessonProfile.cs
 │    ├── StudentProfile.cs
 │    └── StudentCourseProfile.cs
 └── 📂 Services
      ├── BaseService.cs
      ├── CourseService.cs
      ├── LessonService.cs
      ├── StudentServices.cs
      └── ServiceManager.cs

📂 Infrastructure-DataAccsess
 ├── Infrastructure-DataAccsess.csproj
 ├── AppDbContext.cs
 ├── 📂 Configurations
 │    ├── CourseConfiguration.cs
 │    ├── LessonConfiguration.cs
 │    ├── StudentConfiguration.cs
 │    └── StudentCourseConfiguration.cs
 └── 📂 Migrations
      ├── AppDbContextModelSnapshot.cs
     
📂 Presentation
 ├── Presentation.csproj
 ├── Program.cs
 ├── appsettings.json
 ├── appsettings.Development.json
 ├── 📂 Properties
 │    └── launchSettings.json
 └── 📂 Controllers
      ├── CourseController.cs
      ├── LessonController.cs
      └── StudentController.cs

---

## 🛠️ Technologies Used

- **ASP.NET Core 8** – Web API framework
- **Entity Framework Core** – ORM for PostgreSQL
- **PostgreSQL** – Relational database
- **Swashbuckle / Swagger** – Interactive API documentation
- **AutoMapper** – DTO ↔ Entity mapping
- **Onion Architecture** – Layered architecture pattern
- **DTOs** – Clean API models and data transfer
- **LINQ + IQueryable Extensions** – Sorting, filtering, pagination

---

## 📌 Notes

- **GUID IDs** are auto-generated for all entities.
- **DTOs** are used to avoid exposing database entities directly to the client.
- **AutoMapper** simplifies mapping between entities and DTOs.
- **Sorting, Filtering, Pagination** are implemented with reusable `IQueryable` extensions.
- **Onion Architecture** separates core business logic from infrastructure and presentation layers.
- **Database schema** uses `snake_case` for PostgreSQL compatibility.
- **Swagger UI** is fully integrated for testing all CRUD + query features.

---  

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
   
5.Access Swagger UI

Open your browser and navigate to: https://localhost(5001)/swagger
