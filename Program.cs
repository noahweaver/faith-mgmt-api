using FaithMgmtAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql;
using FaithMgmtAPI.Controllers;
using FaithMgmtAPI.Models;

// Create a new web application builder with the provided command line arguments
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
//builder.Services.AddDbContext<FaithMgmtContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("FaithMgmt")));

// Add controllers as services to the application
builder.Services.AddControllers();

// Add API explorer services to the application. This is required for Swagger/OpenAPI generation
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generator services to the application. This will generate Swagger/OpenAPI documents
builder.Services.AddSwaggerGen();

// Configure JSON Serializer
// Add NewtonsoftJson and configure it to ignore reference loops when serializing objects
// Also, set the contract resolver to use the default one
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new DefaultContractResolver());

// Build the application
var app = builder.Build();

// Enable CORS (Cross-Origin Resource Sharing) with any header, origin, and method
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.

// If the application is in development mode, use Swagger and SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use authorization middleware
app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Run the application
app.Run();
