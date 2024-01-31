# Transport Booking Application

The Transport Booking Application is a .NET Core Web API for managing transportation options and bookings. It provides functionalities to view available transportation options, make bookings, and retrieve booking details.

## Features

- View available transportation options.
- Make bookings for selected transportation options.
- Retrieve booking details.

## Technologies Used

- .NET Core
- Entity Framework Core (In-memory database for local development, SQL Server for production)
- ASP.NET Core Web API
- Docker (for containerization)
- NUnit (for unit testing)

## Setup

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)

### Local Development

1. Clone the repository.

    ```bash
    git clone <repository_url>
    cd TransportBookingApp
    ```

2. Build and run the application.

    ```bash
    dotnet build
    dotnet run
    ```

    The application will be accessible at `http://localhost:5000`.

3. Access the API using tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/).

### Docker

Build and run the application using Docker:

```bash
docker build -t transport-booking-app .
docker run -p 8080:80 transport-booking-app
