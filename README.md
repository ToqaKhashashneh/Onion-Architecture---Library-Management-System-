# 📚 Onion Architecture — Library Management System  

A full-stack web application built with **ASP.NET Core API** (Onion Architecture) and **Angular** to manage **Books** and **Categories**.  
Supports full **CRUD operations** with a clean UI and SQL Server database.  

---

## 🚀 Features  

### 🔹 Backend (ASP.NET Core API)  
- Built with **Onion Architecture** (API, Application, Domain, Infrastructure).  
- CRUD operations for **Books** and **Categories**.  
- Stored Procedures for advanced queries.  
- Swagger integration for API documentation.  

### 🔹 Frontend (Angular 17)  
- Clean UI built with **Angular** and **CSS**.  
- Integrated with **Bootstrap icons**  
- Category Management (Add, Edit, Delete, List).  
- Book Management (Add, Edit, Delete, List with Categories).  
- Modal-based forms (no external libraries).  

### 🔹 Database (SQL Server)  
- `CreateTables.sql` → script to generate DB schema.  
- `StoredProcedures.sql` → script for stored procedures (Books + Categories).  

---

## 📂 Project Structure 
LibrarySolution/
│── Library.API/ # ASP.NET Core Web API (Presentation Layer)
│── Library.Application/ # Application Layer (Services, DTOs)
│── Library.Domain/ # Domain Layer (Entities, Interfaces)
│── Library.Infrastructure/ # Infrastructure Layer (EF Core, Repositories, SPs)
│── library-ui/ # Angular Frontend (Books + Categories UI)
│── CreateTables.sql # SQL Script to create tables
│── StoredProcedures.sql # SQL Script for stored procedures
│── LibrarySolution.sln # Visual Studio solution


---

## ⚙️ Setup Instructions  

### 🔹 Backend (ASP.NET Core API)  
1. Open solution in **Visual Studio**.  
2. Update `appsettings.json` with your SQL Server connection string.  
3. Run migrations (if needed) or execute `CreateTables.sql` + `StoredProcedures.sql`.  
4. Run the API → Swagger will be available at:  
https://localhost:7260/swagger
### 🔹 Frontend (Angular)  
1. Navigate to frontend folder:  
```bash
cd library-ui
2. Install dependencies:
npm install
3. Run the app:
ng serve -o
App runs on:
http://localhost:4200

🛠️ Tech Stack

Backend: ASP.NET Core 7, Onion Architecture, EF Core, SQL Server

Frontend: Angular 17, Bootstrap icons

Database: SQL Server (Stored Procedures)
