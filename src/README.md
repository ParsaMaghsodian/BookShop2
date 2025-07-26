# 📚 BookShop2 - Online Book Store

A modern ASP.NET Core web application for an online book store with user management, order processing, and book catalog functionality.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with the following structure:

```
BookShop2/
├── Domain/                    # Domain entities and business logic
├── Application/               # Application services and DTOs
│   ├── DTO/                  # Data Transfer Objects
│   ├── Interfaces/            # Service interfaces
│   ├── Mappers/              # Object mapping configurations
│   └── Services/             # Business logic implementation
├── Infrastructure/            # Data access and external services
│   ├── DataModels/           # Entity Framework models
│   ├── FluentApi/            # Entity configurations
│   └── ApplicationDbContext.cs
└── Migrations/               # Database migrations

BookShop2.Web/                # Presentation layer
├── Areas/                    # Feature-based organization
│   ├── Admin/                # Admin panel
│   ├── User/                 # User dashboard
│   └── Identity/             # Authentication pages
├── Controllers/              # API controllers
├── Pages/                    # Razor Pages
├── ViewComponents/           # Reusable UI components
└── wwwroot/                 # Static files
```

## ✨ Features

### 🛍️ Book Management
- **Book Catalog**: Browse and search books by title
- **Book Details**: View comprehensive book information including ratings and comments
- **Book Categories**: Organized by categories (Technical, Fiction, Children, Novel)
- **Image Support**: Book cover images with file upload functionality
- **Multi-language Support**: Books available in English and Persian

### 👥 User Management
- **User Registration & Authentication**: ASP.NET Core Identity integration
- **User Profiles**: Personal information management
- **Role-based Access**: Admin and User roles with different permissions

### 📦 Order System
- **Shopping Cart**: Add books to cart and manage quantities
- **Order Processing**: Complete purchase workflow
- **Order History**: View past orders and their status
- **Order States**: New, Confirmed, Canceled

### ⭐ Rating & Review System
- **Book Ratings**: 1-5 star rating system
- **User Comments**: Leave reviews and comments on books
- **Average Ratings**: Calculated average ratings displayed on book listings

### 🔧 Admin Panel
- **Book Management**: CRUD operations for books
- **Category Management**: Manage book categories
- **User Management**: View and manage user accounts
- **Order Management**: Process and track orders
- **File Management**: Upload and manage book images

## 🛠️ Technology Stack

### Backend
- **.NET 8.0**: Latest .NET framework
- **ASP.NET Core**: Web application framework
- **Entity Framework Core**: ORM for data access
- **SQL Server**: Primary database
- **Mapster**: Object mapping library
- **ASP.NET Core Identity**: Authentication and authorization

### Frontend
- **Razor Pages**: Server-side rendering
- **Bootstrap**: CSS framework for responsive design
- **jQuery**: JavaScript library for client-side interactions
- **ViewComponents**: Reusable UI components

### Development Tools
- **Entity Framework Tools**: Database migrations
- **Visual Studio Code Generation**: Scaffolding tools

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd BookShop2
   ```

2. **Configure the database connection**
   - Update the connection string in `BookShop2.Web/appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=BookShop2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
   }
   ```

3. **Run database migrations**
   ```bash
   cd BookShop2.Web
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the application**
   - Main application: `https://localhost:5001`
   - Admin panel: `https://localhost:5001/Admin`

## 📊 Database Schema

### Core Entities
- **Books**: Book information, pricing, and metadata
- **BookCategories**: Book classification system
- **Users**: User accounts and profiles
- **Orders**: Purchase transactions
- **Comments**: User reviews and feedback
- **Ratings**: Book rating system

### Key Relationships
- Books belong to Categories (Many-to-One)
- Users can place multiple Orders (One-to-Many)
- Books can have multiple Comments and Ratings (One-to-Many)

## 🔐 Authentication & Authorization

### User Roles
- **Admin**: Full access to admin panel and all features
- **User**: Access to shopping features and personal dashboard

### Security Features
- Password-based authentication
- Role-based authorization
- Secure file uploads (100MB limit)
- HTTPS enforcement

## 📁 Project Structure Details

### Application Layer (`BookShop2/Application/`)
- **DTOs**: Data transfer objects for API communication
- **Interfaces**: Service contracts for dependency injection
- **Services**: Business logic implementation
- **Mappers**: Object mapping configurations using Mapster

### Infrastructure Layer (`BookShop2/Infrastructure/`)
- **DataModels**: Entity Framework entities
- **FluentApi**: Entity configurations and relationships
- **DbContext**: Database context and configuration

### Web Layer (`BookShop2.Web/`)
- **Areas**: Feature-based organization (Admin, User, Identity)
- **Controllers**: API endpoints
- **Pages**: Razor Pages for UI
- **ViewComponents**: Reusable UI components

## 🧪 Development

### Adding New Features
1. Create DTOs in `Application/DTO/`
2. Define interfaces in `Application/Interfaces/`
3. Implement services in `Application/Services/`
4. Add data models in `Infrastructure/DataModels/`
5. Create UI components in appropriate Areas

### Database Changes
1. Modify data models in `Infrastructure/DataModels/`
2. Update FluentApi configurations if needed
3. Create and run migrations:
   ```bash
   dotnet ef migrations add MigrationName
   dotnet ef database update
   ```

## 🚀 Deployment

### Production Configuration
- Update connection strings in `appsettings.Production.json`
- Configure HTTPS certificates
- Set up proper logging levels
- Enable HSTS for security

### Docker Support
The project includes Docker configuration for containerized deployment.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🆘 Support

For support and questions, please open an issue in the repository or contact the development team.

---

**Built with ❤️ using ASP.NET Core and Clean Architecture principles**
