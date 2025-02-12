# MyCards.API

**MyCards.API** is a RESTful API designed to manage a collection of cards, providing endpoints to create, retrieve, update, and delete card information. The project is built using the **.NET** framework and leverages **Azure Functions** for serverless computing.

## Features

- **CRUD Operations**: Perform Create, Read, Update, and Delete operations on card entities.
- **Azure Functions Integration**: Utilize Azure Functions for efficient, scalable, and serverless execution of specific tasks.
- **Entity Framework Core**: Implement data access using Entity Framework Core for database interactions.
- **Swagger Documentation**: Integrated Swagger for API documentation and testing.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local) for local development and testing of Azure Functions.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [Azure SQL Database](https://azure.microsoft.com/en-us/services/sql-database/) for data storage.

## Getting Started

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/lucosmo/Cards.git
   cd Cards/MyCards.API
    ```
2. **Configure the Database**:

- Update the connection string in appsettings.json to point to your SQL Server or Azure SQL Database instance.
- Apply Migrations:

   ```bash
   dotnet ef database update
   ```

2. **Run the Application**:

   ```bash
   dotnet run
   ```
   
The API will be accessible at ```https://localhost:5001 by default```.

### API Endpoints
The following endpoints are available in the MyCards.API:

- GET /api/cards: Retrieve a list of all cards.
- GET /api/cards/{id}: Retrieve a specific card by its ID.
- POST /api/cards: Create a new card.
- PUT /api/cards/{id}: Update an existing card by its ID.
- DELETE /api/cards/{id}: Delete a card by its ID.

### Azure Functions
**The project includes the following Azure Functions**:

- CardProcessorFunction: Triggered by HTTP requests to process card-related operations asynchronously.
- CardCleanupFunction: Timer-triggered function that performs periodic cleanup tasks on the card data.

**To run the Azure Functions locally**:

- Start the Azure Functions Host:

   ```
   func start
   ```

   The functions will be available at ```http://localhost:7071``` by default.

### Contributing
Contributions are welcome! Please fork the repository and submit a pull request for any enhancements or bug fixes.

### License
This project is licensed under the MIT License.
