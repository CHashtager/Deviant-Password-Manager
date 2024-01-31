# Deviant Password Manager

## Introduction

This repository contains the implementation discussions and code snippets for creating a shared password manager using ASP.NET Core. The project involves user authentication, project management, and secure password storage.

## Project Overview

The goal of this project is to create a secure shared password manager where users can manage passwords within projects, each having specific access controls. The implementation discussions cover user management, project administration, and various steps to ensure secure password management.

## Key Features

1. **User Authentication:**
    - Utilizes ASP.NET Core Identity for managing user authentication.
    - Implements secure login and registration endpoints.

2. **Project Management:**
    - Defines project administration roles and access controls.
    - Users can be project admins and have control over shared passwords within their projects.

3. **Password Storage and Retrieval:**
    - Uses AES and BouncyCastle for hashing and securing passwords.

4. **Endpoint Design:**
    - Defines API endpoints for identity, project and password management.

## Architecture

The application is based on .NET 8 and Ardalis Clean Architecture. The backend interacts with a SQL Server database to store user accounts, projects, and encrypted passwords. Using Serilog as Logger system, FastEndpoints for Api Route building and Input Validation, REPL Pattern.

## Key Components

- **ASP.NET Core Web API:** The backend API handles user authentication, project management, and password CRUD operations.
- **Entity Framework Core:** Object-Relational Mapping (ORM) framework used to interact with the SQL Server database.
- **Identity Framework:** Provides user management, authentication, and authorization capabilities.
- **JWT Tokens:** Used for user authentication and authorization across API endpoints.
- **Data Protection API:** Encrypts and decrypts sensitive data like passwords before storing them in the database.

## Getting Started

Do not forget to change db password in `appsettings.json`

```bash
$ git clone https://github.com/omidpakdel/Deviant-Password-Manager.git
$ cd Deviant-Password-Manager
$ dotnet restore
$ dotnet ef migrations add InitIdentity -c AppIdentityDbContext -p src/DeviantPasswordManager.Infrastructure -s src/DeviantPasswordManager.Web -o Identity/Migrations
$ dotnet ef migrations add InitIdentity -c AppDbContext -p src/DeviantPasswordManager.Infrastructure -s src/DeviantPasswordManager.Web -o Data/Migrations
$ dotnet run
```

## Contribution

If you want to contribute to the project, feel free to open issues or submit pull requests.


## License

This project is licensed under the MIT License.


This README provides a high-level overview of the password manager application architecture, key components, password management logic, and implementation steps. Please refer to the code samples and explanations in our discussion for more detailed implementation guidance.
