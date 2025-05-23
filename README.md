# BlogAPI - .NET 9 Web API with Oracle

This project is a sample Web API built with .NET 9. It manages **Users** and **Posts** entities, supports JWT authentication, includes audit tracking, and connects to an Oracle database running in Docker.

---

## Features

- User and Post CRUD operations  
- JWT Authentication and Authorization (used for testing purposes)  
- Pagination support for listing endpoints  
- Audit information (CreatedBy, CreatedAt, UpdatedBy, UpdatedAt) handled via interceptors  
- Oracle database connection with Docker Compose setup  
- Logging implemented using Serilog  

---

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
- [Docker](https://docs.docker.com/get-docker/) and [Docker Compose](https://docs.docker.com/compose/install/)  
- Oracle database (setup via Docker Compose included)  

---

## Setup

1. **Edit `appsettings.json`** to configure your Oracle connection string if needed:

    ```json
    "ConnectionStrings": {
      "OracleConnection": "User Id=xxxx;Password=xxxxx;Data Source=localhost:1521/XE;"
    }
    ```

2. **Run Oracle database with Docker Compose:**

    ```bash
    docker-compose up -d
    ```

3. **Run database migrations:**

    Make sure the `Infrastructure` project (which contains your `ApplicationDbContext`) is selected, then run:

    ```bash
    dotnet ef database update
    ```

---

## Usage

- **Create a user:** Use the endpoint `POST /api/User/CreateUser`  
  This endpoint is marked with `[AllowAnonymous]` to allow new user registrations without authentication.

- **Login:** Use the endpoint `POST /api/auth/login` to obtain a JWT token.

- **Authorization:**  
  Add the JWT token as a Bearer token in the `Authorization` header for all protected endpoints.

- **API Testing:**  
  Swagger UI is available at `/swagger` for exploring and testing the API.

---

## Notes

- Passwords are stored in **plain text** for testing purposes only. **Do NOT store plain text passwords in production.**  
- JWT authentication is implemented primarily for testing and demonstration.  
- User customizable settings are stored in the `SettingsJson` field as serialized JSON.  
- Audit information is automatically handled by interceptors.  
- Logging is implemented using **Serilog**, with logs stored under `logs/blogAPI.log`.  
- Oracle DB user and admin passwords are set in the Docker Compose file.  

---

