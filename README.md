# Reading Log Backend

A backend for the *Reading Log* application.

## Getting Started - for Windows

To get a local copy up and running, follow these steps.

### Prerequisites
- [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- SQL Server Express - [How to Install SQL Server Express](https://www.sqlshack.com/how-to-install-sql-server-express-edition/)
    - Specify *Windows Authentication Mode* during server configuration.

### Installation
1. Clone the repo
    ```sh
    git clone https://github.com/pochern/reading-log-backend.git
    ```
2. Navigate to the ReadingLog.Api directory in the project
    ```sh
    cd ReadingLogBackend/ReadingLog.Api
    ```
3. Build the application
    ```sh
    dotnet build
    ```
4. Run the application
    ```sh
    dotnet run
    ```

## Getting Started - for macOS / Linux

To get a local copy up and running, follow these steps.

### Prerequisites
- [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- MySQL - [How to Install MySQL on Mac OSX](https://flaviocopes.com/mysql-how-to-install/)

### Installation
1. Clone the repo
    ```sh
    git clone https://github.com/pochern/reading-log-backend.git
    ```
2. Navigate to the ReadingLogBackend project directory
    ```sh
    cd ReadingLogBackend
    ```
3. Enable secret storage to hide implementation details
    ```sh
    dotnet user-secrets init
    ```
4. Set a secret for your MySql password
    ```sh
    dotnet user-secrets set "ReadingLog:MySqlPassword" "<MySqlPassword>"
5. Set a secret for your MySql username
    ```sh
    dotnet user-secrets set "ReadingLog:MySqlUsername" "<MySqlUsername>"
    ```
6. Navigate to the ReadingLog.Common directory in the project
    ```sh
    cd ReadingLog.Common
    ```
7. Create the database schema with migrations
    ```sh
    dotnet ef database update
    ```
8. Navigate to the ReadingLog.Api directory in the project
    ```sh
    cd ../ReadingLog.Api
    ```
9. Build the application
    ```sh
    dotnet build
    ```
10. Run the application
    ```sh
    dotnet run
    ```

### Usage
In a browser, navigate to url [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html) to interact with Swagger UI. 

You will see available endpoints and its documentation. The *Example Value* in the **Request Body** of endpoints will contain a valid example of a request body for that endpoint.