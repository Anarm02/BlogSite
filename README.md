# BlogSite

**BlogSite** is a blog platform built with **ASP.NET Core MVC** using the **N-Tier Architecture**. This project allows users to manage blog posts, upload images, and provides user registration and login functionality.

## 📚 Technologies and Tools

- **ASP.NET Core MVC** – Web application framework
- **Entity Framework Core (EF Core)** – ORM (Object-Relational Mapping) for SQL Server integration
- **SQL Server** – Database management system
- **ASP.NET Core Identity** – User authentication and management
- **Cookie-based Authentication** – Secure user authentication method using cookies
- **AutoMapper** – Object-to-object mapping
- **FluentValidation** – Model validation
- **Unit of Work Pattern** – Coordinated management of database operations
- **Local File Storage** – Image upload and storage

## 🚀 Key Features

- **CRUD Operations** – Create, read, update, and delete blog posts
- **Image Uploading** – Upload images to the `wwwroot/uploads` folder
- **User Management** – User registration and login using cookie-based authentication
- **Model Validation** – Validation of forms using FluentValidation
- **AutoMapper** – Mapping between DTOs and Entities
- **Architecture** – Clean and scalable project structure using N-Tier architecture

## 📁 Project Structure

```text
BlogSite/
├── BlogSite.UI          --> ASP.NET Core MVC frontend
├── BlogSite.Business    --> Services (Services, Managers)
├── BlogSite.DataAccess  --> Repository and UoW implementation
├── BlogSite.Entities    --> Entity models and DTOs
├── BlogSite.Core        --> Core interfaces and helper classes
