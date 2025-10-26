# Quickstart Guide

This guide provides instructions to set up and run the Billiard Shop project locally.

## Prerequisites

1.  **.NET 9.0 SDK**: Ensure you have the .NET 9.0 SDK installed.
2.  **SQL Server**: A local or remote SQL Server instance is required. The free SQL Server Express or Developer editions are suitable.

## 1. Database Setup

1.  **Create the Database**: Open a query tool for SQL Server (like SQL Server Management Studio or Azure Data Studio).
2.  **Run the Script**: Open and execute the entire script located at `docs/database/database.sql`. This will create the `BilliardShop` database, all tables, views, stored procedures, and seed it with initial data.

## 2. Application Configuration

1.  **Connection String**: Open the `appsettings.json` file located in `src/BilliardShop.Web/`.
2.  **Update Connection String**: Modify the `DefaultConnection` string to point to your SQL Server instance. For example:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=BilliardShop;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
    }
    ```

## 3. Build and Run the Application

1.  **Open a terminal** at the root of the project directory (`/home/luckyboiz/LuckyBoiz/Projects/Asp.net_MVC/BilliardShop`).
2.  **Build the solution** to restore NuGet packages and compile the code:

    ```bash
    dotnet build
    ```

3.  **Run the web application**:

    ```bash
    dotnet run --project src/BilliardShop.Web
    ```

4.  **Access the Website**: Open your web browser and navigate to the URL provided in the terminal output (usually `https://localhost:7123` or `http://localhost:5123`).
