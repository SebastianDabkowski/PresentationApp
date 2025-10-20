# Building the Conference Application

This document describes how to build and run the Conference Application (ConfApp).

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- A code editor (Visual Studio 2022, Visual Studio Code, or JetBrains Rider)

## Solution Structure

The solution consists of three projects:

1. **ConfAPI** - Blazor Server application with admin interface and REST API
   - Location: `src/ConfAPI/`
   - Provides admin interface for managing presentations
   - Exposes REST API endpoints for mobile app

2. **ConfMobileApp** - Blazor WebAssembly application for attendees
   - Location: `src/ConfMobileApp/`
   - Allows attendees to view presentations, ask questions, and rate sessions

3. **ConfApp.Shared** - Shared class library
   - Location: `src/ConfApp.Shared/`
   - Contains shared models and DTOs

## Building the Solution

### Command Line

1. Navigate to the repository root directory:
   ```bash
   cd /path/to/PresentationApp
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Build the entire solution:
   ```bash
   dotnet build
   ```

### Visual Studio

1. Open `ConfApp.sln` in Visual Studio 2022
2. Build > Build Solution (or press Ctrl+Shift+B)

## Running the Applications

### Running ConfAPI (Admin Interface + API)

The ConfAPI project serves both the admin Blazor interface and the REST API.

**Command Line:**
```bash
cd src/ConfAPI
dotnet run
```

The application will start and display URLs like:
- `https://localhost:5001` - Admin interface
- `http://localhost:5000` - Admin interface (HTTP)

**API Endpoints:**
- `https://localhost:5001/api/presentations` - Presentations API
- `https://localhost:5001/api/questions` - Questions API
- `https://localhost:5001/api/ratings` - Ratings API

**Visual Studio:**
1. Set ConfAPI as the startup project
2. Press F5 or click the "Run" button

### Running ConfMobileApp (Attendee Interface)

The ConfMobileApp is a Blazor WebAssembly application for conference attendees.

**Command Line:**
```bash
cd src/ConfMobileApp
dotnet run
```

The application will start at:
- `https://localhost:5002` (or similar port)

**Note:** Before running the mobile app, make sure to:
1. Update the API base URL in `src/ConfMobileApp/Services/ApiService.cs`
2. Set it to the URL where ConfAPI is running

**Visual Studio:**
1. Set ConfMobileApp as the startup project
2. Press F5 or click the "Run" button

### Running Both Applications Simultaneously

To run both the admin and mobile apps at the same time:

**Visual Studio:**
1. Right-click on the solution in Solution Explorer
2. Select "Configure Startup Projects"
3. Choose "Multiple startup projects"
4. Set both ConfAPI and ConfMobileApp to "Start"
5. Press F5

**Command Line:**
Open two terminal windows and run each application in a separate window.

## Database

The application uses SQLite for data storage. The database file (`confdb.db`) is created automatically when you first run the ConfAPI application.

**Location:** `src/ConfAPI/confdb.db`

**Sample Data:** The application includes seed data with two sample presentations.

## Project Features

### ConfAPI Features
- ✅ Manage presentations (Create, Read, Update, Delete)
- ✅ View questions from attendees
- ✅ Answer questions
- ✅ View ratings and feedback
- ✅ REST API endpoints for mobile app

### ConfMobileApp Features
- ✅ View all presentations
- ✅ View presentation details
- ✅ Ask questions about presentations
- ✅ Rate presentations (1-5 stars)
- ✅ Add comments with ratings
- ✅ View existing questions and answers

## Architecture

The application follows a clean architecture pattern:

```
┌─────────────────┐
│  ConfMobileApp  │ (Blazor WASM - Attendee Interface)
└────────┬────────┘
         │ HTTP/REST
         ▼
┌─────────────────┐
│    ConfAPI      │ (Blazor Server - Admin Interface + API)
├─────────────────┤
│    Services     │ (Business Logic)
├─────────────────┤
│  EF Core DbContext │
├─────────────────┤
│  SQLite Database│
└─────────────────┘
```

## API Documentation

### Presentations Endpoints

- `GET /api/presentations` - Get all presentations
- `GET /api/presentations/{id}` - Get a specific presentation
- `POST /api/presentations` - Create a new presentation
- `PUT /api/presentations/{id}` - Update a presentation
- `DELETE /api/presentations/{id}` - Delete a presentation

### Questions Endpoints

- `GET /api/questions/presentation/{presentationId}` - Get questions for a presentation
- `GET /api/questions/{id}` - Get a specific question
- `POST /api/questions` - Create a new question
- `PUT /api/questions/{id}/answer` - Answer a question
- `DELETE /api/questions/{id}` - Delete a question

### Ratings Endpoints

- `GET /api/ratings/presentation/{presentationId}` - Get ratings for a presentation
- `GET /api/ratings/presentation/{presentationId}/average` - Get average rating
- `POST /api/ratings` - Create a new rating
- `DELETE /api/ratings/{id}` - Delete a rating

## Troubleshooting

### Port Conflicts
If you get port conflict errors, you can change the ports in:
- `src/ConfAPI/Properties/launchSettings.json`
- `src/ConfMobileApp/Properties/launchSettings.json`

### Database Issues
If you encounter database issues:
1. Delete the `confdb.db` file
2. Restart the ConfAPI application
3. The database will be recreated with seed data

### Mobile App Can't Connect to API
1. Ensure ConfAPI is running
2. Update the `ApiBaseUrl` in `src/ConfMobileApp/Services/ApiService.cs`
3. Make sure CORS is properly configured

## Development

### Adding New Features

1. **Models:** Add to `src/ConfApp.Shared/Models/`
2. **Services:** Add to `src/ConfAPI/Services/`
3. **Controllers:** Add to `src/ConfAPI/Controllers/`
4. **Admin Pages:** Add to `src/ConfAPI/Components/Pages/`
5. **Mobile Pages:** Add to `src/ConfMobileApp/Pages/`

### Database Migrations

If you modify the models, you may need to:
1. Delete the existing `confdb.db` file
2. Restart the application
3. The database will be recreated with the new schema

For production, consider using EF Core migrations:
```bash
cd src/ConfAPI
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## License

This project is provided as-is for educational and demonstration purposes.
