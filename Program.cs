using N5_API.Project.Api.Diagnostics;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using N5_API.Project.Repositories;
using N5_API.Project.Services.Interfaces;
using N5_API.Project.Services;
using N5_API.Project.UoW;
using Nest;
using N5_API.Project.Models;
using N5_API.Project.Repositories.ElasticSearch;

var builder = WebApplication.CreateBuilder(args);

#region CORS CONFIGURATION
builder.Services.AddCors(options =>
                options.AddPolicy("CorsPolicy", app => {
                    //builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000").AllowCredentials();
                    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                }));
#endregion

#region Unit Of Work SERVICE

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    // Add services to the container.
    builder.Services.AddDbContext<N5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
    
}
else
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    // Add services to the container.
    builder.Services.AddDbContext<N5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
}


#endregion

#region ELASTIC SEARCH CONFIGURATION

var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("permissions")
    .BasicAuthentication("elastic", "3sLf-T22CYCrO4BIeQ9k"); // Use your actual username and password

var client = new ElasticClient(settings);


builder.Services.AddSingleton<IElasticClient>(client);
builder.Services.AddTransient<ElasticSearchSetup>();

#endregion


#region INJECTIONS SERVICES
builder.Services.AddScoped<IUnitOfWorkSql, UnitOfWorkSql>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IPermissionSearchRepository, PermissionsSearchRepository>();


#endregion

#region INJECTIONS REPOSITORIES

builder.Services.AddEndpointsApiExplorer();
// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(options =>
{
    // options.SwaggerDoc("v1", new() { Title = "Auto_Manager_APIGateway", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                In = ParameterLocation.Header,
            },
            new string[] { }
        }
    });
});

builder.Services.AddMemoryCache();


if (Environment.GetEnvironmentVariable("Debug_Counters") == "true")
{
    builder.Services.AddControllers(options => options.Filters.Add<LogRequestTimeFilterAttribute>());
}
else
{
    builder.Services.AddControllers();
}

#endregion

#region APP SETTINGS
var app = builder.Build();

app.UseCors("CorsPolicy");


var esSetup = app.Services.GetRequiredService<ElasticSearchSetup>();
await esSetup.CreateIndexIfNotExistsAsync("permissions");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
                    c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json",
                            "Service Product API");
                        c.RoutePrefix = string.Empty;
                    });
}

app.UseExceptionHandler("/Error");
// app.UseHsts();

// app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();

app.MapControllers();

app.Run();
#endregion

