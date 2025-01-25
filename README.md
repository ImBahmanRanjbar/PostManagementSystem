
# Post and Content Management System

## Introduction
The Content Management System (CMS) is a robust web application that enables users to manage blog posts and user accounts. It provides an administrative interface where users can perform CRUD (Create, Read, Update, Delete) operations on both posts and user profiles. The system also tracks important metadata such as publication dates and user details.

## Key Features
1. User Management: 
   - Users can register, login, and update their profiles.
   - Administrators can create, edit, and delete user accounts.
   - Administrators can view detailed user information, including registration date, email, and associated posts.

2. Post Management:
   - Users (with appropriate permissions) can create, edit, and publish blog posts.
   - Administrators can view, update, and delete any post, regardless of the author.
   - The system tracks post metadata such as title, content, author, publication date, and status (draft, published, deleted).

3. One-to-Many Relationship: 
   - Each user can have multiple associated posts.
   - The system maintains a clear relationship between users and their posts, allowing administrators to easily view a user's complete posting history.

4. Reporting and Analytics:
   - Administrators can generate reports on user activity, including total posts, average posts per user, and post publication trends.
   - The system provides detailed insights into user engagement, such as most active users, top-performing posts, and comment activity.

5. Responsive Design:
   - The CMS user interface is designed to be mobile-friendly, ensuring a seamless experience across various devices.

6. Security and Permissions:
   - The system implements role-based access control, allowing administrators to manage user permissions.
   - It includes measures to protect against common web vulnerabilities, such as cross-site scripting (XSS) and cross-site request forgery (CSRF).

## Technology Stack
The Content Management System is built using the following technologies:

- Backend: ASP.NET Core MVC, Entity Framework Core, SQL Server
- Frontend: HTML, CSS (with Bootstrap), JavaScript
- Hosting: Azure App Service

## Getting Started
To run the Content Management System locally, follow these steps:

1. Clone the repository from GitHub:
git clone https://github.com/ImBahmanRanjbar/PostManagementSystem.git
2. Open the solution in Visual Studio and restore the NuGet packages.

3. Configure the database connection string in the appsettings.json file.

4. Apply the database migrations using the Entity Framework Core CLI:
dotnet ef database update
5. Build and run the application.

6. Access the CMS in your browser at http://localhost:5000.
