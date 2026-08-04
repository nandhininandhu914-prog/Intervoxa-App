# Intervoxa – Interview Scheduling and Management System

## Overview

Intervoxa is a full-stack Interview Scheduling and Management System developed using ASP.NET Core Web API, Angular, and SQL Server. The application streamlines the recruitment process by enabling HR teams to schedule interviews, administrators to manage users and master data, and interviewers to view their assigned interviews.

The application follows a role-based authentication system with separate dashboards for Admin, HR, and Interviewers.

---

## Features

### Authentication
- JWT-based Authentication
- Role-based Authorization
- Secure Login
- Logout functionality

### Admin Module
- Dashboard
- Manage Candidates
- Manage Interviewers
- Schedule Interviews
- Edit/Delete Interview Schedules
- View Scheduled Interviews
- View Interview Feedback submitted by Interviewers
  
### HR Module
- Dashboard with interview statistics
- Today's Interviews
- Upcoming Interviews
- Scheduled Interview Count
- Completed Interview Count
- Total Interview Count

### Interviewer Module
- Dashboard
- View Assigned Interviews
- View Today's Interviews
- View Upcoming Interviews
- Submit Feedback for Completed Interviews
- Logout

### Interview Feedback Module
- Interviewers can submit feedback only for completed interviews.
- Feedback includes:
  - Technical Skills Rating
  - Communication Skills Rating
  - Overall Rating
  - Remarks
  - Recommendation (Selected / Rejected / Hold)
- Admin can view all submitted interview feedback.

---

## Technology Stack

### Frontend
- Angular 19
- TypeScript
- Bootstrap 5
- HTML5
- CSS3

### Backend
- ASP.NET Core Web API (.NET 8)
- C#
- Entity Framework Core
- LINQ
- JWT Authentication

### Database
- SQL Server
- Entity Framework Code First
- SQL Queries

### Tools
- Visual Studio 2022
- Visual Studio Code
- Swagger
- Git
- GitHub

---

## Project Architecture

```
Angular Frontend
        │
REST API Calls
        │
ASP.NET Core Web API
        │
Entity Framework Core
        │
SQL Server Database
```

----

## User Roles

### Admin
- Manage Candidates
- Manage Interviewers
- Schedule Interviews
- View all schedules

### HR
- View HR Dashboard
- Monitor interview statistics
- View today's interviews
- Track upcoming interviews

### Interviewer
- View assigned interviews
- View today's interviews
- View upcoming interviews

---

## Database Tables

- Users
- Candidates
- Interviews
- Schedules
- Interview Feedback

---

## Authentication

The application uses JSON Web Token (JWT) authentication.

After successful login:

- JWT Token is generated.
- Token is stored in Local Storage.
- Role-based navigation is performed.
- Protected APIs require Authorization Token.

---

---

## Application Workflow

1. Admin schedules interviews for candidates.
2. HR monitors interview schedules through the HR Dashboard.
3. Interviewers log in and view only their assigned interviews.
4. Once an interview is completed, the interviewer submits interview feedback.
5. Feedback is securely stored in the database.
6. Admin can review all interview feedback for recruitment decisions.

---

## Dashboard Features

### Admin Dashboard
- Candidate Management
- Interviewer Management
- Interview Scheduling

### HR Dashboard
- Today's Interviews
- Scheduled Interviews
- Completed Interviews
- Total Interviews

### Interviewer Dashboard
- Assigned Interviews
- Today's Interviews
- Upcoming Interviews

---

## API Modules

### Login API
- User Authentication
- JWT Token Generation

### Candidate API
- CRUD Operations

### Interviewer API
- CRUD Operations

### Schedule API
- Schedule Interviews
- Update Schedule
- Delete Schedule

### HR Dashboard API
- Dashboard Statistics
- Today's Interviews
- Upcoming Interviews

### Interviewer Dashboard API
- Assigned Interviews
- Dashboard Statistics

### Feedback API
- Submit Interview Feedback
- Retrieve All Feedback
- View Candidate Evaluation

---

## Installation

### Clone Repository

```bash
git clone https://github.com/yourusername/intervoxa.git
```

### Backend

```bash
cd Intervoxa_API
```

Restore Packages

```bash
dotnet restore
```

Run Migration

```bash
Update-Database
```

Run Project

```bash
dotnet run
```

---

### Frontend

```bash
cd Intervoxa_UI
```

Install Packages

```bash
npm install
```

Run Angular

```bash
ng serve
```

Application runs at:

```
http://localhost:4200
```

Backend runs at:

```
https://localhost:7296
```

---

## Folder Structure

```
Intervoxa
│
├── Backend
│   ├── Controllers
│   ├── Models
│   ├── DTOs
│   ├── Services
│   ├── Data
│   └── Migrations
│
├── Frontend
│   ├── Components
│   ├── Services
│   ├── Guards
│   ├── Models
│   └── Environment
│
└── Database
```

---

## Future Enhancements

- Email Notifications
- Calendar Integration
- Candidate Dashboard
- HR Reports
- Resume Upload
- Interview Result Tracking
- Export Reports to Excel/PDF
- Interview Reminder Notifications

---

## Author

**Nandhini V**

Software Engineer | .NET Full Stack Developer

### Skills

- C#
- ASP.NET Core Web API
- Angular
- SQL Server
- Entity Framework Core
- JWT Authentication
- LINQ
- Git
- REST APIs

---

## License

This project is developed for learning and portfolio purposes.

## Version

**Current Version:** v1.0

**Release Date:** August 2026

## Project Highlights

- Role-based authentication using JWT.
- CRUD operations with Entity Framework Core.
- Interview scheduling and management.
- Real-time HR Dashboard with interview statistics.
- Interviewer Dashboard showing assigned interviews.
- Interview Feedback module for completed interviews.
- Admin review of interviewer feedback.
- Responsive user interface built with Angular and Bootstrap.
- RESTful Web APIs following layered architecture.
