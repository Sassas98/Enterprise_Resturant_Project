using Applications.Extensions;
using Microsoft.Extensions.Configuration;
using Models.Extensions;
using RestAPI.Extensions;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebServices()
    .AddSwaggerServices()
    .AddSecurityServices(builder.Configuration)
    .AddRepositoryServices(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
