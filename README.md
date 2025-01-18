# Product API

This is a .NET 9-based API project that provides endpoints for managing products. The API supports versioning and uses feature flags to enable or disable specific functionality based on user roles or other conditions.

## Features

- **API Versioning**: Supports two versions of the API (`v1` and `v2`).
- **Feature Management**: Uses feature flags to control access to specific endpoints.
- **User Targeting**: Enables feature flags based on user roles or groups.
- **Entity Framework Core**: Uses an in-memory database (`ProductDbContext`) to manage product data.
- **OpenAPI (Swagger)**: Provides API documentation (enabled in development mode).

---

## Technologies Used

- **.NET 9**: The framework used to build the API.
- **Entity Framework Core**: For database operations.
- **Feature Management**: For enabling/disabling features dynamically.
- **OpenAPI (Swagger)**: For API documentation.
- **Dependency Injection**: For injecting services like `ILogger`, `ProductDbContext`, and `IFeatureManager`.

---

## API Endpoints

### Version 1 (`v1`)

#### Get All Products
- **Endpoint**: `GET /api/v1/product`
- **Description**: Retrieves a list of all products (if the `UseApiV1Product` feature is enabled).
- **Response**: List of `ProductV1` objects.

#### Get Product by ID
- **Endpoint**: `GET /api/v1/product/{id}`
- **Description**: Retrieves a specific product by its ID (if the `UseApiV1Product` feature is enabled).
- **Response**: A `ProductV1` object.

### Version 2 (`v2`)

#### Get Product by ID
- **Endpoint**: `GET /api/v2/product/{id}`
- **Description**: Retrieves a specific product by its ID with additional price details (if the `UseApiV2Product` feature is enabled).
- **Response**: A `ProductV2` object.

---

## Feature Management

The API uses feature flags to control access to specific endpoints. Feature flags are configured in the `appsettings.json` file under the `FeatureManagement` section.

### Example Configuration

```json
"FeatureManagement": {
  "UseV1ProductAPI": true,
  "UseV2ProductAPI": {
    "EnabledFor": [
      {
        "Name": "Microsoft.Targeting",
        "Parameters": {
          "Audience": {
            "Users": [ "User1", "User2" ],
            "Groups": [
              {
                "Name": "beta-testers",
                "RolloutPercentage": 100
              },
              {
                "Name": "internal-user",
                "RolloutPercentage": 100
              }
            ],
            "DefaultRolloutPercentage": 0,
            "Exclusion": {
              "Users": ["User0"]
            }
          }
        }
      }
    ]
  }
}
```

### User Targeting

The `UserTargetingContext` class is used to determine which users or groups have access to specific features. It reads user information from HTTP headers (`x-user-id` and `x-user-groups`).

---

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name
   ```

2. **Install Dependencies**:
   Ensure you have the .NET 9 SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).

3. **Run the Application**:
   ```bash
   dotnet run
   ```

4. **Access the API**:
   - The API will be available at `https://localhost:5001` (or `http://localhost:5000`).
   - Use tools like [Postman](https://www.postman.com/) or [Swagger UI](https://localhost:5001/swagger) (if enabled) to interact with the API.

---

## Configuration

### API Versioning
The API is configured to use URL-based versioning. For example:
- `v1`: `/api/v1/product`
- `v2`: `/api/v2/product`

### Database
The project uses an in-memory database (`ProductDbContext`) for demonstration purposes. You can replace it with a persistent database (e.g., SQL Server, PostgreSQL) by updating the `DbContext` configuration.

### OpenAPI (Swagger)
Swagger is enabled in the development environment. You can access the Swagger UI at `https://localhost:5001/swagger`.

---

## Running the Application

1. **Development Mode**:
   - Run the application using `dotnet run`.
   - Swagger UI will be available for testing the API.

2. **Production Mode**:
   - Ensure proper configuration of feature flags and database settings.
   - Use `dotnet publish` to create a production build.

---
