using Applications.Extensions;
using Microsoft.Extensions.Configuration;
using Models.Extensions;
using RestAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:MyDbContext");
builder.Services.AddWebServices()
    .AddSwaggerServices()
    .AddSecurityServices(builder.Configuration)
    .AddRepositoryServices(connectionString??"")
    .AddApplicationServices();

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
