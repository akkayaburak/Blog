# Blog

Simple blog.

## Technologies
- [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
- [Swagger](https://swagger.io/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)

## Installation

clone the respected git repository :
`
https://github.com/akkayaburak/Blog.git
`

## Usage

You need to change connection string in ``appsettings.json`` file.

```
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb);Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

You need to run this on command prompt to start Swagger.

`dotnet run -p blog.website/blog.website.csproj`

Then you can access it :

`https://localhost:5001/index.html`

## License
[MIT](https://github.com/akkayaburak/Blog/blob/master/LICENSE)