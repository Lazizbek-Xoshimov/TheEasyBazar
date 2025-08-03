# TheEasyBazar 🛒

**TheEasyBazar** is a modern and scalable e-commerce backend platform built using ASP.NET Core. It follows Clean Architecture principles and incorporates best practices for enterprise-level development.

## 🚀 Key Features
- ✅ **ASP.NET Core** - Fast and powerful Web API
- ✅ **SQL Server** - Reliable and robust relational database
- ✅ **Entity Framework Core** - Simplified database interaction using ORM
- ✅ **AutoMapper* - Automatic mapping between Entities and DTOs
- ✅ **Middleware** - Custom middleware for logging, error handling, and authentication
- ✅ **Log Files** - Track and monitor system behavior through logs
- ✅ **Clean Architecture** - Modular, testable, and maintainable codebase

---

# 📁 Project Structure

The project is organized according to Clean Architecture:
- `Domain` - Contains core business models and logic
- `Application` - Application-specific logic and service interfaces
- `Infrastructure` - Database context, repositories, and external service implementations
- `WebApi` - API layer that interacts with clients

## 🔧 Getting Started
1. Configure your SQL Server connection string in `appsettings.json`.
2. Run the following commands in the terminal:
```bash
dotnet ef database update
dotnet run```


