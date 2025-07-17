# MultiChannel Sales Sync System

## Project Purpose & Mock Setup

This project is designed as a **proof-of-concept for a multi-channel sales sync system**. In a real-world scenario, the backend would:

- **Fetch sales orders directly from marketplace APIs** such as Shopify and Amazon Selling Partner API.
- **Sync inventory and accounting data** by calling in-house APIs or microservices.
- **Keep all channels and internal systems in sync** to ensure accurate stock levels, prevent overselling, and maintain clean accounting records.

**In this mock implementation:**

- The `shopifyOrders` and `amazonOrders` collections in MongoDB **stand in for real marketplace APIs**. Instead of making live API calls, the system fetches orders from these collections as if they were responses from Shopify and Amazon.
- The `inventory`, `accounting`, and `logs` collections are also stored in MongoDB, simulating in-house systems for inventory management, transaction recording, and activity logging.

> **Note:**
>
> - The `inventory` collection should be pre-populated with your SKUs and their starting quantities.
>   - If a SKU is missing from the inventory collection, the sync process will still decrement its quantity, which can result in negative stock levels.
>   - This mimics the real-world risk of overselling if inventory is not properly managed.
> - The `accounting` and `logs` collections are automatically created and updated by the application.

---

## Real-World Application

The **real purpose** of this project is to demonstrate the architecture and flow for a robust multi-channel sync system. In production, you would:

- Replace the MongoDB order collections with **live API integrations** for Shopify, Amazon, and other marketplaces.
- Replace the direct MongoDB updates with **HTTP calls to your in-house inventory and accounting APIs**.
- Use the logging system to monitor and audit all sync activities and errors.

This approach ensures that all sales channels and internal systems are always in sync, helping to:

- **Prevent overselling** by keeping inventory accurate across all platforms.
- **Maintain clean accounting** by recording every transaction.
- **Provide traceability** through centralized logging.

---

## Overview

**MultiChannelSalesSync** is a .NET 6+ Web API backend service that:

- Pulls sales orders from Shopify and Amazon (via MongoDB collections).
- Updates stock levels in a MongoDB-backed inventory system.
- Records transactions in a MongoDB-backed accounting system.
- Logs all activities and errors to a MongoDB logs collection.

The project is modular, testable, and uses interfaces for all services.

---

## Project Structure

```
MultiChannelSalesSync/
│
├── Controllers/
│   └── SyncController.cs         # API endpoint for syncing orders
│
├── Interfaces/
│   ├── IAmazonService.cs
│   ├── IShopifyService.cs
│   ├── IInventoryService.cs
│   ├── IAccountingService.cs
│   └── ILoggerService.cs
│
├── Models/
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── InventoryItem.cs
│   ├── Transaction.cs
│   └── LogEntry.cs
│
├── Services/
│   ├── AmazonService.cs
│   ├── ShopifyService.cs
│   ├── InventoryService.cs
│   ├── AccountingService.cs
│   ├── LoggerService.cs
│   └── MongoDbContext.cs
│
├── appsettings.json              # App configuration (add MongoDB settings here)
├── Program.cs                    # Entry point and DI setup
├── MultiChannelSalesSync.csproj  # Project file
└── ...
```

---

## MongoDB Collections

- `shopifyOrders` — Shopify order documents
- `amazonOrders` — Amazon order documents
- `inventory` — Inventory items (stock levels)
- `accounting` — Transaction records
- `logs` — Activity and error logs

> **Note:** Only `shopifyOrders` and `amazonOrders` need to be pre-populated. Other collections are created/updated by the app.

---

## Setup & Configuration

1. **Clone the repository**

2. **Install dependencies**

   ```sh
   dotnet restore
   ```

3. **Add MongoDB settings to `appsettings.json`**

   ```json
   {
     "MongoDbSettings": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "MultiChannelSalesSync"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

4. **Insert sample data into MongoDB**

   - See `shopifyOrders` and `amazonOrders` models for sample.

5. **Build and run the project**

   ```sh
   dotnet run
   ```

6. **Test the API**
   - Use Postman or `curl` to POST to:
     ```
     http://localhost:5000/sync/sync
     ```
   - The sync process will:
     - Fetch orders from MongoDB
     - Update inventory
     - Record transactions
     - Log all activities/errors

---

## Key Features

- **Modular architecture:** All services use interfaces for easy testing and extension.
- **MongoDB integration:** All business data is persisted in MongoDB.
- **Centralized logging:** All activities and errors are logged to the `logs` collection.
- **Easily extensible:** Add more channels, endpoints, or business logic as needed.

---

## Extending the Project

- Add new sales channels by creating new services and collections.
- Add more endpoints/controllers for reporting, querying, or admin features.
- Integrate with real Shopify/Amazon APIs for live data.

---
