using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Models;
using StackOverflowAPI.Seeder;
using StackOverflowAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyStackContext>(
    option => option
    .UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
    );

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

builder.Services.AddScoped<QuestionSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();

var dbContext = scope.ServiceProvider.GetService<MyStackContext>();
var seeder = scope.ServiceProvider.GetRequiredService<QuestionSeeder>();
seeder.Seed();

var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

// questions
app.MapGet("/api/question/{id}", ([FromServices]IQuestionService service, [FromRoute] int id) => service.Get(id));

app.MapGet("/api/questions", (IQuestionService service) => service.getAll());

app.MapPost("/api/createQuestion{userId}", (IQuestionService service, [FromBody]CreateQuestionDto dto, [FromRoute] int userId) 
    => service.Create(dto, userId));

// answers
app.MapGet("/api/answers", (IAnswerService service) => service.getAll());

app.MapPost("/api/createAnswer{userId}", (IAnswerService service, [FromBody] CreateAnswerDto dto, [FromRoute] int userId)
    => service.Create(dto, userId));



app.Run();


