## 📘 README.md — Genetic Map Project (CI/CD + Azure + GitHub Actions)
EN
### 👥 Project Overview

This project is a web application designed to provide **early diagnosis** by analyzing patients' **past disease data** and **familial genetic history**. Built with ASP.NET Core 8, the project uses **Identity** for user authentication, **RoleManager** for role-based access control, and **Cookie Authentication** for session management.

---

### 🔧 Technologies Used

| Technology        | Description                               |
| ----------------- | ----------------------------------------- |
| ASP.NET Core 8    | Web application development framework     |
| Entity Framework  | ORM for database operations               |
| SQL Server        | Database management system                |
| Identity          | User and role management                  |
| Cookie Auth       | Authentication and session management     |
| GitHub Actions    | For CI/CD pipeline                        |
| Azure App Service | Deployment and hosting on Microsoft Azure |

---

### 🛡 Authentication & Role-Based Access

User registration, login, and role management are handled with the `Identity` library. The following roles are supported:

* `Admin`: Manages users and the system
* `Doctor`: Accesses patient data and makes diagnoses
* `Patient`: Views and updates their own data

Authentication is handled using **Cookie Authentication**. Configured as follows in `Startup.cs` or `Program.cs`:

```csharp
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });
```

---

### 🚀 CI/CD Pipeline (GitHub Actions + Azure App Service)

#### 1️⃣ GitHub Actions CI/CD Pipeline

A CI/CD pipeline is configured via GitHub Actions to perform the following:

* Code build (`dotnet build`)
* Run unit tests (`dotnet test`)
* Deploy to Azure App Service (`dotnet publish` + `zip deploy`)

##### 📄 `.github/workflows/dotnet-azure-deploy.yml`
*Create a yaml file


> 📌 The `AZURE_PUBLISH_PROFILE` secret must be obtained from the Azure Portal (details below).

---

### ☁️ Azure Portal Configuration

#### 1. Create Azure App Service

* Log in to Azure Portal
* Go to "App Services" → "Create"

  * **Runtime stack**: `.NET 8 (LTS)`
  * **Region**: Choose a location close to your users
  * **Publish**: Code
  * **Operating System**: Windows or Linux

#### 2. Get Publish Profile

* Go to your App Service → "Overview" → "Get Publish Profile"
* Download the `.PublishSettings` file
* Encode content (base64 not required) → Add it to GitHub Secrets as `AZURE_PUBLISH_PROFILE`

#### 3. Application Settings

In Azure App Service → Configuration → Application settings:

| Key                      | Value                  |
| ------------------------ | ---------------------- |
| `ASPNETCORE_ENVIRONMENT` | `Production`           |

---

### 🔐 GitHub Secrets Configuration

In GitHub → Settings → Secrets and variables → Actions:

| Secret Name             | Description                                |
| ----------------------- | ------------------------------------------ |
| `AZURE_PUBLISH_PROFILE` | Content from Azure `.PublishSettings` file |

---

### ✅ After Deployment

1. Project is automatically deployed to Azure.
2. Each commit or merge triggers build, test, and deployment.
3. Logs can be monitored in the GitHub Actions tab.

---

### 📌 Additional Security Notes

* **Do not store sensitive data in `appsettings.json`.**
* Use `Environment.GetEnvironmentVariable("SenderEmail")` for reading sensitive values in production.
* Enable "HTTPS only" in Azure App Service for secure connections.

---

### 📢 Contact

For more information or to contribute to the project:

🌐 https://www.linkedin.com/in/asuman-odabaşı
