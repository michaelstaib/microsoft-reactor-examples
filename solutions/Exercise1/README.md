# Creating a GraphQL server from zero

1. Create a new console project.

dotnet new console

2. Go to the project file and append `.Web` to `Microsoft.NET.Sdk`

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

> This step transformed our console application into an ASP.NET Core web application.

3. Delete all the code in the `Program.cs` and replace it with the following.

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run();

> This step added the base structure for the webserver configuration.

4. Run your server and check that its working.

`dotnet watch --no-hot-reload`

5. Open your server URL and verify that it will return `hello`. 

6. Add the `HotChocolate.AspNetCore` package.

dotnet add package HotChocolate.AspNetCore

> This step transformed our ASP.NET Core web application into a server capable of GraphQL.

6. Create a new file `Query.cs` and paste the following code.

```csharp
public class Query
{
    public string Hello(string name = "World")
        => $"Hello, {name}!";
}
```

7. Switch to the `Program.cs` and add `builder.Services.AddGraphQLServer().AddQueryType<Query>();`.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Hello");

app.Run();
```

8. Last swap out `MapGet` with `MapGraphQL`

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
```

9. Open http://localhost:5000/graphql


