# CharityOrg Management System

A comprehensive **Charity Management System** built with **ASP.NET Core 8 Web API**, following **Clean Architecture** principles and **CQRS** pattern. This enterprise-grade system streamlines charitable organization operations, managing donors, beneficiaries, donations, projects, volunteers, employees, and financial reporting with robust security and automation features.

---

## 🌟 Key Highlights

- ✅ **Clean Architecture** with clear separation of concerns (Domain, Application, Infrastructure, WebAPI)
- ✅ **CQRS Pattern** using MediatR for scalable command/query separation
- ✅ **Advanced Reporting** with PDF (QuestPDF) and Excel (EPPlus) export capabilities
- ✅ **JWT Authentication** with ASP.NET Core Identity and role-based access control
- ✅ **Background Jobs** using Hangfire for scheduled tasks and automated reporting
- ✅ **RESTful API** with comprehensive Swagger/OpenAPI documentation
- ✅ **Entity Framework Core** with SQL Server and code-first migrations
- ✅ **AutoMapper** for clean DTO mapping
- ✅ **FluentValidation** for robust input validation
- ✅ **Email & SMS Notifications** using MailKit and Twilio
- ✅ **CORS Support** for Angular frontend integration

---

## 📋 Table of Contents

- [Features](#-features)
- [Technology Stack](#️-technology-stack)
- [Project Architecture](#-project-architecture)
- [API Endpoints](#-api-endpoints)
- [Getting Started](#-getting-started)
- [Database Schema](#-database-schema)
- [Authentication & Authorization](#-authentication--authorization)
- [Reporting System](#-reporting-system)
- [Background Jobs](#-background-jobs)
- [Configuration](#️-configuration)
- [Testing](#-testing)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🚀 Features

### 👥 Stakeholder Management

#### **Donors**
- Complete CRUD operations for donor management
- Track donor contact information, donation history, and preferences
- Generate donor-specific reports (PDF/Excel)
- View donation summaries and contribution analytics

#### **Beneficiaries**
- Manage beneficiary profiles and needs assessment
- Track aid distribution and assistance history
- Generate beneficiary reports with detailed analytics
- Monitor beneficiary status and support requirements

#### **Volunteers**
- Volunteer registration and profile management
- Track volunteer skills, availability, and participation
- Assign volunteers to specific projects
- Generate volunteer activity reports

#### **Employees**
- Internal staff management system
- Employee profile and role management
- Track employee assignments and responsibilities

---

### 💰 Financial Management

#### **Donations**
- Record incoming donations with donor linkage
- Support multiple donation types and payment methods
- Track donation dates, amounts, and purposes
- Generate donation reports by date range, donor, or project
- Export donation data to PDF and Excel formats

#### **Expenses**
- Comprehensive expense tracking and categorization
- Link expenses to specific projects or operations
- Monitor expense approvals and status
- Generate detailed expense reports and financial summaries

#### **Transactions**
- Complete transaction logging for audit trails
- Track all financial movements (donations, expenses, transfers)
- Generate transaction reports with filtering capabilities
- Support for financial reconciliation and auditing

---

### 📊 Advanced Reporting System

The system features a **robust reporting engine** with multiple export formats:

#### **Report Types**
1. **Donor Reports**
   - Individual donor contribution history
   - Donor demographics and analytics
   - Top donors and contribution trends

2. **Beneficiary Reports**
   - Beneficiary assistance history
   - Aid distribution analytics
   - Beneficiary demographics

3. **Donation Reports**
   - Donation summaries by date range
   - Donation trends and analytics
   - Campaign-specific donation tracking

4. **Financial Reports**
   - Income vs. Expense analysis
   - Budget tracking and variance reports
   - Financial health dashboards

5. **Project Reports**
   - Project progress and completion status
   - Project budget vs. actual expenses
   - Volunteer participation in projects

6. **Expense Reports**
   - Expense categorization and analysis
   - Department-wise expense tracking
   - Expense approval workflows

#### **Export Formats**
- **PDF Reports**: Professional, print-ready reports using QuestPDF
- **Excel Reports**: Data-rich spreadsheets using EPPlus for further analysis

---

### 📋 Project & Operations Management

#### **Projects**
- Create and manage charity projects with detailed information
- Set project goals, budgets, and timelines
- Track project status (Planning, Active, Completed, Cancelled)
- Link projects to donations and expenses
- Generate comprehensive project reports

#### **Project Volunteers**
- Assign volunteers to specific projects
- Track volunteer hours and contributions
- Manage volunteer roles within projects
- Generate project volunteer reports

#### **Notifications**
- System-wide notification capabilities
- Email notifications using MailKit
- SMS notifications using Twilio
- Automated notifications for important events

---

### 🔐 Security & Authentication

- **JWT (JSON Web Token)** authentication
- **ASP.NET Core Identity** for user management
- **Role-based access control** (RBAC)
- Secure password hashing and storage
- Token-based API authentication
- Admin user seeding for initial setup

---

### ⚙️ Background Jobs & Automation

- **Hangfire** integration for background job processing
- Scheduled report generation
- Automated email notifications
- Recurring tasks and job scheduling
- Job monitoring and management dashboard

---

## 🛠️ Technology Stack

### **Backend Framework**
- **.NET 8** (ASP.NET Core Web API)
- **C# 12** with nullable reference types

### **Architecture & Patterns**
- **Clean Architecture** (Domain, Application, Infrastructure, WebAPI layers)
- **CQRS** (Command Query Responsibility Segregation) using **MediatR**
- **Repository Pattern** for data access abstraction
- **Dependency Injection** for loose coupling

### **Database & ORM**
- **SQL Server** (LocalDB or full instance)
- **Entity Framework Core 8** with code-first migrations
- **LINQ** for data querying

### **Libraries & Packages**
- **MediatR** (13.0.0) - CQRS implementation
- **AutoMapper** (12.0.0) - Object-to-object mapping
- **FluentValidation** (12.0.0) - Input validation
- **QuestPDF** (2025.7.0) - PDF report generation
- **EPPlus** (8.0.8) - Excel report generation
- **Hangfire** (1.8.20) - Background job processing
- **MailKit** (4.13.0) - Email notifications
- **Twilio** (7.12.0) - SMS notifications
- **Azure.Storage.Blobs** (12.25.0) - Cloud storage integration

### **API & Documentation**
- **Swagger/OpenAPI 3.0** - Interactive API documentation
- **JWT Bearer Authentication** - Secure API access

### **Frontend Integration**
- **CORS** configured for Angular frontend (http://localhost:4200)

---

## 📂 Project Architecture

The solution follows **Clean Architecture** principles with clear separation of concerns:

```
CharityOrg/
│
├── Domain/                          # Enterprise Business Rules
│   ├── Entities/                    # Domain entities (Donor, Beneficiary, etc.)
│   │   ├── ApplicationUser.cs
│   │   ├── Beneficiary.cs
│   │   ├── Donation.cs
│   │   ├── Donor.cs
│   │   ├── Employee.cs
│   │   ├── Expense.cs
│   │   ├── Notification.cs
│   │   ├── Project.cs
│   │   ├── ProjectVolunteer.cs
│   │   ├── ReportSchedule.cs
│   │   ├── Transaction.cs
│   │   └── Volunteer.cs
│   └── Domain.csproj
│
├── Application/                     # Application Business Rules
│   ├── Common/                      # Shared application logic
│   ├── DTOs/                        # Data Transfer Objects
│   ├── Features/                    # CQRS Commands & Queries
│   │   ├── Beneficiaries/
│   │   ├── Donations/
│   │   ├── Donors/
│   │   ├── Employees/
│   │   ├── Expenses/
│   │   ├── GeneralReports/
│   │   ├── ProjectVolunteers/
│   │   ├── Projects/
│   │   ├── Reports/                 # Reporting features
│   │   │   ├── Beneficiaries/
│   │   │   ├── Donations/
│   │   │   ├── Donors/
│   │   │   └── Financial/
│   │   └── Volunteers/
│   ├── Interfaces/                  # Application interfaces
│   ├── Mappings/                    # AutoMapper profiles
│   └── Application.csproj
│
├── Infrastructure/                  # External Concerns
│   ├── Data/                        # Database context & seeding
│   │   └── SeedData.cs
│   ├── Migrations/                  # EF Core migrations
│   ├── Persistence/                 # DbContext configuration
│   ├── Repositories/                # Repository implementations
│   │   ├── BeneficiaryRepository.cs
│   │   ├── DonationRepository.cs
│   │   ├── DonorRepository.cs
│   │   ├── EmployeeRepository.cs
│   │   ├── ExpenseRepository.cs
│   │   ├── ProjectRepository.cs
│   │   ├── ProjectVolunteerRepository.cs
│   │   ├── TransactionRepository.cs
│   │   ├── VolunteerRepository.cs
│   │   └── ReportRepo/              # Report-specific repositories
│   ├── Services/                    # Service implementations
│   │   ├── EmailService.cs
│   │   ├── NotificationService.cs
│   │   ├── ReportExportService.cs
│   │   └── ReportSchedulerService.cs
│   └── Infrastructure.csproj
│
├── WebAPI/                          # Presentation Layer
│   ├── Controllers/                 # API Controllers
│   │   ├── AuthController.cs
│   │   ├── BeneficiariesController.cs
│   │   ├── BeneficiaryReportsController.cs
│   │   ├── DonationReportsController.cs
│   │   ├── DonationsController.cs
│   │   ├── DonorReportsController.cs
│   │   ├── DonorsController.cs
│   │   ├── EmployeesController.cs
│   │   ├── ExpensesController.cs
│   │   ├── FinanceReportsController.cs
│   │   ├── NotificationsController.cs
│   │   ├── ProjectReportsController.cs
│   │   ├── ProjectVolunteerReportsController.cs
│   │   ├── ProjectVolunteersController.cs
│   │   ├── ProjectsController.cs
│   │   ├── ReportExportController.cs
│   │   ├── ReportsController.cs
│   │   ├── TransactionsController.cs
│   │   └── VolunteersController.cs
│   ├── Program.cs                   # Application entry point & DI configuration
│   ├── appsettings.json             # Configuration settings
│   └── WebAPI.csproj
│
├── UnitTest/                        # Unit Tests
│   └── UnitTest.csproj
│
├── CharitySYS.sln                   # Solution file
└── README.md                        # This file
```

### **Dependency Flow**
```
WebAPI → Infrastructure → Application → Domain
```

- **Domain**: No dependencies (pure business entities)
- **Application**: Depends only on Domain
- **Infrastructure**: Depends on Application and Domain
- **WebAPI**: Depends on Application and Infrastructure

---

## 🔌 API Endpoints

### **Authentication**
```
POST   /api/Auth/register          # Register new user
POST   /api/Auth/login             # Login and get JWT token
```

### **Donors**
```
GET    /api/Donors                 # Get all donors
GET    /api/Donors/{id}            # Get donor by ID
POST   /api/Donors                 # Create new donor
PUT    /api/Donors/{id}            # Update donor
DELETE /api/Donors/{id}            # Delete donor
```

### **Beneficiaries**
```
GET    /api/Beneficiaries          # Get all beneficiaries
GET    /api/Beneficiaries/{id}     # Get beneficiary by ID
POST   /api/Beneficiaries          # Create new beneficiary
PUT    /api/Beneficiaries/{id}     # Update beneficiary
DELETE /api/Beneficiaries/{id}     # Delete beneficiary
```

### **Donations**
```
GET    /api/Donations              # Get all donations
GET    /api/Donations/{id}         # Get donation by ID
POST   /api/Donations              # Create new donation
PUT    /api/Donations/{id}         # Update donation
DELETE /api/Donations/{id}         # Delete donation
```

### **Expenses**
```
GET    /api/Expenses               # Get all expenses
GET    /api/Expenses/{id}          # Get expense by ID
POST   /api/Expenses               # Create new expense
PUT    /api/Expenses/{id}          # Update expense
DELETE /api/Expenses/{id}          # Delete expense
```

### **Projects**
```
GET    /api/Projects               # Get all projects
GET    /api/Projects/{id}          # Get project by ID
POST   /api/Projects               # Create new project
PUT    /api/Projects/{id}          # Update project
DELETE /api/Projects/{id}          # Delete project
```

### **Volunteers**
```
GET    /api/Volunteers             # Get all volunteers
GET    /api/Volunteers/{id}        # Get volunteer by ID
POST   /api/Volunteers             # Create new volunteer
PUT    /api/Volunteers/{id}        # Update volunteer
DELETE /api/Volunteers/{id}        # Delete volunteer
```

### **Project Volunteers**
```
GET    /api/ProjectVolunteers      # Get all project volunteer assignments
GET    /api/ProjectVolunteers/{id} # Get assignment by ID
POST   /api/ProjectVolunteers      # Assign volunteer to project
PUT    /api/ProjectVolunteers/{id} # Update assignment
DELETE /api/ProjectVolunteers/{id} # Remove volunteer from project
```

### **Employees**
```
GET    /api/Employees              # Get all employees
GET    /api/Employees/{id}         # Get employee by ID
POST   /api/Employees              # Create new employee
PUT    /api/Employees/{id}         # Update employee
DELETE /api/Employees/{id}         # Delete employee
```

### **Transactions**
```
GET    /api/Transactions           # Get all transactions
GET    /api/Transactions/{id}      # Get transaction by ID
POST   /api/Transactions           # Create new transaction
```

### **Reports**
```
GET    /api/DonorReports/pdf       # Generate donor report (PDF)
GET    /api/DonorReports/excel     # Generate donor report (Excel)

GET    /api/BeneficiaryReports/pdf # Generate beneficiary report (PDF)
GET    /api/BeneficiaryReports/excel # Generate beneficiary report (Excel)

GET    /api/DonationReports/pdf    # Generate donation report (PDF)
GET    /api/DonationReports/excel  # Generate donation report (Excel)

GET    /api/FinanceReports/pdf     # Generate financial report (PDF)
GET    /api/FinanceReports/excel   # Generate financial report (Excel)

GET    /api/ProjectReports/pdf     # Generate project report (PDF)
GET    /api/ProjectReports/excel   # Generate project report (Excel)

GET    /api/ProjectVolunteerReports/pdf   # Generate volunteer report (PDF)
GET    /api/ProjectVolunteerReports/excel # Generate volunteer report (Excel)
```

### **Notifications**
```
GET    /api/Notifications          # Get all notifications
POST   /api/Notifications          # Send notification
```

> **Note**: All endpoints (except Auth) require JWT Bearer token authentication.

---

## 🚀 Getting Started

### **Prerequisites**

Before you begin, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or full instance)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/) for version control

### **Installation Steps**

#### 1. **Clone the Repository**
```bash
git clone https://github.com/moaaz10esmail-cloud/CharityOrg.git
cd CharityOrg
```

#### 2. **Restore NuGet Packages**
```bash
dotnet restore
```

#### 3. **Configure Database Connection**

Update the connection string in `WebAPI/appsettings.json` if necessary:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CharitySysDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**For SQL Server Express or full instance**, use:
```json
"DefaultConnection": "Server=localhost;Database=CharitySysDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

**For SQL Server with username/password**:
```json
"DefaultConnection": "Server=localhost;Database=CharitySysDb;User Id=your_username;Password=your_password;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

#### 4. **Apply Database Migrations**

Open a terminal in the solution root directory and run:

```bash
dotnet ef database update --project Infrastructure --startup-project WebAPI
```

This will create the database and apply all migrations.

#### 5. **Configure JWT Settings (Optional)**

Update JWT settings in `WebAPI/appsettings.json` if needed:

```json
{
  "Jwt": {
    "Key": "YourSuperSecretKeyHere_ChangeThisInProduction",
    "Issuer": "https://localhost:7273",
    "Audience": "CharitySystemUser"
  }
}
```

> **⚠️ Security Warning**: Change the JWT Key in production to a strong, random secret!

#### 6. **Run the Application**

```bash
dotnet run --project WebAPI
```

Or using Visual Studio:
- Set `WebAPI` as the startup project
- Press `F5` or click **Run**

#### 7. **Access the API**

Once running, the API will be available at:
- **HTTPS**: `https://localhost:7273`
- **HTTP**: `http://localhost:5273`

#### 8. **Explore API Documentation**

Navigate to the Swagger UI:
```
https://localhost:7273/swagger
```

Or simply:
```
https://localhost:7273
```

The Swagger UI provides interactive API documentation where you can test all endpoints.

---

## 🗄️ Database Schema

The system uses **Entity Framework Core** with the following main entities:

### **Core Entities**

| Entity | Description | Key Fields |
|--------|-------------|------------|
| **Donor** | Donor information | Name, Email, Phone, Address |
| **Beneficiary** | Beneficiary details | Name, NeedsDescription, Status |
| **Donation** | Donation records | Amount, Date, DonorId, ProjectId |
| **Expense** | Expense tracking | Amount, Category, Date, ProjectId |
| **Transaction** | Financial transactions | Type, Amount, Date, Reference |
| **Project** | Charity projects | Name, Description, Budget, Status |
| **Volunteer** | Volunteer profiles | Name, Skills, Availability |
| **ProjectVolunteer** | Project assignments | ProjectId, VolunteerId, Role |
| **Employee** | Staff management | Name, Position, Department |
| **Notification** | System notifications | Message, Type, Recipient, Status |
| **ReportSchedule** | Scheduled reports | ReportType, Frequency, NextRun |
| **ApplicationUser** | User accounts | Email, PasswordHash, Roles |

### **Relationships**
- Donors → Donations (One-to-Many)
- Projects → Donations (One-to-Many)
- Projects → Expenses (One-to-Many)
- Projects → ProjectVolunteers (One-to-Many)
- Volunteers → ProjectVolunteers (One-to-Many)

---

## 🔐 Authentication & Authorization

### **JWT Authentication**

The system uses **JWT (JSON Web Tokens)** for stateless authentication:

1. **Register** a new user via `/api/Auth/register`
2. **Login** via `/api/Auth/login` to receive a JWT token
3. Include the token in subsequent requests:
   ```
   Authorization: Bearer <your-jwt-token>
   ```

### **Default Admin Account**

The system automatically seeds an admin account on first run:

```
Email: admin@charity.com
Password: Admin@123
```

> **⚠️ Security**: Change the admin password immediately after first login!

### **Using Swagger with JWT**

1. Click the **Authorize** button in Swagger UI
2. Enter: `Bearer <your-jwt-token>`
3. Click **Authorize**
4. All subsequent API calls will include the token

---

## 📊 Reporting System

### **PDF Reports (QuestPDF)**

The system generates professional PDF reports with:
- Custom headers and branding
- Tabular data presentation
- Automatic pagination
- Professional styling

**Example Usage**:
```csharp
GET /api/DonorReports/pdf?startDate=2024-01-01&endDate=2024-12-31
```

### **Excel Reports (EPPlus)**

Excel reports provide:
- Structured data in spreadsheet format
- Column headers
- Data ready for further analysis
- Compatible with Microsoft Excel and Google Sheets

**Example Usage**:
```csharp
GET /api/DonationReports/excel?startDate=2024-01-01&endDate=2024-12-31
```

### **Report Types Available**

1. **Donor Reports**: Donor contribution history and analytics
2. **Beneficiary Reports**: Aid distribution and beneficiary demographics
3. **Donation Reports**: Donation summaries and trends
4. **Financial Reports**: Income vs. expense analysis
5. **Project Reports**: Project status and budget tracking
6. **Volunteer Reports**: Volunteer participation and hours

---

## ⚙️ Background Jobs

The system uses **Hangfire** for background job processing:

### **Features**
- Scheduled report generation
- Automated email notifications
- Recurring tasks (daily, weekly, monthly)
- Job monitoring dashboard

### **Accessing Hangfire Dashboard**

Navigate to:
```
https://localhost:7273/hangfire
```

### **Scheduled Jobs**
- Daily donation summaries
- Weekly financial reports
- Monthly project status reports
- Automated email notifications

---

## ⚙️ Configuration

### **appsettings.json Structure**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CharitySysDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "YourSecretKeyHere",
    "Issuer": "https://localhost:7273",
    "Audience": "CharitySystemUser"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### **Environment-Specific Configuration**

- **Development**: `appsettings.Development.json`
- **Production**: `appsettings.Production.json`

---

## 🧪 Testing

### **Unit Tests**

The solution includes a `UnitTest` project for testing:

```bash
dotnet test
```

### **Testing with Swagger**

Use the interactive Swagger UI to test all API endpoints:
1. Navigate to `https://localhost:7273/swagger`
2. Authenticate using JWT token
3. Test endpoints with sample data

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

### **Coding Standards**
- Follow C# coding conventions
- Write unit tests for new features
- Update documentation as needed
- Use meaningful commit messages

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Moaaz Esmail**
- GitHub: [@moaaz10esmail-cloud](https://github.com/moaaz10esmail-cloud)

---

## 🙏 Acknowledgments

- **ASP.NET Core Team** for the excellent framework
- **QuestPDF** for PDF generation capabilities
- **EPPlus** for Excel export functionality
- **Hangfire** for background job processing
- **MediatR** for CQRS implementation
- **AutoMapper** for object mapping

---

## 📞 Support

For issues, questions, or suggestions:
- Open an [Issue](https://github.com/moaaz10esmail-cloud/CharityOrg/issues)
- Contact: moaaz10esmail@gmail.com

---

## 🗺️ Roadmap

Future enhancements planned:
- [ ] Real-time dashboard with SignalR
- [ ] Mobile app integration
- [ ] Advanced analytics and data visualization
- [ ] Multi-language support (i18n)
- [ ] Cloud deployment guides (Azure, AWS)
- [ ] Docker containerization
- [ ] CI/CD pipeline setup
- [ ] Advanced role-based permissions
- [ ] Audit logging system
- [ ] Integration with payment gateways

---

## 📸 Screenshots

> Add screenshots of your Swagger UI, dashboard, and reports here

---

**Built with ❤️ using .NET 8 and Clean Architecture**
