Got it — if your project is **3-layer (not Clean Architecture)**, the README should reflect that clearly. Here’s a corrected and more accurate version:

---

# 📌 Auth & User Profile Service

A **3-layer architecture authentication and user profile service** built with **.NET 8**, designed to manage user identity, authentication, and profile data in a clean and maintainable way.

---

## 🚀 Overview

This service provides core features required in most applications:

* 🔐 User authentication (Register / Login)
* 👤 User profile management
* 🔑 JWT-based authorization
* 🧱 Structured 3-layer architecture

It is ideal for integration into larger systems like web apps, mobile backends, or microservices ecosystems.

---

## 🏗️ Architecture (3-Layer)

The project follows a **classic 3-layer architecture**:

```text
├── Presentation Layer   # API (Controllers, Endpoints)
├── Business Layer       # Services, Logic, Interfaces
├── Data Access Layer    # Database, EF Core, Repositories
```

### 🔹 Layer Responsibilities

* **Presentation Layer**

  * Handles HTTP requests
  * Exposes API endpoints
  * Validates input & returns responses

* **Business Layer**

  * Contains application logic
  * Defines interfaces and services
  * Handles authentication & rules

* **Data Access Layer**

  * Manages database interactions
  * Uses Entity Framework Core
  * Implements repositories

---

## ⚙️ Technologies

* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **JWT Authentication**
* **AutoMapper**
* **SQL Server (configurable)**

---

## 🔑 Features

### Authentication

* User registration
* Secure login
* JWT token generation

### Authorization

* Protected endpoints
* Role-based access (if implemented)

### User Profile

* Retrieve user data
* Update profile information

---

## 📦 Installation

### 1. Clone the repository

```bash
git clone https://github.com/mwilaalexis/AuthAndUserProfileService.git
cd AuthAndUserProfileService
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure app settings

Update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_connection_string"
  },
  "Jwt": {
    "Key": "your_secret_key",
    "Issuer": "your_app",
    "Audience": "your_users"
  }
}
```

---

## ▶️ Run the Project

```bash
dotnet run
```

Swagger will be available at:

```
https://localhost:{port}/swagger
```


## 📡 API Endpoints (Example)

| Method | Endpoint           | Description    |
| ------ | ------------------ | -------------- |
| POST   | /api/auth/register | Register user  |
| POST   | /api/auth/login    | Login user     |
| GET    | /api/profile/id  | Get profile    |
| PUT    | /api/profile/id  | Update profile |

---

## 🔐 Security

* JWT authentication
* Password hashing
* Input validation
* Protected routes

---

## 🧪 Testing

You can test using:

* Swagger UI
* Postman
* REST Client (VS Code)

---

## 📈 Future Improvements

* Refresh tokens
* Email verification
* OAuth integration (Google, GitHub)
* Role & permission system
* Logging & monitoring

---

## 🤝 Contributing

1. Fork the repo
2. Create a branch
3. Commit your changes
4. Open a Pull Request

---

##  License

MIT License

---

## 👤 Author

Alexis Mwila
[https://github.com/mwilaalexis](https://github.com/mwilaalexis)
