# DigiReserve API Documentation

DigiReserve is a versatile and customizable ASP.NET Core-based API designed for managing reservations across different industries. This API is structured for scalability and includes robust features to manage time slots, reservations, user authentication, and more.

## Table of Contents
1. [Overview](#overview)
2. [Installation](#installation)
3. [Configuration](#configuration)
4. [API Endpoints](#api-endpoints)
   - [Authentication](#authentication)
   - [User Management](#user-management)
   - [Reservation Management](#reservation-management)
   - [Time Slot Management](#time-slot-management)
5. [Usage Examples](#usage-examples)
6. [Contributing](#contributing)
7. [License](#license)

---

### 1. Overview <a name="overview"></a>
DigiReserve provides a RESTful interface to manage reservation data for various industries. Key features include:
- **User Management**: Authentication and user profile management.
- **Reservation Handling**: Create, view, update, and cancel reservations.
- **Time Slot Management**: Define and manage available reservation times.
  
### 2. Installation <a name="installation"></a>
**Prerequisites**:
- .NET Core SDK 6.x or higher
- SQL Server or another supported database for data storage

**Steps**:
1. Clone this repository:
   ```bash
   git clone https://github.com/your-repository/DigiReserve.git
   ```
2. Navigate to the project directory:
   ```bash
   cd DigiReserve
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update the `appsettings.json` file to configure your database connection and other settings (see [Configuration](#configuration) for details).

5. Run the API:
   ```bash
   dotnet run
   ```

### 3. Configuration <a name="configuration"></a>
Modify `appsettings.json` to customize settings:
- **ConnectionStrings**: Define your database connection here.
- **JWTSettings**: Configure JWT authentication settings for secure API access.

Example:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your SQL Server connection string here"
  },
  "JWTSettings": {
    "Secret": "YourSecretKey",
    "Issuer": "DigiReserveAPI",
    "Audience": "DigiReserveClient"
  }
}
```

### 4. API Endpoints <a name="api-endpoints"></a>
Below are the primary API endpoints for DigiReserve.

#### Authentication <a name="authentication"></a>
- **POST /api/auth/register**: Register a new user.
- **POST /api/auth/login**: Authenticate a user and retrieve a JWT token.

#### User Management <a name="user-management"></a>
- **GET /api/user/profile**: Retrieve the authenticated user's profile information.
- **PUT /api/user/profile**: Update the authenticated user's profile.

#### Reservation Management <a name="reservation-management"></a>
- **GET /api/reservations**: Retrieve all reservations.
- **POST /api/reservations**: Create a new reservation.
- **PUT /api/reservations/{id}**: Update an existing reservation.
- **DELETE /api/reservations/{id}**: Delete a reservation by ID.

#### Time Slot Management <a name="time-slot-management"></a>
- **GET /api/timeslots**: Retrieve all available time slots.
- **POST /api/timeslots**: Create a new time slot.
- **PUT /api/timeslots/{id}**: Update a time slot.
- **DELETE /api/timeslots/{id}**: Delete a time slot by ID.

### 5. Usage Examples <a name="usage-examples"></a>
Here are some quick examples of using the API endpoints:

**Register a User**:
```bash
curl -X POST "https://your-api-url/api/auth/register" -H "Content-Type: application/json" -d '{
  "username": "newuser",
  "password": "password123"
}'
```

**Create a Reservation**:
```bash
curl -X POST "https://your-api-url/api/reservations" -H "Authorization: Bearer <token>" -H "Content-Type: application/json" -d '{
  "timeSlotId": 1,
  "userId": 123
}'
```