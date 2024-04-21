# Clean Structured Project - ASP.NET Core

This template is for a clean structured ASP.NET Core web project, follows the Clean Architecture principles, SOLID design principles, implements the Dependency Injection, Repository, and Unit of Work design pattern, and utilizes Entity Framework Core for data access. It provides a standardized structure and organization for building robust and maintainable ASP.NET Core web applications with complete CRUD (Create, Read, Update, Delete) operations. Feel free to ask any questions or share your thoughts.

#### Reference
You can visit my blog post- [Clean Structured Project – ASP.NET Core](https://binarybytez.com/clean-structured-project/)

## Project Structure

The project structure is designed to promote separation of concerns and modularity, making it easier to understand, test, and maintain the application.

```
├── src
│   ├── Core                    # Contains the core business logic, domain models, view models, etc.
│   ├── Infrastructure          # Contains infrastructure concerns such as data access, external services, etc.
│   └── UI                      # Contains the user interface layer, including controllers, views, extensions, etc.
├── tests
│   ├── Core.Tests              # Contains unit tests for the core layer
│   ├── Infrastructure.Tests    # Contains unit tests for the infrastructure layer
│   └── UI.Tests                # Contains unit tests for the UI layer
└── README.md                   # Project documentation (you are here!)
```

## Getting Started

To use this project template, follow the steps below:

1. Ensure the .NET 7 SDK is installed on your machine.
2. Clone or download this repository to your local machine.
3. Open the solution in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
4. Build the solution to restore NuGet packages and compile the code.
5. Configure the necessary database connection settings in the `appsettings.json` file of the Infrastructure project.
6. Open the Package Manager Console, select `Project.Infrastructure` project, and run the `Update-Database` command to create the database
7. Run the application by starting the `Project.UI` project.

## Project Features

This project template includes the following features:

- **Clean Architecture**: The project is structured according to the principles of [Clean Architecture](https://binarybytez.com/understanding-clean-architecture/), which promotes separation of concerns and a clear division of responsibilities.
- **SOLID Design Principles**: The code adheres to [SOLID principles](https://binarybytez.com/mastering-solid-design-principles/) (Single Responsibility, Open-Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion), making it easier to maintain and extend.
- **Repository Pattern**: The [repository pattern](https://binarybytez.com/understanding-clean-architecture/) abstracts the data access layer and provides a consistent interface for working with data.
- **Unit of Work Pattern**: The unit of work pattern helps manage transactions and ensures consistency when working with multiple repositories.
- **Entity Framework Core**: The project utilizes Entity Framework Core as the ORM (Object-Relational Mapping) tool for data access.
- **ASP.NET Core Web**: The project includes an [ASP.NET Core web project](https://binarybytez.com/clean-structured-project/) that serves as the user interface layer, handling HTTP requests and responses.
- **CRUD Operations**: The project template provides a foundation for implementing complete CRUD (Create, Read, Update, Delete) operations on entities using Entity Framework Core.
- **Dependency Injection**: The project utilizes the built-in [dependency injection](https://binarybytez.com/understanding-dependency-injection/) container in ASP.NET Core, making it easy to manage and inject dependencies throughout the application.
- **Unit Testing**: The solution includes separate test projects for unit testing the core, infrastructure, and UI layers.

## Usage

[The project template](https://binarybytez.com/clean-structured-project/) provides a starting point for implementing CRUD operations on entities using Entity Framework Core. You can modify and extend the existing code to suit your specific application requirements. Here's an overview of the key components involved in the CRUD operations:

1. **Models**: The `Core` project contains the domain models representing the entities you want to perform CRUD operations on. Update the models or add new ones according to your domain.
2. **Repositories**: The `Infrastructure` project contains repository implementations that handle data access operations using Entity Framework Core. Modify the repositories or create new ones to match your entity models and database structure.
3. **Services**: The `Core` project contains services that encapsulate the business logic and orchestrate the operations on repositories. Update or create new services to handle CRUD operations on your entities.
4. **Controllers**: The `UI` project contains controllers that handle HTTP requests and responses. Update or create new controllers to expose the CRUD endpoints for your entities.

Make sure to update the routes, validation, and error-handling logic to align with your application requirements and [best practices](https://binarybytez.com/performance-optimization-and-monitoring-in-asp-net-core/).

## Authors

If you have any questions or need further assistance, please contact the project author at [@kawser2133](https://www.github.com/kawser2133) || [![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/kawser2133)

<a href="https://www.buymeacoffee.com/kawser" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a><br/>
**Thanks for your support!**

## Contributing

I want you to know that contributions to this project are welcome. Please open an issue or submit a pull request if you have any ideas, bug fixes, or improvements.  

## License

This project is licensed under the [MIT License](LICENSE).
