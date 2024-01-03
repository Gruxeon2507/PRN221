# PRN221 

This repository contains projects for the PRN221 subject, focusing on .NET development with Windows Presentation Foundation (WPF).

## Projects

1. **DemoApplication**: A WPF application that demonstrates basic operations such as data entry and display. The application allows you to enter car information and display it. The source code can be found in [DemoApplication](DemoApplication/DemoApplication).

2. **WPFFormGenModel**: A more complex WPF application that interacts with a database using Entity Framework. It includes features such as data binding, value converters, and database operations. The source code can be found in [WPFFormGenModel](WPFFormGenModel/WPFFormGenModel).

## Getting Started

To run these projects, you need to have .NET Core SDK and Visual Studio installed on your machine.

1. Clone the repository.
2. Open the solution file (.sln) of the project you want to run in Visual Studio.
3. Build the solution (Ctrl+Shift+B).
4. Run the project (F5).

## Database Setup

The WPFFormGenModel project uses a SQL Server database. The connection string is configured in the `appsettings.json` file of the project. Make sure to update the connection string according to your SQL Server instance.

The database schema and data scripts can be found in the [`Databases`](command:_github.copilot.openRelativePath?%5B%22Databases%22%5D "Databases") folder.