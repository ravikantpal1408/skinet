## This is E-Commerce web Application that is built using ASP.NET Core 🤙

Install Dotnet EF Tool <br>
dotnet tool install --global dotnet-ef --version 3.1.101<br>

dotnet ef migrations add InitialCreate -o Data/Migrations -p API/ <br>

 dotnet ef database update -p API/ <br>
 
 
 # SPECIFICATION PATTERN
 👉 Describe a query in an object
 👉 Returns IQueryable<T> 
 👉 Generic list method takes specification as parameter
    👉 ProductsWithTypesAndBrandSpecification
 
 