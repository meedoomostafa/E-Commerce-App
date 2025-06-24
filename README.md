# E-Commerce App 🛍️

A comprehensive e-commerce web application built with **ASP.NET Core MVC** using **.NET 9** and **SQL Server**. This project demonstrates modern web development practices including MVC architecture, Entity Framework Core, and responsive design.

## 🚀 Features

- **User Authentication & Authorization**
  - User registration and login
  - Role-based access control (Admin/Customer)
  - Secure password handling

- **Product Management**
  - Product catalog with categories
  - Product search and filtering
  - Product details with images
  - Inventory management (Admin)

- **Shopping Experience**
  - Shopping cart functionality
  - Wishlist management
  - Order processing
  - Order history tracking

- **Admin Panel**
  - Product CRUD operations
  - Order management
  - User management
  - Sales analytics

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core MVC (.NET 9)
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap
- **Authentication**: ASP.NET Core Identity
- **Version Control**: Git & GitHub

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Local DB or Full Version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

## 🔧 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/meedoomostafa/E-Commerce-App.git
cd E-Commerce-App
```

### 2. Configure Database Connection

1. Open `appsettings.json` file
2. Update the connection string to match your SQL Server configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ECommerceAppDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

**For SQL Server Express:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=ECommerceAppDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Restore NuGet Packages

```bash
dotnet restore
```

### 4. Apply Database Migrations

```bash
# Create initial migration (if not exists)
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

### 5. Seed Sample Data (Optional)

If the project includes data seeding, run:

```bash
dotnet run --seed-data
```

### 6. Run the Application

```bash
dotnet run
```

The application will be available at:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`

## 📁 Project Structure

```
E-Commerce-App/
├── Controllers/           # MVC Controllers
├── Models/               # Data Models & ViewModels
├── Views/                # MVC Views (Razor Pages)
├── Data/                 # DbContext & Migrations
├── Services/             # Business Logic Services
├── wwwroot/              # Static Files (CSS, JS, Images)
├── Areas/                # Admin Area (if applicable)
├── Migrations/           # EF Core Migrations
├── appsettings.json      # Configuration
└── Program.cs            # Application Entry Point
```

## 🎯 Usage

### For Customers:
1. **Registration**: Create a new account
2. **Browse Products**: Explore the product catalog
3. **Add to Cart**: Select desired products
4. **Checkout**: Complete your purchase
5. **Order Tracking**: View order history

### For Administrators:
1. **Login**: Use admin credentials
2. **Manage Products**: Add, edit, or remove products
3. **Process Orders**: Handle customer orders
4. **User Management**: Manage customer accounts

## 🔒 Default Admin Account

After seeding data, use these credentials to access admin panel:
- **Email**: `admin@ecommerce.com`
- **Password**: `Admin@123`

## 📊 Database Schema

The application uses the following main entities:

- **Users**: Customer and admin user accounts
- **Products**: Product information and inventory
- **Categories**: Product categorization
- **Orders**: Customer orders and order items
- **Cart**: Shopping cart items
- **Reviews**: Product reviews and ratings

## 🐛 Troubleshooting

### Common Issues:

1. **Database Connection Error**
   - Verify SQL Server is running
   - Check connection string in `appsettings.json`
   - Ensure database exists

2. **Migration Issues**
   ```bash
   # Reset migrations
   dotnet ef database drop
   dotnet ef migrations remove
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

3. **Port Already in Use**
   - Change ports in `Properties/launchSettings.json`
   - Or kill the process using the port

4. **NuGet Package Restore Issues**
   ```bash
   # Clear NuGet cache
   dotnet nuget locals all --clear
   dotnet restore
   ```

## 🚀 Deployment

### Deploy to IIS:
1. Publish the application: `dotnet publish -c Release`
2. Copy published files to IIS directory
3. Configure IIS site and application pool
4. Update connection string for production database

### Deploy to Azure:
1. Create Azure Web App
2. Configure deployment from GitHub
3. Set up Azure SQL Database
4. Update connection strings in Azure portal

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Submit a pull request

## 📝 Development Guidelines

- Follow C# naming conventions
- Use Entity Framework Core for data access
- Implement proper error handling
- Add unit tests for business logic
- Follow MVC pattern principles
- Use dependency injection

## 🔮 Future Enhancements

- [ ] Payment gateway integration (Stripe/PayPal)
- [ ] Email notifications
- [ ] Product reviews and ratings
- [ ] Advanced search with filters
- [ ] Multi-language support
- [ ] Mobile app API
- [ ] Real-time notifications
- [ ] Analytics dashboard

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Mostafa Meedo**
- GitHub: [@meedoomostafa](https://github.com/meedoomostafa)
- Email: [mezo.225577@gmail.com]

## 🙏 Acknowledgments

- ASP.NET Core Documentation
- Entity Framework Core Documentation
- Bootstrap for responsive design
- Community tutorials and resources

---

⭐ **Star this repository if you found it helpful!**

## 📞 Support

If you have any questions or need help with setup, please:
1. Check the troubleshooting section
2. Open an issue on GitHub
3. Contact the author

---

*This project is part of my learning journey in ASP.NET Core MVC development and serves as a foundation for building modern e-commerce applications.*
