# Task list
----------------
## Description
Task List is a  C# application designed to task management .

This project is built using the following technologies:

*   **Backend:**
    
    *   C# .NET: The core programming language for server-side functionality.
        
    *   ASP.NET: A web application framework for building dynamic websites and APIs.
        
    *   Entity Framework Core: An Object-Relational Mapper (ORM) that simplifies database interactions.
        
    *   SQL Server: The relational database management system used for data persistence.
        
*   **Client-side:**
    
    *   MVC & Razor Pages: The chosen framework for structuring web pages and handling user interactions.
        

**Getting Started**

1.  **Prerequisites:**
    
    *   Ensure you have .NET installed on your development machine. You can download it from the official Microsoft website: [https://dotnet.microsoft.com/en-us/download/dotnet-framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework)
        
    *   (Optional) Install SQL Server Management Studio (SSMS) to manage your database locally: [https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
        
2.  **Clone the Repository:**
    

`````
git clone https://github.com/Tess-mltx/TaskListCsharp.git
`````


1.  **Restore Dependencies:**
    

`````
cd TaskList dotnet restore
`````


1.  This step creates the database schema based on your entity models. Only necessary if you have existing database migrations.
    

`````
 dotnet ef database update
`````


