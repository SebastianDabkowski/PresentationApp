# Conference Application - Quick Start Guide

This repository contains a complete conference management system built with C# and Blazor.

## What's Been Created

Based on the README diagram specifications, this application implements:

### 1. ConfAPI - Admin Interface
- **Technology**: Blazor Server
- **Purpose**: Admin dashboard for conference organizers
- **Features**:
  - Manage presentations (create, edit, delete)
  - View and answer attendee questions
  - Monitor ratings and feedback
  - REST API for mobile app

### 2. ConfMobileApp - Attendee Interface  
- **Technology**: Blazor WebAssembly
- **Purpose**: Interface for conference attendees
- **Features**:
  - Browse presentation schedule
  - Ask questions about presentations
  - Rate presentations with stars
  - View Q&A threads

### 3. ConfApp.Shared - Shared Library
- **Technology**: .NET Class Library
- **Purpose**: Common data models
- **Contains**: Presentation, Question, Rating models

## Quick Start

### Prerequisites
- .NET 9.0 SDK or later

### Run Admin Interface
```bash
cd src/ConfAPI
dotnet run
```
Then open: http://localhost:5089

### Run Attendee Interface
```bash
cd src/ConfMobileApp
dotnet run
```

### Build Everything
```bash
dotnet build
```

## Project Structure
```
├── ConfApp.sln                    # Solution file
├── BUILD.md                       # Detailed build instructions
├── src/
│   ├── ConfAPI/                   # Admin app + API
│   │   ├── Components/            # Blazor components
│   │   ├── Controllers/           # API controllers
│   │   ├── Services/              # Business logic
│   │   ├── Data/                  # Database context
│   │   └── wwwroot/               # Static files
│   ├── ConfMobileApp/             # Attendee app
│   │   ├── Pages/                 # Blazor pages
│   │   ├── Services/              # API client
│   │   └── wwwroot/               # Static files
│   └── ConfApp.Shared/            # Shared models
│       └── Models/                # Data models
```

## Key Features

✅ **Admin Dashboard** - Complete presentation management  
✅ **Attendee App** - Interactive presentation viewer  
✅ **RESTful API** - Full CRUD operations  
✅ **SQLite Database** - Automatic setup with seed data  
✅ **Responsive UI** - Bootstrap 5 based design  
✅ **Real-time Updates** - Blazor Server SignalR connection  

## Sample Data

The application includes two sample presentations:
1. "Introduction to Blazor" by John Doe
2. "Advanced C# Patterns" by Jane Smith

## Documentation

For detailed build instructions, API documentation, and troubleshooting, see [BUILD.md](BUILD.md).

## Architecture Diagram

```
┌─────────────────────────┐
│   ConfMobileApp         │
│   (Blazor WebAssembly)  │
│   - Browse              │
│   - Ask Questions       │
│   - Rate                │
└────────┬────────────────┘
         │ HTTP/REST
         ▼
┌─────────────────────────┐
│   ConfAPI               │
│   (Blazor Server)       │
│   - Admin UI            │
│   - REST API            │
├─────────────────────────┤
│   Services Layer        │
│   - PresentationService │
│   - QuestionService     │
│   - RatingService       │
├─────────────────────────┤
│   EF Core + SQLite      │
│   - ConfDB              │
└─────────────────────────┘
```

## Technologies

- .NET 9.0
- C# 12
- Blazor Server & WebAssembly
- Entity Framework Core 9.0
- SQLite Database
- Bootstrap 5
- ASP.NET Core Web API

## License

This project is provided as-is for educational and demonstration purposes.
